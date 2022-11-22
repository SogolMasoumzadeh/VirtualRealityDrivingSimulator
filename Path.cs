using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	// Use this for initialization

	public Color linecolor;
	private List <Transform> nodes = new List<Transform> ();
	private float radious = 0.3f ;


	void OnDrawGizmosSelected()
	{

		Gizmos.color = linecolor;
		Transform[] PathTransform = GetComponentsInChildren <Transform> ();
		nodes = new List<Transform>();

		for (int i = 0; i < PathTransform.Length ; i++ )
		{
			if (PathTransform [i] != transform)
			{
				nodes.Add(PathTransform [i]);
			}
		}

		for (int i = 0; i < nodes.Count; i ++)
		{
			Vector3 currentNode = nodes[i].position;
			Vector3 previousNode = Vector3 .zero; 
			if ( i != 0)
				 previousNode = nodes[i - 1].position;
		
			else if   ((i == 0) && (nodes.Count > 1))
				 previousNode = nodes[nodes.Count -1].position; 
			
			Gizmos.DrawLine (previousNode , currentNode);
			Gizmos.DrawWireSphere (currentNode, radious); 
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
