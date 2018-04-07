using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldrotation : MonoBehaviour {
	GameObject map;
	public bool IsPressedRight;
	public bool IsPressedLeft;
	// Use this for initialization
	void Start () {
		map = GameObject.Find("World");
		IsPressedRight = false;
		IsPressedLeft = false;
	}
	
	// Update is called once per frame
	void Update () {
		OnClickButtonLeft();
		OnClickButtonRight();
	}
	
	public void ClickStartRight()
	{
		IsPressedRight = true;
	}

	public void ClickEndRight()
	{
		IsPressedRight = false;
	}

	public void ClickStartLeft()
	{
		IsPressedLeft = true;
	}

	public void ClickEndLeft()
	{
		IsPressedLeft = false;
	}


	public void OnClickButtonRight()
	{
		if (IsPressedRight)
		{
			map.transform.Rotate(new Vector3(0.0f, -3.0f, 0.0f), Space.Self);
		}
	}

	public void  OnClickButtonLeft()
	{
		if (IsPressedLeft)
		{
			map.transform.Rotate(new Vector3(0.0f, 3.0f, 0.0f), Space.Self);
		}
	}
}
