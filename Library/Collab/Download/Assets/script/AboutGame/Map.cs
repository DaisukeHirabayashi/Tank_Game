using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {
    int t = 5;
    public GameObject track;
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update() {
        // float y = (float)(track.transform.rotation.y / Math.PI);
        while (t == 0)
        {
            gameObject.transform.position = new Vector3(track.transform.position.x, 0, track.transform.position.z);
            t = 200;
        }
        t--;
        //gameObject.transform.rotation = Quaternion.Euler(0,y,0);
    }
}
