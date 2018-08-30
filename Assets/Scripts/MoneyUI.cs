using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour {

	// Use this for initialization
    public Text moneyText;
	
	// Update is called once per frame
	void Update () {
	    moneyText.text   = "Gold: "+PlayerStats.money.ToString();
	}
}
