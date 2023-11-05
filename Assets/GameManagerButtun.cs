using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI���i
using UnityEngine.UI;



public partial class GameManager : MonoBehaviour
{

    //���ʉ�
    public AudioClip SEcheck;


    #region ���{�^��
    #region ���ŏ��̑I��

    //�R�}���h�i�{�^���j
    public void ButtonBattlePlayer01()
    {
        GetComponent<AudioSource>().PlayOneShot(SESystem);
        Debug.Log("ButtonBattlePlayer01");
        choiceCommand01 = 1;
        UIchoice01.SetActive(false);

    }

    public void ButtonBattlePlayer02()
    {
        GetComponent<AudioSource>().PlayOneShot(SESystem);
        Debug.Log("ButtonBattlePlayer02");
        choiceCommand02 = 1;
        UIchoice02.SetActive(false);
    }


    #endregion ���ŏ��̑I��
    #region�������X�^�[�̌��
    #region �Z��։��
    //�v���C���[01��
    public void ButtonChangePlayer01()
    {
        GetComponent<AudioSource>().PlayOneShot(SESystem);
        Debug.Log("�v���C���[01�̃����X�^�[�̌�։��");
        choiceCommand01 = 2;
        UIchoice01.SetActive(false);

    }
    //�v���C���[02��
    public void ButtonChangePlayer02()
    {
        GetComponent<AudioSource>().PlayOneShot(SESystem);
        //�v���C���[01���̕\�L�ƕς���H
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
        monster05 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

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
        monster06 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

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

        Debug.Log("�v���C���[02�̃����X�^�[�̌�։��");
        choiceCommand02 = 2;
        UIchoice02.SetActive(false);

    }




    #endregion �Z��։��
    #region �Z��փ{�^��
    public void BackChangeMonster01()
    {
        stateNumber = 101;
        choiceCommand01 = 0;
        ChangeMonster01.SetActive(false);
        UIchoice01.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }


    public void BackChangeMonster02()
    {
        if (stateNumber == 204)
        { stateNumber = 202; }
        else if (stateNumber == 206)
        { stateNumber = 101; }

        choiceCommand02 = 0;
        ChangeMonster02.SetActive(false);
        UIchoice02.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(SESystem);

    }


    public void ChangeMonsterTo01()
    {
        //�v���C���[01��
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 1;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);

            GetComponent<AudioSource>().PlayOneShot(SESystem);

        }
        //�v���C���[02��
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 1;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);

            GetComponent<AudioSource>().PlayOneShot(SESystem);
        }
    }



    public void ChangeMonsterTo02()
    {
        //�v���C���[01��
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 2;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //�v���C���[02��
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 2;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void ChangeMonsterTo03()
    {
        //�v���C���[01��
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 3;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //�v���C���[02��
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 3;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void ChangeMonsterTo04()
    {
        //�v���C���[01��
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 4;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //�v���C���[02��
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 4;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void ChangeMonsterTo05()
    {
        //�v���C���[01��
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 5;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //�v���C���[02��
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 5;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void ChangeMonsterTo06()
    {
        //�v���C���[01��
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 6;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //�v���C���[02��
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 6;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }





    #endregion �Z��փ{�^��
    #endregion �������X�^�[�̌��
    #region������I��

    public void ButtonStatusPlayer01()
    {
        Debug.Log("ButtonStatusPlayer01");
        choiceCommand01 = 3;
        UIchoice01.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }

    public void Weapon01Player01()
    {
        WN01 = 1;
        UIweapon01.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void Weapon02Player01()
    {
        WN01 = 2;
        UIweapon01.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void Weapon03Player01()
    {
        WN01 = 3;
        UIweapon01.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void Weapon04Player01()
    {
        WN01 = 4;
        UIweapon01.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
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
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }



    public void ButtonStatusPlayer02()
    {
        Debug.Log("ButtonStatusPlayer02");
        choiceCommand02 = 3;
        UIchoice02.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }

    public void Weapon01Player02()
    {
        WN02 = 1;
        UIweapon02.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void Weapon02Player02()
    {
        WN02 = 2;
        UIweapon02.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void Weapon03Player02()
    {
        WN02 = 3;
        UIweapon02.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
    }
    public void Weapon04Player02()
    {
        WN02 = 4;
        UIweapon02.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SESystem);
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
        GetComponent<AudioSource>().PlayOneShot(SESystem);

    }
}
    #endregion������I��
#endregion ���{�^��


