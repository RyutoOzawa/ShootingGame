using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public GameObject resetButton;
    public GameObject titleButton;

    //�G�̐��𐔂���p�̕ϐ�
    private GameObject[] enemy;

    //�p�l����o�^����
    public GameObject panel;

    public GameObject spawnEnemy;


    //�X�R�A�Ǘ�
    private int score = 0;
    public Text scoreText;

    //�G�̃��X�|�[���^�C��
    public float enemyRespawnTime = 5;


    //���݂̃^�C�}�[
    float nowTime = 0;

    void Start()
    {
        //fps�̌Œ�
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;

        //�p�l�����B��
        panel.SetActive(false);

        //�^�C�}�[��������
        nowTime = enemyRespawnTime;

      

        score = 0;
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
            resetButton.SetActive(true);
            titleButton.SetActive(true);
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
