using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Sound
    public GameObject Sound;


    // 弾丸発射点
    //public Transform muzzle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 1) {
        //   Destroy(gameObject);
        //}
        // Destroy(GameObject.Find("bullet"), 3.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
       //Debug.Log(collision.gameObject.name);
        SendRecv.fire = true;
        if (collision.gameObject.name == "EtanksBody") {
           //Destroy(gameObject);
            //enemy.tankdata.HP -= player.tankData.attak;

            //Debug.Log("aaa");

        } else if(collision.gameObject.name == "LeftR" ||
                  collision.gameObject.name == "rightR" ||
                  collision.gameObject.name == "Back" ||
                  collision.gameObject.name == "Front" ||
                  collision.gameObject.name == "tanksBody" ||
                  collision.gameObject.name == "turret"
                 ) {
            //Debug.Log("asd");
            player.tankData.HP -= enemy.tankdata.attak;
        }

        Destroy(gameObject);

       
        GameObject Sounds = Instantiate(Sound) as GameObject;
        Sounds.transform.rotation = gameObject.transform.rotation;
        Sounds.transform.position = gameObject.transform.position;

    }



}

