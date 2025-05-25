using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        sceneFader.FadeTo(levelToLoad);
	}

	public void Quit ()
	{
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Debug.Log("Exciting...");
		Application.Quit();
	}

}
