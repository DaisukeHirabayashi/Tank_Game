using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UserInterface : MonoBehaviour {


    Slider _slider;


	// Use this for initialization
	void Start () {
        _slider = GameObject.Find("UI").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        

        _slider.value = (float) player.tankData.HP/player.tankData.MaxHP;

	}
}
