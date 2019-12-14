using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;


public class SendRecv : MonoBehaviour {






    public string Address = "192.168.1.213";//RaspberryPiのIPアドレス
    public string Host= "192.168.1.213";
    public int port = 12345;//使用するポート
    public int H_port = 12344;//使用するポート
    public int F_port = 12342;//使用するポート
    public static bool fire = false;


    // Use this for initialization
    void Start () {

    }

	// Update is called once per frame
	void Update () {



        //player.tankData = GetPosition(player.tankData);//位置取得
        SendToRaspiMessage();//データ送信
        //SendToHostMessage();
        if (fire) {
            //SendFireMessage();
        }
    
    }


     
    private TankData GetPosition(TankData data)//VIVEからのデータ受信を模したダミー
    {


        data.PutTankPosition(new Vector3(data.Positon.x + player.MoveSpeedx, data.Positon.y, data.Positon.z + player.MoveSpeedz));
        //data.PutTankPosition(new Vector3(GameObject.Find("track1").transform.position.x, GameObject.Find("track1").transform.position.y-0.36f, GameObject.Find("track1").transform.position.z));
        player.r += player.rotateSpeed;
        data.PutTankRotate(Quaternion.Euler(-90, player.r, 0));
        return data;
    }



public void SendToRaspiMessage()//RaspberryPiへの送信を想定したメソッド
{

    // 宛先の作成　ここのIPアドレスとポート番号を書き換える
    var remote = new IPEndPoint(
                        IPAddress.Parse(Address),   //IPアドレス
                        port);                      //ポート番号

    // メッセージの準備
    var message = Encoding.UTF8.GetBytes(player.sendr+","+player.sendl+"," +player.sendq);//送信するデータはここに書き込む　

    Debug.Log(player.sendr + "," + player.sendl + "," + player.sendq);

    // UDPでメッセージ送信
    var client = new UdpClient(port);     // ローカルポート番号を指定
    client.Connect(remote);                // 接続先を設定
    client.Send(message, message.Length);  // 同期処理なので、送信し終わるまで処理が止まる。
    client.Close();

}

/*
public void SendFireMessage()//hostへのfireの送信を想定したメソッド
{

    // 宛先の作成　ここのIPアドレスとポート番号を書き換える
    var remote = new IPEndPoint(
                        IPAddress.Parse(Host),   //IPアドレス
                        F_port);                      //ポート番号

    // メッセージの準備
    var message = Encoding.UTF8.GetBytes("p1f,f");//送信するデータはここに書き込む　

    //Debug.Log(player.sendr + "," + player.sendl + "," + player.sendq);

    // UDPでメッセージ送信
    var client = new UdpClient(F_port);     // ローカルポート番号を指定
    client.Connect(remote);                // 接続先を設定
    client.Send(message, message.Length);  // 同期処理なので、送信し終わるまで処理が止まる。
    client.Close();

    fire = false;

}

public void SendToHostMessage()//hostへの送信を想定したメソッド
{

    // 宛先の作成　ここのIPアドレスとポート番号を書き換える
    var remote = new IPEndPoint(
                        IPAddress.Parse(Host),   //IPアドレス
                        H_port);                      //ポート番号

    // メッセージの準備
    var message = Encoding.UTF8.GetBytes("p1r,"+ Turret.r);//送信するデータはここに書き込む　

    //Debug.Log(player.sendr + "," + player.sendl + "," + player.sendq);

    // UDPでメッセージ送信
    var client = new UdpClient(H_port);     // ローカルポート番号を指定
    client.Connect(remote);                // 接続先を設定
    client.Send(message, message.Length);  // 同期処理なので、送信し終わるまで処理が止まる。
    client.Close();

    fire = false;

}
*/
}
