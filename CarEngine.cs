using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarEngine : MonoBehaviour {

	// Use this for initialization

	public Transform path;
	public float MaxSteerAngle = 40f;
	public float turningspeed = 5f;
	public float MaxMotorTorque = 80f;
	public float BreakTorque = 1000f;
	public float CurrentSpeed;
	public float MaxSpeed = 100f;
	public WheelCollider WheelFL;
	public WheelCollider WheelFR;
	public WheelCollider WheelRL;
	public WheelCollider WheelRR;

//	public Texture2D normal;
//	public Texture2D breaking;
//	public Renderer CarRenderer;

	private List <Transform> nodes = new List<Transform>();
	private int CurrentNode = 0;
	private float threshold = 0.5f;
	private float InitialTorque = 0.0f;
	private float InitialBreaking = 0.0f;
	private float TargetSteerAngle = 0.0f; 
	private float TimePassed = 0.0f;


	void Start () {

		Transform[] PathTransform = path.GetComponentsInChildren <Transform> ();
		nodes = new List<Transform>();
		
		for (int i = 0; i < PathTransform.Length ; i++ )
		{
			if (PathTransform [i] != path.transform)
			{
				nodes.Add(PathTransform [i]);
			}
		}
	
	}
	
	//When comes to calculations use fixed update
	void FixedUpdate () {
		TimePassed += Time.deltaTime;
		Debug.Log (TimePassed);

		if (Application.loadedLevel == 5)
		{
			if (TimePassed > 60f)
			{
					Debug.Log ("We are going back to main menue");
					Application.LoadLevel("MainMenue");
			}
		}

		if (Application.loadedLevel == 6)
		{
			if (TimePassed > 80f)
			{
				Debug.Log ("We are going back to main menue");
				Application.LoadLevel("MainMenue");
			}
		}

		if (Application.loadedLevel == 7)
		{
			if (TimePassed > 117f)
			{
				Debug.Log ("We are going back to main menue");
				Application.LoadLevel("MainMenue");
			}
		}

		ApplyDrive ();
		Drive ();
		CheckWayPointDistance ();
		Lerping ();
	
	
	}

	private void ApplyDrive()
	{
		Vector3 relativeVector = transform.InverseTransformPoint (nodes [CurrentNode].position);
		//relativeVector /= relativeVector.magnitude;
		float steer = relativeVector.x / relativeVector.magnitude;
		steer *= MaxSteerAngle;
		TargetSteerAngle = steer;
		//WheelFL.steerAngle = steer;
		//WheelFR.steerAngle = steer;
	}

	private void Drive()
	{
		CurrentSpeed = 2 * Mathf.PI * WheelFL.radius * WheelFL.rpm * 60 / 1000;

		if (CurrentSpeed < MaxSpeed) {
			WheelFL.motorTorque = MaxMotorTorque;
			WheelFR.motorTorque = MaxMotorTorque;
			WheelRL.motorTorque = MaxMotorTorque;
			WheelRR.motorTorque = MaxMotorTorque;
		}
		else
		{
			WheelFL.motorTorque = InitialTorque;
			WheelFR.motorTorque = InitialTorque;
			WheelRL.motorTorque = InitialTorque;
			WheelRR.motorTorque = InitialTorque;
		}

	}

	private void CheckWayPointDistance()
	{
		if (Vector3.Distance (transform.position, nodes [CurrentNode].position) < threshold)
		{
			if ( CurrentNode == nodes.Count -1 )
			{
				//this.enabled = false;

				CurrentNode = nodes.Count - 2; 
				WheelFL.motorTorque = InitialTorque;
				WheelFR.motorTorque = InitialTorque;
				WheelRL.motorTorque = InitialTorque;
				WheelRR.motorTorque = InitialTorque;

				WheelFL.brakeTorque = BreakTorque;
				WheelFR.brakeTorque = BreakTorque;
				WheelRL.brakeTorque = BreakTorque;
				WheelRR.brakeTorque = BreakTorque;

//				
			}
			CurrentNode +=1;
			Debug.Log(CurrentNode);
		}
	}

	private void Lerping()
	{
		WheelFL.steerAngle = Mathf.Lerp (WheelFL.steerAngle, TargetSteerAngle, Time.deltaTime * turningspeed);
		WheelFR.steerAngle = Mathf.Lerp (WheelFR.steerAngle, TargetSteerAngle, Time.deltaTime * turningspeed);

	}



}
