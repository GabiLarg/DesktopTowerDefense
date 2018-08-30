using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool gameEnded;
	// Update is called once per frame
    void Start()
    {
        SceneManager.UnloadScene("GameOver");
    }
	void Update () {
        if(gameEnded)
            return;

	    if(PlayerStats.lives <=0)
        {
            EndGame();
        }

	}

    void EndGame()
    {
        Debug.Log("Game Over!");
        gameEnded = true;
        SceneManager.LoadScene("GameOver");
    }
}
