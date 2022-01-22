using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTheTurret : MonoBehaviour
{
    public float posY = 0.33f; // Y coordinate offset for turrets
    public GameObject turretPrefab; // public GameObject for enemyPrefab in Unity

    private CastleScript castle;

    private void Start()
    {
        castle = GameObject.Find("Castle").GetComponent<CastleScript>();
    }

    private void OnMouseDown() // Function to spawn a turret of clicked Turret platform
    {
        Vector3 temp = transform.position;
        temp.y = posY;
        
        if(castle.castleHP > 0)
            Instantiate(turretPrefab, temp, Quaternion.Euler(0f, 90f, 0f)); // Instantiate prefab of Turret with started parametres
    }
}
