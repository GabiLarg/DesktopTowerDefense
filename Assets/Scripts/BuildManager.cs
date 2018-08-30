using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private TurretBlueprint turretToBuild;

    public GameObject turretLaserPrefab;

    public GameObject turretCanonPrefab;
	// Use this for initialization
	void Awake () 
    {
        if (instance != null)
            return;
        instance = this;
	}
	
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money< turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost; 
        var turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position, node.transform.rotation);
        node.turret = turret;
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }
	public void SelectTurretToBuild (TurretBlueprint turret) 
    {
        turretToBuild = turret;
	}
}
