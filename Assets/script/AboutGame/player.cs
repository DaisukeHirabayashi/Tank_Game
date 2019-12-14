using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{


    public static int sendr = 0;                            //右側のクローラー回転速度(0-255 中央値　127を0とする。)
    public static int sendl = 0;                            //右側のクローラー回転速度(0-255 中央値　127を0とする。)
    public static int sendq = 0;                            //砲の回転角 0-255 （0-365度）　
    public static float MoveSpeedx = 0f;                       //自機のx軸移動量
    public static float MoveSpeedz = 0f;                       //自機のz軸移動量
    public static float rotateSpeed = 0f;                      //自機の回転量
    public static float r = 0f;                                //自機の向いている方向
    public static TankData tankData = new TankData();   //自機の各種情報  

    public int MaxHP = 100;             //最大体力
    public int fireRate = 120;          //射撃間隔
    public float TankSpeed = 0.03f;         //戦車速度
    public float MaxRotateSpeed = 0.3f;   //旋回速度
    public int attak = 10;


    public GameObject Ban;

    public static int t = 0;
    // bullet prefab
    public GameObject bullet;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public int speed = 1000;


    void Start()
    {
        tankData.MaxHP = MaxHP;
        tankData.HP = MaxHP;
        tankData.fireRate = fireRate;
        tankData.speed = TankSpeed;
        tankData.rotateSpeed = MaxRotateSpeed;
        tankData.attak = attak;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("TankHorizontal") > 0.1f) {
            Debug.Log("asdf");
        }
        t++;

        Move();//移動量決定
        if (Input.GetButton("fire") && t > tankData.fireRate)
        {
            fire();
        }
        if (tankData.HP <= 0) {

            Instantiate(Ban, this.transform.position, Quaternion.identity);
            SceneManager.LoadScene("GameOver");
            tankData.HP = tankData.MaxHP;
        }
    }

    public void Move()//十字キーの入力を元に自機の移動量と回転量を決定
                      //現在は絶対位置で移動量を管理しているが、今後変更する予定あり
    {
        r = GameObject.Find("Tank").transform.eulerAngles.y;
        MoveSpeedx = 0f;
        MoveSpeedz = 0f;
        rotateSpeed = 0f;
        sendr = 127;
        sendl = 127;
        sendq = (int)((170 + (Turret.r - r)) % 340) * 255 / 340;
        if (sendq < 1)
        {
            sendq = 1;
        } else if (sendq > 254) {
            sendq = 254;
        }


        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetAxis("TankVertical") < -0.0f) &&
            !FrontHit.Hit
           ) //上キー
            {
                MoveSpeedx = tankData.speed * Mathf.Sin((Turret.r - 90) / 180 * Mathf.PI);
                MoveSpeedz = tankData.speed * Mathf.Cos((Turret.r - 90) / 180 * Mathf.PI);
                sendr = 1;
                sendl = 1;
            }
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetAxis("TankVertical") > 0.0f) &&
                 !BackHit.Hit
                ) //下キー
            {
                MoveSpeedx = -0.4f * tankData.speed * Mathf.Sin((Turret.r - 90) / 180 * Mathf.PI);
                MoveSpeedz = -0.4f * tankData.speed * Mathf.Cos((Turret.r - 90) / 180 * Mathf.PI);
                sendr = 254;
                sendl = 254;
            }


        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetAxis("TankHorizontal") < -0.0f) &&
            !LeftRHit.Hit
           ) //左キー
            {
                rotateSpeed = -1f * tankData.rotateSpeed;
                sendr = 254;
                sendl = 1;

            }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetAxis("TankHorizontal") > 0.0f) &&
            !RightRHit.Hit
                    )//右キー
            {
                rotateSpeed = tankData.rotateSpeed;
                sendr = 1;
                sendl = 254;

            }
        
        if (
            tankData.Positon.x + MoveSpeedx < -15 || 15 < tankData.Positon.x + MoveSpeedx ||
            tankData.Positon.z + MoveSpeedz < -15 || 15 < tankData.Positon.z + MoveSpeedz
            )
        {
            MoveSpeedx = 0f;
            MoveSpeedz = 0f;
            rotateSpeed = 0f;
            sendr = 127;
            sendl = 127;
            //sendq = (int)((360 + (Turret.r - r)) % 360) * 256 / 360;
            if (sendq < 0) {
                sendq = 256 - sendq;
            }
        }


    }

    public void fire()
    {
        t = 0;
        AudioSource sound01 = GetComponent<AudioSource>();
        sound01.PlayOneShot(sound01.clip);

        // 弾丸の複製
        GameObject bullets = Instantiate(bullet) as GameObject;

        Vector3 force;

        bullets.transform.rotation = GameObject.Find("turret").transform.rotation;
        force = GameObject.Find("turret").transform.forward * speed;

        // Rigidbodyに力を加えて発射
        bullets.GetComponent<Rigidbody>().AddForce(force);

        // 弾丸の位置を調整
        bullets.transform.position = muzzle.position;

        Destroy(bullets, 2.0f);
    }


}
