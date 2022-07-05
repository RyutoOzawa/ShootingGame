using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //敵の数を数える用の変数
    private GameObject[] enemy;

    //パネルを登録する
    public GameObject panel;

    public GameObject spawnEnemy;

    //敵のリスポーンタイム
    public float enemyRespawnTime = 5;

    //敵の最大数
    public int maxEnemy = 0;

    //現在の敵の数
    int nowEnemyCount = 0;

    //現在のタイマー
    float nowTime = 0;

    void Start()
    {
        //パネルを隠す
        panel.SetActive(false);

        //タイマーを初期化
        nowTime = enemyRespawnTime;

        //敵の数を初期化
        nowEnemyCount = maxEnemy;
    }

     void Update()
    {
        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //シーンに1匹もEnemyがいなくなったら
        if(enemy.Length == 0)
        {
            //パネルを表示させる
            panel.SetActive(true);
        }

        //タイマーを減らす
        nowTime -= Time.deltaTime;

        //タイマーが０になったら敵をスポーン
        if(nowTime <= 0)
        {

            CreateFixedEnemy(180.0f);

            //タイマーを初期化
            nowTime = enemyRespawnTime;
        }

    }

    private void CreateFixedEnemy(float axis)
    {
        float rand = Random.Range((float)-25,(float) 25);
        Quaternion rota = new Quaternion();
        rota = Quaternion.identity;
        rota.y = axis;
        Vector3 pos = new Vector3(rand, 0, 15.0f );

        GameObject enemyClone = Instantiate(spawnEnemy, pos, rota);
       
    }
}
