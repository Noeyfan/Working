﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class TvController : MonoBehaviour {
	//public MovieTexture movT;
	// Use this for initialization
	private OculusController oc;
	private int cnt;
	private bool isOn;
	private float timeRecord;
	private float interve = 1f;
	MovieTexture[] movT;

	public int channelAmount = 2;


	void Start () {
		timeRecord = 0;
		oc = GameObject.FindGameObjectWithTag("Player").GetComponent<OculusController>();
	}

	void OnCollisionEnter(Collision c) {
		if(c.gameObject.tag == "Hand" && timeRecord <= Time.time - interve) {
			timeRecord = Time.time;
			if(!isOn) {
				isOn = true;
				initTV();
			}else {
				//switch tv
				//ChangeChannel();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void ChangeChannel() {
		if(cnt < movT.Length) {
			StopTv(cnt);
			PlayTv(cnt++);
		}else {
			cnt = 0;
		}
	}

	void initTV() {
		movT = new MovieTexture[channelAmount];
		for(int i = 0; i < channelAmount; i++) {
			string loadurl = "MovieTexture/Video/mv" + i;
			movT[i] = Resources.Load(loadurl) as MovieTexture;
		}
		print(movT.Length);
		PlayTv(0);
	}

	void PlayTv(int i) {
		renderer.material.mainTexture = movT[i];
		renderer.material.shader = Shader.Find("Unlit/Texture");
		movT[i].Play();
		audio.clip = movT[i].audioClip;
		audio.Play();
	}

	void StopTv(int i) {
		movT[i].Stop();
		audio.Stop();
	}
}
