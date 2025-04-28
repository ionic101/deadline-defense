using UnityEngine;

public class TowersController : MonoBehaviour
{
    public static TowersController instance;
    private Tower towerToBuild;

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

    public void ChooseTowerToBuild(Tower tower)
    {
        towerToBuild = tower;
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
    }
}
