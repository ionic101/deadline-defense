using UnityEngine;
using UnityEngine.UI;

public class WavesCounter : MonoBehaviour
{
    public Text wavesText;
    public WaveSpawner waveObject;
   
    // Update is called once per frame
    void Update()
    {
        wavesText.text = PlayerStats.Rounds.ToString() + "/" + waveObject.waves.Length.ToString();
    }
}
