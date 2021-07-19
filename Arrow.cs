using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float ArrowSpeed;
    public float BaseArrowDamage;
    public GameObject HitImpactPrefab;

    private bool wasDamage = false;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * ArrowSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject impact = (GameObject)Instantiate(HitImpactPrefab, transform.position, transform.rotation);
            Destroy(impact, 1f);
            
            if(!wasDamage)
            {
                collision.gameObject.GetComponent<EnemyHealth>().takeDamage(BaseArrowDamage);
                wasDamage = true;
            }
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Player")
        {
            //DoNothing
        }
        else
        {
            GameObject impact = (GameObject)Instantiate(HitImpactPrefab, transform.position, transform.rotation);
            Destroy(impact, 1f);
            Destroy(this.gameObject);

        }
    }
}
