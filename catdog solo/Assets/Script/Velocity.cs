using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
	private MeshRenderer Mesh;
	private bool roton;
	private bool rotminuson;
	GameObject map;
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
		map = GameObject.Find("World");

		Buttonl = UIManager.GetComponent<Button>().Buttonl;
		Buttonr = UIManager.GetComponent<Button>().Buttonr;
		Mesh = transform.GetComponent<MeshRenderer>();

		roton = false;
		rotminuson = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name != "Tutorial2")
			GameOver();
		else
			TutoEnd();

		RayHitting();

		if (roton)
		{
			UIManager.GetComponent<worldrotation>().IsPressedLeft = true;
		}

		if (rotminuson)
		{
			UIManager.GetComponent<worldrotation>().IsPressedRight = true;
		}
	}

	private void RayHitting()
	{
		RaycastHit hit;
		if (Physics.Raycast(Shadow.transform.position, -Vector3.up, out hit, 10.0f))
			RayColor = hit.collider.GetComponent<Renderer>().material.color;
		else if (Physics.Raycast(Shadow.transform.position, Vector3.up, out hit, 10.0f))
		{
			RayColor = hit.collider.GetComponent<Renderer>().material.color;
			float x = Shadow.transform.position.x - 1.2848f;
			float y = Shadow.transform.position.y + 2.0f;
			Shadow.transform.position = new Vector3(x, y, Shadow.transform.position.z);
		}

		rayui.GetComponent<Image>().color = RayColor;

		float r = RayColor.r;
		float g = RayColor.g;
		float b = RayColor.b;

		if (Rule.IsRedSet(r, g, b))
		{
			raytext.GetComponent<Text>().text = "Red";
		}
		else if (Rule.IsBlueSet(r, g, b))
		{
			raytext.GetComponent<Text>().text = "Blue";
		}
		else if (Rule.IsGreenSet(r, g, b))
		{
			raytext.GetComponent<Text>().text = "Green";
		}
		else if (Rule.IsCyanSet(r, g, b))
		{
			raytext.GetComponent<Text>().text = "Cyan";
		}
		else if (Rule.IsMagentaSet(r, g, b))
		{
			raytext.GetComponent<Text>().text = "Magenta";
		}
		else if (Rule.IsYellowSet(r, g, b))
		{
			raytext.GetComponent<Text>().text = "Yellow";
		}
		else if (r == 0.0f && g == 0.0f && b == 0.0f)
		{
			raytext.GetComponent<Text>().text = "Black";
		}
		else
		{
			raytext.GetComponent<Text>().text = "";
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		float height = other.transform.position.y + 1.6f;
		if (transform.position.y > height)
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
					else if (Rule.IsCyanSet(or, og, ob))
						SphereOff();
					else if (Rule.IsYellowSet(or, og, ob))
					{
						if (UIManager.GetComponent<worldrotation>().Reverse)
							RotReverseOn();
					}
					else if (Rule.IsMagentaSet(or, og, ob))
					{
						int k = map.GetComponentsInChildren<Area>().Length;
						for (int i = 0; i < k; i++)
						{
							map.GetComponentsInChildren<Area>()[i].reColoring();
						}
					}



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

					float k = 0;
					k = Random.Range(1.0f, 2.0f);

					int j = 0;
					while (j == 0)
						j = Random.Range(-1, 2);

					k = k*j;

					Debug.Log(j);
					if (k > 0)
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
				if (i == 0.0f)
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
				}
				i = 1.0f;
			}
		}
		else // 옆면 충돌처리
		{
			if (i == 0.0f)
			{
				rigid.velocity = Vector3.zero;
				target_position = new Vector3(gameObject.transform.position.x - 2.5f, other.transform.position.y - 0.3f, gameObject.transform.position.z);

				Shadow.transform.position = target_position;
				rigid.velocity = GetVelocity(gameObject.transform.position, target_position, ShootAngle);

			}
			i = 1.0f;
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

		float angleBetweenObjects = Vector3.Angle(transform.right, planarTarget - planarPosition) * (targetPos.x > currentPos.x ? 1 : -1);


		Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, transform.up) * velocity;
		finalVelocity = transform.InverseTransformVector(finalVelocity); // 자신의 각도 참조
		
		return finalVelocity;
	}







	private void Rotate(float k)
	{
		roton = true;
		Invoke("RotateStop", k);
	}

	private void RotateStop()
	{
		roton = false;
		rotminuson = false;
		UIManager.GetComponent<worldrotation>().IsPressedRight = false;
		UIManager.GetComponent<worldrotation>().IsPressedLeft = false;
	}

	private void RotateMinus(float k)
	{
		rotminuson = true;
		Invoke("RotateMinusStop", -k);
	}

	private void RotateMinusStop()
	{
		roton = false;
		rotminuson = false;
		UIManager.GetComponent<worldrotation>().IsPressedRight = false;
		UIManager.GetComponent<worldrotation>().IsPressedLeft = false;
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
		if (UIManager.GetComponent<worldrotation>().IsPressedLeft == true)
		{
			UIManager.GetComponent<worldrotation>().IsPressedLeft = false;
			UIManager.GetComponent<worldrotation>().IsPressedRight = true;
		}
		else if (UIManager.GetComponent<worldrotation>().IsPressedRight == true)
		{
			UIManager.GetComponent<worldrotation>().IsPressedRight = false;
			UIManager.GetComponent<worldrotation>().IsPressedLeft = true;
		}

		if (roton)
		{
			roton = false;
			rotminuson = true;
		}

		if (rotminuson)
		{
			roton = true;
			rotminuson = false;
		}


		UIManager.GetComponent<worldrotation>().Reverse = false;

		Invoke("RotReverseOff", 1.5f);
	}

	private void RotReverseOff()
	{
		UIManager.GetComponent<worldrotation>().Reverse = true;

		if (UIManager.GetComponent<worldrotation>().IsPressedLeft == true)
		{
			UIManager.GetComponent<worldrotation>().IsPressedLeft = false;
			UIManager.GetComponent<worldrotation>().IsPressedRight = true;
		}
		else if (UIManager.GetComponent<worldrotation>().IsPressedRight == true)
		{
			UIManager.GetComponent<worldrotation>().IsPressedRight = false;
			UIManager.GetComponent<worldrotation>().IsPressedLeft = true;
		}
	}

	private void GameOver()
	{
		if(transform.position.y < -5.0f && Time.timeScale == 1.0f)
			transform.GetComponent<Destination>().GameEnd();
	}

	public void TutoEnd()
	{
		if (transform.position.y < -10.0f)
		{
			Vector3 pos = GameObject.Find("tile").transform.position;
			pos.y += 10.0f;
			transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
			transform.transform.position = pos;
		}
	}
}