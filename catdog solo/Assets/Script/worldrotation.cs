﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldrotation : MonoBehaviour {
	GameObject map;
	GameObject Ball;
	Vector3 Sphere;
	public bool IsPressedRight;
	public bool IsPressedLeft;
	public float angle;
	public bool Reverse;
	// Use this for initialization
	void Start () {
		map = GameObject.Find("World");
		Ball = GameObject.Find("Sphere");
		IsPressedRight = false;
		IsPressedLeft = false;
		angle = 2.0f;
		Reverse = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0.0f)
		{
			OnClickButtonLeft();
			OnClickButtonRight();
		}
	}
	
	public void ClickStartRight()
	{
		if(Reverse)
			IsPressedRight = true;
		else
			IsPressedLeft = true;
	}

	public void ClickEndRight()
	{
		if (Reverse)
			IsPressedRight = false;
		else
			IsPressedLeft = false;
	}

	public void ClickStartLeft()
	{
		if (Reverse)
			IsPressedLeft = true;
		else
			IsPressedRight = true;
	}

	public void ClickEndLeft()
	{
		if (Reverse)
			IsPressedLeft = false;
		else
			IsPressedRight = false;
	}

	public void OnClickButtonRight()
	{
		if (IsPressedRight)
		{
			//map.transform.Rotate(new Vector3(0.0f, angle * -1, 0.0f), Space.Self);
			Sphere = Ball.transform.position;
			map.transform.RotateAround(Sphere, Vector3.up, angle * -1);
		}
	}

	public void  OnClickButtonLeft()
	{
		if (IsPressedLeft)
		{
			//map.transform.Rotate(new Vector3(0.0f, angle, 0.0f), Space.Self);
			Sphere = Ball.transform.position;
			map.transform.RotateAround(Sphere, Vector3.up, angle);
		}
	}
}
