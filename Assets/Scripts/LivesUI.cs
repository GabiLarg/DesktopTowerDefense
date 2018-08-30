using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesUI : MonoBehaviour {

    public Text livesText;

	void Update () {
        livesText.text = "Lives: " + PlayerStats.lives;
	}
}
