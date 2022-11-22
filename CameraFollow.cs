using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField]private Transform target;

	[SerializeField]private float SmoothSpeed = 10f;

	//[SerializeField]private Vector3 Offset;

	private Vector3 InitialOffset; 
	private Vector3 CurrentOffset; 
	private Vector3 InitialPos; 



	void Start()
	{
		InitialPos = target.position;
		InitialOffset [0] = 7f; 
		InitialOffset [1] = 1.8f; 
		InitialOffset [2] = 30f; 
		InitialPos = target.position + InitialOffset;

		//Debug.Log (InitialOffset);
	}
	void Update()
	{}
	void FixedUpdate()
	{	CurrentOffset [0] = InitialOffset [0] * Mathf.Cos ((target.eulerAngles.y -270) * (Mathf.PI/ 180));
		CurrentOffset [1] = InitialOffset [1];
		CurrentOffset [2] = -1 * InitialOffset [0] * Mathf.Sin ((target.eulerAngles.y -270) * (Mathf.PI/ 180));
		//Debug.Log (target.eulerAngles.y);
		//Debug.Log ((-target.rotation.y) * (Mathf.PI/ 180));
		//Debug.Log (CurrentOffset);
		
		Vector3 DesiredPosition = target.position + CurrentOffset;
		//Debug.Log (target.position);
		//Debug.Log (DesiredPosition);

		Vector3 SmoothedPosition = Vector3.Lerp (transform.position, DesiredPosition, SmoothSpeed * Time.deltaTime);
		Quaternion SmoothRotation = Quaternion.Slerp (transform.rotation, target.rotation, SmoothSpeed * Time.deltaTime);
		transform.position = SmoothedPosition;
		//transform.position = DesiredPosition;
		//transform.rotation = target.rotation * Quaternion.Euler(45,0,0);

		transform.rotation = SmoothRotation;
		//transform.LookAt (target);
	}
}
