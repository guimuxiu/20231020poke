using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI���i
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    #region ���_���[�W�v�Z
    #region ���ŏ��̐ݒ�

    //�v���C���[01�@���@02
    void PlayerAttack01()
    {


        Monster01Player01 player01;
        player01 = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)").GetComponent<Monster01Player02>();



        //�Z���̌Ăяo��
        // �^�C�v�A�З́A�����App�A�����ρA�D��x

        int[] wf9001 = { 1, 50, 100, 10, 1, 0 };
        int[] wf9002 = { 2, 100, 80, 10, 1, 0 };
        int[] wf9003 = { 3, 80, 100, 10, 2, 0 };
        int[] wf9004 = { 4, 0, 100, 10, 3, 0 };

        #endregion ���ŏ��̐ݒ�
        #region����b�З�


        //01��02�̃_���[�W�v�Z
        //�_���[�W = (((���x���~2 / 5 + 2)�~�З́~A / D)/ 50 + 2)
        //�~�͈͕␳�~���₱�����␳�~�V�C�␳�~�}���␳�~�����␳
        //�~�^�C�v��v�␳�~�����␳�~�₯�Ǖ␳�~M�~Mprotect

        float da01 = player01.Level * 2 / 5 + 2;

        //�Z�З�

        float WeaponPower = 0;

        if (WN01 == 1)
        {
            WeaponPower = wf9001[1];
        }
        else if (WN01 == 2)
        {
            WeaponPower = wf9002[1];
        }
        else if (WN01 == 3)
        {
            WeaponPower = wf9003[1];
        }
        else if (WN01 == 4)
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


        if (WN01 == 1 && wf9001[4] == 1)
        {
            da02 = player01.AtRl;
            da03 = player02.BtRl;

            Debug.Log("WN01 == 1 && wf9001[4] == 1");

        }
        else if (WN01 == 1 && wf9001[4] == 2)
        {
            da02 = player01.CtRl;
            da03 = player02.DtRl;


        }
        else if (WN01 == 2 && wf9002[4] == 1)
        {
            da02 = player01.AtRl;
            da03 = player02.BtRl;

            Debug.Log("WN01 == 2 && wf9001[4] == 1");

        }
        else if (WN01 == 2 && wf9002[4] == 2)
        {
            da02 = player01.CtRl;
            da03 = player02.DtRl;

            Debug.Log("WN01 == 2 && wf9001[4] == 2");


        }
        else if (WN01 == 3 && wf9003[4] == 1)
        {
            da02 = player01.AtRl;
            da03 = player02.BtRl;

            Debug.Log("WN01 == 3 && wf9001[4] == 1");


        }
        else if (WN01 == 3 && wf9003[4] == 2)
        {
            da02 = player01.CtRl;
            da03 = player02.DtRl;

            Debug.Log("WN01 == 3 && wf9001[4] == 2");


        }
        else if (WN01 == 4 && wf9004[4] == 1)
        {
            da02 = player01.AtRl;
            da03 = player02.BtRl;

            Debug.Log("WN01 == 4 && wf9001[4] == 1");

        }
        else if (WN01 == 4 && wf9004[4] == 2)
        {
            da02 = player01.CtRl;
            da03 = player02.DtRl;
        }
        else
        {

            da02 = 1;
            da03 = 1;


            Debug.Log(" ��������̑I�����s");
        }

        Debug.Log("�U��or���U�̎����l" + da02);
        Debug.Log("���Uor���h�̎����l" + da03);
        #endregion����b�З�
        #region�������N�␳
        //�U���������N�␳
        float da201 = 1;

        if (player01.AtRa == 0) { da201 = 1; }
        else if (player01.AtRa == 1) { da201 = 3 / 2; }
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


        if (WN01 == 1 && wf9001[4] == 1)
        {
            da02R = da201;
            da03R = da302;
        }
        else if (WN01 == 1 && wf9001[4] == 2)
        {
            da02R = da203;
            da03R = da304;
        }
        else if (WN01 == 2 && wf9002[4] == 1)
        {
            da02R = da201;
            da03R = da302;
        }
        else if (WN01 == 2 && wf9002[4] == 2)
        {
            da02R = da203;
            da03R = da304;
        }
        else if (WN01 == 3 && wf9002[4] == 1)
        {
            da02R = da201;
            da03R = da302;
        }
        else if (WN01 == 3 && wf9002[4] == 2)
        {
            da02R = da203;
            da03R = da304;
        }
        else if (WN01 == 4 && wf9002[4] == 1)
        {
            da02R = da201;
            da03R = da302;
        }
        else if (WN01 == 4 && wf9002[4] == 2)
        {
            da02R = da203;
            da03R = da304;
        }
        else
        {
            Debug.Log(" �������ꃉ���N�̑I�����s");

            da02R = 1;
            da03R = 1;

        }
        //�ŏI�З�=��b�З́~�З͕␳/4096
        float da04 = Mathf.Floor(Mathf.Floor(da01 * WeaponPower * da02 * da02R / (da03 * da03R)) / 50 + 2);

        Debug.Log("���������̌v�Z�l" + da04);
        #endregion  �������N�␳
        #region ���͈͕␳�@�e�q���␳�@�V�C�␳
        //�͈͕␳�v�Z

        float da05 = da04;

        //���₱�����␳

        float da06 = da05;

        //�V�C�␳

        float da07 = da06;
        #endregion ���͈͕␳�@�e�q���␳�@�V�C�␳
        #region���}���␳�@�����␳
        //�}���␳
        //�����̉��~�����N�Ƒ���̏㏸�����N�����͂ǂ����悤�H

        float da08 = 0;
        float da08r = Random.Range(1, 25);

        if (da08r == 1)
        {
            Debug.Log("�}���ɓ�������");

            da08 = da07 * 3 / 2;
        }
        else
        {
            da08 = da07;
            Debug.Log("�}���ɓ�����Ȃ�����");
        }



        Debug.Log("�}�����荞��" + da08);

        //�܎̌ܒ���
        float da09 = Mathf.Ceil(da08 - (1 / 2));

        //�_���[�W����p
        //float[] daR01 ={ da09 * 85 / 100, da09 * 86 / 100 , da09 * 87 / 100 ,da09 * 88 / 100 ,
        //                 da09 * 89 / 100 ,da09 * 90 / 100 , da09 * 91 / 100 ,da09 * 92 / 100 ,
        //                 da09 * 93 / 100 ,da09 * 94 / 100 , da09 * 95 / 100 ,da09 * 96 / 100 ,
        //                 da09 * 97 / 100 ,da09 * 98 / 100 , da09 * 99 / 100 ,da09 * 100 / 100 };

        //�����␳�i�؂�̂āj

        float da10 = Random.Range(85, 101);
        Debug.Log("�����␳" + da10 + "%");

        float da11 = Mathf.Floor(da09 * da10 / 100);
        Debug.Log("��������" + da11);

        //float[] daR02 = { Mathf.Floor(daR01[0]),Mathf.Floor(daR01[1]),Mathf.Floor(daR01[2]),Mathf.Floor(daR01[3]),
        //                  Mathf.Floor(daR01[4]),Mathf.Floor(daR01[5]),Mathf.Floor(daR01[6]),Mathf.Floor(daR01[7]),
        //                  Mathf.Floor(daR01[8]),Mathf.Floor(daR01[9]),Mathf.Floor(daR01[10]),Mathf.Floor(daR01[11])};

        #endregion���}���␳�@�����␳
        #region ���^�C�v�␳

        float da13 = 0;     //�Z�^�C�v

        if (WN01 == 1) { da13 = wf9001[0]; }
        else if (WN01 == 2) { da13 = wf9002[0]; }
        else if (WN01 == 3) { da13 = wf9003[0]; }
        else if (WN01 == 4) { da13 = wf9004[0]; }
        else { Debug.Log("�^�C�v�擾���s"); }

        Debug.Log("�Z�^�C�v" + da13);



        //�^�C�v��v�␳(�܎̌ܒ���)
        float da12 = 1;


        if (da13 == player01.type[0])
        {
            Debug.Log("�^�C�v��vON" + da11 * 1.5f);
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
            da12 = Mathf.Ceil(da11);

        }

        Debug.Log("�^�C�v��v�␳����" + da12);

        //�����␳

        float da14 = 0;



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
        else if (da13 == 1 && player02.type[0] == 13) { da14 = 0.5f; }    //��
        else if (da13 == 1 && player02.type[0] == 14) { da14 = 0; }     //��
        else if (da13 == 1 && player02.type[0] == 15) { da14 = 1; }
        else if (da13 == 1 && player02.type[0] == 16) { da14 = 1; }
        else if (da13 == 1 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 1 && player02.type[0] == 18) { da14 = 1; }
        //�U��������
        else if (da13 == 2 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 2 && player02.type[0] == 1) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 2) { da14 = 0.5f; } //��
        else if (da13 == 2 && player02.type[0] == 3) { da14 = 0.5f; } //��
        else if (da13 == 2 && player02.type[0] == 4) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 5) { da14 = 2; }  //��
        else if (da13 == 2 && player02.type[0] == 6) { da14 = 2; }  //�X
        else if (da13 == 2 && player02.type[0] == 7) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 8) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 9) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 10) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 11) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 12) { da14 = 2; }     //��
        else if (da13 == 2 && player02.type[0] == 13) { da14 = 0.5f; } //��
        else if (da13 == 2 && player02.type[0] == 14) { da14 = 1; }     //��
        else if (da13 == 2 && player02.type[0] == 15) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 16) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 17) { da14 = 2; }  //�|
        else if (da13 == 2 && player02.type[0] == 18) { da14 = 1; }
        //�U��������
        else if (da13 == 3 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 3 && player02.type[0] == 1) { da14 = 1; }
        else if (da13 == 3 && player02.type[0] == 2) { da14 = 2; } //��
        else if (da13 == 3 && player02.type[0] == 3) { da14 = 0.5f; } //��
        else if (da13 == 3 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 3 && player02.type[0] == 5) { da14 = 0.5f; }  //��
        else if (da13 == 3 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 3 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 3 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 3 && player02.type[0] == 9) { da14 = 2; }  //�n
        else if (da13 == 3 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 3 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 3 && player02.type[0] == 12) { da14 = 2; }  //��
        else if (da13 == 3 && player02.type[0] == 13) { da14 = 2; }  //��
        else if (da13 == 3 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 3 && player02.type[0] == 15) { da14 = 0.5f; }  //��
        else if (da13 == 3 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 3 && player02.type[0] == 17) { da14 = 2; }  //�|
        else if (da13 == 3 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                    //�U�������d
        else if (da13 == 4 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 4 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 4 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 4 && player02.type[0] == 3) { da14 = 2; } //��
        else if (da13 == 4 && player02.type[0] == 4) { da14 = 0.5f; }   //�d
        else if (da13 == 4 && player02.type[0] == 5) { da14 = 0.5f; }  //��
        else if (da13 == 4 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 4 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 4 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 4 && player02.type[0] == 9) { da14 = 0; }  //�n
        else if (da13 == 4 && player02.type[0] == 10) { da14 = 2; } //��
        else if (da13 == 4 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 4 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 4 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 4 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 4 && player02.type[0] == 15) { da14 = 0.5f; }  //��
        else if (da13 == 4 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 4 && player02.type[0] == 17) { da14 = 1; }  //�|
        else if (da13 == 4 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                    //�U��������
        else if (da13 == 5 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 5 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 5 && player02.type[0] == 2) { da14 = 0.5f; } //��
        else if (da13 == 5 && player02.type[0] == 3) { da14 = 2; } //��
        else if (da13 == 5 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 5 && player02.type[0] == 5) { da14 = 0.5f; }  //��
        else if (da13 == 5 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 5 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 5 && player02.type[0] == 8) { da14 = 0.5f; } //��
        else if (da13 == 5 && player02.type[0] == 9) { da14 = 2; }  //�n
        else if (da13 == 5 && player02.type[0] == 10) { da14 = 0.5f; } //��
        else if (da13 == 5 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 5 && player02.type[0] == 12) { da14 = 0.5f; }  //��
        else if (da13 == 5 && player02.type[0] == 13) { da14 = 2; }  //��
        else if (da13 == 5 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 5 && player02.type[0] == 15) { da14 = 0.5f; }  //��
        else if (da13 == 5 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 5 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 5 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                    //�U�������X
        else if (da13 == 6 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 6 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 6 && player02.type[0] == 2) { da14 = 0.5f; } //��
        else if (da13 == 6 && player02.type[0] == 3) { da14 = 0.5f; } //��
        else if (da13 == 6 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 6 && player02.type[0] == 5) { da14 = 2; }  //��
        else if (da13 == 6 && player02.type[0] == 6) { da14 = 0.5f; }  //�X
        else if (da13 == 6 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 6 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 6 && player02.type[0] == 9) { da14 = 2; }  //�n
        else if (da13 == 6 && player02.type[0] == 10) { da14 = 2; } //��
        else if (da13 == 6 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 6 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 6 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 6 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 6 && player02.type[0] == 15) { da14 = 2; }  //��
        else if (da13 == 6 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 6 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 6 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                    //�U�������i
        else if (da13 == 7 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 7 && player02.type[0] == 1) { da14 = 2; }  //�m
        else if (da13 == 7 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 7 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 7 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 7 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 7 && player02.type[0] == 6) { da14 = 2; }  //�X
        else if (da13 == 7 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 7 && player02.type[0] == 8) { da14 = 0.5f; } //��
        else if (da13 == 7 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 7 && player02.type[0] == 10) { da14 = 0.5f; } //��
        else if (da13 == 7 && player02.type[0] == 11) { da14 = 0.5f; } //��
        else if (da13 == 7 && player02.type[0] == 12) { da14 = 0.5f; }  //��
        else if (da13 == 7 && player02.type[0] == 13) { da14 = 2; }  //��
        else if (da13 == 7 && player02.type[0] == 14) { da14 = 0; }  //��
        else if (da13 == 7 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 7 && player02.type[0] == 16) { da14 = 2; }  //��
        else if (da13 == 7 && player02.type[0] == 17) { da14 = 2; }  //�|
        else if (da13 == 7 && player02.type[0] == 18) { da14 = 0.5f; } //�d
                                                                       //�U��������
        else if (da13 == 8 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 8 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 8 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 8 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 8 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 8 && player02.type[0] == 5) { da14 = 2; }  //��
        else if (da13 == 8 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 8 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 8 && player02.type[0] == 8) { da14 = 0.5f; } //��
        else if (da13 == 8 && player02.type[0] == 9) { da14 = 0.5f; }  //�n
        else if (da13 == 8 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 8 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 8 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 8 && player02.type[0] == 13) { da14 = 0.5f; }  //��
        else if (da13 == 8 && player02.type[0] == 14) { da14 = 0.5f; }  //��
        else if (da13 == 8 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 8 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 8 && player02.type[0] == 17) { da14 = 0; }  //�|
        else if (da13 == 8 && player02.type[0] == 18) { da14 = 2; } //�d
                                                                    //�U�������n��
        else if (da13 == 9 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 9 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 9 && player02.type[0] == 2) { da14 = 2; } //��
        else if (da13 == 9 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 9 && player02.type[0] == 4) { da14 = 2; }   //�d
        else if (da13 == 9 && player02.type[0] == 5) { da14 = 0.5f; }  //��
        else if (da13 == 9 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 9 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 9 && player02.type[0] == 8) { da14 = 2; } //��
        else if (da13 == 9 && player02.type[0] == 9) { da14 = 2; }  //�n
        else if (da13 == 9 && player02.type[0] == 10) { da14 = 0; } //��
        else if (da13 == 9 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 9 && player02.type[0] == 12) { da14 = 0.5f; }  //��
        else if (da13 == 9 && player02.type[0] == 13) { da14 = 2; }  //��
        else if (da13 == 9 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 9 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 9 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 9 && player02.type[0] == 17) { da14 = 2; }  //�|
        else if (da13 == 9 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                    //�U��������s
        else if (da13 == 10 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 10 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 10 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 10 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 10 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 10 && player02.type[0] == 5) { da14 = 2; }  //��
        else if (da13 == 10 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 10 && player02.type[0] == 7) { da14 = 2; } //�i
        else if (da13 == 10 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 10 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 10 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 10 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 10 && player02.type[0] == 12) { da14 = 2; }  //��
        else if (da13 == 10 && player02.type[0] == 13) { da14 = 0.5f; }  //��
        else if (da13 == 10 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 10 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 10 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 10 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 10 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                     //�U��������
        else if (da13 == 11 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 11 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 11 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 11 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 11 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 11 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 11 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 11 && player02.type[0] == 7) { da14 = 2; } //�i
        else if (da13 == 11 && player02.type[0] == 8) { da14 = 2; } //��
        else if (da13 == 11 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 11 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 11 && player02.type[0] == 11) { da14 = 0.5f; } //��
        else if (da13 == 11 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 11 && player02.type[0] == 13) { da14 = 2; }  //��
        else if (da13 == 11 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 11 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 11 && player02.type[0] == 16) { da14 = 0; }  //��
        else if (da13 == 11 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 11 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                     //�U��������
        else if (da13 == 12 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 12 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 12 && player02.type[0] == 2) { da14 = 0.5f; } //��
        else if (da13 == 12 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 12 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 12 && player02.type[0] == 5) { da14 = 2; }  //��
        else if (da13 == 12 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 12 && player02.type[0] == 7) { da14 = 0.5f; } //�i
        else if (da13 == 12 && player02.type[0] == 8) { da14 = 0.5f; } //��
        else if (da13 == 12 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 12 && player02.type[0] == 10) { da14 = 0.5f; } //��
        else if (da13 == 12 && player02.type[0] == 11) { da14 = 2; } //��
        else if (da13 == 12 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 12 && player02.type[0] == 13) { da14 = 2; }  //��
        else if (da13 == 12 && player02.type[0] == 14) { da14 = 0.5f; }  //��
        else if (da13 == 12 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 12 && player02.type[0] == 16) { da14 = 2; }  //��
        else if (da13 == 12 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 12 && player02.type[0] == 18) { da14 = 0.5f; } //�d
                                                                        //�U��������
        else if (da13 == 13 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 13 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 13 && player02.type[0] == 2) { da14 = 2; } //��
        else if (da13 == 13 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 13 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 13 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 13 && player02.type[0] == 6) { da14 = 2; }  //�X
        else if (da13 == 13 && player02.type[0] == 7) { da14 = 0.5f; } //�i
        else if (da13 == 13 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 13 && player02.type[0] == 9) { da14 = 0.5f; }  //�n
        else if (da13 == 13 && player02.type[0] == 10) { da14 = 2; } //��
        else if (da13 == 13 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 13 && player02.type[0] == 12) { da14 = 2; }  //��
        else if (da13 == 13 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 13 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 13 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 13 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 13 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 13 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                     //�U��������
        else if (da13 == 14 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 14 && player02.type[0] == 1) { da14 = 0; }  //�m
        else if (da13 == 14 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 14 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 14 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 14 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 14 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 14 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 14 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 14 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 14 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 14 && player02.type[0] == 11) { da14 = 2; } //��
        else if (da13 == 14 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 14 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 14 && player02.type[0] == 14) { da14 = 2; }  //��
        else if (da13 == 14 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 14 && player02.type[0] == 16) { da14 = 0.5f; }  //��
        else if (da13 == 14 && player02.type[0] == 17) { da14 = 1; }  //�|
        else if (da13 == 14 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                     //�U��������
        else if (da13 == 15 && player02.type[0] == 0) { da14 = 1; }  //�^�C�v�Ȃ�
        else if (da13 == 15 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 15 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 15 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 15 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 15 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 15 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 15 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 15 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 15 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 15 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 15 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 15 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 15 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 15 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 15 && player02.type[0] == 15) { da14 = 2; }  //��
        else if (da13 == 15 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 15 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 15 && player02.type[0] == 18) { da14 = 0; } //�d
                                                                     //�U��������
        else if (da13 == 16 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 16 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 16 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 16 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 16 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 16 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 16 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 16 && player02.type[0] == 7) { da14 = 0.5f; } //�i
        else if (da13 == 16 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 16 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 16 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 16 && player02.type[0] == 11) { da14 = 2; } //��
        else if (da13 == 16 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 16 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 16 && player02.type[0] == 14) { da14 = 2; }  //��
        else if (da13 == 16 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 16 && player02.type[0] == 16) { da14 = 0.5f; }  //��
        else if (da13 == 16 && player02.type[0] == 17) { da14 = 1; }  //�|
        else if (da13 == 16 && player02.type[0] == 18) { da14 = 0.5f; } //�d
                                                                        //�U�������|
        else if (da13 == 17 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 17 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 17 && player02.type[0] == 2) { da14 = 0.5f; } //��
        else if (da13 == 17 && player02.type[0] == 3) { da14 = 0.5f; } //��
        else if (da13 == 17 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 17 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 17 && player02.type[0] == 6) { da14 = 2; }  //�X
        else if (da13 == 17 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 17 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 17 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 17 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 17 && player02.type[0] == 11) { da14 = 2; } //��
        else if (da13 == 17 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 17 && player02.type[0] == 13) { da14 = 2; }  //��
        else if (da13 == 17 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 17 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 17 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 17 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 17 && player02.type[0] == 18) { da14 = 2; } //�d
                                                                     //�U�������d
        else if (da13 == 18 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 18 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 18 && player02.type[0] == 2) { da14 = 0.5f; } //��
        else if (da13 == 18 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 18 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 18 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 18 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 18 && player02.type[0] == 7) { da14 = 2; } //�i
        else if (da13 == 18 && player02.type[0] == 8) { da14 = 0.5f; } //��
        else if (da13 == 18 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 18 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 18 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 18 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 18 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 18 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 18 && player02.type[0] == 15) { da14 = 2; }  //��
        else if (da13 == 18 && player02.type[0] == 16) { da14 = 2; }  //��
        else if (da13 == 18 && player02.type[0] == 17) { da14 = 0.5f; }  //�|
        else if (da13 == 18 && player02.type[0] == 18) { da14 = 1; } //�d
                                                                     //�U�������^�C�v�Ȃ�
        else if (da13 == 19 && player02.type[0] == 0) { da14 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 19 && player02.type[0] == 1) { da14 = 1; }  //�m
        else if (da13 == 19 && player02.type[0] == 2) { da14 = 1; } //��
        else if (da13 == 19 && player02.type[0] == 3) { da14 = 1; } //��
        else if (da13 == 19 && player02.type[0] == 4) { da14 = 1; }   //�d
        else if (da13 == 19 && player02.type[0] == 5) { da14 = 1; }  //��
        else if (da13 == 19 && player02.type[0] == 6) { da14 = 1; }  //�X
        else if (da13 == 19 && player02.type[0] == 7) { da14 = 1; } //�i
        else if (da13 == 19 && player02.type[0] == 8) { da14 = 1; } //��
        else if (da13 == 19 && player02.type[0] == 9) { da14 = 1; }  //�n
        else if (da13 == 19 && player02.type[0] == 10) { da14 = 1; } //��
        else if (da13 == 19 && player02.type[0] == 11) { da14 = 1; } //��
        else if (da13 == 19 && player02.type[0] == 12) { da14 = 1; }  //��
        else if (da13 == 19 && player02.type[0] == 13) { da14 = 1; }  //��
        else if (da13 == 19 && player02.type[0] == 14) { da14 = 1; }  //��
        else if (da13 == 19 && player02.type[0] == 15) { da14 = 1; }  //��
        else if (da13 == 19 && player02.type[0] == 16) { da14 = 1; }  //��
        else if (da13 == 19 && player02.type[0] == 17) { da14 = 1; }  //�|
        else if (da13 == 19 && player02.type[0] == 18) { da14 = 1; } //�d

        else { Debug.Log("��������1���s"); };





        //�Z�^�C�v���h��^�C�v2

        float da15 = 1;

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
        else if (da13 == 1 && player02.type[1] == 13) { da15 = 0.5f; }    //��
        else if (da13 == 1 && player02.type[1] == 14) { da15 = 0; Debug.Log("1��14"); }     //��
        else if (da13 == 1 && player02.type[1] == 15) { da15 = 1; }
        else if (da13 == 1 && player02.type[1] == 16) { da15 = 1; }
        else if (da13 == 1 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
        else if (da13 == 1 && player02.type[1] == 18) { da15 = 1; }
        //�U��������
        else if (da13 == 2 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 2 && player02.type[1] == 1) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 2) { da15 = 0.5f; } //��
        else if (da13 == 2 && player02.type[1] == 3) { da15 = 0.5f; } //��
        else if (da13 == 2 && player02.type[1] == 4) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 5) { da15 = 2; }  //��
        else if (da13 == 2 && player02.type[1] == 6) { da15 = 2; }  //�X
        else if (da13 == 2 && player02.type[1] == 7) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 8) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 9) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 10) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 11) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 12) { da15 = 2; }     //��
        else if (da13 == 2 && player02.type[1] == 13) { da15 = 0.5f; } //��
        else if (da13 == 2 && player02.type[1] == 14) { da15 = 1; }     //��
        else if (da13 == 2 && player02.type[1] == 15) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 16) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 17) { da15 = 2; }  //�|
        else if (da13 == 2 && player02.type[1] == 18) { da15 = 1; }
        //�U��������
        else if (da13 == 3 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 3 && player02.type[1] == 1) { da15 = 1; }
        else if (da13 == 3 && player02.type[1] == 2) { da15 = 2; } //��
        else if (da13 == 3 && player02.type[1] == 3) { da15 = 0.5f; } //��
        else if (da13 == 3 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 3 && player02.type[1] == 5) { da15 = 0.5f; Debug.Log("�����H"); }  //��
        else if (da13 == 3 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 3 && player02.type[1] == 7) { da15 = 1; } //�i
        else if (da13 == 3 && player02.type[1] == 8) { da15 = 1; } //��
        else if (da13 == 3 && player02.type[1] == 9) { da15 = 2; }  //�n
        else if (da13 == 3 && player02.type[1] == 10) { da15 = 1; } //��
        else if (da13 == 3 && player02.type[1] == 11) { da15 = 1; } //��
        else if (da13 == 3 && player02.type[1] == 12) { da15 = 2; }  //��
        else if (da13 == 3 && player02.type[1] == 13) { da15 = 2; }  //��
        else if (da13 == 3 && player02.type[1] == 14) { da15 = 1; }  //��
        else if (da13 == 3 && player02.type[1] == 15) { da15 = 0.5f; }  //��
        else if (da13 == 3 && player02.type[1] == 16) { da15 = 1; }  //��
        else if (da13 == 3 && player02.type[1] == 17) { da15 = 2; }  //�|
        else if (da13 == 3 && player02.type[1] == 18) { da15 = 1; } //�d
        //�U�������d
        else if (da13 == 4 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 4 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 4 && player02.type[1] == 2) { da15 = 1; } //��
        else if (da13 == 4 && player02.type[1] == 3) { da15 = 2; } //��
        else if (da13 == 4 && player02.type[1] == 4) { da15 = 0.5f; }   //�d
        else if (da13 == 4 && player02.type[1] == 5) { da15 = 0.5f; }  //��
        else if (da13 == 4 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 4 && player02.type[1] == 7) { da15 = 1; } //�i
        else if (da13 == 4 && player02.type[1] == 8) { da15 = 1; } //��
        else if (da13 == 4 && player02.type[1] == 9) { da15 = 0; Debug.Log("4��9"); }  //�n
        else if (da13 == 4 && player02.type[1] == 10) { da15 = 2; } //��
        else if (da13 == 4 && player02.type[1] == 11) { da15 = 1; } //��
        else if (da13 == 4 && player02.type[1] == 12) { da15 = 1; }  //��
        else if (da13 == 4 && player02.type[1] == 13) { da15 = 1; }  //��
        else if (da13 == 4 && player02.type[1] == 14) { da15 = 1; }  //��
        else if (da13 == 4 && player02.type[1] == 15) { da15 = 0.5f; }  //��
        else if (da13 == 4 && player02.type[1] == 16) { da15 = 1; }  //��
        else if (da13 == 4 && player02.type[1] == 17) { da15 = 1; }  //�|
        else if (da13 == 4 && player02.type[1] == 18) { da15 = 1; } //�d
        //�U��������
        else if (da13 == 5 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 5 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 5 && player02.type[1] == 2) { da15 = 0.5f; } //��
        else if (da13 == 5 && player02.type[1] == 3) { da15 = 2; } //��
        else if (da13 == 5 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 5 && player02.type[1] == 5) { da15 = 0.5f; }  //��
        else if (da13 == 5 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 5 && player02.type[1] == 7) { da15 = 1; } //�i
        else if (da13 == 5 && player02.type[1] == 8) { da15 = 0.5f; } //��
        else if (da13 == 5 && player02.type[1] == 9) { da15 = 2; }  //�n
        else if (da13 == 5 && player02.type[1] == 10) { da15 = 0.5f; } //��
        else if (da13 == 5 && player02.type[1] == 11) { da15 = 1; } //��
        else if (da13 == 5 && player02.type[1] == 12) { da15 = 0.5f; }  //��
        else if (da13 == 5 && player02.type[1] == 13) { da15 = 2; }  //��
        else if (da13 == 5 && player02.type[1] == 14) { da15 = 1; }  //��
        else if (da13 == 5 && player02.type[1] == 15) { da15 = 0.5f; }  //��
        else if (da13 == 5 && player02.type[1] == 16) { da15 = 1; }  //��
        else if (da13 == 5 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
        else if (da13 == 5 && player02.type[1] == 18) { da15 = 1; } //�d
        //�U�������X
        else if (da13 == 6 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 6 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 6 && player02.type[1] == 2) { da15 = 0.5f; } //��
        else if (da13 == 6 && player02.type[1] == 3) { da15 = 0.5f; } //��
        else if (da13 == 6 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 6 && player02.type[1] == 5) { da15 = 2; }  //��
        else if (da13 == 6 && player02.type[1] == 6) { da15 = 0.5f; }  //�X
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
        else if (da13 == 6 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
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
        else if (da13 == 7 && player02.type[1] == 8) { da15 = 0.5f; } //��
        else if (da13 == 7 && player02.type[1] == 9) { da15 = 1; }  //�n
        else if (da13 == 7 && player02.type[1] == 10) { da15 = 0.5f; } //��
        else if (da13 == 7 && player02.type[1] == 11) { da15 = 0.5f; } //��
        else if (da13 == 7 && player02.type[1] == 12) { da15 = 0.5f; }  //��
        else if (da13 == 7 && player02.type[1] == 13) { da15 = 2; }  //��
        else if (da13 == 7 && player02.type[1] == 14) { da15 = 0; Debug.Log("7��14"); }  //��
        else if (da13 == 7 && player02.type[1] == 15) { da15 = 1; }  //��
        else if (da13 == 7 && player02.type[1] == 16) { da15 = 2; }  //��
        else if (da13 == 7 && player02.type[1] == 17) { da15 = 2; }  //�|
        else if (da13 == 7 && player02.type[1] == 18) { da15 = 0.5f; } //�d
        //�U��������
        else if (da13 == 8 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 8 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 8 && player02.type[1] == 2) { da15 = 1; } //��
        else if (da13 == 8 && player02.type[1] == 3) { da15 = 1; } //��
        else if (da13 == 8 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 8 && player02.type[1] == 5) { da15 = 2; }  //��
        else if (da13 == 8 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 8 && player02.type[1] == 7) { da15 = 1; } //�i
        else if (da13 == 8 && player02.type[1] == 8) { da15 = 0.5f; } //��
        else if (da13 == 8 && player02.type[1] == 9) { da15 = 0.5f; }  //�n
        else if (da13 == 8 && player02.type[1] == 10) { da15 = 1; } //��
        else if (da13 == 8 && player02.type[1] == 11) { da15 = 1; } //��
        else if (da13 == 8 && player02.type[1] == 12) { da15 = 1; }  //��
        else if (da13 == 8 && player02.type[1] == 13) { da15 = 0.5f; }  //��
        else if (da13 == 8 && player02.type[1] == 14) { da15 = 0.5f; }  //��
        else if (da13 == 8 && player02.type[1] == 15) { da15 = 1; }  //��
        else if (da13 == 8 && player02.type[1] == 16) { da15 = 1; }  //��
        else if (da13 == 8 && player02.type[1] == 17) { da15 = 0; Debug.Log("8��17"); }  //�|
        else if (da13 == 8 && player02.type[1] == 18) { da15 = 2; } //�d
        //�U�������n��
        else if (da13 == 9 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 9 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 9 && player02.type[1] == 2) { da15 = 2; } //��
        else if (da13 == 9 && player02.type[1] == 3) { da15 = 1; } //��
        else if (da13 == 9 && player02.type[1] == 4) { da15 = 2; }   //�d
        else if (da13 == 9 && player02.type[1] == 5) { da15 = 0.5f; }  //��
        else if (da13 == 9 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 9 && player02.type[1] == 7) { da15 = 1; } //�i
        else if (da13 == 9 && player02.type[1] == 8) { da15 = 2; } //��
        else if (da13 == 9 && player02.type[1] == 9) { da15 = 2; }  //�n
        else if (da13 == 9 && player02.type[1] == 10) { da15 = 0; Debug.Log("9��10"); } //��
        else if (da13 == 9 && player02.type[1] == 11) { da15 = 1; } //��
        else if (da13 == 9 && player02.type[1] == 12) { da15 = 0.5f; }  //��
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
        else if (da13 == 10 && player02.type[1] == 13) { da15 = 0.5f; }  //��
        else if (da13 == 10 && player02.type[1] == 14) { da15 = 1; }  //��
        else if (da13 == 10 && player02.type[1] == 15) { da15 = 1; }  //��
        else if (da13 == 10 && player02.type[1] == 16) { da15 = 1; }  //��
        else if (da13 == 10 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
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
        else if (da13 == 11 && player02.type[1] == 11) { da15 = 0.5f; } //��
        else if (da13 == 11 && player02.type[1] == 12) { da15 = 1; }  //��
        else if (da13 == 11 && player02.type[1] == 13) { da15 = 2; }  //��
        else if (da13 == 11 && player02.type[1] == 14) { da15 = 1; }  //��
        else if (da13 == 11 && player02.type[1] == 15) { da15 = 1; }  //��
        else if (da13 == 11 && player02.type[1] == 16) { da15 = 0; Debug.Log("11��16"); }  //��
        else if (da13 == 11 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
        else if (da13 == 11 && player02.type[1] == 18) { da15 = 1; } //�d
        //�U��������
        else if (da13 == 12 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 12 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 12 && player02.type[1] == 2) { da15 = 0.5f; } //��
        else if (da13 == 12 && player02.type[1] == 3) { da15 = 1; } //��
        else if (da13 == 12 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 12 && player02.type[1] == 5) { da15 = 2; }  //��
        else if (da13 == 12 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 12 && player02.type[1] == 7) { da15 = 0.5f; } //�i
        else if (da13 == 12 && player02.type[1] == 8) { da15 = 0.5f; } //��
        else if (da13 == 12 && player02.type[1] == 9) { da15 = 1; }  //�n
        else if (da13 == 12 && player02.type[1] == 10) { da15 = 0.5f; } //��
        else if (da13 == 12 && player02.type[1] == 11) { da15 = 2; } //��
        else if (da13 == 12 && player02.type[1] == 12) { da15 = 1; }  //��
        else if (da13 == 12 && player02.type[1] == 13) { da15 = 2; }  //��
        else if (da13 == 12 && player02.type[1] == 14) { da15 = 0.5f; }  //��
        else if (da13 == 12 && player02.type[1] == 15) { da15 = 1; }  //��
        else if (da13 == 12 && player02.type[1] == 16) { da15 = 2; }  //��
        else if (da13 == 12 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
        else if (da13 == 12 && player02.type[1] == 18) { da15 = 0.5f; } //�d
        //�U��������
        else if (da13 == 13 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 13 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 13 && player02.type[1] == 2) { da15 = 2; } //��
        else if (da13 == 13 && player02.type[1] == 3) { da15 = 1; } //��
        else if (da13 == 13 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 13 && player02.type[1] == 5) { da15 = 1; }  //��
        else if (da13 == 13 && player02.type[1] == 6) { da15 = 2; }  //�X
        else if (da13 == 13 && player02.type[1] == 7) { da15 = 0.5f; } //�i
        else if (da13 == 13 && player02.type[1] == 8) { da15 = 1; } //��
        else if (da13 == 13 && player02.type[1] == 9) { da15 = 0.5f; }  //�n
        else if (da13 == 13 && player02.type[1] == 10) { da15 = 2; } //��
        else if (da13 == 13 && player02.type[1] == 11) { da15 = 1; } //��
        else if (da13 == 13 && player02.type[1] == 12) { da15 = 2; }  //��
        else if (da13 == 13 && player02.type[1] == 13) { da15 = 1; }  //��
        else if (da13 == 13 && player02.type[1] == 14) { da15 = 1; }  //��
        else if (da13 == 13 && player02.type[1] == 15) { da15 = 1; }  //��
        else if (da13 == 13 && player02.type[1] == 16) { da15 = 1; }  //��
        else if (da13 == 13 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
        else if (da13 == 13 && player02.type[1] == 18) { da15 = 1; } //�d
        //�U��������
        else if (da13 == 14 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 14 && player02.type[1] == 1) { da15 = 0; Debug.Log("14��1"); }  //�m
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
        else if (da13 == 14 && player02.type[1] == 16) { da15 = 0.5f; }  //��
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
        else if (da13 == 15 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
        else if (da13 == 15 && player02.type[1] == 18) { da15 = 0; Debug.Log("15��18"); } //�d
        //�U��������
        else if (da13 == 16 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 16 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 16 && player02.type[1] == 2) { da15 = 1; } //��
        else if (da13 == 16 && player02.type[1] == 3) { da15 = 1; } //��
        else if (da13 == 16 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 16 && player02.type[1] == 5) { da15 = 1; }  //��
        else if (da13 == 16 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 16 && player02.type[1] == 7) { da15 = 0.5f; } //�i
        else if (da13 == 16 && player02.type[1] == 8) { da15 = 1; } //��
        else if (da13 == 16 && player02.type[1] == 9) { da15 = 1; }  //�n
        else if (da13 == 16 && player02.type[1] == 10) { da15 = 1; } //��
        else if (da13 == 16 && player02.type[1] == 11) { da15 = 2; } //��
        else if (da13 == 16 && player02.type[1] == 12) { da15 = 1; }  //��
        else if (da13 == 16 && player02.type[1] == 13) { da15 = 1; }  //��
        else if (da13 == 16 && player02.type[1] == 14) { da15 = 2; }  //��
        else if (da13 == 16 && player02.type[1] == 15) { da15 = 1; }  //��
        else if (da13 == 16 && player02.type[1] == 16) { da15 = 0.5f; }  //��
        else if (da13 == 16 && player02.type[1] == 17) { da15 = 1; }  //�|
        else if (da13 == 16 && player02.type[1] == 18) { da15 = 0.5f; } //�d
        //�U�������|
        else if (da13 == 17 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 17 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 17 && player02.type[1] == 2) { da15 = 0.5f; } //��
        else if (da13 == 17 && player02.type[1] == 3) { da15 = 0.5f; } //��
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
        else if (da13 == 17 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
        else if (da13 == 17 && player02.type[1] == 18) { da15 = 2; } //�d
        //�U�������d
        else if (da13 == 18 && player02.type[1] == 0) { da15 = 1; }      //�^�C�v�Ȃ�
        else if (da13 == 18 && player02.type[1] == 1) { da15 = 1; }  //�m
        else if (da13 == 18 && player02.type[1] == 2) { da15 = 0.5f; } //��
        else if (da13 == 18 && player02.type[1] == 3) { da15 = 1; } //��
        else if (da13 == 18 && player02.type[1] == 4) { da15 = 1; }   //�d
        else if (da13 == 18 && player02.type[1] == 5) { da15 = 1; }  //��
        else if (da13 == 18 && player02.type[1] == 6) { da15 = 1; }  //�X
        else if (da13 == 18 && player02.type[1] == 7) { da15 = 2; } //�i
        else if (da13 == 18 && player02.type[1] == 8) { da15 = 0.5f; } //��
        else if (da13 == 18 && player02.type[1] == 9) { da15 = 1; }  //�n
        else if (da13 == 18 && player02.type[1] == 10) { da15 = 1; } //��
        else if (da13 == 18 && player02.type[1] == 11) { da15 = 1; } //��
        else if (da13 == 18 && player02.type[1] == 12) { da15 = 1; }  //��
        else if (da13 == 18 && player02.type[1] == 13) { da15 = 1; }  //��
        else if (da13 == 18 && player02.type[1] == 14) { da15 = 1; }  //��
        else if (da13 == 18 && player02.type[1] == 15) { da15 = 2; }  //��
        else if (da13 == 18 && player02.type[1] == 16) { da15 = 2; }  //��
        else if (da13 == 18 && player02.type[1] == 17) { da15 = 0.5f; }  //�|
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

        Debug.Log("da13=" + da13 + ",da14=" + da14 + ",da15=" + da15);

        //�^�C�v�������v����
        float da16 = da14 * da15;
        if (da16 == 1) { Debug.Log("�������{"); }
        else if (da16 == 4) { Debug.Log("���ʂ͔��Q��(4�{)"); }
        else if (da16 == 2) { Debug.Log("���ʂ͔��Q��(2�{)"); }
        else if (da16 == 0.5f) { Debug.Log("���ʂ͂��܂ЂƂ̂悤��(0.5�{)"); }
        else if (da16 == 0.25f) { Debug.Log("���ʂ͂��܂ЂƂ̂悤��(0.25�{)"); }
        else if (da16 == 0f) { Debug.Log("���ʂ͂Ȃ��悤��"); }
        else { Debug.Log("�������v���莸�s"); }

        float da17 = Mathf.Floor(da12 * da16);
        Debug.Log("���������" + da17);

        #endregion ���^�C�v�␳
        #region ���Ώ��@M�␳
        //�₯�ǔ���
        float da18 = da17;

        //M�␳(�Ǖ␳�~�u���C���t�H�[�X�␳�~�X�i�C�p�[�␳�~
        //����߂��˕␳�~���ӂ��ӂق̂��␳�~Mhalf�~Mfilter�~
        //�t�����h�K�[�h�␳�~������̂��ѕ␳�~���g���m�[���␳�~
        //���̂��̂��ܕ␳�~�����̎��␳�~Mtwice(�����_�ȉ��𒀈�l�̌ܓ�)(�ŏI�I�Ɍ܎̌ܒ���)

        float da19 = Mathf.Ceil(da18 - 0.5f);

        //Mprotect�␳(Z���U/�_�C�}�b�N�X�킴���܂����ԂȂǂŌy�����ꂽ�Ƃ�0.25�{)

        float da20 = da19;

        Debug.Log("�ŏI�_���[�W�֐��l" + da20);
        #endregion ���Ώ��@M�␳
        #region ���ŏI�_���[�W�v�Z
        //�ŏI�_���[�W�v�Z

        player02.HPNow -= da20;

        player02.statusDisplay();

        Debug.Log("�v���C���[02�̃����X�^�[��HP" + player02.HPNow + "/" + player02.HPMax);


        string WNlog = "";

        if (WN01 == 1) { WNlog = "���肩����"; }
        else if (WN01 == 2) { WNlog = "������������"; }
        else if (WN01 == 3) { WNlog = "�Ƃтǂ���"; }
        else if (WN01 == 4) { WNlog = "������"; }


        UImessage.GetComponent<Text>().text =
        "�v���C���[01�̃����X�^�[�̍U���I  " + WNlog + "!! \n" +
        "�}������" + da08r + "/24 \n " +
        "�����␳" + da10 + "% \n" +
        "�^�C�v����" + da16 + "�{ \n" +
        "�_���[�W" + da20;


    }
    //�_���[�W�v�Z��
    #endregion ���ŏI�_���[�W�v�Z
    #endregion ���_���[�W�v�Z
}
