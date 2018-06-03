using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdColor : MonoBehaviour {
	private float i = 0.0f;
	private ColorSet Rule;
	// Use this for initialization
	void Start () {
		transform.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
		Rule = GameObject.Find("Sphere").GetComponent<ColorSet>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (i == 0.0f)
		{
			transform.GetComponent<Velocity>().ShootAngle = 50.0f;
			float or = other.transform.GetComponent<Renderer>().material.color.r;
			float og = other.transform.GetComponent<Renderer>().material.color.g;
			float ob = other.transform.GetComponent<Renderer>().material.color.b;
			if (or == 0.0f && og == 0.0f && ob == 0.0f) {  } // 검은색은 무시
			else
			{
				if (Rule.IsRedSet(or, og, ob))
					transform.GetComponent<Velocity>().ShootAngle = 30.0f;
				else if (Rule.IsBlueSet(or, og, ob))
					transform.GetComponent<Velocity>().ShootAngle = 70.0f;


				other.transform.GetComponent<Renderer>().material.color = UnityEngine.Color.black;
			}
			i = 1.0f;
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		i = 0.0f;
	}
}
