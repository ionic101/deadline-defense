using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
            Toggle();
		}
	}

	public void Toggle ()
	{
        ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
            FindObjectOfType<AudioManager>().PauseMusic();
            Time.timeScale = 0f;
			Debug.Log("signal");
		} else
		{
            FindObjectOfType<AudioManager>().UnPauseMusic();
            Time.timeScale = 1f;
		}
	}

	public void Retry ()
	{
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

	public void Menu ()
	{
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Toggle();
		sceneFader.FadeTo(menuSceneName);
    }

}
