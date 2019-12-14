using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMain : MonoBehaviour
{
    public GameObject enemy;
    public static int maxt = 8000;
    int t = 1;

    // Use this for initialization
    void Start()
    {
        player.tankData.PutTankData(GameObject.Find("Tank").transform.position, GameObject.Find("Tank").transform.rotation);//tankDataに自機の初期値を入力
    }


    // Update is called once per frame
    void Update()
    {
        t--;
        if (t == 0) {
            Vector3 force = new Vector3();
            float R = (GameObject.Find("turret").transform.rotation.y + Random.Range(90f, 270f)) / 180 * Mathf.PI;
            force.Set(-GameObject.Find("turret").transform.position.x + (30 * Mathf.Sin(R)), 0.65f, -GameObject.Find("turret").transform.position.z + (30 * Mathf.Cos(R)));
            Instantiate(enemy, force, Quaternion.identity);
            t = maxt;
        }

        //GameObject.Find("Tank").transform.position = player.tankData.Positon;
        //GameObject.Find("Tank").transform.localRotation = player.tankData.Rotate;

        //Debug.Log("x = " + player.tankData.Positon.x + ", y = " + player.tankData.Positon.y + ", z = " + player.tankData.Positon.z);



    }


}
