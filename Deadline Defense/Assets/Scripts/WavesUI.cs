using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    private Text wavesText;
    public WaveSpawner waveObject;

    private void Start()
    {
        wavesText = GetComponent<Text>();
    }

    private void Update()
    {
        wavesText.text = PlayerStats.Rounds.ToString() + "/" + waveObject.waves.Length.ToString();
    }
}
