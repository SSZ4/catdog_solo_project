using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTouch : MonoBehaviour
{
	private Touch tempt;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				tempt = Input.GetTouch(i);
				if (tempt.phase == TouchPhase.Ended)
				{    //해당 터치가 끝나면
					MaintoStart();
					break;   //한 프레임(update)에는 하나만.
				}
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			MaintoStart();
		}
	}

	public void MaintoStart()
	{
			SceneManager.LoadScene("Select");
	}
}
