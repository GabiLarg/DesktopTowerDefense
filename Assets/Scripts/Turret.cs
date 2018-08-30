using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    private Transform target;
    public Transform turretTop;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public string enemyTag = "Enemy";
	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        foreach(var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //Find the closest target
        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else
            target = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(turretTop.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turretTop.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
	}

    private void Shoot()
    {
        var bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
