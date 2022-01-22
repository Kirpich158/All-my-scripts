using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public float range = 1f;
    public float rotSpeed = 5f;
    public float fireRate = 1f;
    public GameObject fireballPrefab;
    public Transform fireballSpawn;

    private Transform targetMain;
    private float fireCountdown = 0f;

    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.2f);
    }

    void SearchTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject target in targets)
        {
            float distanceBetween = Vector3.Distance(transform.position, target.transform.position);
            if (distanceBetween < minDistance)
            {
                minDistance = distanceBetween;
                closestEnemy = target;
            }
        }

        if (closestEnemy != null && minDistance <= range)
        {
            targetMain = closestEnemy.transform;
            //transform.LookAt(targetMain);
        }
        else
        {
            targetMain = null;
        }
    }

    void Update()
    {
        if (targetMain == null)
            return;
        
        //Rotation to the closest enemy 
        Vector3 dir = targetMain.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(gameObject.transform.rotation, lookRot, Time.deltaTime * rotSpeed).eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(0f, rot.y, 0f);

        if(fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1 / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Fire()
    {
        GameObject fireballObject = (GameObject)Instantiate(fireballPrefab, fireballSpawn.position, fireballSpawn.rotation);
        FireballScript fireball = fireballObject.GetComponent<FireballScript>();

        if(fireball != null)
        {
            fireball.Chase(targetMain);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
