// ﻿using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;
//
// public class GetMjpeg : MonoBehaviour
// {
//
//     public string url = "http://192.168.1.213:8080/javascript_simple.html";
//
//     IEnumerator Start()
//     {
//         WWW www = new WWW(url);
//         yield return www;
//         RawImage renderer = GetComponent<RawImage>();
//         renderer.texture = www.texture;
//     }
//
//     void Update()
//     {
//         Start();
//     }
// }
