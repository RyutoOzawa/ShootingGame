using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //�G�̐��𐔂���p�̕ϐ�
    private GameObject[] enemy;

    //�p�l����o�^����
    public GameObject panel;

    void Start()
    {
        //�p�l�����B��
        panel.SetActive(false);
    }

     void Update()
    {
        //�V�[���ɑ��݂��Ă���Enemy�^�O�������Ă���I�u�W�F�N�g
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //�V�[����1�C��Enemy�����Ȃ��Ȃ�����
        if(enemy.Length == 0)
        {
            //�p�l����\��������
            panel.SetActive(true);
        }

    }
}