using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


public class HostGetUdp : MonoBehaviour

{
    public int LOCA_LPORT = 12344;
    static UdpClient udp;
    Thread thread;

    private static string[] arr;

    void Start()
    {
        udp = new UdpClient(LOCA_LPORT);
        //udp.Client.ReceiveTimeout = 1000;
        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();
    }

    void Update()
    {
    }

    void OnApplicationQuit()
    {
        thread.Abort();
    }

    private static void ThreadMethod()
    {
        while (true)
        {

            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            string text = Encoding.ASCII.GetString(data);
            Debug.Log(text);
            GetData(text);

        }
    }

    private static void GetData(string A){
        arr = A.Split(',');
        //player.tankData.Positon.x = float.Parse(arr[0]);
        //player.tankData.Positon.y = float.Parse(arr[1]);
        //player.tankData.Positon.z = float.Parse(arr[2]);
        //player.tankData.PutTankRotate(Quaternion.AngleAxis(float.Parse(arr[3]), new Vector3(0, 1, 0)));
    }
}