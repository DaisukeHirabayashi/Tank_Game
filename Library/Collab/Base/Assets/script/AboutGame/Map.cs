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
        gameObject.tansform.psition = new Vectoe3(track.transform.position.x,0, track.transform.position.z);
        gameObject.tansform.rotation = Quaternion.Euler(0, track.transform.rotation.y, 0);
    }
}
