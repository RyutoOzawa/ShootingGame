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
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        //���V�t�g�L�[��������Ă���Ȃ�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //�X�s�[�h���_�b�V�����̃X�s�[�h��
            speed = slowSpeed;
        }
        else//������Ă��Ȃ��Ȃ�
        {
            //�X�s�[�h��ʏ��
            speed = normalSpeed;
        }

        //�E���L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //�E����0.01����
            pos.x += speed;
        }

        //�����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //������0.01����
            pos.x -= speed;
        }

        //����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //�����0.01����
            pos.z += speed;
        }

        //�����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //������0.01����
            pos.z -= speed;
        }
        transform.position = new Vector3(pos.x, pos.y, pos.z);

    }
}
