using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathScript : MonoBehaviour {

	public Color Path_color;
	private List<Transform> nodes = new List<Transform>();

	void  OnDrawGizmos()
	{
		Gizmos.color = Path_color;
		Transform[] Path_transforms = GetComponentsInParent<Transform>();
		nodes = new List<Transform>();
		for (int i = 0; i < Path_transforms.Length; i++)
		{
			if (Path_transforms[i] != transform)
				nodes.Add(Path_transforms[i]);
		}

		for (int i = 0; i < nodes.Count ; i++) 
		{
			Vector3 current_node = nodes[i].position;
			Vector3 prev_node = Vector3.zero;
			if (i > 0)
			{
				 prev_node = nodes[i-1].position; 
			}

			else if( i == 0 && nodes.Count > 1)
			{
				prev_node = nodes[i].position;
			}
			Gizmos.DrawLine(current_node, prev_node);
		}

	}

}
