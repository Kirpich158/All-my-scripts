using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject rocketPrefab; //tworzymy GameObject aby wstawić nasz prefab rakiety

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl)) //sprawdzamy, czy potrzebny klawisz został naciśnięty, aby wystrzelić pocisk
        {
            GameObject rocketObject = Instantiate(rocketPrefab); //tworzymy rakietę
            //ustawiamy startowe wartości rotation, żeby pokazać jak rakieta robi hak i obraca się do potrzebnego celu
            rocketObject.transform.eulerAngles = new Vector3(
                rocketObject.transform.eulerAngles.x,
                rocketObject.transform.eulerAngles.y - 45,
                rocketObject.transform.eulerAngles.z
            ); 
            //ustawiamy startowe wartości pozycji, żeby rakieta została zrobiona przed naszą bazooką
            rocketObject.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z + 1.5f); 
        }

        //Esc żeby zamknąć program
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}