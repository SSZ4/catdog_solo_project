using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Velocity : MonoBehaviour {
	Rigidbody rigid;
	GameObject Shadow;
	private Vector3 target_position;
	float i = 0.0f;
	public UnityEngine.Color RayColor;
	public float ShootAngle;
	private ColorSet Rule;
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody>();
		Shadow = GameObject.Find("Shadow");
		ShootAngle = 50.0f;
		Rule = GameObject.Find("Sphere").GetComponent<ColorSet>();
		transform.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast(Shadow.transform.position, -Vector3.up, out hit, 10.0f))
			RayColor = hit.collider.GetComponent<Renderer>().material.color;

		Debug.Log(RayColor);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (i == 0.0f)
		{
			transform.GetComponent<Velocity>().ShootAngle = 50.0f;
			float or = other.transform.GetComponent<Renderer>().material.color.r;
			float og = other.transform.GetComponent<Renderer>().material.color.g;
			float ob = other.transform.GetComponent<Renderer>().material.color.b;
			if (or == 0.0f && og == 0.0f && ob == 0.0f) { } // 검은색은 무시
			else
			{
				if (Rule.IsRedSet(or, og, ob))
					transform.GetComponent<Velocity>().ShootAngle = 30.0f;
				else if (Rule.IsBlueSet(or, og, ob))
					transform.GetComponent<Velocity>().ShootAngle = 70.0f;


				other.transform.GetComponent<Renderer>().material.color = UnityEngine.Color.black;
			}
		}

		if (other.transform.tag == "Plane")
		{		
			if (i == 0.0f)
			{	
				//Debug.Log("Enter");
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x + 11.4f, gameObject.transform.position.y, gameObject.transform.position.z);

				Shadow.transform.position = target_position;

				//Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
				//Debug.Log(target_position.x + " " + target_position.y + " " + target_position.z);
			
				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

				i = 1.0f;
			}
		}

		if (other.transform.tag == "CirclePlane")
		{
			if (i == 0.0f)
			{
				//Debug.Log("Enter");
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x + 22.8f, gameObject.transform.position.y, gameObject.transform.position.z);

				Shadow.transform.position = target_position;

				//Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
				//Debug.Log(target_position.x + " " + target_position.y + " " + target_position.z);

				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

				i = 1.0f;
			}
		}

		if (other.transform.tag == "SquarePlane")
		{
			if (i == 0.0f)
			{
				//Debug.Log("Enter");
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x - 11.4f, gameObject.transform.position.y, gameObject.transform.position.z);

				Shadow.transform.position = target_position;

				//Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
				//Debug.Log(target_position.x + " " + target_position.y + " " + target_position.z);

				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

				i = 1.0f;
			}
		}

	}

	private void OnCollisionExit(Collision other)
	{
		i = 0.0f;
	}

	
	Vector3 GetVelocity(Vector3 currentPos, Vector3 targetPos, float initialAngle)
	{
		float gravity = Physics.gravity.magnitude;
		float angle = initialAngle * Mathf.Deg2Rad;

		Vector3 planarTarget = new Vector3(targetPos.x, 0, targetPos.z);
		Vector3 planarPosition = new Vector3(currentPos.x, 0, currentPos.z);

		float distance = Vector3.Distance(planarTarget, planarPosition);
		float yOffset = currentPos.y - targetPos.y;

		float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
		Vector3 velocity = new Vector3(initialVelocity * Mathf.Cos(angle), initialVelocity * Mathf.Sin(angle), 0.0f);
		//Vector3 velocity = new Vector3(0f, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

		//Debug.Log(Vector3.Angle(transform.right, planarTarget - planarPosition));
		float angleBetweenObjects = Vector3.Angle(transform.right, planarTarget - planarPosition) * (targetPos.x > currentPos.x ? 1 : -1);

		//Debug.Log(angleBetweenObjects);

		Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, transform.up) * velocity;
		//Debug.Log(velocity);
		//Debug.Log(finalVelocity);
		finalVelocity = transform.InverseTransformVector(finalVelocity); // 자신의 각도 참조
		
		return finalVelocity;
	}

	

}





























/* 언젠가 하자
		if (Input.GetKey("d"))
		{
			transform.Rotate(new Vector3(0.0f, -3.0f, 0.0f), Space.Self);
			
			rigid.AddForce(-transform.right * rigid.velocity.x * (1 - Mathf.Sin(87 * Mathf.Deg2Rad)));
			rigid.AddForce(-transform.forward * rigid.velocity.x * Mathf.Cos(87 * Mathf.Deg2Rad));
			
			//rigid.velocity = new Vector3(rigid.velocity.x * Mathf.Sin(87 * Mathf.Deg2Rad), rigid.velocity.y, -rigid.velocity.x * Mathf.Cos(87 * Mathf.Deg2Rad));
			//rigid.velocity = Vector3.zero;
			//rigid.velocity = GetVelocity(transform.position, target_position + new Vector3(-1.0f, 0.0f, 1.0f), 0.0f);
		}

		if (Input.GetKey("a"))
		{
			transform.Rotate(new Vector3(0.0f, 3.0f, 0.0f), Space.Self);
			rigid.velocity = new Vector3(rigid.velocity.x * Mathf.Sin(87 * Mathf.Deg2Rad), rigid.velocity.y, rigid.velocity.x * Mathf.Cos(87 * Mathf.Deg2Rad));
			//rigid.velocity = Vector3.zero;
			//rigid.velocity = GetVelocity(transform.position, target_position + new Vector3(-1.0f, 0.0f, 1.0f), 0.0f);
		}
*/
