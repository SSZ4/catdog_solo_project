using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {
	// Use this for initialization
	public GameObject ButtonM;
	public GameObject ButtonR;
	public GameObject Buttonl;
	public GameObject Buttonr;
	GameObject ui;
	void Start () {

		ui = GameObject.Find("UIManager");
		ButtonM = ui.GetComponent<Button>().ButtonM;
		ButtonR = ui.GetComponent<Button>().ButtonR;

		Buttonl = ui.GetComponent<Button>().Buttonl;
		Buttonr = ui.GetComponent<Button>().Buttonr;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (Time.timeScale != 0.0f && other.transform.tag == "Dest")
		{
			GameEnd();
		}
	}

	public void GameEnd()
	{
		ButtonM.SetActive(true);
		Vector3 pos = ButtonM.transform.position;
		pos.x += 200.0f;
		ButtonM.transform.position = pos;

		ButtonR.SetActive(true);
		pos = ButtonR.transform.position;
		pos.x += 300.0f;
		ButtonR.transform.position = pos;


		Buttonl.SetActive(false);
		Buttonr.SetActive(false);

		Time.timeScale = 0.0f;
	}

}
