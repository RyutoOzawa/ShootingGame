using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //弾の速度
    public float speed = 1;

    //自然消滅までのタイマー　
    public float time = 2;

    //進行方向
    protected Vector3 forward = new Vector3(0, 0, 1);

    //打ち出すときの角度
    protected Quaternion forwardAxis = Quaternion.identity;

    //Rigibody用変数
    protected Rigidbody rb;

    //Enemy用変数
    protected GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //Rigibody変数の初期化
        rb = this.GetComponent<Rigidbody>();

        //生成時に進行方向を決める
        if(enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //移動量を進行方向にスピード分だけ加える
        rb.velocity = forwardAxis * forward * speed;

        //空中に浮かないようにする
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        //時間制限が来たら自然消滅する
        time -= Time.deltaTime;

        if(time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //あたったオブジェクトがPLayer or PlayerBodyなら
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBody")
        {
            //自分を消滅させる
            Destroy(this.gameObject);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().Damage();
        }
    }
    
    //弾を打ち出したキャラクターの情報を渡す関数
    public void SetCharacterObject(GameObject character)
    {
        //弾を打ち出したキャラクターの情報を受け取る
        this.enemy = character;
    }

    //打ち出す角度を決定するための関数
    public void SetForwardAxis(Quaternion axis)
    {
        //設定された角度を受け取る
        this.forwardAxis = axis;
    }
}
