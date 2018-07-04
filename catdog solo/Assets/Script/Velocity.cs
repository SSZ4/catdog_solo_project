using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Velocity : MonoBehaviour {
	Rigidbody rigid;
	GameObject Shadow;
	private Vector3 target_position;
	private float i = 0.0f;
	public UnityEngine.Color RayColor;
	public float ShootAngle;
	private ColorSet Rule;
	GameObject UIManager;
	GameObject rayui;
	GameObject raytext;
	public float or;
	public float og;
	public float ob;
	public GameObject Buttonl;
	public GameObject Buttonr;
	//GameObject map;
	// Use this for initialization
	void Start () { 
		rigid = gameObject.GetComponent<Rigidbody>();
		Shadow = GameObject.Find("Shadow");
		ShootAngle = 50.0f;
		Rule = GameObject.Find("Sphere").GetComponent<ColorSet>();
		transform.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
		rayui = GameObject.Find("raycastui");
		raytext = GameObject.Find("raytext");
		UIManager = GameObject.Find("UIManager");
		//map = GameObject.Find("World");

		Buttonl = UIManager.GetComponent<Button>().Buttonl;
		Buttonr = UIManager.GetComponent<Button>().Buttonr;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast(Shadow.transform.position, -Vector3.up, out hit, 10.0f))
			RayColor = hit.collider.GetComponent<Renderer>().material.color;

		rayui.GetComponent<Image>().color = RayColor;

		float r = RayColor.r;
		float g = RayColor.g;
		float b = RayColor.b;

		if (Rule.IsRedSet(r, g, b)) {
			raytext.GetComponent<Text>().text = "Red";
		}
		else if (Rule.IsBlueSet(r, g, b)) {
			raytext.GetComponent<Text>().text = "Blue";
		}
		else if (Rule.IsGreenSet(r, g, b)) {
			raytext.GetComponent<Text>().text = "Green";
		}
		else if (Rule.IsCyanSet(r, g, b)) {
			raytext.GetComponent<Text>().text = "Cyan";
		}
		else if (Rule.IsMagentaSet(r, g, b)) {
			raytext.GetComponent<Text>().text = "Magenta";
		}
		else if (Rule.IsYellowSet(r, g, b)) {
			raytext.GetComponent<Text>().text = "Yellow";
		}
		else if (r == 0.0f && g == 0.0f && b == 0.0f)
		{
			raytext.GetComponent<Text>().text = "Black";
		}
		else {
			raytext.GetComponent<Text>().text = "";
		}

		//Debug.Log(RayColor);
	}

	private void OnCollisionEnter(Collision other)
	{

		if (i == 0.0f)
		{
			transform.GetComponent<Velocity>().ShootAngle = 50.0f;
			or = other.transform.GetComponent<Renderer>().material.color.r;
			og = other.transform.GetComponent<Renderer>().material.color.g;
			ob = other.transform.GetComponent<Renderer>().material.color.b;
			if (or == 0.0f && og == 0.0f && ob == 0.0f) { } // 검은색은 무시
			else
			{
				if (Rule.IsRedSet(or, og, ob))
					ShootAngle = 30.0f;
				else if (Rule.IsBlueSet(or, og, ob))
					ShootAngle = 70.0f;
				else if (Rule.IsGreenSet(or, og, ob))
					LeftRightOff();



				//other.transform.GetComponent<Renderer>().material.color = UnityEngine.Color.black;
			}
		}

		if (other.transform.tag == "Plane")
		{		
			if (i == 0.0f)
			{	
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x + 11.4f, gameObject.transform.position.y, gameObject.transform.position.z);

				Shadow.transform.position = target_position;
				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

				i = 1.0f;
			}
		}

		if (other.transform.tag == "CirclePlane")
		{
			if (i == 0.0f)
			{
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x + 22.8f, gameObject.transform.position.y, gameObject.transform.position.z);

				Shadow.transform.position = target_position;
				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

				i = 1.0f;
			}
		}

		if (other.transform.tag == "SquarePlane")
		{
			if (i == 0.0f)
			{
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x - 11.4f, gameObject.transform.position.y, gameObject.transform.position.z);

				Shadow.transform.position = target_position;
				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

				i = 1.0f;
			}
		}

		if (other.transform.tag == "StarPlane")
		{
			if (i == 0.0f)
			{
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x + 11.4f, gameObject.transform.position.y, gameObject.transform.position.z);

				Shadow.transform.position = target_position;
				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

				int k = 0;
				while (k == 0)
				{
					k = Random.Range(-2, 2);
				}
				

				Debug.Log(k);
				if(k > 0)
				{
					Rotate(k);
				}
				else
				{
					RotateMinus(k);
				}

				i = 1.0f;
			}
		}

		if (other.transform.tag == "TriPlane")
		{
			rigid.velocity = Vector3.zero;
			target_position = new Vector3(gameObject.transform.position.x + 11.4f, gameObject.transform.position.y, gameObject.transform.position.z);

			Debug.Log(target_position.x + " " + target_position.y + " " + target_position.z);

			Shadow.transform.position = target_position;
			Vector3 pos = target_position;
			pos.x -= 2.28f;
			pos.y += 4.0f;
			gameObject.transform.position = pos;
			rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);


			/*
			Vector3 pos = target_position;
			pos.y += 3.0f;
			transform.position = pos;
			*/
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

	private void Rotate(int k)
	{
		UIManager.GetComponent<worldrotation>().IsPressedLeft = true;
		Invoke("RotateStop", k);
	}

	private void RotateStop()
	{
		UIManager.GetComponent<worldrotation>().IsPressedLeft = false;
	}

	private void RotateMinus(int k)
	{
		UIManager.GetComponent<worldrotation>().IsPressedRight = true;
		Invoke("RotateMinusStop", -k);
	}

	private void RotateMinusStop()
	{
		UIManager.GetComponent<worldrotation>().IsPressedRight = false;
	}

	private void LeftRightOff()
	{
		Buttonl.SetActive(false);
		Buttonr.SetActive(false);
		UIManager.GetComponent<worldrotation>().IsPressedLeft = false;
		UIManager.GetComponent<worldrotation>().IsPressedRight = false;

		Invoke("LeftRightOn", 1.5f);
	}

	private void LeftRightOn()
	{
		UIManager.GetComponent<worldrotation>().IsPressedLeft = false;
		UIManager.GetComponent<worldrotation>().IsPressedRight = false;
		Buttonl.SetActive(true);
		Buttonr.SetActive(true);
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
