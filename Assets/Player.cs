using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int playerHp = 5;

    public GameObject resetButton;
    public GameObject titleButton;
    public GameObject gameoverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hpが0になったら死亡、リセットボタンとタイトルに戻るボタンをアクティブに
        if (playerHp <= 0)
        {
            Destroy(this.gameObject);
            resetButton.SetActive(true);
            titleButton.SetActive(true);
            gameoverUI.SetActive(true);
        }
    }

    public void Damage()
    {
        playerHp = playerHp - 1;
    }
}
