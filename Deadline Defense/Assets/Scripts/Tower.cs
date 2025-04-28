using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;


public class Tower : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;
    private float fireCountdown = 0f;
	private int level = 1;

    public List<TowerInfo> Upgrades;
	public TowerInfo TowerInfo;
    public string EnemyTag = "Enemy";


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

		if (nearestEnemy != null && shortestDistance <= TowerInfo.FireRange)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		} else
		{
			target = null;
		}

	}

	void Update () {
		if (target == null)
		{
			return;
		}

		UpdateRotation();

		if (fireCountdown <= 0f)
		{
			Shoot();
			fireCountdown = 1f / TowerInfo.FireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	public int GetSellAmount()
	{
		return 100;
	}


    void UpdateRotation ()
	{
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        GetComponent<Transform>().rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
    }

	void Shoot ()
	{
        if (targetEnemy)
            targetEnemy.TakeDamage(TowerInfo.FireDamage);
	}

	void Upgrade()
	{
		level++;
		TowerInfo = Upgrades[level - 2];
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerInfo.FireRange);
    }
}
