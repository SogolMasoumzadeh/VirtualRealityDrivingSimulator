using UnityEngine;
using System.Collections;

internal enum Speet_type
{
	MPH,
	KPH
}
public class New_CarControll : MonoBehaviour {

	//Public Variables of the class

	[SerializeField] private WheelCollider[] Wheel_colliders = new WheelCollider[4];
	[SerializeField] private GameObject[] Wheel_Object = new GameObject[4];
	[SerializeField] private Vector3 COM;
	[SerializeField] private float Max_Steer_Angle;
	[SerializeField] private float Max_Torque;
	[SerializeField] private float Reverse_Torque;
	[SerializeField] private float Brake_Torque;
	[SerializeField] private float Max_Hand_Torque;
	[SerializeField] private float m_DownFroce = 100f;
	[SerializeField] private Speet_type SpeedType;
	[SerializeField] private float Max_Speed = 100f;
	[Range(0, 1)] [SerializeField] private float m_Steer_Helper; // 0 is raw physics , 1 the car will grip in the direction it is facing
	[Range(0, 1)] [SerializeField] private float m_Traction_Control; // 0 is no traction control, 1 is full interference
	[SerializeField] private float Max_Friction;

	//Private variables of the class

	private Quaternion[] Wheel_Objects_LocalRots;
	private Vector3 Prev_Pos, Current_Pos;
	private float Current_Steer_Angle;
	private float current_hand_brake;
	private float Prev_Rot;
	private float Current_Torque;
	private Rigidbody Rigid_Body;
	//public Rigidbody RB;
	private const float k_Reverse_Thresh = 0.01f;

	// Public input variables from the input/ output device

	public bool Skidding { get; private set; }
	public float BrakeInput { get; private set; }
	public float InputSteerAngle{ get { return Current_Steer_Angle; }}
	public float CurrentSpeed{ get { return Rigid_Body.velocity.magnitude*2.23693629f; }}
	public float InputMaxSpeed{get { return Max_Speed; }}
	public float Revs { get; private set; }
	public float AccelInput { get; private set; }
	// Use this for initialization
	void Start () {
	
		Wheel_Objects_LocalRots = new Quaternion[4];

		for (int i = 0; i < 4; i++)
		{
			Wheel_Objects_LocalRots[i] = Wheel_Object[i].transform.localRotation;
		}
		Wheel_colliders [0].attachedRigidbody.centerOfMass = COM;
		Max_Hand_Torque = float.MaxValue;
		Rigid_Body = GetComponent<Rigidbody> ();
		//RB = GetComponent <Rigidbody>();
		Current_Torque = Max_Torque - (m_Traction_Control * Max_Torque);
	}
	// End of function start

	// Function Move with the inputs of wteer wheel, accelerator, brake an dthe hand brake.

	public void MovingTheCar(float steering, float accelerating, float braking ,float Handbraking)
	{
		// Aligning the position and the rotation of the wheel coliders and the wheel objects togetehr
		Quaternion quat;
		Vector3 pos;
		for (int i =0; i < 4; i++)
		{
			Wheel_colliders[i].GetWorldPose(out pos, out quat);
			Wheel_Object[i].transform.position = pos;
			Wheel_Object[i].transform.rotation = quat;
		}

		//Setting the effect of the steer wheel of the front wheels
		// The front wheels are i = 0,1.
		Current_Steer_Angle = steering * Max_Steer_Angle;
		Wheel_colliders [0].steerAngle = Current_Steer_Angle;
		Wheel_colliders [1].steerAngle = Current_Steer_Angle;

		//Necessary functions for the movement of the car
		Realign ();
		Drive (accelerating, braking);
		CarSpeed ();

		//Setting the effect of the handbrake on tne rear wheels
		// The rear wheels are i = 2,3.

		if (Handbraking > 0) 
		{
			current_hand_brake = Handbraking * Max_Hand_Torque;
			//current_hand_brake = Max_Hand_Torque;
			Wheel_colliders [2].brakeTorque = current_hand_brake;
			Wheel_colliders [3].brakeTorque = current_hand_brake;
		}

		//Necessary functions for the movement of the car
		DownForce ();
		TractionControll ();

	}
	// End of function MovingTheCar

private void CarSpeed()
	{
		float speed = Rigid_Body.velocity.magnitude;
		switch (SpeedType) {
		case Speet_type.MPH:
		
			speed *= 2.23693629f;
			if (speed > Max_Speed)
				Rigid_Body.velocity = (Max_Speed / 2.23693629f) *Rigid_Body.velocity.normalized;
			break;
		
		case Speet_type.KPH:
			speed *= 3.6f;
			if (speed > Max_Speed)
				Rigid_Body.velocity = (Max_Speed / 3.6f) * Rigid_Body.velocity.normalized;
			break;
		}
	}
	// End of the function CarSpeed

