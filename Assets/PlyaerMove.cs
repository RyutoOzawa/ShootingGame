using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;

        //右矢印キーが押されたとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右方向0.01動く
            pos.x += 0.01f;
        }

        //左矢印キーが押されたとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左方向0.01動く
            pos.x -= 0.01f;
        }

        //上矢印キーが押されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //上方向0.01動く
            pos.z += 0.01f;
        }

        //下矢印キーが押されたとき
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //下方向0.01動く
            pos.z -= 0.01f;
        }
        transform.position = new Vector3(pos.x, pos.y, pos.z);

    }
}
