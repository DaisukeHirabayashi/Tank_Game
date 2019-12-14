using UnityEngine;



public class TankData : MonoBehaviour {//戦車の各種情報をまとめて管理するクラス

        public Vector3 Positon;             //位置
        public Quaternion Rotate;           //向いてる方向
        public int MaxHP = 100;             //最大体力
        public int HP = 100;                //体力
        public int fireRate = 120;          //射撃間隔
        public float speed = 0.03f;         //戦車速度
        public float rotateSpeed = 0.3f;   //旋回速度
        public int attak = 10;


    public TankData(Vector3 p, Quaternion r, int HP)
        {
            this.Positon = p;
            this.Rotate = r;
            this.MaxHP = HP;
            this.HP = HP;
        }

        public TankData(Vector3 p, Quaternion r)
        {
            this.Positon = p;
            this.Rotate = r;
            
        }


        public TankData()
        {
            this.Positon = new Vector3();
            this.Rotate = new Quaternion();
        }


        //引数の受け渡し
        public void PutTankData(Vector3 p, Quaternion r)
        {
            this.Positon = p;
            this.Rotate = r;
        }

        public void PutTankPosition(Vector3 p)
        {
            this.Positon = p;
        }

        public void PutTankRotate(Quaternion r)
        {
            this.Rotate = r;
        }

    }

