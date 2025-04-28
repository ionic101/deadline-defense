using UnityEngine.UI;
using UnityEngine;
public class InterectButton : MonoBehaviour
{

    public int towerPrice;

    public Button button;
    // Update is called once per frame

    void Start()
    {
        button.interactable = true;

    }


    void Update()
    {
        if (PlayerStats.Money < towerPrice)
        {
            button.interactable = false;
        }
        else { 
            button.interactable = true;
        }
    }
}
