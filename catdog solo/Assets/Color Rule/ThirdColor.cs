using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdColor : MonoBehaviour {
	private float i = 0.0f;
	private ColorSet Rule;
	private MeshRenderer Mesh;
	public GameObject Buttonl;
	public GameObject Buttonr;
	public GameObject ui;
	// Use this for initialization
	void Start () {
		transform.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
		Rule = GameObject.Find("Sphere").GetComponent<ColorSet>();
		Mesh = transform.GetComponent<MeshRenderer>();

		ui = GameObject.Find("UIManager");
		Buttonl = ui.GetComponent<Button>().Buttonl;
		Buttonr = ui.GetComponent<Button>().Buttonr;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (i == 0.0f)
		{
			//Debug.Log("Enter");
			float or = transform.GetComponent<Velocity>().or;
			float og = transform.GetComponent<Velocity>().og;
			float ob = transform.GetComponent<Velocity>().ob;
			//Debug.Log(or + " " + og + " " + ob);

			if (Rule.IsCyanSet(or, og, ob))
				SphereOff();
			else if (Rule.IsYellowSet(or, og, ob)) {
				if(ui.GetComponent<worldrotation>().Reverse)
					RotReverseOn();
			}

			i = 1.0f;
		}
	}
	private void OnCollisionExit(Collision other)
	{
		i = 0.0f;
	}


	private void SphereOff()
	{
		Mesh.enabled = false;
		Invoke("SphereOn", 1.5f);
	}

	private void SphereOn()
	{
		Mesh.enabled = true;
	}

	private void RotReverseOn()
	{
		if (ui.GetComponent<worldrotation>().IsPressedLeft == true)
		{
			ui.GetComponent<worldrotation>().IsPressedLeft = false;
			ui.GetComponent<worldrotation>().IsPressedRight = true;
		}
		else if (ui.GetComponent<worldrotation>().IsPressedRight == true)
		{
			ui.GetComponent<worldrotation>().IsPressedRight = false;
			ui.GetComponent<worldrotation>().IsPressedLeft = true;
		}

		ui.GetComponent<worldrotation>().Reverse = false;

		Invoke("RotReverseOff", 0.5f);
	}

	private void RotReverseOff()
	{
		ui.GetComponent<worldrotation>().Reverse = true;

		if (ui.GetComponent<worldrotation>().IsPressedLeft == true)
		{
			ui.GetComponent<worldrotation>().IsPressedLeft = false;
			ui.GetComponent<worldrotation>().IsPressedRight = true;
			//Debug.Log("Enter");
		}
		else if (ui.GetComponent<worldrotation>().IsPressedRight == true)
		{
			ui.GetComponent<worldrotation>().IsPressedRight = false;
			ui.GetComponent<worldrotation>().IsPressedLeft = true;
		}
	}
}
