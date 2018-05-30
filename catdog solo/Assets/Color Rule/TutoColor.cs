using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoColor : MonoBehaviour {
	private float i = 0.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (i == 0.0f)
		{
			if (other.transform.tag == "Plane") // 태그는 임시로 설정함.
			{
				float or = other.transform.GetComponent<Renderer>().material.color.r;
				float og = other.transform.GetComponent<Renderer>().material.color.g;
				float ob = other.transform.GetComponent<Renderer>().material.color.b;
				if (or == 0.0f && og == 0.0f && ob == 0.0f) { } // 검은색은 무시
				else
				{
					other.transform.GetComponent<Renderer>().material.color = UnityEngine.Color.black;
				}
				i = 1.0f;
			}
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		i = 0.0f;
	}
}
