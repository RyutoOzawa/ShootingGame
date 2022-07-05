using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public GameObject resetButton;
    public GameObject titleButton;

    //敵の数を数える用の変数
    private GameObject[] enemy;

    //パネルを登録する
    public GameObject panel;

    public GameObject spawnEnemy;


    //スコア管理
    private int score = 0;
    public Text scoreText;

    //敵のリスポーンタイム
    public float enemyRespawnTime = 5;


    //現在のタイマー
    float nowTime = 0;

    void Start()
    {
        //fpsの固定
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;

        //パネルを隠す
        panel.SetActive(false);

        //タイマーを初期化
        nowTime = enemyRespawnTime;

      

        score = 0;
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
            resetButton.SetActive(true);
            titleButton.SetActive(true);
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

    public void AddSocre(int addidx)
    {
        score = score + addidx;
        Debug.Log("score:" + score);
        scoreText.text = "score:" + score;
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
}
