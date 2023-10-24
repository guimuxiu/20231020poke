using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI部品
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //状態番号
    private int stateNumber = 0;

    //汎用タイマー
    private float timeCounter = 0.0f;

    //UI メッセージ
    public GameObject UImessage;

    //UI コマンド
    public GameObject UIchoice01;
    public GameObject UIchoice02;

    //UI 技
    public GameObject UIweapon01;
    public GameObject UIweapon02;

    //プレイヤーのUI操作の結果
    //0=未選択、1=剣、2=槍
    private int choiceCommand = 0;






    // Start is called before the first frame update
    void Start()
    {
    
     }
// Update is called once per frame
void Update()
    {
        //タイマー
        timeCounter += Time.deltaTime;

        if (timeCounter == 3.0f) 
        {
            Debug.Log("3秒経過");
        }


            //敵が登場する演出
            if (stateNumber == 0)
        {
            if (timeCounter > 3.0f)
            {
                UImessage.GetComponent<Text>().text = "対戦開始";

                //タイマーリセット
                timeCounter = 0.0f;

                //状態変更
                stateNumber = 101;
            }
        }
       
        else if (stateNumber == 101)
        {
            if (timeCounter > 1.0f)
            { 
              
           
              //コマンドON
              UIchoice01.SetActive(true);

                //"たたかう"ボタンを押したとき
                if (Input.ButtonBattlePlayer01)
                {
                    //技選択画面に移動
                    stateNumber = 102;
                    Debug.Log("技選択画面に移動");
                }

                //"いれかえ"ボタンを押したとき
                if (Input.ButtonChangePlayer01)
                {

                    //入れ替え画面に移動
                    stateNumber = 103;
                    Debug.Log("入れ替え画面に移動");
                }

            }
        }

        else if (stateNumber == 102)
        {
            if (timeCounter > 1.0f)
            {
                //コマンドOFF
                UIchoice01.SetActive(false);





                //状態変更
                stateNumber = 102;
            }






            //コマンドが選択されるまでの待機
            else if (stateNumber == 103)
        {
            if (choiceCommand != 0)
            {
                Debug.Log("プレイヤー１の選択が完了→プレイヤー２へ");

                //状態変更
                stateNumber = 104;
            }
        }
    }

    //コマンド（ボタン）
    public void buttonAttack()
    {
        Debug.Log("攻撃が選択されました。");

        //UIweapon.SetActive(true);
        UIchoice01.SetActive(false);
    }

    public void weaponSword()
    {
        //剣
        choiceCommand = 1;
    }
}