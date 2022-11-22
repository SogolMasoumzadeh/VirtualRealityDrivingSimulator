using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public class MangerAudio : MonoBehaviour {

	// Use this for initialization
	[SerializeField]private Sound[] sounds;
	public float _Time;

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
		Play("Theme");
	}
	
	public void Play(string name)
	{   


		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) 
			return;
//		if (name == "wrongway") {
//			_Time += Time.deltaTime;
//			if (_Time > 3.0f)
//			{
//				s.source.mute = true;
//				Debug.Log ("Time is finished");
//			}
//		}

		s.source.Play(); 
	}
	void Update(){



			// Checking the wrong route for level one
			if (Application.loadedLevel == 2) {
		 
			if (CheckPoints.turntheparticleon ==18) 
			{
				Debug.Log ("WrongWay");
				Play ("wrongway");
			}// inner first if for the wrong way
				
//			if (CheckPoints.turntheparticleon == 17) 
//			{
//				Debug.Log ("WrongWay");
//				Play ("wrongway");
//			}// inner first if for the wrong way

				if (CheckPoints.turntheparticleon == 16) {
					Debug.Log ("GoodJob Audio will be play");
					Play ("GoodJob");
				}// inner second if for the goodjob
			} // application.loaded level if

			//Checking the wrong route for level two
			if (Application.loadedLevel == 3) {
			
				if (CheckPoints.turntheparticleon == 24 || CheckPoints.turntheparticleon == 27) {
					Debug.Log ("WrongWay");
					Play ("wrongway");
				}// inner if for the wrong way

				if (CheckPoints.turntheparticleon == 22) {
					Debug.Log ("GoodJob Audio will be play");
					Play ("GoodJob");
				}// inner second if for the goodjob

			} // application.loaded level if

			if (Application.loadedLevel == 4) {
			
				if (CheckPoints.turntheparticleon == 31 || CheckPoints.turntheparticleon == 34 || CheckPoints.turntheparticleon == 37) {
					Debug.Log ("WrongWay");
					Play ("wrongway");
				}// inner if for the wrong way
			
				if (CheckPoints.turntheparticleon == 29) {
					Debug.Log ("GoodJob Audio will be play");
					Play ("GoodJob");
				}// inner second if for the goodjob
			
			} // application.loaded level if

		
	}
}
