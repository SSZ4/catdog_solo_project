using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public bool Scale;
	public GameObject ButtonM;
	public GameObject ButtonR;
	public GameObject ButtonC;
	public GameObject Buttonl;
	public GameObject Buttonr;
	// Use this for initialization
	void Start() {
		Scale = false;

		if (null != GameObject.Find("Main"))
		{
			ButtonM = GameObject.Find("Main");
			ButtonM.SetActive(false);
		}
		if (null != GameObject.Find("ReStart"))
		{
			ButtonR = GameObject.Find("ReStart");
			ButtonR.SetActive(false);
		}
		if (null != GameObject.Find("Continue"))
		{ 
			ButtonC = GameObject.Find("Continue");
			ButtonC.SetActive(false);
		}

		Buttonl = GameObject.Find("left");
		Buttonr = GameObject.Find("right");
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
		ButtonM.SetActive(false);
		ButtonR.SetActive(false);
		ButtonC.SetActive(false);

		Buttonr.SetActive(true);
		Buttonl.SetActive(true);

		Time.timeScale = 1.0f;
	}

	public void GameStop()
	{
		if (Scale)
		{
			Time.timeScale = 0.0f;

			ButtonM.SetActive(true);
			ButtonR.SetActive(true);
			ButtonC.SetActive(true);

			Buttonl.SetActive(false);
			Buttonr.SetActive(false);

			Scale = false;
		}
	}
}
