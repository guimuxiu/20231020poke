using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster01Player01 : MonoBehaviour
{

    //��Ԕԍ�
    private int stateNumber = 0;

    //�ėp�^�C�}�[
    private float timeCounter = 0.0f;

    public int MonNommber = 9999;  //�����X�^�[�̐}�Ӄi���o�[
    public int Monform = 005;       //�����X�^�[�̃t�H�����i���o�[
    public int gender = 2;         //�����X�^�[�̐��ʁ@1=���@2=���@0=�Ȃ�
    public int[] type = { 1, 2, 0 };      //�^�C�v1�@�m�[�}��   �^�C�v2�@��  �^�C�v3�@�Ȃ�
    public int teratype = 3;�@ //�e���X�^�C�v�@��
    public float[] nature = { 0, 1.1f, 0.9f, 1.0f, 1.0f, 1.0f }; //���i�@���݂�����
    public int ability = 0001; //����0001�@�������イ
    public int item = 001;     //�A�C�e��001�@��������̂���
    public int Level = 50;
    public int[] MonBaV = { 100, 60, 50, 40, 30, 30 }; //�푰�l100-60-50-40-30-20
    public int[] MonInV = { 31, 31, 31, 31, 31, 31 };    //�̒l31-31-31-31-31-31
    public int[] MonEfV = { 252, 252, 0, 0, 0, 4 };      //�w�͒l252-252-0-0-0-4
    public float[] MonRealV = { 0, 0, 0, 0, 0, 0};        //�����l0-0-0-0-0-0
    public int[] WeaponSet = { 0,9001, 9002, 9003, 9004 };  //�Z�\��


    public float HPMax ;  //HP�ő�l
    public float HPNow;   //HP���ݒl
    public float AtRl ;�@�@//�����U�������l
    public float BtRl ; �@ //�����h������l
    public float CtRl ; �@ //����U�������l
    public float DtRl ;    //����h������l
    public float StRl ;    //�f���������l

    public int AtRa;�@�@//�����U�������N
    public int BtRa; �@ //�����h�䃉���N
    public int CtRa; �@ //����U�������N
    public int DtRa;    //����h�䃉���N
    public int StRa;    //�f���������N






    //public int HP = 100;
    //public int HPNow = 0;
    //public int At = 10;




    // Start is called before the first frame update
    void Start()
    {

        
        //Debug.Log("�v���C���[01�푰�l" + this.MonBaV[0]+","+ this.MonBaV[1] + "," + this.MonBaV[2] + "," + this.MonBaV[3] + "," + this.MonBaV[4] + "," + this.MonBaV[5]);
        //Debug.Log("�v���C���[01�̒l" + this.MonInV[0]+ "," + this.MonInV[1] + "," + this.MonInV[2] + "," + this.MonInV[3] + "," + this.MonInV[4] + "," + this.MonInV[5]);
        //Debug.Log("�v���C���[01�w�͒l" + this.MonEfV[0] + "," + this.MonEfV[1] + "," + this.MonEfV[2] + "," + this.MonEfV[3] + "," + this.MonEfV[4] + "," + this.MonEfV[5]);




        //HP�����l:(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+���x��+10) �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        HPMax = Mathf.Floor((((MonBaV[0] * 2 + MonInV[0]
                + Mathf.Floor(MonEfV[0] / 4))
                ) * Level) /100)+ Level +10;

        //Debug.Log("01�������X�^�[��H�����l" + this.HPMax);

        HPNow = HPMax;

        //A�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
         AtRl= Mathf.Floor((Mathf.Floor((((MonBaV[1] * 2 + MonInV[1]
                + Mathf.Floor(MonEfV[1] / 4))
                ) * Level) / 100) + 5)* nature[1]);

        //Debug.Log("01�������X�^�[��A�����l" + this.AtRl);

        //B�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        BtRl = Mathf.Floor((Mathf.Floor((((MonBaV[2] * 2 + MonInV[2]
               + Mathf.Floor(MonEfV[2] / 4))
               ) * Level) / 100) + 5) * nature[2]);

        //Debug.Log("01�������X�^�[��B�����l" + this.BtRl);

        //C�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        CtRl = Mathf.Floor((Mathf.Floor((((MonBaV[3] * 2 + MonInV[3]
               + Mathf.Floor(MonEfV[3] / 4))
               ) * Level) / 100) + 5) * nature[3]);

        //Debug.Log("01�������X�^�[��C�����l" + this.CtRl);

        //D�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        DtRl = Mathf.Floor((Mathf.Floor((((MonBaV[4] * 2 + MonInV[4]
               + Mathf.Floor(MonEfV[4] / 4))
               ) * Level) / 100) + 5) * nature[4]);

        //Debug.Log("01�������X�^�[��D�����l" + this.DtRl);


        //S�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        StRl = Mathf.Floor((Mathf.Floor((((MonBaV[5] * 2 + MonInV[5]
               + Mathf.Floor(MonEfV[5] / 4))
               ) * Level) / 100) + 5) * nature[5]);

       // Debug.Log("01�������X�^�[��S�����l" + this.StRl);

    }







    // Update is called once per frame
    void Update()
    {
        //�^�C�}�[
        timeCounter += Time.deltaTime;


        // �Q�[���J�n���Ƀ����X�^�[����ʍ����璆���Ɋ���Ă���

        if (stateNumber == 0)
        {
            this.transform.position += new Vector3(1f*Time.deltaTime, 0f,0f);

            //x���W��-4.5f���߂����stateNumber = 1�Ɉړ�����
            if (this.transform.position.x >= -4.5f) 
            {
                
                stateNumber = 1;
            }
        
        }


    }


   

    //�U�������邽�߂̊֐�
    public void requestAttack (int number)
    {
        GetComponent<Animator>().SetTrigger("Attack0" + number);
    }


    public void requestDamage ()
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }

    public void statusDisplay()
    {
�@�@�@//Player1���̃X�e�[�^�X���X�V


    }


}


