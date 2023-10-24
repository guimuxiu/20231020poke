using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI���i
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //��Ԕԍ�
    private int stateNumber = 0;

    //�ėp�^�C�}�[
    private float timeCounter = 0.0f;

    //UI ���b�Z�[�W
    public GameObject UImessage;

    //UI �R�}���h
    public GameObject UIchoice01;
    public GameObject UIchoice02;

    //UI �Z
    public GameObject UIweapon01;
    public GameObject UIweapon02;

    //�v���C���[��UI����̌���
    //0=���I���A1=���A2=��
    private int choiceCommand = 0;






    // Start is called before the first frame update
    void Start()
    {
    
     }
// Update is called once per frame
void Update()
    {
        //�^�C�}�[
        timeCounter += Time.deltaTime;

        if (timeCounter == 3.0f) 
        {
            Debug.Log("3�b�o��");
        }


            //�G���o�ꂷ�鉉�o
            if (stateNumber == 0)
        {
            if (timeCounter > 3.0f)
            {
                UImessage.GetComponent<Text>().text = "�ΐ�J�n";

                //�^�C�}�[���Z�b�g
                timeCounter = 0.0f;

                //��ԕύX
                stateNumber = 101;
            }
        }
       
        else if (stateNumber == 101)
        {
            if (timeCounter > 1.0f)
            { 
              
           
              //�R�}���hON
              UIchoice01.SetActive(true);

                //"��������"�{�^�����������Ƃ�
                if (Input.ButtonBattlePlayer01)
                {
                    //�Z�I����ʂɈړ�
                    stateNumber = 102;
                    Debug.Log("�Z�I����ʂɈړ�");
                }

                //"���ꂩ��"�{�^�����������Ƃ�
                if (Input.ButtonChangePlayer01)
                {

                    //����ւ���ʂɈړ�
                    stateNumber = 103;
                    Debug.Log("����ւ���ʂɈړ�");
                }

            }
        }

        else if (stateNumber == 102)
        {
            if (timeCounter > 1.0f)
            {
                //�R�}���hOFF
                UIchoice01.SetActive(false);





                //��ԕύX
                stateNumber = 102;
            }






            //�R�}���h���I�������܂ł̑ҋ@
            else if (stateNumber == 103)
        {
            if (choiceCommand != 0)
            {
                Debug.Log("�v���C���[�P�̑I�����������v���C���[�Q��");

                //��ԕύX
                stateNumber = 104;
            }
        }
    }

    //�R�}���h�i�{�^���j
    public void buttonAttack()
    {
        Debug.Log("�U�����I������܂����B");

        //UIweapon.SetActive(true);
        UIchoice01.SetActive(false);
    }

    public void weaponSword()
    {
        //��
        choiceCommand = 1;
    }
}