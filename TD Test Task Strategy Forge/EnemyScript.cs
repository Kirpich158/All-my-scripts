using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 2f;
    public int enemyHP = 3;

    public Vector3 com;
    public Rigidbody r;
    

    private Transform target;
    private int wavepointIndex = 0;
    private GameObject bublesHP;
    private CastleScript castle;
    private int lastEnemyInWave;
    private EnemySpawner spawn;
    private UIScript uiScript;

    void Start()
    {
        target = WayPtsScript.pts[wavepointIndex];
        bublesHP = GameObject.Find("Castle Health");
        GameObject castleGO = GameObject.Find("Castle");
        castle = castleGO.GetComponent<CastleScript>();

        r = GetComponent<Rigidbody>();
        r.centerOfMass = com;
        spawn = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        var fooGroup = Resources.FindObjectsOfTypeAll<UIScript>();
        if (fooGroup.Length > 0)
        {
            uiScript = fooGroup[0];
        }
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.01f)
        {
                wavepointIndex++;
                target = WayPtsScript.pts[wavepointIndex];
        }    
    }

    public void TakeDMG(int dmgPts)
    {
        enemyHP -= dmgPts;

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
            // boom script
            if (--spawn.enemyCount-1 == 0 && spawn.wave > spawn.numberOfWaves)
            {
                uiScript.Activation(); // Win screen will pop-up
                GameObject ui = GameObject.Find("Background (L)");
                ui.transform.GetChild(0).gameObject.SetActive(false);
                ui.transform.GetChild(1).gameObject.SetActive(true);

                spawn.GetComponent<EnemySpawner>().enabled = false; // Spawn of enemies will be disabled
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Speed of enemies will be 0
                foreach (GameObject e in enemies)
                {
                    e.GetComponent<EnemyScript>().speed = 0f;
                }
                GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret"); // Speed of enemies will be 0
                foreach (GameObject t in turrets)
                {
                    t.GetComponent<TurretShooting>().enabled = false;
                }
            }
            
        }
    }
}
