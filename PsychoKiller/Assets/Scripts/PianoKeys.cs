﻿using UnityEngine;
using System.Collections;

public class PianoKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		audio.Play ();
	}
}
