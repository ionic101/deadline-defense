using UnityEngine;
using System.Collections.Generic;


public class Tower : MonoBehaviour
{
    private Enemy targetEnemy;
    private float fireCountdown = 0f;
	private int curLevel = 0;

    public List<TowerUpgrade> Upgrades;
    public string EnemyTag = "Enemy";

	public string Name = "Tower";
	public Sprite Sprite;
    public float ShootRange = 15f;
    public float ShootDamage = 1f;
    public float ShootRate = 1f;
	public int BuyCost = 100;
    public int SellCost = 0;
	public int Level { get {  return curLevel + 1; } }
	public TowerUpgrade NextUpgrade {
		get
		{
			Debug.Log(Upgrades.Count);
            if (curLevel < Upgrades.Count)
				return Upgrades[curLevel];
			return null;
		}
	}
	public bool IsCanUpdate
	{
		get
		{
			return curLevel < Upgrades.Count &&
				PlayerStats.Money >= Upgrades[curLevel].UpgradeCost;
		}
	}

    void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= ShootRange)
		{
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		}
		else
		{
			targetEnemy = null;
		}

	}

	void Update ()
	{
		if (targetEnemy == null)
			return;

		UpdateRotation();

		if (fireCountdown <= 0f)
		{
			Shoot();
			fireCountdown = 1f / ShootRate;
		}

		fireCountdown -= Time.deltaTime;
	}

    void UpdateRotation ()
	{
        Vector3 dir = targetEnemy.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        GetComponent<Transform>().rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
    }

    void Shoot ()
	{
        if (targetEnemy)
            targetEnemy.TakeDamage(ShootDamage);


		switch (Name) 
		{
			case "Полицейский":
                FindObjectOfType<AudioManager>().Play("pistolet");
				break;
			case "Солдат":
                FindObjectOfType<AudioManager>().Play("avtomat");
				break;

            case "Tower":
                FindObjectOfType<AudioManager>().Play("granata");
                break;

        }
		if (Name.Equals("Полицейский")) 
		{
            
        }
		Debug.Log(Name);
		
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ShootRange);
    }

	public void Upgrade()
	{
		if (!IsCanUpdate)
			return;

        ShootRange = Upgrades[curLevel].FireRange;
        ShootDamage = Upgrades[curLevel].FireDamage;
        ShootRate = Upgrades[curLevel].FireRate;
        SellCost = Upgrades[curLevel].SellCost;
		PlayerStats.Money -= Upgrades[curLevel].UpgradeCost;
        curLevel++;
    }

	
}
