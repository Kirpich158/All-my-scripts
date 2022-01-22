using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float speed = 4f;

    private Transform target;

    public void Chase(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        
        if (dir.magnitude <= distanceThisFrame)
        {
            Damaging(target);
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void Damaging(Transform enemy)
    {
        EnemyScript _enemy = enemy.GetComponent<EnemyScript>();
        if (_enemy != null)
            _enemy.TakeDMG(1);
    }
}