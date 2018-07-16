using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {
	public GameObject[] ChildHexagon;
	public UnityEngine.Color[] TileColor;
	// Use this for initialization
	void Start () {
		ChildHexagon = new GameObject[7];
		for (int i = 0; i < 7; i++) {
			ChildHexagon[i] = this.transform.GetChild(i).gameObject;
		}
		TileColor = new UnityEngine.Color[7];
		
		TileColor[0] = UnityEngine.Color.black;

		for (int i = 1; i < 7; i++)
		{
			int k = Random.Range(1, 12);
			switch (k)
			{
				case 1:
					TileColor[i] = new UnityEngine.Color(1.0f, 0.25f, 0.0f);
					break;
				case 2:
					TileColor[i] = new UnityEngine.Color(1.0f, 0.0f, 0.25f);
					break;
				case 3:
					TileColor[i] = new UnityEngine.Color(0f, 1.0f, 0.25f);
					break;
				case 4:
					TileColor[i] = new UnityEngine.Color(0.0f, 0.75f, 0.0f);
					break;
				case 5:
					TileColor[i] = new UnityEngine.Color(0.0f, 0.25f, 1.0f);
					break;
				case 6:
					TileColor[i] = new UnityEngine.Color(0.0f, 0.0f, 0.75f);
					break;
				case 7:
					TileColor[i] = new UnityEngine.Color(0.0f, 1.0f, 0.75f);
					break;
				case 8:
					TileColor[i] = new UnityEngine.Color(0.0f, 0.75f, 1.0f);
					break;
				case 9:
					TileColor[i] = new UnityEngine.Color(1.0f, 0.0f, 0.75f);
					ChildHexagon[i].GetComponentInChildren<MeshCollider>().convex = true;
					ChildHexagon[i].GetComponentInChildren<MeshCollider>().isTrigger = true;
					break;
				case 10:
					TileColor[i] = new UnityEngine.Color(0.75f, 0.0f, 1.0f);
					ChildHexagon[i].GetComponentInChildren<MeshCollider>().convex = true;
					ChildHexagon[i].GetComponentInChildren<MeshCollider>().isTrigger = true;
					break;
				case 11:
					TileColor[i] = new UnityEngine.Color(0.75f, 1.0f, 0.0f);
					break;
				case 12:
					TileColor[i] = new UnityEngine.Color(1.0f, 0.75f, 0.0f);
					break;

			}
		}
		
		for (int i = 0; i < 7; i++)
		{
			ChildHexagon[i].GetComponentInChildren<Renderer>().material.color = TileColor[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
