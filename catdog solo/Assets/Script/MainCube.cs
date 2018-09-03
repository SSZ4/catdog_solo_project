using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCube : MonoBehaviour {

	[SerializeField]
	UnityEngine.Color blockColor;
	
	const float scaleTime = 2.5f;
	const float lifeTime = 7.0f;
	

	Vector3 start = new Vector3(1.0f, 1.0f, 1.0f);
	Vector3 end = new Vector3(0.1f, 0.1f, 0.1f);

	// Use this for initialization
	void Start () {
		GameObject [] Cubes = GameObject.FindGameObjectsWithTag("Cube");

		foreach (GameObject c in Cubes)
		{
			//UnityEngine.Color mat = new UnityEngine.Color(Random.Range(2, 4) * 0.25f, 1.0f, 1.0f);
			//c.GetComponent<Renderer>().material.color = blockColor;
			c.GetComponent<Rigidbody>().AddForce(new Vector3((Random.Range(-5, 5) * 10), (Random.Range(-5, 5) * 10 + 50), (Random.Range(-5, 5)) * 10) * 15);
			StartCoroutine(ChangeScale(c));
			StartCoroutine(Kill(c));
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ChangeScale (GameObject obj)
	{
		for (float timer = 0.0f; timer < scaleTime; timer += Time.deltaTime)
		{
			obj.transform.localScale = Vector3.Lerp(start, end, timer / scaleTime);
			yield return null;
		}
	}

	IEnumerator Kill (GameObject obj)
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy(obj);
	}
}
