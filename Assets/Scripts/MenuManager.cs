using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private GameObject pause;
	[SerializeField] private GameObject win;
	static public bool pauseActive = false;

    public void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Continue()
	{
		Cursor.lockState = CursorLockMode.Locked;
		pause.SetActive(false);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Back()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void Update()
	{
		if (pause.activeInHierarchy || endOfGame.Win == true)
		{
			pauseActive = true;
		}
		else
		{
			pauseActive = false;
		}

		if (endOfGame.Win == true)
		{
			win.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
		}

		//toggle the pause menu with escape
		if (Input.GetKeyDown("escape"))
		{
			if (Cursor.lockState == CursorLockMode.None)
			{
				Cursor.lockState = CursorLockMode.Locked;
				pause.SetActive(false);
			}
			if (Cursor.lockState == CursorLockMode.Locked)
			{
				Cursor.lockState = CursorLockMode.None;
				pause.SetActive(true);
			}
		}
	}
}