using UnityEngine;
public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private Transform target;
    private int wavePointIndex = 0;
    public int health = 5;
    public int reward = 1;
	// Use this for initialization
	void Start () {
        target = Waypoints.points[0];
	}
	
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
            PlayerStats.money += reward;
        }

    }
	// Update is called once per frame
	void Update () {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

	}

    private void GetNextWayPoint()
    {
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            PlayerStats.lives--;
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }
}
