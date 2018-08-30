using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {

 
	public void CallMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
