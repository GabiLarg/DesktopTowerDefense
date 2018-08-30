using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Transform target;
    private float speed = 50f;
    public int damage = 1;
    public GameObject impactEffect;
    public void Seek(Transform target)
    {
        this.target = target;
    }
	
	// Update is called once per frame
	void Update () {
	    if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        var distanceThisFrame = speed * Time.deltaTime;

        //avoid Overshoot
        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
	}

    private void HitTarget()
    {
        var effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
        
        Damage(target);
        
    }

    void Damage(Transform enemy)
    {
        var enemyReference =  enemy.GetComponent<Enemy>();
        if (enemyReference != null)
        {
            enemyReference.TakeDamage(damage);
        }
    }
}
