using UnityEngine;
using System.Collections;

public class CarWheel : MonoBehaviour {

	// Use this for initialization
	public WheelCollider TargetWheel;
	private Vector3 wheelposition  = new Vector3();
	private Quaternion Wheelrotation = new Quaternion();
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TargetWheel.GetWorldPose (out wheelposition, out Wheelrotation);
		transform.position = wheelposition;
		transform.rotation = Wheelrotation;
	}
}
