using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Renderer>().material.color = new Vector4(1.0f, 0.5f, 0.5f, 0.0f);
	}
}
