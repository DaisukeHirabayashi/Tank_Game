using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class enemy : MonoBehaviour {

    public static TankData tankData = new TankData();

    public static float MoveSpeedx = 0f;                       //自機のx軸移動量
    public static float MoveSpeedz = 0f;                       //自機のz軸移動量
    public static float rotateSpeed = 0f;                      //自機の回転量
    public static float r = 0f;                                //自機の向いている方向
    public static TankData tankdata = new TankData();   //自機の各種情報
    float ER;                         // Use this for initialization
    public System.Random R;

    public GameObject Ban;
    public GameObject Sound;

    public static int t = 0;
    // bullet prefab
    public GameObject bullet;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public int speed = 200;
    public AudioSource[] audioSources;
    public AudioSource sound01;
    public AudioSource sound02;
    float sk;
    int HP = 40;

    void Start () {
        tankdata.attak = 10;
        tankdata.HP = 40;
        tankdata.fireRate = 1200;
        audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
}

	// Update is called once per frame
	void Update () {
        t++;

        float step = speed * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90f, 0), step);


        if (t > tankdata.fireRate)
        {
            fire();
        }

        ER = (float)(Math.Atan((gameObject.transform.position.x - GameObject.Find("Tank").transform.position.x) / (gameObject.transform.position.z - GameObject.Find("Tank").transform.position.z)) / (2 * Math.PI) * 360);

        if (gameObject.transform.position.z - GameObject.Find("Tank").transform.position.z < 0)
        {
            ER += 180;
        }

        //if (gameObject.transform.rotation.y != ER - 90) {
        //    Debug.Log( ER -90);
            //gameObject.transform.rotation = Quaternion.Euler(0, (gameObject.transform.rotation.y + 1)%360, 0);
        //}



        gameObject.transform.GetChild(0).transform.GetChild(0).transform.rotation = Quaternion.Euler(-90, -90, ER);
        if (HP <= 0)
        {
            Instantiate(Ban, this.transform.position, Quaternion.identity);
            sound01.PlayOneShot(sound02.clip);
            Destroy(gameObject);
            tankdata.HP = 40;

        }
        else {

        }

    }

    public void fire()
    {
        t = 0;
        sound01.PlayOneShot(sound01.clip);

        // 弾丸の複製
        GameObject bullets = Instantiate(bullet) as GameObject;

        Vector3 force = new Vector3();

        bullets.transform.rotation = Quaternion.Euler(0, ER, 0);
        //force = GameObject.Find("EMuzzle").transform.forward * speed;
        sk = (float)Math.Sqrt(Math.Pow(gameObject.transform.position.x - GameObject.Find("Tank").transform.position.x,2) + Math.Pow(gameObject.transform.position.z - GameObject.Find("Tank").transform.position.z,2));
        force.Set(-(gameObject.transform.position.x - GameObject.Find("Tank").transform.position.x ) / sk * speed + UnityEngine.Random.Range(-150f, 150f), 0, -(gameObject.transform.position.z - GameObject.Find("Tank").transform.position.z) /sk * speed + UnityEngine.Random.Range(-150f, 150f));

        // Rigidbodyに力を加えて発射
        bullets.GetComponent<Rigidbody>().AddForce(force);

        // 弾丸の位置を調整
        bullets.transform.position = muzzle.position;

        Destroy(bullets, 4.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("asdfgh");
        Debug.Log(collision.gameObject.name);
        SendRecv.fire = true;
        if (collision.gameObject.name == "bullet(Clone)")
        {
            //Destroy(gameObject);
            HP -= player.tankData.attak;

            Debug.Log(gameObject.name + "="+ HP);

        }
        GameObject Sounds = Instantiate(Sound) as GameObject;
        Sounds.transform.rotation = gameObject.transform.rotation;
        Sounds.transform.position = gameObject.transform.position;

    }
}
