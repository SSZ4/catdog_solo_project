using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMover : MonoBehaviour {
	GameObject Ball;
	Vector3 curpos;
	// Use this for initialization
	void Start () {
		Ball = GameObject.Find("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
		TutoMove2();
	}


	public void MaintoTuto()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Tutorial2");
	}


	public void MaintoStart()
	{
		SceneManager.LoadScene("Select");
	}

	public void StarttoMain()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Main");
	}

	public void SelecttoFirst()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("First");
	}

	public void SelecttoSecond()
	{
		if (GameObject.Find("raycastui2").GetComponent<Image>().color.a == 1.0f)
		{
			Time.timeScale = 1.0f;
			SceneManager.LoadScene("Second");
		}
	}

	public void SelecttoThird()
	{
		if (GameObject.Find("raycastui3").GetComponent<Image>().color.a == 1.0f)
		{
			Time.timeScale = 1.0f;
			SceneManager.LoadScene("Third");
		}
	}

	public void SelecttoFourth()
	{
		if (GameObject.Find("raycastui4").GetComponent<Image>().color.a == 1.0f)
		{
			Time.timeScale = 1.0f;
			SceneManager.LoadScene("Fourth");
		}
	}

	public void SelecttoFifth()
	{
		if (GameObject.Find("raycastui5").GetComponent<Image>().color.a == 1.0f)
		{
			Time.timeScale = 1.0f;
			SceneManager.LoadScene("Fifth");
		}
	}	

	public void SelecttoSixth()
	{
		if (GameObject.Find("raycastui6").GetComponent<Image>().color.a == 1.0f)
		{
			Time.timeScale = 1.0f;
			SceneManager.LoadScene("Sixth");
		}
	}

	public void GameExit()
	{
		Application.Quit();
		//UnityEditor.EditorApplication.isPlaying = false; //에디터로 실행 시 종료
	}
	
	public void ReStart()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void TutoSelect()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Select");
	}

	private void TutoMove2()
	{
		if (SceneManager.GetActiveScene().name == "Tutorial2" && Ball.transform.position.y < -10.0f)
		{
			Vector3 pos = GameObject.Find("tile").transform.position;
			pos.y += 10.0f;
			Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
			Ball.transform.position = pos;
		}
	}
}
