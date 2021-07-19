using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    public float cubeSize;
    public int cubesInRow;
    public float explosionForce;
    public float explosionRadius;
    public float explosionUpward;
    

    float cubesPivotDistance;
    Vector3 cubesPivot;

    // Start is called before the first frame update
    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //do zmiany, w zależności jakie będziemy używać nazwe
        if(other.gameObject.tag == "ship") 
        {
            explode();
        }
    }

    public void explode()
    {
        gameObject.SetActive(false);
        
        for(int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;
        //do zmiany, myślę że będziemy używać "Sphere" dla planet i "Cube" dla stacji benzynowej, bo mamy używać proste obiekty
        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
}
