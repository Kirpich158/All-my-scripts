using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 50f;
    public bool canShoot;
    public bool canRotate;
    public float boundX = -11f;
    public Transform attackPoint;
    public GameObject bulletPrefab;

    private bool canMove = true;
    private Animator anim;
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0) //return 0 or 1, cause max value (2) is exclusive
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f)); //mby Random.Range(1f, 4f) or Random.Range(1f, 3.5f) :thinking:
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if(temp.x < boundX)           
                Destroy(gameObject);            
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);        
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().isEnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f)); //mby Random.Range(1f, 4f) or Random.Range(1f, 3.5f) :thinking:
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet")
        {
            canMove = false;
            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }

            Invoke("DestroyGameObject", 3f);

            //play explosion sound
            anim.Play("Destroy");
        }
    }
}
