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
        SendRecv.fire = true;
        Debug.Log("asd");
        if (collision.gameObject.name == "tanksBody") {
           //Destroy(gameObject);
            enemy.tankdata.HP -= player.tankData.attak;

        } else {
            
        }

        Destroy(gameObject);

        //弾丸の複製
        GameObject Sounds = Instantiate(Sound) as GameObject;
        Sounds.transform.rotation = gameObject.transform.rotation;

       
    }



}

