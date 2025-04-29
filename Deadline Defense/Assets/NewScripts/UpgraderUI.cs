using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderUI : MonoBehaviour
{
    public static UpgraderUI instance;
    public GameObject Upgrader;

    public Text TowerTitle;
    public Image TowerImage;

    public Text LevelCurText;
    public Text LevelUpgradeText;

    public Text DamageCurText;
    public Text DamageUpgradeText;

    public Text RadiusCurText;
    public Text RadiusUpgradeText;

    public Text SellText;
    public Text UpgradeText;

    private Tower curTower;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one UpgraderUI in scene!");
            return;
        }
        instance = this;
    }

    public void UpdateData(Tower tower)
    {
        curTower = tower;
        TowerTitle.text = tower.Name;
        TowerImage.sprite = tower.Sprite;
        LevelCurText.text = tower.Level.ToString();
        DamageCurText.text = tower.ShootDamage.ToString();
        RadiusCurText.text = tower.ShootRange.ToString();
        SellText.text = "Продать $" + tower.SellCost.ToString();

        TowerUpgrade nextUpgrade = tower.NextUpgrade;
        if (nextUpgrade == null)
        {
            LevelUpgradeText.text = "MAX";
            DamageUpgradeText.text = "MAX";
            RadiusUpgradeText.text = "MAX";
            UpgradeText.text = "MAX";
        }
        else
        {
            LevelUpgradeText.text = (tower.Level + 1).ToString();
            DamageUpgradeText.text = nextUpgrade.FireDamage.ToString();
            RadiusUpgradeText.text = nextUpgrade.FireRange.ToString();
            UpgradeText.text = "Улучшить $" + nextUpgrade.UpgradeCost.ToString();
        }
    }

    public void UpgradeTower()
    {
        if (curTower == null || !curTower.IsCanUpdate)
            return;

        curTower.Upgrade();
        UpdateData(curTower);
    }

    public void Sell()
    {
        PlayerStats.Money += curTower.SellCost;
        Destroy(curTower.gameObject);
        Upgrader.SetActive(false);

    }
}
