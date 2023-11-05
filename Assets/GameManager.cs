using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI���i
using UnityEngine.UI;



public partial class GameManager : MonoBehaviour
{
    #region ���I�u�W�F�N�g���̒�`

    //�X�e�C�g�ԍ�
    private int stateNumber = 0;

    //�ėp�^�C�}�[
    private float timeCounter = 0.0f;

    //UI ���b�Z�[�W
    public GameObject UImessage;

    //UI �X�e�C�g�ԍ��̕\��
    public GameObject UIStateNumber;

    //UI �����X�^�[�̕\��
    public GameObject UIplayer01text;
    public GameObject UIplayer02text;

    //UI �����X�^�[HP
    public GameObject Ul01HPtext;
    public GameObject Ul02HPtext;

    //UI �R�}���h
    public GameObject UIchoice01;
    public GameObject UIchoice02;

    //UI �Z
    public GameObject UIweapon01;
    public GameObject UIweapon02;

    //UI�X�e�[�^�X
    public GameObject UIStatus01;
    public GameObject UIStatus02;

    //�v���C���[��UI����̌���
    //0=���I���A1=���������A2=���ꂩ�� 3=�X�e�[�^�X
    private int choiceCommand01 = 0;
    private int choiceCommand02 = 0;

    //�v���C���[�̕���I���̌���
    //0=���I���A1=����1�A�c�c
    private int WN01 = 0;
    private int WN02 = 0;


    //�����X�^�[�̌�։��
    public GameObject ChangeMonster01;
    public GameObject ChangeMonster02;



    //�s���������ǂ����̊m�F
    //0=���s���A1=�s���ς�
    private int ActionCheck01 = 0;
    private int ActionCheck02 = 0;


    //�c�胂���X�^�[��
    private int MonsterCount01 = 6;
    private int MonsterCount02 = 6;


    //�Z�e�L�X�g
    public GameObject TextWeapon01Player01;
    public GameObject TextWeapon02Player01;
    public GameObject TextWeapon03Player01;
    public GameObject TextWeapon04Player01;
    public GameObject TextWeapon01Player02;
    public GameObject TextWeapon02Player02;
    public GameObject TextWeapon03Player02;
    public GameObject TextWeapon04Player02;


    //���C�t�o�[
    public GameObject UIHPnow1;
    public GameObject UIHPnow2;


    //���݂̃����X�^�[�̊Ǘ��ԍ�
    private int PL01 = 5;
    private int PL02 = 6;


    //�����X�^�[�̃v���n�u
    public GameObject[] PL01prefab = new GameObject[10];
    public GameObject[] PL02prefab = new GameObject[10];


    //����ւ��{�^��
    public GameObject[] PL01changeButton = new GameObject[10];
    public GameObject[] PL02changeButton = new GameObject[10];

    //SE
    public AudioClip SESystem;
   

    #endregion�@���I�u�W�F�N�g���̒�`
    #region ���X�^�[�g���ɐ����������
    void Start()
    {
        //�v���C���[1���̐���(�ҋ@)
        Instantiate(PL01prefab[1]);
        Instantiate(PL01prefab[2]);
        Instantiate(PL01prefab[3]);
        Instantiate(PL01prefab[4]);
        Instantiate(PL01prefab[6]);

        //�v���C���[1���̐���(5)
        Instantiate(PL01prefab[PL01]).GetComponent<Monster01Player01>().stateNumber = 0;

        //�v���C���[1���̐���(�ҋ@)
        Instantiate(PL02prefab[1]);
        Instantiate(PL02prefab[2]);
        Instantiate(PL02prefab[3]);
        Instantiate(PL02prefab[4]);
        Instantiate(PL02prefab[5]);

        //�v���C���[2���̐���(6)
        Instantiate(PL02prefab[PL02]).GetComponent<Monster01Player02>().stateNumber = 0;



    }
    #endregion ���X�^�[�g���ɐ����������
    #region�@���A�b�v�f�[�g
    #region �������ݒ�
    void Update()
    {
        //�^�C�}�[
        timeCounter += Time.deltaTime;

        //�X�e�C�g�ԍ���\������
        UIStateNumber.GetComponent<Text>().text = "" + stateNumber;


        //player01,02���`����

        Monster01Player01 player01;
        player01 = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)").GetComponent<Monster01Player02>();



