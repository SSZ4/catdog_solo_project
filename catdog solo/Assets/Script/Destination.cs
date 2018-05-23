using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (Time.timeScale != 0.0f && other.transform.tag == "Dest")
		{
			GameEnd();
		}
	}

	public void GameEnd()
	{

		GameObject Button = GameObject.Find("Main");
		Vector3 pos = Button.transform.position;
		pos.y += 200.0f;
		Button.transform.position = pos;

		Button = GameObject.Find("ReStart");
		pos = Button.transform.position;
		pos.x += 150.0f;
		pos.y += 200.0f;
		Button.transform.position = pos;

		Button = GameObject.Find("right");
		pos = Button.transform.position;
		pos.x += 200.0f;
		Button.transform.position = pos;

		Button = GameObject.Find("left");
		pos = Button.transform.position;
		pos.x -= 200.0f;
		Button.transform.position = pos;

		Time.timeScale = 0.0f;
	}

}
