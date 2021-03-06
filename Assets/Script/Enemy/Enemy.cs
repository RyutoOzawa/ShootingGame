using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemyの体力用変数
    private int enemyHp;

    public int giveScore;

    public GManager gManager;
    

    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を指定しておく
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //もしHPが0になったら
        if(enemyHp <= 0)
        {
            //自分で消える
            Destroy(this.gameObject);
            gManager.AddSocre(giveScore);
        }
    }

    public void Damage()
    {
        //enemyの体力を1減らす
        enemyHp = enemyHp - 1;
        
    }
}
