using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject Track;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float y = Track.transform.rotation.y/180 * Mathf.PI;
        gameObject.transform.position = new Vector3(Track.transform.position.x,0, Track.transform.position.z);
        gameObject.transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
