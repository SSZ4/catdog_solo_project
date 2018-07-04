using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject [] Cubes = GameObject.FindGameObjectsWithTag("Cube");

		foreach (GameObject c in Cubes)
		{
			UnityEngine.Color mat = new UnityEngine.Color(Random.Range(2, 4) * 0.25f, 1.0f, 1.0f);
			c.GetComponent<Renderer>().material.color = mat;
			c.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5, 5), 0.0f, Random.Range(-5, 5)) * 10f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
