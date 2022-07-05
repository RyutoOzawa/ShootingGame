using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //�G�̐��𐔂���p�̕ϐ�
    private GameObject[] enemy;

    //�p�l����o�^����
    public GameObject panel;

    public GameObject spawnEnemy;

    //�G�̃��X�|�[���^�C��
    public float enemyRespawnTime = 5;

    //�G�̍ő吔
    public int maxEnemy = 0;

    //���݂̓G�̐�
    int nowEnemyCount = 0;

    //���݂̃^�C�}�[
    float nowTime = 0;

    void Start()
    {
        //�p�l�����B��
        panel.SetActive(false);

        //�^�C�}�[��������
        nowTime = enemyRespawnTime;

        //�G�̐���������
        nowEnemyCount = maxEnemy;
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

        //�^�C�}�[�����炷
        nowTime -= Time.deltaTime;

        //�^�C�}�[���O�ɂȂ�����G���X�|�[��
        if(nowTime <= 0)
        {

            CreateFixedEnemy(180.0f);

            //�^�C�}�[��������
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
