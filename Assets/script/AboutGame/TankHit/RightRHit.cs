﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRHit : MonoBehaviour {

    public static bool Hit = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name != "Tree")
        {
            Hit = true;
            Debug.Log("FRHIT!!");
        }
    }

    void OnCollisionExit(Collision other)
    {
        Hit = false;
    }
}