using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TutoStart()
	{
		Time.timeScale = 1.0f;
		GameObject Button = GameObject.Find("Help");
		Button.SetActive(false);
		//Button.transform.Translate(Vector3.up * 1000.0f);
	}
}
