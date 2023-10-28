using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//UI���i
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�X�e�C�g�ԍ�
    private int stateNumber = 0;

    //�ėp�^�C�}�[
    private float timeCounter = 0.0f;

    //UI ���b�Z�[�W
    public GameObject UImessage;

    //UI �X�e�C�g�ԍ��̕\��
    public GameObject UIStateNumber;

    //UI �����X�^�[HP
    public GameObject Ul01HPtext;
    public GameObject Ul02HPtext;

    //UI �R�}���h
    public GameObject UIchoice01;
    public GameObject UIchoice02;

    //UI �Z
    public GameObject UIweapon01;
    public GameObject UIweapon02;

    //�v���C���[��UI����̌���
    //0=���I���A1=���������A2=���ꂩ�� 3=�X�e�[�^�X
    private int choiceCommand01 = 0;
    private int choiceCommand02 = 0;
   
    //�v���C���[�̕���I���̌���
    //0=���I���A1=����1�A�c�c
    private int weaponNumber01 = 0;
    private int weaponNumber02 = 0;
   

    //�s���������ǂ����̊m�F
    //0=���s���A1=�s���ς�
    private int ActionCheck01 = 0;
    private int ActionCheck02 = 0;


    //�Z�e�L�X�g
    public GameObject TextWeapon01Player01;
    public GameObject TextWeapon02Player01;
    public GameObject TextWeapon03Player01;
    public GameObject TextWeapon04Player01;
    public GameObject TextWeapon01Player02;
    public GameObject TextWeapon02Player02;
    public GameObject TextWeapon03Player02;
    public GameObject TextWeapon04Player02;


    // Start is called before the first frame update
    void Start()
   {

      

    }
    // Update is called once per frame
    void Update()
    {
        //�^�C�}�[
        timeCounter += Time.deltaTime;

        //�X�e�C�g�ԍ���\������
        UIStateNumber.GetComponent<Text>().text = "" + stateNumber;


        //player01,02���`����

        Monster01Player01 player01;
        player01 = GameObject.Find("Monster01Player01").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster01Player02").GetComponent<Monster01Player02>();

        //HP��\������
        Ul01HPtext.GetComponent<Text>().text = "HP:" + player01.HPNow + "/" + player01.HPMax;
        Ul02HPtext.GetComponent<Text>().text = "HP:" + player02.HPNow + "/" + player02.HPMax;



        if (timeCounter == 3.0f)
        {
            Debug.Log("3�b�o��");
        }

        //�����X�^�[���o�ꂷ�鉉�o
        if (stateNumber == 0)
        {
            if (timeCounter > 3.0f)
            {
               �@UImessage.GetComponent<Text>().text = "�ΐ�J�n";

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                //�X�e�C�g�ύX
                stateNumber = 101;
            }
        }

        else if (stateNumber == 101)
        {
            if (timeCounter > 1.0f)
            {
                //���I��
                choiceCommand01 = 0;

                //�R�}���hON
                UIchoice01.SetActive(true);

                //�s���m�Foff
                ActionCheck01 = 0;
                ActionCheck02 = 0;

                //�X�e�C�g�ύX
                stateNumber = 102;            
            }
        }



        //�R�}���h���I�������܂ł̑ҋ@
        else if (stateNumber == 102)
        {


            if (choiceCommand01 != 0)
            {


                if (choiceCommand01 == 1)
                {

                    Debug.Log("�v���C���[01�̍s���I��:����������I��");

                    //���I��
                    weaponNumber01 = 0;

                    //�R�}���hON
                    UIweapon01.SetActive(true);



                    //�Z�\�����Z�b�g
                    string wn9001 = "���肩����";
                    int[] wf9001 = { 1, 50, 100, 10, 1, 0 };

                    string wn9002 = "������������";
                    int[] wf9002 = { 2, 100, 80, 10, 1, 0 };

                    string wn9003 = "�Ƃтǂ���";
                    int[] wf9003 = { 3, 80, 100, 10, 2, 0 };

                    string wn9004 = "������";
                    int[] wf9004 = { 4, 0, 100, 10, 2, 0 };

                    TextWeapon01Player01.GetComponent<Text>().text = "" + wn9001;
                    TextWeapon02Player01.GetComponent<Text>().text = "" + wn9002;
                    TextWeapon03Player01.GetComponent<Text>().text = "" + wn9003;
                    TextWeapon04Player01.GetComponent<Text>().text = "" + wn9004;



                    //�X�e�C�g�ύX��01�̋Z�I�����
                    stateNumber = 103;

                }
            }
        }
        //�Z���I�������܂ł̑ҋ@
        else if (stateNumber == 103)
        {

           
            if (weaponNumber01 != 0)
            {
                Debug.Log("�v���C���[01�͋Z" + weaponNumber01 + "��I��");

                //���I��
                choiceCommand02 = 0;

                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("�v���C���[02�̍s���I��");
            }
        }

        else if (stateNumber == 202)
        {
            if (choiceCommand02 != 0)
            {
                if (choiceCommand02 == 1)
                {
                    //���I��
                    weaponNumber02 = 0;
                    //�R�}���hON
                    UIweapon02.SetActive(true);
                    Debug.Log("�v���C���[02�̍s���I��:����������I��");


                    //�Z�\�����Z�b�g
                    string wn9001 = "���肩����";
                    int[] wf9001 = { 1, 50, 100, 10, 1, 0 };

                    string wn9002 = "������������";
                    int[] wf9002 = { 2, 100, 80, 10, 1, 0 };

                    string wn9003 = "�Ƃтǂ���";
                    int[] wf9003 = { 3, 80, 100, 10, 2, 0 };

                    string wn9004 = "������";
                    int[] wf9004 = { 4, 0, 100, 10, 2, 0 };

                    TextWeapon01Player02.GetComponent<Text>().text = "" + wn9001;
                    TextWeapon02Player02.GetComponent<Text>().text = "" + wn9002;
                    TextWeapon03Player02.GetComponent<Text>().text = "" + wn9003;
                    TextWeapon04Player02.GetComponent<Text>().text = "" + wn9004;

                    //�X�e�C�g�ύX
                    stateNumber = 203;
                    Debug.Log("�v���C���[02�̋Z�I��");
                }

            }
        }
        //���킪�I�������܂ł̑ҋ@
        else if (stateNumber == 203)
        {

            if (weaponNumber02 != 0)
            {
                stateNumber = 301;
                Debug.Log("�v���C���[02�͋Z��I��");
            }
        }

        //�퓬�J�n

        else if (stateNumber == 301)
        {
            GameObject.Find("Monster01Player01").GetComponent<Monster01Player01>().requestAttack(weaponNumber01);

            //�^�C�}�[���Z�b�g
            timeCounter = 0.0f;

            stateNumber = 302;

        }

        else if (stateNumber == 302)
        {

            if (timeCounter > 0.5f)
            {
                GameObject.Find("Monster01Player02").GetComponent<Monster01Player02>().requestDamage();
                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                //�X�e�C�g�ύX
                stateNumber = 303;

            }
        }

        else if (stateNumber == 303)
        {
            if (timeCounter > 1.0f)
            {
                GameObject.Find("Monster01Player02").GetComponent<Monster01Player02>().requestAttack(weaponNumber02);

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                stateNumber = 304;

            }

        }

        else if (stateNumber == 304)
        {
            if (timeCounter > 0.5f)
            {
                GameObject.Find("Monster01Player01").GetComponent<Monster01Player01>().requestDamage();
                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                

                //�����l�m�F
                Debug.Log("�v���C���[01�����l�m�F" + player01.HPMax + "," + player01.AtRl + "," + player01.BtRl + ","
                    + player01.CtRl + "," + player01.DtRl + "," + player01.StRl);

                Debug.Log("�v���C���[02�����l�m�F" + player02.HPMax + "," + player02.AtRl + "," + player02.BtRl + ","
                   + player02.CtRl + "," + player02.DtRl + "," + player02.StRl);


                //�f������r
                if (player01.StRl > player02.StRl)
                {

                    Debug.Log("�v���C���[01�̕�������");

                    //player01����U������
                    stateNumber = 311;

                }

                else if (player01.StRl < player02.StRl)
                {

                    Debug.Log("�v���C���[02�̕�������");

                    //player01����U������
                    stateNumber = 312;

                }

                else
                {
                  //  Debug.Log("����");

                    //��������
                    if (Random.Range(1, 2) > 1)

                    {
                        Debug.Log("�����Ńv���C���[01���D��");
                        stateNumber = 311;
                    }
                    else
                    {
                        Debug.Log("�����Ńv���C���[02���D��");
                        stateNumber = 312;
                    }

                }
            }
        }
        //�v���C���[01�̍U��
        else if (stateNumber == 311)
        {
            //�s���m�Fon
            ActionCheck01 = 1;

            Debug.Log("�����X�^�[05�̍U���I");

            //�Z���̌Ăяo��
            // �^�C�v�A�З́A�����App�A�����ρA�D��x

            int[] wf9001 = { 1, 50, 100, 10, 1, 0 };
            int[] wf9002 = { 2, 100, 80, 10, 1, 0 };
            int[] wf9003 = { 3, 80, 100, 10, 2, 0 };
            int[] wf9004 = { 4, 0, 100, 10, 3, 0 };





            //01��02�̃_���[�W�v�Z
            //�_���[�W = (((���x���~2 / 5 + 2)�~�З́~A / D)/ 50 + 2)
            //�~�͈͕␳�~���₱�����␳�~�V�C�␳�~�}���␳�~�����␳
            //�~�^�C�v��v�␳�~�����␳�~�₯�Ǖ␳�~M�~Mprotect

            float da01 = player01.Level*2 / 5 + 2 ;

            //�Z�З�

            float WeaponPower=0;
            
            if(choiceCommand01 == 1)
            {
                 WeaponPower = wf9001[1];
            }
            else if (choiceCommand01 == 2)
            {
                 WeaponPower = wf9002[1];
            }
            else if (choiceCommand01 == 3)
            {
                 WeaponPower = wf9003[1];
            }
            else if (choiceCommand01 == 4)
            {
                 WeaponPower = wf9003[1];
            }
            else
            {
                Debug.Log("�Z�I�����s");
            }

            Debug.Log("�Z�З�" + WeaponPower);


            //�������ꔻ��

            float da02 = 0;
            float da03 = 0;


            if (choiceCommand01 == 1 && wf9001[4]==1)
            {
                da02= player01.AtRl;
                da03= player02.BtRl;
            }
            else if(choiceCommand01 == 1 && wf9001[4] == 2)
            {
                da02 = player01.CtRl;
                da03 = player02.DtRl;
            }
            else if (choiceCommand01 == 2 && wf9002[4]==1)
            {
                da02 = player01.AtRl;
                da03 = player02.BtRl;
            }
            else if (choiceCommand01 == 2 && wf9002[4] == 2)
            {
                da02 = player01.CtRl;
                da03 = player02.DtRl;
            }
            else if (choiceCommand01 == 3 && wf9002[4] == 1)
            {
                da02 = player01.AtRl;
                da03 = player02.BtRl;
            }
            else if (choiceCommand01 == 3 && wf9002[4] == 2)
            {
                da02 = player01.CtRl;
                da03 = player02.DtRl;
            }
            else if (choiceCommand01 == 4 && wf9002[4] == 1)
            {
                da02 = player01.AtRl;
                da03 = player02.BtRl;
            }
            else if (choiceCommand01 == 4 && wf9002[4] == 2)
            {
                da02 = player01.CtRl;
                da03 = player02.DtRl;
            }
            else
            {
                Debug.Log(" ��������̑I�����s");
            }

            Debug.Log("�U��or���U�̎����l"+da02);
            Debug.Log("���Uor���h�̎����l" + da03);

            //�U���������N�␳
            float da201 = 1;

            if(player01.AtRa ==0) { da201 = 1; }
            else if( player01.AtRa == 1) { da201 = 3 / 2; }
            else if (player01.AtRa == 2) { da201 = 4 / 2; }
            else if (player01.AtRa == 3) { da201 = 5 / 2; }
            else if (player01.AtRa == 4) { da201 = 6 / 2; }
            else if (player01.AtRa == 5) { da201 = 7 / 2; }
            else if (player01.AtRa == 6) { da201 = 8 / 2; }
            else if (player01.AtRa == -1) { da201 = 2 / 3; }
            else if (player01.AtRa == -2) { da201 = 2 / 4; }
            else if (player01.AtRa == -3) { da201 = 2 / 5; }
            else if (player01.AtRa == -4) { da201 = 2 / 6; }
            else if (player01.AtRa == -5) { da201 = 2 / 7; }
            else if (player01.AtRa == -6) { da201 = 2 / 8; }
            else { Debug.Log(" A�����N�v�Z���s"); }

            float da203 = 1;

            if (player01.CtRa == 0) { da203 = 1; }
            else if (player01.CtRa == 1) { da203 = 3 / 2; }
            else if (player01.CtRa == 2) { da203 = 4 / 2; }
            else if (player01.CtRa == 3) { da203 = 5 / 2; }
            else if (player01.CtRa == 4) { da203 = 6 / 2; }
            else if (player01.CtRa == 5) { da203 = 7 / 2; }
            else if (player01.CtRa == 6) { da203 = 8 / 2; }
            else if (player01.CtRa == -1) { da203 = 2 / 3; }
            else if (player01.CtRa == -2) { da203 = 2 / 4; }
            else if (player01.CtRa == -3) { da203 = 2 / 5; }
            else if (player01.CtRa == -4) { da203 = 2 / 6; }
            else if (player01.CtRa == -5) { da203 = 2 / 7; }
            else if (player01.CtRa == -6) { da203 = 2 / 8; }
            else { Debug.Log(" C�����N�v�Z���s"); }

            //�h�䑤�����N�␳

            float da302 = 1;
            if (player01.BtRa == 0) { da302 = 1; }
            else if (player01.BtRa == 1) { da302 = 3 / 2; }
            else if (player01.BtRa == 2) { da302 = 4 / 2; }
            else if (player01.BtRa == 3) { da302 = 5 / 2; }
            else if (player01.BtRa == 4) { da302 = 6 / 2; }
            else if (player01.BtRa == 5) { da302 = 7 / 2; }
            else if (player01.BtRa == 6) { da302 = 8 / 2; }
            else if (player01.BtRa == -1) { da302 = 2 / 3; }
            else if (player01.BtRa == -2) { da302 = 2 / 4; }
            else if (player01.BtRa == -3) { da302 = 2 / 5; }
            else if (player01.BtRa == -4) { da302 = 2 / 6; }
            else if (player01.BtRa == -5) { da302 = 2 / 7; }
            else if (player01.BtRa == -6) { da302 = 2 / 8; }
            else { Debug.Log(" B�����N�v�Z���s"); }

            float da304 = 1;
            if (player01.DtRa == 0) { da304 = 1; }
            else if (player01.DtRa == 1) { da304 = 3 / 2; }
            else if (player01.DtRa == 2) { da304 = 4 / 2; }
            else if (player01.DtRa == 3) { da304 = 5 / 2; }
            else if (player01.DtRa == 4) { da304 = 6 / 2; }
            else if (player01.DtRa == 5) { da304 = 7 / 2; }
            else if (player01.DtRa == 6) { da304 = 8 / 2; }
            else if (player01.DtRa == -1) { da304 = 2 / 3; }
            else if (player01.DtRa == -2) { da304 = 2 / 4; }
            else if (player01.DtRa == -3) { da304 = 2 / 5; }
            else if (player01.DtRa == -4) { da304 = 2 / 6; }
            else if (player01.DtRa == -5) { da304 = 2 / 7; }
            else if (player01.DtRa == -6) { da304 = 2 / 8; }
            else { Debug.Log(" D�����N�v�Z���s"); }


            //�����N�␳��̈З�

            float da02R = 0;
            float da03R = 0;


            if (choiceCommand01 == 1 && wf9001[4] == 1)
            {
                da02R = da201;
                da03R = da302;
            }
            else if (choiceCommand01 == 1 && wf9001[4] == 2)
            {
                da02R = da203;
                da03R = da304;
            }
            else if (choiceCommand01 == 2 && wf9002[4] == 1)
            {
                da02R = da201;
                da03R = da302;
            }
            else if (choiceCommand01 == 2 && wf9002[4] == 2)
            {
                da02R = da203;
                da03R = da304;
            }
            else if (choiceCommand01 == 3 && wf9002[4] == 1)
            {
                da02R = da201;
                da03R = da302;
            }
            else if (choiceCommand01 == 3 && wf9002[4] == 2)
            {
                da02R = da203;
                da03R = da304;
            }
            else if (choiceCommand01 == 4 && wf9002[4] == 1)
            {
                da02R = da201;
                da03R = da302;
            }
            else if (choiceCommand01 == 4 && wf9002[4] == 2)
            {
                da02R = da203;
                da03R = da304;
            }
            else
            {
                Debug.Log(" �������ꃉ���N�̑I�����s");
            }




            //�ŏI�З�=��b�З́~�З͕␳/4096


            float da04 = Mathf.Floor(Mathf.Floor(da01 * WeaponPower * da02 *da02R / (da03*da03R)) / 50 + 2);

            Debug.Log("���������̌v�Z�l" + da04);

            //�͈͕␳�v�Z

            float da05 = da04;
            
            //���₱�����␳

            float da06 = da05;

            //�V�C�␳

            float da07 = da06;

            //�}���␳
            //�����̉��~�����N�Ƒ���̏㏸�����N�����͂ǂ����悤�H

            float da08 = 0;

            if (Random.Range(1, 16) == 16)
            {
                Debug.Log("�}���ɓ�������");

                da08 = da07 * 3 / 2;
            }
            else if (Random.Range(1, 16) < 16)
            {
                da08 = da07;
                Debug.Log("�}���ɓ�����Ȃ�����");

            }
            else
            {
                Debug.Log("�}�����莸�s");
            }


            Debug.Log("�}�����荞��"+da08);

            //�܎̌ܒ���
            float da09 = Mathf.Ceil(da08 - 1/2);

            //�_���[�W����p
            //float[] daR01 ={ da09 * 85 / 100, da09 * 86 / 100 , da09 * 87 / 100 ,da09 * 88 / 100 ,
            //                 da09 * 89 / 100 ,da09 * 90 / 100 , da09 * 91 / 100 ,da09 * 92 / 100 ,
            //                 da09 * 93 / 100 ,da09 * 94 / 100 , da09 * 95 / 100 ,da09 * 96 / 100 ,
            //                 da09 * 97 / 100 ,da09 * 98 / 100 , da09 * 99 / 100 ,da09 * 100 / 100 };

            //�����␳�i�؂�̂āj

            float da10 = Random.Range(85, 100);
            Debug.Log("�����␳" + da10+"%");

            float da11 = Mathf.Floor(da09 * da10 / 100);
            Debug.Log("��������" + da11);

            //float[] daR02 = { Mathf.Floor(daR01[0]),Mathf.Floor(daR01[1]),Mathf.Floor(daR01[2]),Mathf.Floor(daR01[3]),
            //                  Mathf.Floor(daR01[4]),Mathf.Floor(daR01[5]),Mathf.Floor(daR01[6]),Mathf.Floor(daR01[7]),
            //                  Mathf.Floor(daR01[8]),Mathf.Floor(daR01[9]),Mathf.Floor(daR01[10]),Mathf.Floor(daR01[11])};

           

            float da13 = 0;     //�Z�^�C�v
            if (choiceCommand01 == 1)
            {
                da13 = wf9001[0];
            }
            else if (choiceCommand01 == 2)
            {
                da13 = wf9002[0];
            }
            else if (choiceCommand01 == 3)
            {
                da13 = wf9003[0];
            }
            else if (choiceCommand01 == 4)
            {
                da13 = wf9004[0];
            }
            else
            {
                Debug.Log("�^�C�v�擾���s");
            }


            //�^�C�v��v�␳(�܎̌ܒ���)
            float da12 = 0;


            if (da13 == player01.type[0])
            {
                Debug.Log("�^�C�v��vON" + da11 * 1.5f);
                da12 = Mathf.Ceil(da11 * 1.5f�@-0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("�^�C�v��vON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[0])
            {
                Debug.Log("�^�C�v��vON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("�^�C�v��vON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[0])
            {
                Debug.Log("�^�C�v��vON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("�^�C�v��vON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if ((da13 == player01.type[0]))
            {
                Debug.Log("�^�C�v��vON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("�^�C�v��vON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else 
            {
                Debug.Log("�^�C�v�s��v");
            }

            Debug.Log("�^�C�v��v�␳����" + da12);

            //�����␳

            float da14 = 0;
            float da15 = 0;


            //�Z�^�C�v���h��^�C�v1
            //�U�������m�[�}��
            if (da13 == 1 && player02.type[0] == 0) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 1) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 2) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 3) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 4) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 5) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 6) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 7) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 8) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 9) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 10) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 11) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 12) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 13) { da14 = 1 / 2; }    //��
            else if (da13 == 1 && player02.type[0] == 14) { da14 = 0; }     //��
            else if (da13 == 1 && player02.type[0] == 15) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 16) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 1 && player02.type[0] == 18) { da14 = 1; }
            //�U��������
            else if (da13 == 2 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 2 && player02.type[0] == 1) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 2) { da14 = 1 / 2; }�@//��
            else if (da13 == 2 && player02.type[0] == 3) { da14 = 1 / 2; }�@//��
            else if (da13 == 2 && player02.type[0] == 4) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 5) { da14 = 2; }  //��
            else if (da13 == 2 && player02.type[0] == 6) { da14 = 2; }  //�X
            else if (da13 == 2 && player02.type[0] == 7) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 8) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 9) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 10) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 11) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 12) { da14 = 2; }     //��
            else if (da13 == 2 && player02.type[0] == 13) { da14 = 1 / 2; } //��
            else if (da13 == 2 && player02.type[0] == 14) { da14 = 1; }     //��
            else if (da13 == 2 && player02.type[0] == 15) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 16) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 17) { da14 = 2; }  //�|
            else if (da13 == 2 && player02.type[0] == 18) { da14 = 1; }
            //�U��������
            else if (da13 == 3 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 3 && player02.type[0] == 1) { da14 = 1; }
            else if (da13 == 3 && player02.type[0] == 2) { da14 = 2; }�@//��
            else if (da13 == 3 && player02.type[0] == 3) { da14 = 1 / 2; }�@//��
            else if (da13 == 3 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 3 && player02.type[0] == 5) { da14 = 1 / 2; }  //��
            else if (da13 == 3 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 3 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 3 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 3 && player02.type[0] == 9) { da14 = 2; }  //�n
            else if (da13 == 3 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 3 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 3 && player02.type[0] == 12) { da14 = 2; }  //��
            else if (da13 == 3 && player02.type[0] == 13) { da14 = 2; }  //��
            else if (da13 == 3 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 3 && player02.type[0] == 15) { da14 = 1 / 2; }  //��
            else if (da13 == 3 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 3 && player02.type[0] == 17) { da14 = 2; }  //�|
            else if (da13 == 3 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U�������d
            else if (da13 == 4 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 4 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 4 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 4 && player02.type[0] == 3) { da14 = 2; }�@//��
            else if (da13 == 4 && player02.type[0] == 4) { da14 = 1 / 2; }�@�@�@//�d
            else if (da13 == 4 && player02.type[0] == 5) { da14 = 1 / 2; }  //��
            else if (da13 == 4 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 4 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 4 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 4 && player02.type[0] == 9) { da14 = 0; }  //�n
            else if (da13 == 4 && player02.type[0] == 10) { da14 = 2; }�@//��
            else if (da13 == 4 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 4 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 4 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 4 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 4 && player02.type[0] == 15) { da14 = 1 / 2; }  //��
            else if (da13 == 4 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 4 && player02.type[0] == 17) { da14 = 1; }  //�|
            else if (da13 == 4 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U��������
            else if (da13 == 5 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 5 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 5 && player02.type[0] == 2) { da14 = 1 / 2; }�@//��
            else if (da13 == 5 && player02.type[0] == 3) { da14 = 2; }�@//��
            else if (da13 == 5 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 5 && player02.type[0] == 5) { da14 = 1 / 2; }  //��
            else if (da13 == 5 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 5 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 5 && player02.type[0] == 8) { da14 = 1 / 2; }�@//��
            else if (da13 == 5 && player02.type[0] == 9) { da14 = 2; }  //�n
            else if (da13 == 5 && player02.type[0] == 10) { da14 = 1 / 2; }�@//��
            else if (da13 == 5 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 5 && player02.type[0] == 12) { da14 = 1 / 2; }  //��
            else if (da13 == 5 && player02.type[0] == 13) { da14 = 2; }  //��
            else if (da13 == 5 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 5 && player02.type[0] == 15) { da14 = 1 / 2; }  //��
            else if (da13 == 5 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 5 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 5 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U�������X
            else if (da13 == 6 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 6 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 6 && player02.type[0] == 2) { da14 = 1 / 2; }�@//��
            else if (da13 == 6 && player02.type[0] == 3) { da14 = 1 / 2; }�@//��
            else if (da13 == 6 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 6 && player02.type[0] == 5) { da14 = 2; }  //��
            else if (da13 == 6 && player02.type[0] == 6) { da14 = 1 / 2; }  //�X
            else if (da13 == 6 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 6 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 6 && player02.type[0] == 9) { da14 = 2; }  //�n
            else if (da13 == 6 && player02.type[0] == 10) { da14 = 2; }�@//��
            else if (da13 == 6 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 6 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 6 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 6 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 6 && player02.type[0] == 15) { da14 = 2; }  //��
            else if (da13 == 6 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 6 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 6 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U�������i
            else if (da13 == 7 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 7 && player02.type[0] == 1) { da14 = 2; }  //�m
            else if (da13 == 7 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 7 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 7 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 7 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 7 && player02.type[0] == 6) { da14 = 2; }  //�X
            else if (da13 == 7 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 7 && player02.type[0] == 8) { da14 = 1 / 2; }�@//��
            else if (da13 == 7 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 7 && player02.type[0] == 10) { da14 = 1 / 2; }�@//��
            else if (da13 == 7 && player02.type[0] == 11) { da14 = 1 / 2; }�@//��
            else if (da13 == 7 && player02.type[0] == 12) { da14 = 1 / 2; }  //��
            else if (da13 == 7 && player02.type[0] == 13) { da14 = 2; }  //��
            else if (da13 == 7 && player02.type[0] == 14) { da14 = 0; }  //��
            else if (da13 == 7 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 7 && player02.type[0] == 16) { da14 = 2; }  //��
            else if (da13 == 7 && player02.type[0] == 17) { da14 = 2; }  //�|
            else if (da13 == 7 && player02.type[0] == 18) { da14 = 1 / 2; } //�d
            //�U��������
            else if (da13 == 8 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 8 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 8 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 8 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 8 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 8 && player02.type[0] == 5) { da14 = 2; }  //��
            else if (da13 == 8 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 8 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 8 && player02.type[0] == 8) { da14 = 1 / 2; }�@//��
            else if (da13 == 8 && player02.type[0] == 9) { da14 = 1 / 2; }  //�n
            else if (da13 == 8 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 8 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 8 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 8 && player02.type[0] == 13) { da14 = 1 / 2; }  //��
            else if (da13 == 8 && player02.type[0] == 14) { da14 = 1 / 2; }  //��
            else if (da13 == 8 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 8 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 8 && player02.type[0] == 17) { da14 = 0; }  //�|
            else if (da13 == 8 && player02.type[0] == 18) { da14 = 2; } //�d
            //�U�������n��
            else if (da13 == 9 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 9 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 9 && player02.type[0] == 2) { da14 = 2; }�@//��
            else if (da13 == 9 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 9 && player02.type[0] == 4) { da14 = 2; }�@�@�@//�d
            else if (da13 == 9 && player02.type[0] == 5) { da14 = 1 / 2; }  //��
            else if (da13 == 9 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 9 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 9 && player02.type[0] == 8) { da14 = 2; }�@//��
            else if (da13 == 9 && player02.type[0] == 9) { da14 = 2; }  //�n
            else if (da13 == 9 && player02.type[0] == 10) { da14 = 0; }�@//��
            else if (da13 == 9 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 9 && player02.type[0] == 12) { da14 = 1 / 2; }  //��
            else if (da13 == 9 && player02.type[0] == 13) { da14 = 2; }  //��
            else if (da13 == 9 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 9 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 9 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 9 && player02.type[0] == 17) { da14 = 2; }  //�|
            else if (da13 == 9 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U��������s
            else if (da13 == 10 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 10 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 10 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 10 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 10 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 10 && player02.type[0] == 5) { da14 = 2; }  //��
            else if (da13 == 10 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 10 && player02.type[0] == 7) { da14 = 2; }�@//�i
            else if (da13 == 10 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 10 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 10 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 10 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 10 && player02.type[0] == 12) { da14 = 2; }  //��
            else if (da13 == 10 && player02.type[0] == 13) { da14 = 1 / 2; }  //��
            else if (da13 == 10 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 10 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 10 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 10 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 10 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U��������
            else if (da13 == 11 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 11 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 11 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 11 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 11 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 11 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 11 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 11 && player02.type[0] == 7) { da14 = 2; }�@//�i
            else if (da13 == 11 && player02.type[0] == 8) { da14 = 2; }�@//��
            else if (da13 == 11 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 11 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 11 && player02.type[0] == 11) { da14 = 1 / 2; }�@//��
            else if (da13 == 11 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 11 && player02.type[0] == 13) { da14 = 2; }  //��
            else if (da13 == 11 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 11 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 11 && player02.type[0] == 16) { da14 = 0; }  //��
            else if (da13 == 11 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 11 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U��������
            else if (da13 == 12 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 12 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 12 && player02.type[0] == 2) { da14 = 1 / 2; }�@//��
            else if (da13 == 12 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 12 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 12 && player02.type[0] == 5) { da14 = 2; }  //��
            else if (da13 == 12 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 12 && player02.type[0] == 7) { da14 = 1 / 2; }�@//�i
            else if (da13 == 12 && player02.type[0] == 8) { da14 = 1 / 2; }�@//��
            else if (da13 == 12 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 12 && player02.type[0] == 10) { da14 = 1 / 2; }�@//��
            else if (da13 == 12 && player02.type[0] == 11) { da14 = 2; }�@//��
            else if (da13 == 12 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 12 && player02.type[0] == 13) { da14 = 2; }  //��
            else if (da13 == 12 && player02.type[0] == 14) { da14 = 1 / 2; }  //��
            else if (da13 == 12 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 12 && player02.type[0] == 16) { da14 = 2; }  //��
            else if (da13 == 12 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 12 && player02.type[0] == 18) { da14 = 1 / 2; } //�d
            //�U��������
            else if (da13 == 13 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 13 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 13 && player02.type[0] == 2) { da14 = 2; }�@//��
            else if (da13 == 13 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 13 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 13 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 13 && player02.type[0] == 6) { da14 = 2; }  //�X
            else if (da13 == 13 && player02.type[0] == 7) { da14 = 1 / 2; }�@//�i
            else if (da13 == 13 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 13 && player02.type[0] == 9) { da14 = 1 / 2; }  //�n
            else if (da13 == 13 && player02.type[0] == 10) { da14 = 2; }�@//��
            else if (da13 == 13 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 13 && player02.type[0] == 12) { da14 = 2; }  //��
            else if (da13 == 13 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 13 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 13 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 13 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 13 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 13 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U��������
            else if (da13 == 14 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 14 && player02.type[0] == 1) { da14 = 0; }  //�m
            else if (da13 == 14 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 14 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 14 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 14 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 14 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 14 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 14 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 14 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 14 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 14 && player02.type[0] == 11) { da14 = 2; }�@//��
            else if (da13 == 14 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 14 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 14 && player02.type[0] == 14) { da14 = 2; }  //��
            else if (da13 == 14 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 14 && player02.type[0] == 16) { da14 = 1 / 2; }  //��
            else if (da13 == 14 && player02.type[0] == 17) { da14 = 1; }  //�|
            else if (da13 == 14 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U��������
            else if (da13 == 15 && player02.type[0] == 0) { da14 = 1; }  //�^�C�v�Ȃ�
            else if (da13 == 15 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 15 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 15 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 15 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 15 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 15 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 15 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 15 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 15 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 15 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 15 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 15 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 15 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 15 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 15 && player02.type[0] == 15) { da14 = 2; }  //��
            else if (da13 == 15 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 15 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 15 && player02.type[0] == 18) { da14 = 0; } //�d
            //�U��������
            else if (da13 == 16 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 16 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 16 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 16 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 16 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 16 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 16 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 16 && player02.type[0] == 7) { da14 = 1 / 2; }�@//�i
            else if (da13 == 16 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 16 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 16 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 16 && player02.type[0] == 11) { da14 = 2; }�@//��
            else if (da13 == 16 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 16 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 16 && player02.type[0] == 14) { da14 = 2; }  //��
            else if (da13 == 16 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 16 && player02.type[0] == 16) { da14 = 1 / 2; }  //��
            else if (da13 == 16 && player02.type[0] == 17) { da14 = 1; }  //�|
            else if (da13 == 16 && player02.type[0] == 18) { da14 = 1 / 2; } //�d
            //�U�������|
            else if (da13 == 17 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 17 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 17 && player02.type[0] == 2) { da14 = 1 / 2; }�@//��
            else if (da13 == 17 && player02.type[0] == 3) { da14 = 1 / 2; }�@//��
            else if (da13 == 17 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 17 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 17 && player02.type[0] == 6) { da14 = 2; }  //�X
            else if (da13 == 17 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 17 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 17 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 17 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 17 && player02.type[0] == 11) { da14 = 2; }�@//��
            else if (da13 == 17 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 17 && player02.type[0] == 13) { da14 = 2; }  //��
            else if (da13 == 17 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 17 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 17 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 17 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 17 && player02.type[0] == 18) { da14 = 2; } //�d
            //�U�������d
            else if (da13 == 18 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 18 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 18 && player02.type[0] == 2) { da14 = 1 / 2; }�@//��
            else if (da13 == 18 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 18 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 18 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 18 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 18 && player02.type[0] == 7) { da14 = 2; }�@//�i
            else if (da13 == 18 && player02.type[0] == 8) { da14 = 1 / 2; }�@//��
            else if (da13 == 18 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 18 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 18 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 18 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 18 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 18 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 18 && player02.type[0] == 15) { da14 = 2; }  //��
            else if (da13 == 18 && player02.type[0] == 16) { da14 = 2; }  //��
            else if (da13 == 18 && player02.type[0] == 17) { da14 = 1 / 2; }  //�|
            else if (da13 == 18 && player02.type[0] == 18) { da14 = 1; } //�d
            //�U�������^�C�v�Ȃ�
            else if (da13 == 19 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 19 && player02.type[0] == 1) { da14 = 1; }  //�m
            else if (da13 == 19 && player02.type[0] == 2) { da14 = 1; }�@//��
            else if (da13 == 19 && player02.type[0] == 3) { da14 = 1; }�@//��
            else if (da13 == 19 && player02.type[0] == 4) { da14 = 1; }�@�@�@//�d
            else if (da13 == 19 && player02.type[0] == 5) { da14 = 1; }  //��
            else if (da13 == 19 && player02.type[0] == 6) { da14 = 1; }  //�X
            else if (da13 == 19 && player02.type[0] == 7) { da14 = 1; }�@//�i
            else if (da13 == 19 && player02.type[0] == 8) { da14 = 1; }�@//��
            else if (da13 == 19 && player02.type[0] == 9) { da14 = 1; }  //�n
            else if (da13 == 19 && player02.type[0] == 10) { da14 = 1; }�@//��
            else if (da13 == 19 && player02.type[0] == 11) { da14 = 1; }�@//��
            else if (da13 == 19 && player02.type[0] == 12) { da14 = 1; }  //��
            else if (da13 == 19 && player02.type[0] == 13) { da14 = 1; }  //��
            else if (da13 == 19 && player02.type[0] == 14) { da14 = 1; }  //��
            else if (da13 == 19 && player02.type[0] == 15) { da14 = 1; }  //��
            else if (da13 == 19 && player02.type[0] == 16) { da14 = 1; }  //��
            else if (da13 == 19 && player02.type[0] == 17) { da14 = 1; }  //�|
            else if (da13 == 19 && player02.type[0] == 18) { da14 = 1; } //�d

            else { Debug.Log("��������1���s"); };


            //�Z�^�C�v���h��^�C�v2
            //�U�������m�[�}��
            if (da13 == 1 && player02.type[1] == 0) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 1) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 2) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 3) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 4) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 5) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 6) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 7) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 8) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 9) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 10) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 11) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 12) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 13) { da15 = 1 / 2; }    //��
            else if (da13 == 1 && player02.type[1] == 14) { da15 = 0; }     //��
            else if (da13 == 1 && player02.type[1] == 15) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 16) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 1 && player02.type[1] == 18) { da15 = 1; }
            //�U��������
            else if (da13 == 2 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 2 && player02.type[1] == 1) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 2) { da15 = 1 / 2; } //��
            else if (da13 == 2 && player02.type[1] == 3) { da15 = 1 / 2; } //��
            else if (da13 == 2 && player02.type[1] == 4) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 5) { da15 = 2; }  //��
            else if (da13 == 2 && player02.type[1] == 6) { da15 = 2; }  //�X
            else if (da13 == 2 && player02.type[1] == 7) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 8) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 9) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 10) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 11) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 12) { da15 = 2; }     //��
            else if (da13 == 2 && player02.type[1] == 13) { da15 = 1 / 2; } //��
            else if (da13 == 2 && player02.type[1] == 14) { da15 = 1; }     //��
            else if (da13 == 2 && player02.type[1] == 15) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 16) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 17) { da15 = 2; }  //�|
            else if (da13 == 2 && player02.type[1] == 18) { da15 = 1; }
            //�U��������
            else if (da13 == 3 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 3 && player02.type[1] == 1) { da15 = 1; }
            else if (da13 == 3 && player02.type[1] == 2) { da15 = 2; } //��
            else if (da13 == 3 && player02.type[1] == 3) { da15 = 1 / 2; } //��
            else if (da13 == 3 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 3 && player02.type[1] == 5) { da15 = 1 / 2; }  //��
            else if (da13 == 3 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 3 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 3 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 3 && player02.type[1] == 9) { da15 = 2; }  //�n
            else if (da13 == 3 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 3 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 3 && player02.type[1] == 12) { da15 = 2; }  //��
            else if (da13 == 3 && player02.type[1] == 13) { da15 = 2; }  //��
            else if (da13 == 3 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 3 && player02.type[1] == 15) { da15 = 1 / 2; }  //��
            else if (da13 == 3 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 3 && player02.type[1] == 17) { da15 = 2; }  //�|
            else if (da13 == 3 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U�������d
            else if (da13 == 4 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 4 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 4 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 4 && player02.type[1] == 3) { da15 = 2; } //��
            else if (da13 == 4 && player02.type[1] == 4) { da15 = 1 / 2; }   //�d
            else if (da13 == 4 && player02.type[1] == 5) { da15 = 1 / 2; }  //��
            else if (da13 == 4 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 4 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 4 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 4 && player02.type[1] == 9) { da15 = 0; }  //�n
            else if (da13 == 4 && player02.type[1] == 10) { da15 = 2; } //��
            else if (da13 == 4 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 4 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 4 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 4 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 4 && player02.type[1] == 15) { da15 = 1 / 2; }  //��
            else if (da13 == 4 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 4 && player02.type[1] == 17) { da15 = 1; }  //�|
            else if (da13 == 4 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U��������
            else if (da13 == 5 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 5 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 5 && player02.type[1] == 2) { da15 = 1 / 2; } //��
            else if (da13 == 5 && player02.type[1] == 3) { da15 = 2; } //��
            else if (da13 == 5 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 5 && player02.type[1] == 5) { da15 = 1 / 2; }  //��
            else if (da13 == 5 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 5 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 5 && player02.type[1] == 8) { da15 = 1 / 2; } //��
            else if (da13 == 5 && player02.type[1] == 9) { da15 = 2; }  //�n
            else if (da13 == 5 && player02.type[1] == 10) { da15 = 1 / 2; } //��
            else if (da13 == 5 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 5 && player02.type[1] == 12) { da15 = 1 / 2; }  //��
            else if (da13 == 5 && player02.type[1] == 13) { da15 = 2; }  //��
            else if (da13 == 5 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 5 && player02.type[1] == 15) { da15 = 1 / 2; }  //��
            else if (da13 == 5 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 5 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 5 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U�������X
            else if (da13 == 6 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 6 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 6 && player02.type[1] == 2) { da15 = 1 / 2; } //��
            else if (da13 == 6 && player02.type[1] == 3) { da15 = 1 / 2; } //��
            else if (da13 == 6 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 6 && player02.type[1] == 5) { da15 = 2; }  //��
            else if (da13 == 6 && player02.type[1] == 6) { da15 = 1 / 2; }  //�X
            else if (da13 == 6 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 6 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 6 && player02.type[1] == 9) { da15 = 2; }  //�n
            else if (da13 == 6 && player02.type[1] == 10) { da15 = 2; } //��
            else if (da13 == 6 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 6 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 6 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 6 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 6 && player02.type[1] == 15) { da15 = 2; }  //��
            else if (da13 == 6 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 6 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 6 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U�������i
            else if (da13 == 7 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 7 && player02.type[1] == 1) { da15 = 2; }  //�m
            else if (da13 == 7 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 7 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 7 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 7 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 7 && player02.type[1] == 6) { da15 = 2; }  //�X
            else if (da13 == 7 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 7 && player02.type[1] == 8) { da15 = 1 / 2; } //��
            else if (da13 == 7 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 7 && player02.type[1] == 10) { da15 = 1 / 2; } //��
            else if (da13 == 7 && player02.type[1] == 11) { da15 = 1 / 2; } //��
            else if (da13 == 7 && player02.type[1] == 12) { da15 = 1 / 2; }  //��
            else if (da13 == 7 && player02.type[1] == 13) { da15 = 2; }  //��
            else if (da13 == 7 && player02.type[1] == 14) { da15 = 0; }  //��
            else if (da13 == 7 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 7 && player02.type[1] == 16) { da15 = 2; }  //��
            else if (da13 == 7 && player02.type[1] == 17) { da15 = 2; }  //�|
            else if (da13 == 7 && player02.type[1] == 18) { da15 = 1 / 2; } //�d
            //�U��������
            else if (da13 == 8 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 8 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 8 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 8 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 8 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 8 && player02.type[1] == 5) { da15 = 2; }  //��
            else if (da13 == 8 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 8 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 8 && player02.type[1] == 8) { da15 = 1 / 2; } //��
            else if (da13 == 8 && player02.type[1] == 9) { da15 = 1 / 2; }  //�n
            else if (da13 == 8 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 8 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 8 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 8 && player02.type[1] == 13) { da15 = 1 / 2; }  //��
            else if (da13 == 8 && player02.type[1] == 14) { da15 = 1 / 2; }  //��
            else if (da13 == 8 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 8 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 8 && player02.type[1] == 17) { da15 = 0; }  //�|
            else if (da13 == 8 && player02.type[1] == 18) { da15 = 2; } //�d
            //�U�������n��
            else if (da13 == 9 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 9 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 9 && player02.type[1] == 2) { da15 = 2; } //��
            else if (da13 == 9 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 9 && player02.type[1] == 4) { da15 = 2; }   //�d
            else if (da13 == 9 && player02.type[1] == 5) { da15 = 1 / 2; }  //��
            else if (da13 == 9 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 9 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 9 && player02.type[1] == 8) { da15 = 2; } //��
            else if (da13 == 9 && player02.type[1] == 9) { da15 = 2; }  //�n
            else if (da13 == 9 && player02.type[1] == 10) { da15 = 0; } //��
            else if (da13 == 9 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 9 && player02.type[1] == 12) { da15 = 1 / 2; }  //��
            else if (da13 == 9 && player02.type[1] == 13) { da15 = 2; }  //��
            else if (da13 == 9 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 9 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 9 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 9 && player02.type[1] == 17) { da15 = 2; }  //�|
            else if (da13 == 9 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U��������s
            else if (da13 == 10 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 10 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 10 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 10 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 10 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 10 && player02.type[1] == 5) { da15 = 2; }  //��
            else if (da13 == 10 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 10 && player02.type[1] == 7) { da15 = 2; } //�i
            else if (da13 == 10 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 10 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 10 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 10 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 10 && player02.type[1] == 12) { da15 = 2; }  //��
            else if (da13 == 10 && player02.type[1] == 13) { da15 = 1 / 2; }  //��
            else if (da13 == 10 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 10 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 10 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 10 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 10 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U��������
            else if (da13 == 11 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 11 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 11 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 11 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 11 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 11 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 11 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 11 && player02.type[1] == 7) { da15 = 2; } //�i
            else if (da13 == 11 && player02.type[1] == 8) { da15 = 2; } //��
            else if (da13 == 11 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 11 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 11 && player02.type[1] == 11) { da15 = 1 / 2; } //��
            else if (da13 == 11 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 11 && player02.type[1] == 13) { da15 = 2; }  //��
            else if (da13 == 11 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 11 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 11 && player02.type[1] == 16) { da15 = 0; }  //��
            else if (da13 == 11 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 11 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U��������
            else if (da13 == 12 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 12 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 12 && player02.type[1] == 2) { da15 = 1 / 2; } //��
            else if (da13 == 12 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 12 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 12 && player02.type[1] == 5) { da15 = 2; }  //��
            else if (da13 == 12 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 12 && player02.type[1] == 7) { da15 = 1 / 2; } //�i
            else if (da13 == 12 && player02.type[1] == 8) { da15 = 1 / 2; } //��
            else if (da13 == 12 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 12 && player02.type[1] == 10) { da15 = 1 / 2; } //��
            else if (da13 == 12 && player02.type[1] == 11) { da15 = 2; } //��
            else if (da13 == 12 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 12 && player02.type[1] == 13) { da15 = 2; }  //��
            else if (da13 == 12 && player02.type[1] == 14) { da15 = 1 / 2; }  //��
            else if (da13 == 12 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 12 && player02.type[1] == 16) { da15 = 2; }  //��
            else if (da13 == 12 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 12 && player02.type[1] == 18) { da15 = 1 / 2; } //�d
            //�U��������
            else if (da13 == 13 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 13 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 13 && player02.type[1] == 2) { da15 = 2; } //��
            else if (da13 == 13 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 13 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 13 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 13 && player02.type[1] == 6) { da15 = 2; }  //�X
            else if (da13 == 13 && player02.type[1] == 7) { da15 = 1 / 2; } //�i
            else if (da13 == 13 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 13 && player02.type[1] == 9) { da15 = 1 / 2; }  //�n
            else if (da13 == 13 && player02.type[1] == 10) { da15 = 2; } //��
            else if (da13 == 13 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 13 && player02.type[1] == 12) { da15 = 2; }  //��
            else if (da13 == 13 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 13 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 13 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 13 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 13 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 13 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U��������
            else if (da13 == 14 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 14 && player02.type[1] == 1) { da15 = 0; }  //�m
            else if (da13 == 14 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 14 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 14 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 14 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 14 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 14 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 14 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 14 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 14 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 14 && player02.type[1] == 11) { da15 = 2; } //��
            else if (da13 == 14 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 14 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 14 && player02.type[1] == 14) { da15 = 2; }  //��
            else if (da13 == 14 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 14 && player02.type[1] == 16) { da15 = 1 / 2; }  //��
            else if (da13 == 14 && player02.type[1] == 17) { da15 = 1; }  //�|
            else if (da13 == 14 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U��������
            else if (da13 == 15 && player02.type[1] == 0) { da15 = 1; }  //�^�C�v�Ȃ�
            else if (da13 == 15 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 15 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 15 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 15 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 15 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 15 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 15 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 15 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 15 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 15 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 15 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 15 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 15 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 15 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 15 && player02.type[1] == 15) { da15 = 2; }  //��
            else if (da13 == 15 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 15 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 15 && player02.type[1] == 18) { da15 = 0; } //�d
            //�U��������
            else if (da13 == 16 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 16 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 16 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 16 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 16 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 16 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 16 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 16 && player02.type[1] == 7) { da15 = 1 / 2; } //�i
            else if (da13 == 16 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 16 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 16 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 16 && player02.type[1] == 11) { da15 = 2; } //��
            else if (da13 == 16 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 16 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 16 && player02.type[1] == 14) { da15 = 2; }  //��
            else if (da13 == 16 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 16 && player02.type[1] == 16) { da15 = 1 / 2; }  //��
            else if (da13 == 16 && player02.type[1] == 17) { da15 = 1; }  //�|
            else if (da13 == 16 && player02.type[1] == 18) { da15 = 1 / 2; } //�d
            //�U�������|
            else if (da13 == 17 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 17 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 17 && player02.type[1] == 2) { da15 = 1 / 2; } //��
            else if (da13 == 17 && player02.type[1] == 3) { da15 = 1 / 2; } //��
            else if (da13 == 17 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 17 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 17 && player02.type[1] == 6) { da15 = 2; }  //�X
            else if (da13 == 17 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 17 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 17 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 17 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 17 && player02.type[1] == 11) { da15 = 2; } //��
            else if (da13 == 17 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 17 && player02.type[1] == 13) { da15 = 2; }  //��
            else if (da13 == 17 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 17 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 17 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 17 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 17 && player02.type[1] == 18) { da15 = 2; } //�d
            //�U�������d
            else if (da13 == 18 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 18 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 18 && player02.type[1] == 2) { da15 = 1 / 2; } //��
            else if (da13 == 18 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 18 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 18 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 18 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 18 && player02.type[1] == 7) { da15 = 2; } //�i
            else if (da13 == 18 && player02.type[1] == 8) { da15 = 1 / 2; } //��
            else if (da13 == 18 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 18 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 18 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 18 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 18 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 18 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 18 && player02.type[1] == 15) { da15 = 2; }  //��
            else if (da13 == 18 && player02.type[1] == 16) { da15 = 2; }  //��
            else if (da13 == 18 && player02.type[1] == 17) { da15 = 1 / 2; }  //�|
            else if (da13 == 18 && player02.type[1] == 18) { da15 = 1; } //�d
            //�U�������^�C�v�Ȃ�
            else if (da13 == 19 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
            else if (da13 == 19 && player02.type[1] == 1) { da15 = 1; }  //�m
            else if (da13 == 19 && player02.type[1] == 2) { da15 = 1; } //��
            else if (da13 == 19 && player02.type[1] == 3) { da15 = 1; } //��
            else if (da13 == 19 && player02.type[1] == 4) { da15 = 1; }   //�d
            else if (da13 == 19 && player02.type[1] == 5) { da15 = 1; }  //��
            else if (da13 == 19 && player02.type[1] == 6) { da15 = 1; }  //�X
            else if (da13 == 19 && player02.type[1] == 7) { da15 = 1; } //�i
            else if (da13 == 19 && player02.type[1] == 8) { da15 = 1; } //��
            else if (da13 == 19 && player02.type[1] == 9) { da15 = 1; }  //�n
            else if (da13 == 19 && player02.type[1] == 10) { da15 = 1; } //��
            else if (da13 == 19 && player02.type[1] == 11) { da15 = 1; } //��
            else if (da13 == 19 && player02.type[1] == 12) { da15 = 1; }  //��
            else if (da13 == 19 && player02.type[1] == 13) { da15 = 1; }  //��
            else if (da13 == 19 && player02.type[1] == 14) { da15 = 1; }  //��
            else if (da13 == 19 && player02.type[1] == 15) { da15 = 1; }  //��
            else if (da13 == 19 && player02.type[1] == 16) { da15 = 1; }  //��
            else if (da13 == 19 && player02.type[1] == 17) { da15 = 1; }  //�|
            else if (da13 == 19 && player02.type[1] == 18) { da15 = 1; } //�d

            else { Debug.Log("��������2���s"); };

            //�^�C�v�������v����
            float da16 = da14 * da15;
            if (da16 == 1) { Debug.Log("�������{"); }
            else if (da16 == 2) { Debug.Log("���ʂ͔��Q��(2�{)"); }
            else if (da16 == 0.5f) { Debug.Log("���ʂ͂��܂ЂƂ̂悤��(0.5�{)"); }
            else if (da16 == 0.25f) { Debug.Log("���ʂ͂��܂ЂƂ̂悤��(0.25�{)"); }
            else if (da16 == 0f) { Debug.Log("���ʂ͂Ȃ��悤��"); }
            else { Debug.Log("�������v���莸�s"); }

            float da17 = Mathf.Floor(da12 * da16);
            Debug.Log("���������" + da17);


            //�₯�ǔ���
            float da18=da17 ;

            //M�␳(�Ǖ␳�~�u���C���t�H�[�X�␳�~�X�i�C�p�[�␳�~
            //����߂��˕␳�~���ӂ��ӂق̂��␳�~Mhalf�~Mfilter�~
            //�t�����h�K�[�h�␳�~������̂��ѕ␳�~���g���m�[���␳�~
            //���̂��̂��ܕ␳�~�����̎��␳�~Mtwice(�����_�ȉ��𒀈�l�̌ܓ�)(�ŏI�I�Ɍ܎̌ܒ���)

            float da19 = Mathf.Ceil(da18-0.5f);

            //Mprotect�␳(Z���U/�_�C�}�b�N�X�킴���܂����ԂȂǂŌy�����ꂽ�Ƃ�0.25�{)

            float da20 = da19;

            Debug.Log("�ŏI�_���[�W�֐��l" + da20);


�@�@�@�@�@�@//�ŏI�_���[�W�v�Z

            player02.HPNow -= da20;

            player02.statusDisplay();

            Debug.Log("�����X�^�[06��HP" + player02.HPNow +"/"+ player02.HPMax);


            //�X�e�C�g�ύX


            if (player02.HPNow < 0)
            {
                Debug.Log("�����X�^�[06�͓|�ꂽ�I");
                UImessage.GetComponent<Text>().text = "�����X�^�[06�͓|�ꂽ�I";

                //�v���C���[02�̂݃����X�^�[�I�����
                stateNumber = 402;

            }
                 // �v���C���[02�����s���Ȃ�X�e�C�g312�Ɉړ�
            if(ActionCheck02 == 0)
            {
                stateNumber = 312;
            }
            
                //�v���C���[02���s���ςȂ�X�e�C�g101�Ɉړ�
            else
            {
                stateNumber = 101;

            }

        }

        //02��01�̃_���[�W�v�Z

        else if (stateNumber == 312)
        {
            //�s���m�Fon
            ActionCheck02 = 1;
            Debug.Log("�����X�^�[06�̍U���I");

            player01.HPNow -= player02.AtRl;

                player01.statusDisplay();

                Debug.Log("�����X�^�[05��HP"+player01.HPNow);


            if (player01.HPNow < 0)
            {
                Debug.Log("�����X�^�[05�͓|�ꂽ�I");
                UImessage.GetComponent<Text>().text = "�����X�^�[05�͓|�ꂽ�I";

                //�v���C���[01�̂݃����X�^�[�I�����
                stateNumber = 101;

            }
            // �v���C���[01�����s���Ȃ�X�e�C�g311�Ɉړ�
            else if (ActionCheck01 == 0)
            {
                stateNumber = 311;
            }

            //�v���C���[01���s���ςȂ�X�e�C�g101�Ɉړ�
            else
            {
                stateNumber = 101;
            }

        }

  
    }

    //�R�}���h�i�{�^���j
    public void ButtonBattlePlayer01()
    {
        Debug.Log("ButtonBattlePlayer01");
        choiceCommand01 = 1;
        UIchoice01.SetActive(false);

    }

    public void ButtonChangePlayer01()
    {
        Debug.Log("ButtonChangePlayer01");
        choiceCommand01 = 2;
        UIchoice01.SetActive(false);
    }

    public void ButtonStatusPlayer01()
    {
        Debug.Log("ButtonStatusPlayer01");
        choiceCommand01 = 3;
        UIchoice01.SetActive(false);

    }

    public void Weapon01Player01()
    {
        weaponNumber01 = 1;
        UIweapon01.SetActive(false);

    }
    public void Weapon02Player01()
    {
        weaponNumber01 = 2;
        UIweapon01.SetActive(false);
    }
    public void Weapon03Player01()
    {
        weaponNumber01 = 3;
        UIweapon01.SetActive(false);
    }
    public void Weapon04Player01()
    {
        weaponNumber01 = 4;
        UIweapon01.SetActive(false);
    }
    public void WeaponBackPlayer01()
    {
        //
        UIweapon01.SetActive(false);
        UIchoice01.SetActive(true);
        //�X�e�C�g�ύX
        stateNumber = 102;
        //�N���A
        choiceCommand01 = 0;

    }


    public void ButtonBattlePlayer02()
    {
        Debug.Log("ButtonBattlePlayer02");
        choiceCommand02 = 1;
        UIchoice02.SetActive(false);
    }

    public void ButtonChangePlayer02()
    {
        Debug.Log("ButtonChangePlayer02");
        choiceCommand02 = 2;
        UIchoice02.SetActive(false);
    }

    public void ButtonStatusPlayer02()
    {
        Debug.Log("ButtonStatusPlayer02");
        choiceCommand02 = 3;
        UIchoice02.SetActive(false);

    }

    public void Weapon01Player02()
    {
        weaponNumber02 = 1;
        UIweapon02.SetActive(false);

    }
    public void Weapon02Player02()
    {
        weaponNumber02 = 2;
        UIweapon02.SetActive(false);
    }
    public void Weapon03Player02()
    {
        weaponNumber02 = 3;
        UIweapon02.SetActive(false);
    }
    public void Weapon04Player02()
    {
        weaponNumber02 = 4;
        UIweapon02.SetActive(false);
    }
    public void WeaponBackPlayer02()
    {
        //
        UIweapon02.SetActive(false);
        UIchoice02.SetActive(true);
        //�X�e�C�g�ύX
        stateNumber = 202;
        //�N���A
        choiceCommand02 = 0;

    }


}