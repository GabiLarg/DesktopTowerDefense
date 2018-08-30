using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public static int startMoney = 80;

    public static int lives;
    public static int startLives = 20;
	// Use this for initialization
	void Start () {
        money = startMoney;
        lives = startLives;
	}
	

}
