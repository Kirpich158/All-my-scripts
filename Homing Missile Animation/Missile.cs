using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //zmienne potrzebne do celowania pociskiem
    public Transform RocketTarget;
    public Rigidbody RocketRigBody;

    public float turnSpeed;
    public float rocketFlySpeed;

    private Transform RocketLocalTrans;

    // Start is called before the first frame update
    void Start()
    {
        RocketLocalTrans = GetComponent<Transform>(); 
    }

    private void FixedUpdate()
    {
        RocketRigBody.velocity = RocketLocalTrans.forward * rocketFlySpeed; //nadajemy rakiecie prędkość za pomocą zmiennej rocketFlySpeed (którą możemy modyfikować)

        //obracamy rakietę na cel (ale każda następna rakieta będzie leciała do startowej pozycji naszego celu nawet jeśli już zrzuciliśmy kub pierwszą rakietą)
        //dzieje się tak z tego powodu że nie mogę dodać jako cel GameObject, tylko prefab kuba, a pozycja tego prefabu nie zmienia się po zestrzeleniu
        //i rakieta leci dalej do startowej pozycji naszego celu
        var rocketTargetRot = Quaternion.LookRotation(RocketTarget.position - RocketLocalTrans.position);
        RocketRigBody.MoveRotation(Quaternion.RotateTowards(RocketLocalTrans.rotation, rocketTargetRot, turnSpeed));       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //robimy impact zderzenia rakiety z celem dla urody lub widoczności
        if (collision.gameObject.CompareTag("Target"))
        {
            Rigidbody targetRigBody = collision.gameObject.GetComponent<Rigidbody>();
            if (targetRigBody)
            {
                targetRigBody.AddForceAtPosition(Vector3.up * 250f, targetRigBody.position); //dodajemy force żeby nasz docelowy kub odleciał od uderzenia
                GameObject.Destroy(gameObject); //i usuwamy pocisk, który się z nim zderzył
            }
                
        }
    }
}