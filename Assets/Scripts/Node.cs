using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    public Color hoverColor; 

    private Renderer rend;
    private Color startColor;
    public GameObject turret;
    public BuildManager buildManager;

	void Start () 
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
	}
    
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = Color.red;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild || turret != null)
            return;

        buildManager.BuildTurretOn(this);
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
	// Use this for initialization


}
