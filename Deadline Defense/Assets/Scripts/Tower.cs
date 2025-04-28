using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    private Transform target;
    private Enemy targetEnemy;
    private float fireCountdown = 0f;


    public float Range = 15f;
    public float Damage = 1f;
    public float FireRate = 1f;
    public Transform MeshTransform;
    public string enemyTag = "Enemy";

    void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
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

		if (nearestEnemy != null && shortestDistance <= Range)
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
			fireCountdown = 1f / FireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	void UpdateRotation ()
	{
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        MeshTransform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
    }

	void Shoot ()
	{
        if (targetEnemy)
            targetEnemy.TakeDamage(Damage);
	}
}
