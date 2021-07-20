using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float minY, maxY;
    public float attackTimer = 0.35f;

    private float currentAttackTimer;
    private bool canAttack;
    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentAttackTimer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }
    
    void MovePlayer()
    {
        //return 1 if W or arrow up is pressed
        if(Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            //check for higher edge
            if (temp.y > maxY)      
                temp.y = maxY;            
            transform.position = temp;
        }
        //return -1 if S or arrow down is pressed
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            //check for lower edge
            if (temp.y < minY)
                temp.y = minY;
            transform.position = temp;
        }
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if(attackTimer > currentAttackTimer) //possibility for shooting
            canAttack = true;
        if (Input.GetKeyDown(KeyCode.Space)) //shoot by pressing Spacebar
        {
            if (canAttack)
            {
                canAttack = false;
                attackTimer = 0f;

                Instantiate(playerBullet, attackPoint.position, Quaternion.identity);

                //play the sound FX
            }
                
        }

    }
}
