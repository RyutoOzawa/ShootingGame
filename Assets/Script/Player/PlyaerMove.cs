using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerMove : MonoBehaviour
{
    public float normalSpeed = 0;

    public float slowSpeed = 0;

    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;

        //左シフトキーが押されているなら
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //スピードをダッシュ時のスピードに
            speed = slowSpeed;
        }
        else//押されていないなら
        {
            //スピードを通常に
            speed = normalSpeed;
        }

        //右矢印キーが押されたとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右方向0.01動く
            pos.x += speed;
        }

        //左矢印キーが押されたとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左方向0.01動く
            pos.x -= speed;
        }

        //上矢印キーが押されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //上方向0.01動く
            pos.z += speed;
        }

        //下矢印キーが押されたとき
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //下方向0.01動く
            pos.z -= speed;
        }
        transform.position = new Vector3(pos.x, pos.y, pos.z);

    }
}