	private void Drive(float accelerating, float braking) 
	{
		//Applying the input of the keys
		//for (int i = 0; i< 4; i++) 
		//{
			//Wheel_colliders[i].motorTorque = Max_Torque * Input.GetAxis ("Vertical");
			
		//}
		// Aplying the accelerator effect
		for (int i = 0; i < 4; i++)
		{
			Wheel_colliders[i].motorTorque = accelerating * (Current_Torque/4f);
			FindObjectOfType <MangerAudio> ().Play ("AccelerationLow");

		}

		// Applying the brake effect
		for (int i = 0; i < 4; i++)
		{
			// The stop of the car due braking
			// the conditions for applying the brake is that
			// the current speed be greater than a certain amount so applying brake would be rational
			// also the car is moving in the correct direction
			if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, Rigid_Body.velocity) < 50f) 
			{
				Wheel_colliders[i].brakeTorque = Brake_Torque*braking; 
			}

			// The backward movement of the car due to braking
			else
			{
				Wheel_colliders[i].brakeTorque = 0f;
				Wheel_colliders[i].motorTorque = Reverse_Torque*braking;
				FindObjectOfType <MangerAudio> ().Play ("DecelerationLow");

			}
		}
	}
	// End of the function drive

	//Use this function to realign the car
	// at first it will check if it is needed to realign the car
	// then: It will calculate the drifted angle of the car in degrees
	// then: It will realign the car using that degree angle but using uaternioun rotation
	// and in the ned: due to the quaternion for alligning the velocity has chnaged.
	// Hence, the new velocity is calculated.

	private void Realign ()
	{
		for (int i =0; i < 4; i++)
		{
			WheelHit Wheel_Hit;
			Wheel_colliders[i].GetGroundHit(out Wheel_Hit);

			// no need for going to the next if as the car 
			// is not on the ground and no realigning is needed
			if (Wheel_Hit.normal == Vector3.zero)
				return;
		}

		// The realigning act

		if (Mathf.Abs(Prev_Rot - transform.eulerAngles.y) < 10f)
		{
			var turnadjust = (transform.eulerAngles.y - Prev_Rot) * m_Steer_Helper; 
			Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3. up);
			Rigid_Body.velocity = velRotation *Rigid_Body.velocity; 
		}
		Prev_Rot = transform.eulerAngles.y;

	}
	// End of the function HelpofSteer

	// Adding a negative force to the car. The higher the speed the higher the negative grip force.
	private void DownForce ()
	{
		Wheel_colliders [0].attachedRigidbody.AddForce (-transform.up * m_DownFroce * Wheel_colliders [0].attachedRigidbody.velocity.magnitude);
	}
	// End of the function DownForce

	private void TractionControll ()
	{
		WheelHit Wheel_Hit;
		for (int i = 0; i < 4; i++) 
		{
			Wheel_colliders[i].GetGroundHit(out Wheel_Hit);
			float forward_friction = Wheel_Hit.forwardSlip;
			if (forward_friction >= Max_Friction && Current_Torque >=0 )
				Current_Torque -= 10* m_Traction_Control;
			else
			{
				Current_Torque += 10* m_Traction_Control;
				if (Current_Torque >= Max_Torque)
					Current_Torque = Max_Torque;
			}
		}

	} // End of the function TractionControll

	// Update is called once per frame
	void Update () {
	
	}
}