        //���C�t�o�[ (�}�C�i�X�ɂȂ�����0�ɂ���j
        UIHPnow1.GetComponent<RectTransform>().localScale = new Vector3((player01.HPNow / player01.HPMax), 1.0f, 1.0f);

        if ((player01.HPNow / player01.HPMax) <= 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
        if ((player01.HPNow / player01.HPMax) <= 0.2f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
        if (player01.HPNow <= 0) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }


        UIHPnow2.GetComponent<RectTransform>().localScale = new Vector3((player02.HPNow / player02.HPMax), 1.0f, 1.0f);
        if ((player02.HPNow / player02.HPMax) <= 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
        if ((player02.HPNow / player02.HPMax) <= 0.2f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
        if (player02.HPNow <= 0) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }

        //�����X�^�[���O
        if (player01.gender == 0)
        { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ������"; }
        else if (player01.gender == 1)
        { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }
        else if (player01.gender == 2)
        { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }

        if (player02.gender == 0)
        { UIplayer02text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ������"; }
        else if (player02.gender == 1)
        { UIplayer02text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }
        else if (player02.gender == 2)
        { UIplayer02text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }




        //public GameObject UIplayer02text;


        #endregion �������ݒ�ButtonBattlePlayer01()
        #region�@���X�e�C�g0�@�J�n���


        //�����X�^�[���o�ꂷ�鉉�o
        if (stateNumber == 0)
        {
            if (timeCounter > 3.0f)
            {
                UImessage.GetComponent<Text>().text = "�ΐ�J�n";




                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                //�X�e�C�g�ύX
                stateNumber = 101;
            }
        }

        #endregion�@���X�e�C�g0�@�J�n���
        #region���X�e�C�g100�ԑ�@�v���C���[01�̑I�����
        else if (stateNumber == 101)
        {


            //HP��\��
            Ul01HPtext.GetComponent<Text>().text = "HP:" + player01.HPNow + "/" + player01.HPMax;
            Ul02HPtext.GetComponent<Text>().text = "HP:" + player02.HPNow + "/" + player02.HPMax;

            //���C�t�o�[ (�}�C�i�X�ɂȂ�����0�ɂ���j
            if ((player01.HPNow / player01.HPMax) > 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
            if ((player01.HPNow / player01.HPMax) <= 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
            if ((player01.HPNow / player01.HPMax) <= 0.2f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
            if (player01.HPNow <= 0) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }



            if ((player02.HPNow / player02.HPMax) > 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
            if ((player02.HPNow / player02.HPMax) <= 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
            if ((player02.HPNow / player02.HPMax) <= 0.2f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
            if (player02.HPNow <= 0) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }




            if (timeCounter > 3.0f)
            {




                //���I��
                choiceCommand01 = 0;



                //�s���m�Foff
                ActionCheck01 = 0;
                ActionCheck02 = 0;

                //
                UImessage.GetComponent<Text>().text = "�s���I��";

                //�R�}���hON
                UIchoice01.SetActive(true);

                //�X�e�C�g�ύX
                stateNumber = 102;
            }
        }



        //�R�}���h���I�������܂ł̑ҋ@
        else if (stateNumber == 102)
        {

            UIchoice02.SetActive(false);


            if (choiceCommand01 == 1)
            {



                Debug.Log("�v���C���[01�̍s���I��:����������I��");

                //���I��
                WN01 = 0;
                WN02 = 0;


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


            if (choiceCommand01 == 2)
            {

                ChangeMonster01.SetActive(true);


                //�X�e�C�g�ύX��01�̋Z�I�����
                stateNumber = 104;


            }




            if (choiceCommand01 == 3)
            {

                UIStatus01.SetActive(true);


                //�X�e�C�g�ύX
                stateNumber = 105;


            }

        }
        //�Z�I��(�v���C���[01)
        else if (stateNumber == 103)
        {

            //���I��
            choiceCommand02 = 0;


            if (WN01 == 1)
            {
                Debug.Log("�v���C���[01�͋Z" + WN01 + "��I��");


                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("�v���C���[02�̍s���I��");
            }
            else if (WN01 == 2)
            {
                Debug.Log("�v���C���[01�͋Z" + WN01 + "��I��");



                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("�v���C���[02�̍s���I��");
            }
            else if (WN01 == 3)
            {
                Debug.Log("�v���C���[01�͋Z" + WN01 + "��I��");



                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("�v���C���[02�̍s���I��");
            }
            else if (WN01 == 4)
            {
                Debug.Log("�v���C���[01�͋Z" + WN01 + "��I��");



                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("�v���C���[02�̍s���I��");
            }


        }


        else if (stateNumber == 104)
        {
            Monster01Player01 monster01;
            monster01 = GameObject.Find("Monster01Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster01.HPNow <= 0)
            {
                //��
                PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL01changeButton[1].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL01changeButton[1].GetComponent<Button>().enabled = true;
            }


            Monster01Player01 monster02;
            monster02 = GameObject.Find("Monster02Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster02.HPNow <= 0)
            {
                //��
                PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL01changeButton[2].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL01changeButton[2].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster03;
            monster03 = GameObject.Find("Monster03Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster03.HPNow <= 0)
            {
                //��
                PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL01changeButton[3].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL01changeButton[3].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster04;
            monster04 = GameObject.Find("Monster04Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster04.HPNow <= 0)
            {
                //��
                PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL01changeButton[4].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL01changeButton[4].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster05;
            monster05 = GameObject.Find("Monster05Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster05.HPNow <= 0)
            {
                //��
                PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL01changeButton[5].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL01changeButton[5].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster06;
            monster06 = GameObject.Find("Monster06Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster06.HPNow <= 0)
            {
                //��
                PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL01changeButton[6].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL01changeButton[6].GetComponent<Button>().enabled = true;

            }



            //��ւ��������X�^�[��UI�p�l��
            if (player01.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ������"; }
            else if (player01.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }
            else if (player01.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }

            if (player02.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ������"; }
            else if (player02.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }
            else if (player02.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }



        }




        //�X�e�[�^�X�m�F���
        else if (stateNumber == 105)
        {
            if (Input.GetMouseButtonDown(0))
            {

                UIStatus01.SetActive(false);
                UIchoice01.SetActive(true);

                choiceCommand01 = 0;

                stateNumber = 102;
            }

        }

        else if (stateNumber == 106)
        {


            if (timeCounter > 3.0f)
            {

                ChangeMonster01.SetActive(true);

                Monster01Player01 monster01;
                monster01 = GameObject.Find("Monster01Player01(Clone)").GetComponent<Monster01Player01>();

                if (monster01.HPNow <= 0)
                {
                    //��
                    PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    //�{�^���������Ȃ�����
                    PL01changeButton[1].GetComponent<Button>().enabled = false;
                }
                else
                {
                    //��
                    PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    //�{�^����������
                    PL01changeButton[1].GetComponent<Button>().enabled = true;
                }


                Monster01Player01 monster02;
                monster02 = GameObject.Find("Monster02Player01(Clone)").GetComponent<Monster01Player01>();

                if (monster02.HPNow <= 0)
                {
                    //��
                    PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    //�{�^���������Ȃ�����
                    PL01changeButton[2].GetComponent<Button>().enabled = false;
                }
                else
                {
                    //��
                    PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    //�{�^����������
                    PL01changeButton[2].GetComponent<Button>().enabled = true;

                }

                Monster01Player01 monster03;
                monster03 = GameObject.Find("Monster03Player01(Clone)").GetComponent<Monster01Player01>();

                if (monster03.HPNow <= 0)
                {
                    //��
                    PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    //�{�^���������Ȃ�����
                    PL01changeButton[3].GetComponent<Button>().enabled = false;
                }
                else
                {
                    //��
                    PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    //�{�^����������
                    PL01changeButton[3].GetComponent<Button>().enabled = true;

                }

                Monster01Player01 monster04;
                monster04 = GameObject.Find("Monster04Player01(Clone)").GetComponent<Monster01Player01>();

                if (monster04.HPNow <= 0)
                {
                    //��
                    PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    //�{�^���������Ȃ�����
                    PL01changeButton[4].GetComponent<Button>().enabled = false;
                }
                else
                {
                    //��
                    PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    //�{�^����������
                    PL01changeButton[4].GetComponent<Button>().enabled = true;

                }

                Monster01Player01 monster05;
                monster05 = GameObject.Find("Monster05Player01(Clone)").GetComponent<Monster01Player01>();

                if (monster05.HPNow <= 0)
                {
                    //��
                    PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    //�{�^���������Ȃ�����
                    PL01changeButton[5].GetComponent<Button>().enabled = false;
                }
                else
                {
                    //��
                    PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    //�{�^����������
                    PL01changeButton[5].GetComponent<Button>().enabled = true;

                }

                Monster01Player01 monster06;
                monster06 = GameObject.Find("Monster06Player01(Clone)").GetComponent<Monster01Player01>();

                if (monster06.HPNow <= 0)
                {
                    //��
                    PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    //�{�^���������Ȃ�����
                    PL01changeButton[6].GetComponent<Button>().enabled = false;
                }
                else
                {
                    //��
                    PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    //�{�^����������
                    PL01changeButton[6].GetComponent<Button>().enabled = true;

                }

                if (player01.gender == 0)
                { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ������"; }
                else if (player01.gender == 1)
                { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }
                else if (player01.gender == 2)
                { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }

                if (player02.gender == 0)
                { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ������"; }
                else if (player02.gender == 1)
                { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }
                else if (player02.gender == 2)
                { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }

            }
        }



        #endregion���X�e�C�g100�ԑ�@�v���C���[01�̑I�����
        #region�@���X�e�C�g200�ԑ�@�v���C���[02�̑I�����
        //�s���I���v���C���[02
        else if (stateNumber == 202)
        {


            if (choiceCommand02 == 1)
            {
                //���I��
                WN02 = 0;
                //�R�}���hON
                UIweapon02.SetActive(true);
                Debug.Log("�v���C���[02�̍s���I��:����������I��");


                //�Z�\�����Z�b�g
                //string wn9001 = "���肩����";
                //int[] wf9001 = { 1, 50, 100, 10, 1, 0 };

                //string wn9002 = "������������";
                //int[] wf9002 = { 2, 100, 80, 10, 1, 0 };

                //string wn9003 = "�Ƃтǂ���";
                //int[] wf9003 = { 3, 80, 100, 10, 2, 0 };

                //string wn9004 = "������";
                //int[] wf9004 = { 4, 0, 100, 10, 2, 0 };

                TextWeapon01Player02.GetComponent<Text>().text = "�Œ�30" ;
                TextWeapon02Player02.GetComponent<Text>().text = "�Œ�100" ;
                TextWeapon03Player02.GetComponent<Text>().text = "�Œ�200";
                TextWeapon04Player02.GetComponent<Text>().text = "�Œ�300";

                //�X�e�C�g�ύX
                stateNumber = 203;
                Debug.Log("�v���C���[02�̋Z�I��");
            }


            if (choiceCommand02 == 2)
            {

                ChangeMonster02.SetActive(true);



                //�X�e�C�g�ύX
                stateNumber = 204;

            }



            if (choiceCommand02 == 3)
            {

                UIStatus02.SetActive(true);


                //�X�e�C�g�ύX��02�̌�։��
                stateNumber = 205;
            }






        }
        //�Z�I���v���C���[02
        else if (stateNumber == 203)
        {

            if (WN02 != 0)
            {

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                stateNumber = 301;
                Debug.Log("�v���C���[02�͋Z��I��");
            }
        }

        //�����X�^�[���
        else if (stateNumber == 204)
        {
            Monster01Player02 monster01;
            monster01 = GameObject.Find("Monster01Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster01.HPNow <= 0)
            {
                //��
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[1].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[1].GetComponent<Button>().enabled = true;
            }


            Monster01Player02 monster02;
            monster02 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster02.HPNow <= 0)
            {
                //��
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[2].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[2].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster03;
            monster03 = GameObject.Find("Monster03Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster03.HPNow <= 0)
            {
                //��
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[3].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[3].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster04;
            monster04 = GameObject.Find("Monster04Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster04.HPNow <= 0)
            {
                //��
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[4].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[4].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster05;
            monster05 = GameObject.Find("Monster05Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster05.HPNow <= 0)
            {
                //��
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[5].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[5].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster06;
            monster06 = GameObject.Find("Monster06Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster06.HPNow <= 0)
            {
                //��
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[6].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[6].GetComponent<Button>().enabled = true;

            }



            //��ւ��������X�^�[��UI�p�l��
            if (player01.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ������"; }
            else if (player01.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }
            else if (player01.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }

            if (player02.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ������"; }
            else if (player02.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }
            else if (player02.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }








        }


        //�X�e�[�^�X�m�F
        else if (stateNumber == 205)
        {
            if (Input.GetMouseButtonDown(0))
            {

                UIStatus02.SetActive(false);
                UIchoice02.SetActive(true);

                choiceCommand02 = 0;

                stateNumber = 202;
            }

        }


        //�s���I���v���C���[02
        else if (stateNumber == 206)
        {
            ChangeMonster02.SetActive(true);

            Monster01Player02 monster01;
            monster01 = GameObject.Find("Monster01Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster01.HPNow <= 0)
            {
                //��
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[1].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[1].GetComponent<Button>().enabled = true;
            }


            Monster01Player02 monster02;
            monster02 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster02.HPNow <= 0)
            {
                //��
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[2].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[2].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster03;
            monster03 = GameObject.Find("Monster03Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster03.HPNow <= 0)
            {
                //��
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[3].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[3].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster04;
            monster04 = GameObject.Find("Monster04Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster04.HPNow <= 0)
            {
                //��
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[4].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[4].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster05;
            monster05 = GameObject.Find("Monster05Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster05.HPNow <= 0)
            {
                //��
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[5].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[5].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster06;
            monster06 = GameObject.Find("Monster06Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster06.HPNow <= 0)
            {
                //��
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //�{�^���������Ȃ�����
                PL02changeButton[6].GetComponent<Button>().enabled = false;
            }
            else
            {
                //��
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //�{�^����������
                PL02changeButton[6].GetComponent<Button>().enabled = true;

            }



            //��ւ��������X�^�[��UI�p�l��
            if (player01.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ������"; }
            else if (player01.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }
            else if (player01.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL01.ToString("D2") + "�@Lv:50 ��"; }

            if (player02.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ������"; }
            else if (player02.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }
            else if (player02.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "�����X�^�[" + PL02.ToString("D2") + "�@Lv:50 ��"; }





        }


        #endregion�@���X�e�C�g200�ԑ�@�v���C���[02�̑I�����
        #region�@���X�e�C�g300�ԑ�@�ΐ풆
        //�퓬�J�n

        else if (stateNumber == 301)
        {


            if (timeCounter > 0.5f)
            {
                timeCounter = 0.0f;

                UImessage.GetComponent<Text>().text = "�s���J�n";

                stateNumber = 304;

            }

        }

        else if (stateNumber == 302)
        {

            if (timeCounter > 1.5f)
            {

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                //�v���C���[01�̍s���ɐi��
                stateNumber = 311;


            }
        }

        else if (stateNumber == 303)
        {
            if (timeCounter > 1.5f)
            {

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;
                //�v���C���[01�̍s���ɐi��
                stateNumber = 312;

            }

        }

        else if (stateNumber == 304)
        {
            if (timeCounter > 1.0f)
            {

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

                    UImessage.GetComponent<Text>().text = ("�v���C���[01�̕�������");

                    //player01����U������
                    stateNumber = 311;

                }

                else if (player01.StRl < player02.StRl)
                {

                    UImessage.GetComponent<Text>().text = ("�v���C���[02�̕�������");

                    //player01����U������
                    stateNumber = 312;

                }

                else
                {
                    //  Debug.Log("����");

                    //��������
                    if (Random.Range(1, 3) < 1.5f)

                    {
                        UImessage.GetComponent<Text>().text = ("�����Ńv���C���[01���D��");
                        stateNumber = 311;
                    }
                    else
                    {
                        UImessage.GetComponent<Text>().text = ("�����Ńv���C���[02���D��");
                        stateNumber = 312;
                    }

                }
            }
        }
        //�v���C���[01�̍U��
        else if (stateNumber == 311)
        {
            if (timeCounter > 1.0f)
            {

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;


                //�s���m�Fon
                ActionCheck01 = 1;


                //�U�����[�V����


                if (WN01 == 1) { player01.requestAttack(1); }
                else if (WN01 == 2) { player01.requestAttack(2); }
                else if (WN01 == 3) { player01.requestAttack(3); }
                else if (WN01 == 4) { player01.requestAttack(4); }



                //�U���֐�
                PlayerAttack01();



                //�_���[�W���[�V����
                player02.requestDamage();


                Ul02HPtext.GetComponent<Text>().text = "HP:" + player02.HPNow + "/" + player02.HPMax;
                if (player02.HPNow <= 0)
                { Ul02HPtext.GetComponent<Text>().text = "HP:�Ђ�"; }


                //���C�t�o�[ (�}�C�i�X�ɂȂ����獕�ɂ���j
                if ((player01.HPNow / player01.HPMax) > 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
                if ((player01.HPNow / player01.HPMax) <= 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
                if ((player01.HPNow / player01.HPMax) <= 0.2f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
                if (player01.HPNow <= 0) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }



                if ((player02.HPNow / player02.HPMax) > 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
                if ((player02.HPNow / player02.HPMax) <= 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
                if ((player02.HPNow / player02.HPMax) <= 0.2f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
                if (player02.HPNow <= 0) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }







                //�X�e�C�g�ύX


                if (player02.HPNow <= 0)
                {

                    //�v���C���[02���|���
                    player02.requestDeath();

                    //�����X�^�[�J�E���g��-1����
                    MonsterCount02 -= 1;
                    Debug.Log("02���̎c��" + this.MonsterCount02);

                    //�Q�[���N���A���
                    stateNumber = 401;

                }
                // �v���C���[02�����s���Ȃ�X�e�C�g312�Ɉړ�
                else if (ActionCheck02 == 0)
                {

                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;

                    stateNumber = 303;

                }

                //�v���C���[02���s���ςȂ�X�e�C�g101�Ɉړ�
                else
                {
                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;

                    stateNumber = 101;

                }
            }
        }

        //02��01�̃_���[�W�v�Z

        else if (stateNumber == 312)
        {
            if (timeCounter > 1.0f)
            {

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;


                //�s���m�Fon
                ActionCheck02 = 1;


                // �U�����[�V����
                player02.requestAttack(WN02);


                //�_���[�W�v�Z
                if (WN02 == 1)
                {
                    player01.HPNow -= 30;
                    UImessage.GetComponent<Text>().text = "�v���C���[02���̍U���I\n �_���[�W 30";
                }

                else�@if(WN02 ==2)
                {
                    player01.HPNow -= 100;
                    UImessage.GetComponent<Text>().text = "�v���C���[02���̍U���I\n �_���[�W 100";
                }

                else if (WN02 == 3)
                {
                    player01.HPNow -= 200;
                    UImessage.GetComponent<Text>().text = "�v���C���[02���̍U���I\n �_���[�W 200";
                }

                else if (WN02 == 4)
                {
                    player01.HPNow -= 300;
                    UImessage.GetComponent<Text>().text = "�v���C���[02���̍U���I\n �_���[�W 300";
                }


                //�_���[�W���[�V����
                player01.requestDamage();


                Debug.Log("�����X�^�[��HP" + player01.HPNow);


                //HP��\������
                Ul01HPtext.GetComponent<Text>().text = "HP:" + player01.HPNow + "/" + player01.HPMax;
                if (player01.HPNow <= 0)
                { Ul01HPtext.GetComponent<Text>().text = "HP:�Ђ�"; }


                //���C�t�o�[ (�}�C�i�X�ɂȂ�����0�ɂ���j
                UIHPnow1.GetComponent<RectTransform>().localScale = new Vector3((player01.HPNow / player01.HPMax), 1.0f, 1.0f);

                if ((player01.HPNow / player01.HPMax) > 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
                if ((player01.HPNow / player01.HPMax) <= 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
                if ((player01.HPNow / player01.HPMax) <= 0.2f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
                if (player01.HPNow <= 0) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }


                UIHPnow2.GetComponent<RectTransform>().localScale = new Vector3((player02.HPNow / player02.HPMax), 1.0f, 1.0f);
                if ((player02.HPNow / player02.HPMax) > 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
                if ((player02.HPNow / player02.HPMax) <= 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
                if ((player02.HPNow / player02.HPMax) <= 0.2f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
                if (player02.HPNow <= 0) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }







                if (player01.HPNow <= 0)
                {


                    timeCounter = 0.0f;

                   

                    //�����X�^�[�J�E���g��-1����
                    MonsterCount01 -= 1;
                    Debug.Log("01���̎c��" + this.MonsterCount01);

                    //���[�V�����F�v���C���[01���|���
                    player01.requestDeath();

                    //�Q�[���I�[�o�[���
                    stateNumber = 402;




                }
                // �v���C���[01�����s���Ȃ�X�e�C�g311�Ɉړ�
                else if (ActionCheck01 == 0)
                {

                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;
                    //�퓬�J�n�ɖ߂�
                    stateNumber = 302;

                }

                //�v���C���[01���s���ςȂ�X�e�C�g101�Ɉړ�
                else
                {

                    stateNumber = 101;

                }
            }
        }
        #endregion�@���ΐ풆
        #region�@���X�e�C�g400�ԑ�@�ΐ�I������





        else if (stateNumber == 401)
        {




            if (timeCounter > 3.0f)
            {

                UImessage.GetComponent<Text>().text = "�v���C���[02���̃����X�^�[�͓|�ꂽ�I";
                //01���̎c����0�̂Ƃ�404�ɍs���B���̑���106�ɍs��
                if (MonsterCount02 <= 0)
                {
                    stateNumber = 403;

                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;
                }
                else
                {
                    stateNumber = 206;
                }


            }










        }


        else if (stateNumber == 402)
        {

            if (timeCounter > 3.0f)
            {

                Debug.Log("�v���C���[01���̃����X�^�[�͓|�ꂽ�I");
               

                UImessage.GetComponent<Text>().text = "�v���C���[01���̃����X�^�[�͓|�ꂽ�I";

                //01���̎c����0�̂Ƃ�404�ɍs���B���̑���106�ɍs��
                if (MonsterCount01 <= 0)
                {
                    stateNumber = 404;

                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;
                }
                else
                {
                    stateNumber = 106;

                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;

                }

            }





        }
        else if (stateNumber == 403)
        {

            if (timeCounter > 3.0f)
            {

                UImessage.GetComponent<Text>().text = "�ΐ�ɏ�������";




                if (Input.GetMouseButtonDown(0))
                {

                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;

                    stateNumber = 0;
                }

            }

        }
        else if (stateNumber == 404)
        {
            if (timeCounter > 3.0f)
            {



                UImessage.GetComponent<Text>().text = "�ΐ�ɔs�k����";



                if (Input.GetMouseButtonDown(0))
                {
                    //�^�C�}�[���Z�b�g
                    timeCounter = 0.0f;

                    stateNumber = 0;


                }

            }
        }




    }
}//�X�e�C�g����I��
    #endregion�@���X�e�C�g400�ԑ�@�ΐ�I������
    #endregion�@���A�b�v�f�[�g

