using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public bool Scale;
	// Use this for initialization
	void Start () {
		Scale = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0.0f)
		{
			GameStop();
		}
	}

	public void SetButton()
	{
		Scale = true;
	}

	public void Continue()
	{
		GameObject Button = GameObject.Find("Main");
		Vector3 pos = Button.transform.position;
		pos.y -= 200.0f;
		Button.transform.position = pos;

		Button = GameObject.Find("ReStart");
		pos = Button.transform.position;
		pos.y -= 200.0f;
		Button.transform.position = pos;

		Button = GameObject.Find("Continue");
		pos = Button.transform.position;
		pos.y -= 200.0f;
		Button.transform.position = pos;


		Button = GameObject.Find("right");
		pos = Button.transform.position;
		pos.x -= 200.0f;
		Button.transform.position = pos;

		Button = GameObject.Find("left");
		pos = Button.transform.position;
		pos.x += 200.0f;
		Button.transform.position = pos;

		Time.timeScale = 1.0f;
	}

	public void GameStop()
	{
		if (Scale)
		{
			Time.timeScale = 0.0f;

			GameObject Button = GameObject.Find("Main");
			Vector3 pos = Button.transform.position;
			pos.y += 200.0f;
			Button.transform.position = pos;

			Button = GameObject.Find("ReStart");
			pos = Button.transform.position;
			pos.y += 200.0f;
			Button.transform.position = pos;

			Button = GameObject.Find("Continue");
			pos = Button.transform.position;
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


			Scale = false;
		}
	}
}
