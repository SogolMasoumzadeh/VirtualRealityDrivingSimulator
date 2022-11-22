using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

[System.Serializable]
public class Sound {

	// Use this for initialization
	public string name;
	public AudioClip clip;

	[Range(0f,1f)]
	public float volume;

	[Range(0.1f,3f)]
	public float pitch;

	[HideInInspector]
	public AudioSource source;

	public bool loop;
	}

