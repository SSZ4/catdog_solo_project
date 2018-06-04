using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour {
	GameObject Ball;
	// Use this for initialization
	void Start () {
		Ball = GameObject.Find("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
		TutoMove();
		TutoMove2();
	}


	public void MaintoTuto()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Tutorial");
	}


	public void MaintoStart()
	{
		SceneManager.LoadScene("Select");
	}

	public void StarttoMain()
	{
		SceneManager.LoadScene("Main");
	}

	public void SelecttoFirst()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("First");
	}

	public void SelecttoSecond()

	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Second");
	}

	public void SelecttoThird()

	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Third");
	}

	public void GameExit()
	{
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false; //에디터로 실행 시 종료
	}
	
	public void ReStart()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void TutoMove()
	{
		if (SceneManager.GetActiveScene().name == "Tutorial" && Ball.transform.position.y < -10.0f)
		{
			SceneManager.LoadScene("Tutorial2");
		}
	}
	private void TutoMove2()
	{
		if (SceneManager.GetActiveScene().name == "Tutorial2" && Ball.transform.position.y < -10.0f)
		{
			SceneManager.LoadScene("Tutorial3");
		}
	}	
}
