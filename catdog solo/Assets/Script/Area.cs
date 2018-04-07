using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {
	public GameObject[] ChildHexagon;
	// Use this for initialization
	void Start () {
		ChildHexagon = new GameObject[7];

		for (int i = 0; i < 7; i++) {
			ChildHexagon[i] = this.transform.GetChild(i).gameObject;
		}
		ChildHexagon[1].GetComponentInChildren<Renderer>().material.color = UnityEngine.Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
