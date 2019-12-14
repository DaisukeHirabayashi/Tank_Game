using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class HostTarnsUdp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SendClientMessage();

    }

    public string Player1Address = "192.168.1.213";
    public string Player2Address = "192.168.1.213";
    public int port = 12343;//使用するポート



    public void SendClientMessage()//hostへの送信を想定したメソッド
    {

        // 宛先の作成　ここのIPアドレスとポート番号を書き換える
        var remote = new IPEndPoint(
            IPAddress.Parse(Player1Address),   //IPアドレス
                            port);                      //ポート番号

        // メッセージの準備
        var message = Encoding.UTF8.GetBytes(GameObject.Find("track1").transform.position.x + ","+ GameObject.Find("track1").transform.position.y + "," + GameObject.Find("track1").transform.position.z+"," + GameObject.Find("track1").transform.localRotation.y);


        // UDPでメッセージ送信
        var client = new UdpClient(port);     // ローカルポート番号を指定
        client.Connect(remote);                // 接続先を設定
        //client.Send(message, message.Length);  // 同期処理なので、送信し終わるまで処理が止まる。
        client.Close();


    }

}
