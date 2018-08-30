using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSapwner : MonoBehaviour {

    public Transform firstEnemyPrefab;
    public Transform secondEnemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public Text countDownText;
    private float coundDown = 2f;
    private int waveNumber = 1;
    private int rounds = 1;

	// Update is called once per frame
	void Update () 
    {
	    if(coundDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            coundDown = timeBetweenWaves;
        }
        coundDown -= Time.deltaTime;
	}
    IEnumerator SpawnWave()
    {
        
        if (rounds % 5 == 0)
        {
            for (int i = 0; i < waveNumber; i++)
            {

                SpawnEnemy(secondEnemyPrefab);

                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            for (int i = 0; i < waveNumber; i++)
            {

                SpawnEnemy(firstEnemyPrefab);

                yield return new WaitForSeconds(0.5f);
            }

        }
        rounds++;
        waveNumber++;
    }

    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
