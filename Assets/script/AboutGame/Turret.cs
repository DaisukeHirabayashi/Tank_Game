using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public static float r = 90;
    public float MaxTurretSpeed = 1; //砲塔の最大速度
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        turretRotate();
    }

    public void turretRotate() {

        float mouse_x_delta = Input.GetAxis("Mouse X") + Input.GetAxis("TurretHorizontal")/10f;
        r -= -MaxTurretSpeed > mouse_x_delta * 10? -MaxTurretSpeed : -MaxTurretSpeed <= mouse_x_delta * 10 && mouse_x_delta * 10 <= MaxTurretSpeed ? mouse_x_delta * 5 : MaxTurretSpeed;
        if (-170 < r - (GameObject.Find("Tank").transform.eulerAngles.y ) && r - (GameObject.Find("Tank").transform.eulerAngles.y) < 170) {
            Debug.Log(r - (GameObject.Find("Tank").transform.eulerAngles.y));
            Debug.Log((GameObject.Find("Tank").transform.eulerAngles.y));
            // GameObject.Find("tanksBody").transform.localRotation = Quaternion.AngleAxis(r, new Vector3(0, 1, 0));
            GameObject.Find("tanksBody").transform.rotation = Quaternion.Euler(-90,r,0);
        } else if (r - (GameObject.Find("Tank").transform.eulerAngles.y) >= 170) {
            r = 170 + GameObject.Find("Tank").transform.eulerAngles.y;
        } else {
            r = -170 + GameObject.Find("Tank").transform.eulerAngles.y;
        }


    }
}