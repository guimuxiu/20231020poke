using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster01Player02 : MonoBehaviour
{

    //��Ԕԍ�
    public int stateNumber = -1;

    //�ėp�^�C�}�[
    private float timeCounter = 0.0f;


    //�����X�^�[���O
    public string Name = "����`";

    public int MonNommber = 9999;  //�����X�^�[�̐}�Ӄi���o�[
    public int Monform = 006;       //�����X�^�[�̃t�H�����i���o�[
    public int gender = 1;         //�����X�^�[�̐��ʁ@1=���@2=���@0=�Ȃ�
    public int[] type = { 4, 5, 0 };      //�^�C�v4�@�d�C   �^�C�v5�@��  �^�C�v3�@�Ȃ�
    public int teratype = 6;�@ //�e���X�^�C�v�@�X
    public float[] nature = { 0, 0.9f, 1.1f, 1.0f, 1.0f, 1.0f }; //���i�@
    public int ability = 0002; //����0002�@���߂ӂ炵
    public int item = 002;     //�A�C�e��002�@�A�C�X������
    public int Level = 50;
    public int[] MonBaV = { 100, 20, 60, 50, 40, 30 }; //�푰�l100-20-60-50-40-30
    public int[] MonInV = { 31, 31, 31, 31, 31, 31 };    //�̒l31-31-31-31-31-31-31
    public int[] MonEfV = { 252, 0, 252, 0, 0, 4 };      //�w�͒l252-252-0-0-0-4
    public float[] MonRealV = { 0, 0, 0, 0, 0, 0 };        //�����l0-0-0-0-0-0
    public int[] WeaponSet = {0, 9001, 9002, 9003, 9004 };  //�Z�\��



    public float HPMax;  //HP�ő�l
    public float HPNow;   //HP���ݒl
    public float AtRl;�@�@//�����U�������l
    public float BtRl; �@ //�����h������l
    public float CtRl; �@ //����U�������l
    public float DtRl;    //����h������l
    public float StRl;    //�f���������l

    public int AtRa = 0;�@�@//�����U�������N
    public int BtRa = 0; �@ //�����h�䃉���N
    public int CtRa = 0; �@ //����U�������N
    public int DtRa = 0;    //����h�䃉���N
    public int StRa = 0;    //�f���������N

    //���ʉ�
    public AudioClip SEattack01;
    public AudioClip SEattack02;
    public AudioClip SEattack03;
    public AudioClip SEattack04;
    public AudioClip SEDEath;


    //public int lv = 1;
    //public int HP = 100;
    //public int At = 10;






    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log("�v���C���[02�푰�l" + this.MonBaV[0] + "," + this.MonBaV[1] + "," + this.MonBaV[2] + "," + this.MonBaV[3] + "," + this.MonBaV[4] + "," + this.MonBaV[5]);
        //Debug.Log("�v���C���[02�̒l" + this.MonInV[0] + "," + this.MonInV[1] + "," + this.MonInV[2] + "," + this.MonInV[3] + "," + this.MonInV[4] + "," + this.MonInV[5]);
        //Debug.Log("�v���C���[02�w�͒l" + this.MonEfV[0] + "," + this.MonEfV[1] + "," + this.MonEfV[2] + "," + this.MonEfV[3] + "," + this.MonEfV[4] + "," + this.MonEfV[5]);




        //HP�����l:(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+���x��+10) �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        HPMax = Mathf.Floor((((MonBaV[0] * 2 + MonInV[0]
                + Mathf.Floor(MonEfV[0] / 4))
                ) * Level) / 100) + Level + 10;

        //Debug.Log("02�������X�^�[��H�����l" + this.HPMax);

        HPNow = HPMax;



        //A�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        AtRl = Mathf.Floor((Mathf.Floor((((MonBaV[1] * 2 + MonInV[1]
               + Mathf.Floor(MonEfV[1] / 4))
               ) * Level) / 100) + 5) * nature[1]);

        //Debug.Log("02�������X�^�[��A�����l" + this.AtRl);

        //B�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        BtRl = Mathf.Floor((Mathf.Floor((((MonBaV[2] * 2 + MonInV[2]
               + Mathf.Floor(MonEfV[2] / 4))
               ) * Level) / 100) + 5) * nature[2]);

        //Debug.Log("02�������X�^�[��B�����l" + this.BtRl);

        //C�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        CtRl = Mathf.Floor((Mathf.Floor((((MonBaV[3] * 2 + MonInV[3]
               + Mathf.Floor(MonEfV[3] / 4))
               ) * Level) / 100) + 5) * nature[3]);

        //Debug.Log("02�������X�^�[��C�����l" + this.CtRl);

        //D�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�
        DtRl = Mathf.Floor((Mathf.Floor((((MonBaV[4] * 2 + MonInV[4]
               + Mathf.Floor(MonEfV[4] / 4))
               ) * Level) / 100) + 5) * nature[4]);

        //Debug.Log("02�������X�^�[��D�����l" + this.DtRl);


        //S�����l:{(�푰�l�~2+�̒l+�w�͒l��4)�~���x����100+5}�~���i�␳ �������_�ȉ��͌v�Z�̂��тɐ؂�̂�

       

        StRl = Mathf.Floor((Mathf.Floor((((MonBaV[5] * 2 + MonInV[5]
               + Mathf.Floor(MonEfV[5] / 4))
               ) * Level) / 100) + 5) * nature[5]);

       // Debug.Log("02�������X�^�[��S�����l" + this.StRl);

    }

    // Update is called once per frame
    void Update()
    {
        //�^�C�}�[
        timeCounter += Time.deltaTime;

        if (stateNumber == 0)
        {
            this.transform.position += new Vector3(-1f * Time.deltaTime, 0f, 0f);

            if (this.transform.position.x <= 4.5f)
            {
                stateNumber = 1;
            }


        }



    }
    public void requestAttack(int number)
    {
         if(number == 01)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack01);
            GetComponent<Animator>().SetTrigger("Attack01");
        }
        else if (number == 02)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack02);
            GetComponent<Animator>().SetTrigger("Attack02");
        }
        else if (number == 03)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack03);
            GetComponent<Animator>().SetTrigger("Attack03");
        }
        else if (number == 04)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack04);
            GetComponent<Animator>().SetTrigger("Attack03");
        }

    }

    public void requestDamage()
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }
    public void requestDeath()
    {
        GetComponent<Animator>().SetTrigger("Death");
    
    
    }

    public void requestRelive()
    {
        GetComponent<Animator>().SetTrigger("Relive");
    }



    public void statusDisplay()
    {
        //Player2���̃X�e�[�^�X���X�V




    }




}
