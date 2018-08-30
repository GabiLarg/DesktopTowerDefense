using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    public TurretBlueprint turretLaser;
    public TurretBlueprint turretCanon;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    } 

    public void SelectTurretLaser()
    {
        buildManager.SelectTurretToBuild(turretLaser);
    }

    public void SelectTurretCanon()
    {
        buildManager.SelectTurretToBuild(turretCanon);

    }
}
