using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float destroyTimer = 3f;

    [HideInInspector]
    public bool isEnemyBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isEnemyBullet)
            speed *= -1f;
        
        Invoke("DestroyGameObject", destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet" || target.tag == "Enemy")
        {
            DestroyGameObject();
        }
    }
}
