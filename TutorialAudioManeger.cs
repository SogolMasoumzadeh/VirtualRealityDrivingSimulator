using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public class TutorialAudioManeger : MonoBehaviour {
	
	// Use this for initialization
	[SerializeField]private Sound[] sounds;
	//public float _Time;
	
	void Awake () {
		
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
		
	}
	
	void Start()
	{
		Play("Guidance");
	}
	
	public void Play(string name)
	{   
		
		
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) 
			return;
		s.source.Play(); 

	} // void play

} // Mono behavior
