using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageAccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(PlayerPrefs.HasKey("second"));
		if (PlayerPrefs.HasKey("second"))
		{
			UnityEngine.Color c = GameObject.Find("raycastui2").GetComponent<Image>().color;
			c.a = 1.0f;
			GameObject.Find("raycastui2").GetComponent<Image>().color = c;
		}

		if (PlayerPrefs.HasKey("third"))
		{
			UnityEngine.Color c = GameObject.Find("raycastui3").GetComponent<Image>().color;
			c.a = 1.0f;
			GameObject.Find("raycastui3").GetComponent<Image>().color = c;
		}

		if (PlayerPrefs.HasKey("fourth"))
		{
			UnityEngine.Color c = GameObject.Find("raycastui4").GetComponent<Image>().color;
			c.a = 1.0f;
			GameObject.Find("raycastui4").GetComponent<Image>().color = c;
		}

		if (PlayerPrefs.HasKey("fifth"))
		{
			UnityEngine.Color c = GameObject.Find("raycastui5").GetComponent<Image>().color;
			c.a = 1.0f;
			GameObject.Find("raycastui5").GetComponent<Image>().color = c;
		}

		if (PlayerPrefs.HasKey("sixth"))
		{
			UnityEngine.Color c = GameObject.Find("raycastui6").GetComponent<Image>().color;
			c.a = 1.0f;
			GameObject.Find("raycastui6").GetComponent<Image>().color = c;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
