using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;

	[Header("Attributes")]
	public float range = 15f;
	public float fireRate =  1.0f;
	private float fireCountdown = 0f;
	[Header("Unity Setup")]
	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public GameObject bulletPrefab;
	public Transform firePoint;

	// Use this for initialization
	void Start () {
	
		InvokeRepeating("UpdateTarget", 0f, 0.5f);

	}

	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistnace = Mathf.Infinity;
		GameObject nearestEnemey = null;
		foreach (GameObject enemy in enemies) {
			
			float distanceToEnemey = Vector3.Distance (transform.position, enemy.transform.position);

			if (distanceToEnemey < shortestDistnace) {
				shortestDistnace = distanceToEnemey;
				nearestEnemey = enemy;
			}
		}
		if (nearestEnemey != null && shortestDistnace <= range) {
			target = nearestEnemey.transform;
		} else {
			target = null;
		}
	}
	// Update is called once per frame
	void Update () {
		if (target == null)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if (fireCountdown <= 0f)
		{
			Shoot ();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;
	}

	void Shoot()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
