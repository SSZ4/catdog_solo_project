using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsRedSet(float or, float og, float ob)
	{
		if (or >= 0.75f && og <= 1.0f && og >= 0.0f && og <= 0.25f && ob >= 0.0f && ob <= 0.25f)
			return true;
		else
			return false;
	}

	public bool IsGreenSet(float or, float og, float ob)
	{
		if (or >= 0.0f && og <= 0.25f && og >= 0.75f && og <= 1.0f && ob >= 0.0f && ob <= 0.25f)
			return true;
		else
			return false;
	}

	public bool IsBlueSet(float or, float og, float ob)
	{
		if (or >= 0.0f && og <= 0.25f && og >= 0.0f && og <= 0.25f && ob >= 0.75f && ob <= 1.0f)
			return true;
		else
			return false;
	}

	public bool IsCyanSet(float or, float og, float ob)
	{
		if (or >= 0.0f && og <= 0.25f && og >= 0.75f && og <= 1.0f && ob >= 0.75f && ob <= 1.0f)
			return true;
		else
			return false;
	}

	public bool IsMagentaSet(float or, float og, float ob)
	{
		if (or >= 0.75f && og <= 1.0f && og >= 0.0f && og <= 0.25f && ob >= 0.75f && ob <= 1.0f)
			return true;
		else
			return false;
	}

	public bool IsYellowSet(float or, float og, float ob)
	{
		if (or >= 0.75f && og <= 1.0f && og >= 0.75f && og <= 1.0f && ob >= 0.0f && ob <= 0.25f)
			return true;
		else
			return false;
	}

}
