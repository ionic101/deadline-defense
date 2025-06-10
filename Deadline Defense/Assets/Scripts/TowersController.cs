using UnityEngine;

public class TowersController : MonoBehaviour
{
    public static TowersController instance;
    private Tower towerToBuild;

    private GameObject cancelButton;

    public bool IsCanBuild {
        get
        {
            return towerToBuild != null &&
                PlayerStats.Money >= towerToBuild.BuyCost;
        } 
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one TowersController in scene!");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        cancelButton = GameObject.FindWithTag("cancel");
        cancelButton.SetActive(false);
    }

    public void ChooseTowerToBuild(Tower tower)
    {
        FindFirstObjectByType<AudioManager>().Play("selectTower");
        towerToBuild = tower;
        cancelButton.SetActive(true);
    }

    public void UnchooseTowerToBuild()
    {
        towerToBuild = null;
        cancelButton.SetActive(false);
    }

    public void Build(Node node)
    {
        if (!IsCanBuild)
        {
            Debug.LogError("Cant build tower");
            return;
        }
        PlayerStats.Money -= towerToBuild.BuyCost; 
        node.tower = Instantiate(towerToBuild, node.towerPosition, Quaternion.identity);
        towerToBuild = null;
        cancelButton.SetActive(false);
    }
}
