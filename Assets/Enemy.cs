using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy�̗̑͗p�ϐ�
    private int enemyHp;

    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂��w�肵�Ă���
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //����HP��0�ɂȂ�����
        if(enemyHp <= 0)
        {
            //�����ŏ�����
            Destroy(this.gameObject);
        }
    }

    public void Damage()
    {
        //enemy�̗̑͂�1���炷
        enemyHp = enemyHp - 1;
        Destroy(bullet);
    }
}