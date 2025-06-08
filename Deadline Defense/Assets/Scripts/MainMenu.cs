using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
        FindFirstObjectByType<AudioManager>().Play("ButtonClick");
        sceneFader.FadeTo(levelToLoad);
	}

	public void Quit ()
	{
        FindFirstObjectByType<AudioManager>().Play("ButtonClick");
        Debug.Log("Exciting...");
		Application.Quit();
	}

}
