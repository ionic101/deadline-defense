using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour {

	private Text moneyText;

    private void Start()
    {
        moneyText = GetComponent<Text>();
    }

    void Update () {
        moneyText.text = PlayerStats.Money.ToString();
	}
}
