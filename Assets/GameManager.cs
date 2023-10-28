using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//UI部品
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //ステイト番号
    private int stateNumber = 0;

    //汎用タイマー
    private float timeCounter = 0.0f;

    //UI メッセージ
    public GameObject UImessage;

    //UI ステイト番号の表示
    public GameObject UIStateNumber;

    //UI モンスターHP
    public GameObject Ul01HPtext;
    public GameObject Ul02HPtext;

    //UI コマンド
    public GameObject UIchoice01;
    public GameObject UIchoice02;

    //UI 技
    public GameObject UIweapon01;
    public GameObject UIweapon02;

    //プレイヤーのUI操作の結果
    //0=未選択、1=こうげき、2=いれかえ 3=ステータス
    private int choiceCommand01 = 0;
    private int choiceCommand02 = 0;
   
    //プレイヤーの武器選択の結果
    //0=未選択、1=武器1、……
    private int weaponNumber01 = 0;
    private int weaponNumber02 = 0;
   

    //行動したかどうかの確認
    //0=未行動、1=行動済み
    private int ActionCheck01 = 0;
    private int ActionCheck02 = 0;


    //技テキスト
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
        //タイマー
        timeCounter += Time.deltaTime;

        //ステイト番号を表示する
        UIStateNumber.GetComponent<Text>().text = "" + stateNumber;


        //player01,02を定義する

        Monster01Player01 player01;
        player01 = GameObject.Find("Monster01Player01").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster01Player02").GetComponent<Monster01Player02>();

        //HPを表示する
        Ul01HPtext.GetComponent<Text>().text = "HP:" + player01.HPNow + "/" + player01.HPMax;
        Ul02HPtext.GetComponent<Text>().text = "HP:" + player02.HPNow + "/" + player02.HPMax;



        if (timeCounter == 3.0f)
        {
            Debug.Log("3秒経過");
        }

        //モンスターが登場する演出
        if (stateNumber == 0)
        {
            if (timeCounter > 3.0f)
            {
               　UImessage.GetComponent<Text>().text = "対戦開始";

                //タイマーリセット
                timeCounter = 0.0f;

                //ステイト変更
                stateNumber = 101;
            }
        }

        else if (stateNumber == 101)
        {
            if (timeCounter > 1.0f)
            {
                //未選択
                choiceCommand01 = 0;

                //コマンドON
                UIchoice01.SetActive(true);

                //行動確認off
                ActionCheck01 = 0;
                ActionCheck02 = 0;

                //ステイト変更
                stateNumber = 102;            
            }
        }



        //コマンドが選択されるまでの待機
        else if (stateNumber == 102)
        {


            if (choiceCommand01 != 0)
            {


                if (choiceCommand01 == 1)
                {

                    Debug.Log("プレイヤー01の行動選択:たたかうを選んだ");

                    //未選択
                    weaponNumber01 = 0;

                    //コマンドON
                    UIweapon01.SetActive(true);



                    //技構成をセット
                    string wn9001 = "きりかかる";
                    int[] wf9001 = { 1, 50, 100, 10, 1, 0 };

                    string wn9002 = "おそいかかる";
                    int[] wf9002 = { 2, 100, 80, 10, 1, 0 };

                    string wn9003 = "とびどうぐ";
                    int[] wf9003 = { 3, 80, 100, 10, 2, 0 };

                    string wn9004 = "きあい";
                    int[] wf9004 = { 4, 0, 100, 10, 2, 0 };

                    TextWeapon01Player01.GetComponent<Text>().text = "" + wn9001;
                    TextWeapon02Player01.GetComponent<Text>().text = "" + wn9002;
                    TextWeapon03Player01.GetComponent<Text>().text = "" + wn9003;
                    TextWeapon04Player01.GetComponent<Text>().text = "" + wn9004;



                    //ステイト変更→01の技選択画面
                    stateNumber = 103;

                }
            }
        }
        //技が選択されるまでの待機
        else if (stateNumber == 103)
        {

           
            if (weaponNumber01 != 0)
            {
                Debug.Log("プレイヤー01は技" + weaponNumber01 + "を選んだ");

                //未選択
                choiceCommand02 = 0;

                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("プレイヤー02の行動選択");
            }
        }

        else if (stateNumber == 202)
        {
            if (choiceCommand02 != 0)
            {
                if (choiceCommand02 == 1)
                {
                    //未選択
                    weaponNumber02 = 0;
                    //コマンドON
                    UIweapon02.SetActive(true);
                    Debug.Log("プレイヤー02の行動選択:たたかうを選んだ");


                    //技構成をセット
                    string wn9001 = "きりかかる";
                    int[] wf9001 = { 1, 50, 100, 10, 1, 0 };

                    string wn9002 = "おそいかかる";
                    int[] wf9002 = { 2, 100, 80, 10, 1, 0 };

                    string wn9003 = "とびどうぐ";
                    int[] wf9003 = { 3, 80, 100, 10, 2, 0 };

                    string wn9004 = "きあい";
                    int[] wf9004 = { 4, 0, 100, 10, 2, 0 };

                    TextWeapon01Player02.GetComponent<Text>().text = "" + wn9001;
                    TextWeapon02Player02.GetComponent<Text>().text = "" + wn9002;
                    TextWeapon03Player02.GetComponent<Text>().text = "" + wn9003;
                    TextWeapon04Player02.GetComponent<Text>().text = "" + wn9004;

                    //ステイト変更
                    stateNumber = 203;
                    Debug.Log("プレイヤー02の技選択");
                }

            }
        }
        //武器が選択されるまでの待機
        else if (stateNumber == 203)
        {

            if (weaponNumber02 != 0)
            {
                stateNumber = 301;
                Debug.Log("プレイヤー02は技を選んだ");
            }
        }

        //戦闘開始

        else if (stateNumber == 301)
        {
            GameObject.Find("Monster01Player01").GetComponent<Monster01Player01>().requestAttack(weaponNumber01);

            //タイマーリセット
            timeCounter = 0.0f;

            stateNumber = 302;

        }

        else if (stateNumber == 302)
        {

            if (timeCounter > 0.5f)
            {
                GameObject.Find("Monster01Player02").GetComponent<Monster01Player02>().requestDamage();
                //タイマーリセット
                timeCounter = 0.0f;

                //ステイト変更
                stateNumber = 303;

            }
        }

        else if (stateNumber == 303)
        {
            if (timeCounter > 1.0f)
            {
                GameObject.Find("Monster01Player02").GetComponent<Monster01Player02>().requestAttack(weaponNumber02);

                //タイマーリセット
                timeCounter = 0.0f;

                stateNumber = 304;

            }

        }

        else if (stateNumber == 304)
        {
            if (timeCounter > 0.5f)
            {
                GameObject.Find("Monster01Player01").GetComponent<Monster01Player01>().requestDamage();
                //タイマーリセット
                timeCounter = 0.0f;

                

                //実数値確認
                Debug.Log("プレイヤー01実数値確認" + player01.HPMax + "," + player01.AtRl + "," + player01.BtRl + ","
                    + player01.CtRl + "," + player01.DtRl + "," + player01.StRl);

                Debug.Log("プレイヤー02実数値確認" + player02.HPMax + "," + player02.AtRl + "," + player02.BtRl + ","
                   + player02.CtRl + "," + player02.DtRl + "," + player02.StRl);


                //素早さ比較
                if (player01.StRl > player02.StRl)
                {

                    Debug.Log("プレイヤー01の方が速い");

                    //player01から攻撃する
                    stateNumber = 311;

                }

                else if (player01.StRl < player02.StRl)
                {

                    Debug.Log("プレイヤー02の方が速い");

                    //player01から攻撃する
                    stateNumber = 312;

                }

                else
                {
                  //  Debug.Log("同速");

                    //同速乱数
                    if (Random.Range(1, 2) > 1)

                    {
                        Debug.Log("同速でプレイヤー01が優先");
                        stateNumber = 311;
                    }
                    else
                    {
                        Debug.Log("同速でプレイヤー02が優先");
                        stateNumber = 312;
                    }

                }
            }
        }
        //プレイヤー01の攻撃
        else if (stateNumber == 311)
        {
            //行動確認on
            ActionCheck01 = 1;

            Debug.Log("モンスター05の攻撃！");

            //技情報の呼び出し
            // タイプ、威力、命中、pp、物特変、優先度

            int[] wf9001 = { 1, 50, 100, 10, 1, 0 };
            int[] wf9002 = { 2, 100, 80, 10, 1, 0 };
            int[] wf9003 = { 3, 80, 100, 10, 2, 0 };
            int[] wf9004 = { 4, 0, 100, 10, 3, 0 };





            //01→02のダメージ計算
            //ダメージ = (((レベル×2 / 5 + 2)×威力×A / D)/ 50 + 2)
            //×範囲補正×おやこあい補正×天気補正×急所補正×乱数補正
            //×タイプ一致補正×相性補正×やけど補正×M×Mprotect

            float da01 = player01.Level*2 / 5 + 2 ;

            //技威力

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
                Debug.Log("技選択失敗");
            }

            Debug.Log("技威力" + WeaponPower);


            //物理特殊判定

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
                Debug.Log(" 物理特殊の選択失敗");
            }

            Debug.Log("攻撃or特攻の実数値"+da02);
            Debug.Log("特攻or特防の実数値" + da03);

            //攻撃側ランク補正
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
            else { Debug.Log(" Aランク計算失敗"); }

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
            else { Debug.Log(" Cランク計算失敗"); }

            //防御側ランク補正

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
            else { Debug.Log(" Bランク計算失敗"); }

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
            else { Debug.Log(" Dランク計算失敗"); }


            //ランク補正後の威力

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
                Debug.Log(" 物理特殊ランクの選択失敗");
            }




            //最終威力=基礎威力×威力補正/4096


            float da04 = Mathf.Floor(Mathf.Floor(da01 * WeaponPower * da02 *da02R / (da03*da03R)) / 50 + 2);

            Debug.Log("かっこ内の計算値" + da04);

            //範囲補正計算

            float da05 = da04;
            
            //おやこあい補正

            float da06 = da05;

            //天気補正

            float da07 = da06;

            //急所補正
            //自分の下降ランクと相手の上昇ランク無視はどうしよう？

            float da08 = 0;

            if (Random.Range(1, 16) == 16)
            {
                Debug.Log("急所に当たった");

                da08 = da07 * 3 / 2;
            }
            else if (Random.Range(1, 16) < 16)
            {
                da08 = da07;
                Debug.Log("急所に当たらなかった");

            }
            else
            {
                Debug.Log("急所判定失敗");
            }


            Debug.Log("急所判定込み"+da08);

            //五捨五超入
            float da09 = Mathf.Ceil(da08 - 1/2);

            //ダメージ判定用
            //float[] daR01 ={ da09 * 85 / 100, da09 * 86 / 100 , da09 * 87 / 100 ,da09 * 88 / 100 ,
            //                 da09 * 89 / 100 ,da09 * 90 / 100 , da09 * 91 / 100 ,da09 * 92 / 100 ,
            //                 da09 * 93 / 100 ,da09 * 94 / 100 , da09 * 95 / 100 ,da09 * 96 / 100 ,
            //                 da09 * 97 / 100 ,da09 * 98 / 100 , da09 * 99 / 100 ,da09 * 100 / 100 };

            //乱数補正（切り捨て）

            float da10 = Random.Range(85, 100);
            Debug.Log("乱数補正" + da10+"%");

            float da11 = Mathf.Floor(da09 * da10 / 100);
            Debug.Log("乱数込み" + da11);

            //float[] daR02 = { Mathf.Floor(daR01[0]),Mathf.Floor(daR01[1]),Mathf.Floor(daR01[2]),Mathf.Floor(daR01[3]),
            //                  Mathf.Floor(daR01[4]),Mathf.Floor(daR01[5]),Mathf.Floor(daR01[6]),Mathf.Floor(daR01[7]),
            //                  Mathf.Floor(daR01[8]),Mathf.Floor(daR01[9]),Mathf.Floor(daR01[10]),Mathf.Floor(daR01[11])};

           

            float da13 = 0;     //技タイプ
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
                Debug.Log("タイプ取得失敗");
            }


            //タイプ一致補正(五捨五超入)
            float da12 = 0;


            if (da13 == player01.type[0])
            {
                Debug.Log("タイプ一致ON" + da11 * 1.5f);
                da12 = Mathf.Ceil(da11 * 1.5f　-0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("タイプ一致ON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[0])
            {
                Debug.Log("タイプ一致ON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("タイプ一致ON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[0])
            {
                Debug.Log("タイプ一致ON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("タイプ一致ON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if ((da13 == player01.type[0]))
            {
                Debug.Log("タイプ一致ON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else if (da13 == player01.type[1])
            {
                Debug.Log("タイプ一致ON" + da11 * 3 / 2);
                da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
            }
            else 
            {
                Debug.Log("タイプ不一致");
            }

            Debug.Log("タイプ一致補正込み" + da12);

            //相性補正

            float da14 = 0;
            float da15 = 0;


            //技タイプ→防御タイプ1
            //攻撃側がノーマル
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
            else if (da13 == 1 && player02.type[0] == 13) { da14 = 1 / 2; }    //岩
            else if (da13 == 1 && player02.type[0] == 14) { da14 = 0; }     //霊
            else if (da13 == 1 && player02.type[0] == 15) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 16) { da14 = 1; }
            else if (da13 == 1 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 1 && player02.type[0] == 18) { da14 = 1; }
            //攻撃側が炎
            else if (da13 == 2 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 2 && player02.type[0] == 1) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 2) { da14 = 1 / 2; }　//炎
            else if (da13 == 2 && player02.type[0] == 3) { da14 = 1 / 2; }　//水
            else if (da13 == 2 && player02.type[0] == 4) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 5) { da14 = 2; }  //草
            else if (da13 == 2 && player02.type[0] == 6) { da14 = 2; }  //氷
            else if (da13 == 2 && player02.type[0] == 7) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 8) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 9) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 10) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 11) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 12) { da14 = 2; }     //虫
            else if (da13 == 2 && player02.type[0] == 13) { da14 = 1 / 2; } //岩
            else if (da13 == 2 && player02.type[0] == 14) { da14 = 1; }     //霊
            else if (da13 == 2 && player02.type[0] == 15) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 16) { da14 = 1; }
            else if (da13 == 2 && player02.type[0] == 17) { da14 = 2; }  //鋼
            else if (da13 == 2 && player02.type[0] == 18) { da14 = 1; }
            //攻撃側が水
            else if (da13 == 3 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 3 && player02.type[0] == 1) { da14 = 1; }
            else if (da13 == 3 && player02.type[0] == 2) { da14 = 2; }　//炎
            else if (da13 == 3 && player02.type[0] == 3) { da14 = 1 / 2; }　//水
            else if (da13 == 3 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 3 && player02.type[0] == 5) { da14 = 1 / 2; }  //草
            else if (da13 == 3 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 3 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 3 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 3 && player02.type[0] == 9) { da14 = 2; }  //地
            else if (da13 == 3 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 3 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 3 && player02.type[0] == 12) { da14 = 2; }  //虫
            else if (da13 == 3 && player02.type[0] == 13) { da14 = 2; }  //岩
            else if (da13 == 3 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 3 && player02.type[0] == 15) { da14 = 1 / 2; }  //竜
            else if (da13 == 3 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 3 && player02.type[0] == 17) { da14 = 2; }  //鋼
            else if (da13 == 3 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が電
            else if (da13 == 4 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 4 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 4 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 4 && player02.type[0] == 3) { da14 = 2; }　//水
            else if (da13 == 4 && player02.type[0] == 4) { da14 = 1 / 2; }　　　//電
            else if (da13 == 4 && player02.type[0] == 5) { da14 = 1 / 2; }  //草
            else if (da13 == 4 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 4 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 4 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 4 && player02.type[0] == 9) { da14 = 0; }  //地
            else if (da13 == 4 && player02.type[0] == 10) { da14 = 2; }　//飛
            else if (da13 == 4 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 4 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 4 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 4 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 4 && player02.type[0] == 15) { da14 = 1 / 2; }  //竜
            else if (da13 == 4 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 4 && player02.type[0] == 17) { da14 = 1; }  //鋼
            else if (da13 == 4 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が草
            else if (da13 == 5 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 5 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 5 && player02.type[0] == 2) { da14 = 1 / 2; }　//炎
            else if (da13 == 5 && player02.type[0] == 3) { da14 = 2; }　//水
            else if (da13 == 5 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 5 && player02.type[0] == 5) { da14 = 1 / 2; }  //草
            else if (da13 == 5 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 5 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 5 && player02.type[0] == 8) { da14 = 1 / 2; }　//毒
            else if (da13 == 5 && player02.type[0] == 9) { da14 = 2; }  //地
            else if (da13 == 5 && player02.type[0] == 10) { da14 = 1 / 2; }　//飛
            else if (da13 == 5 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 5 && player02.type[0] == 12) { da14 = 1 / 2; }  //虫
            else if (da13 == 5 && player02.type[0] == 13) { da14 = 2; }  //岩
            else if (da13 == 5 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 5 && player02.type[0] == 15) { da14 = 1 / 2; }  //竜
            else if (da13 == 5 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 5 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 5 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が氷
            else if (da13 == 6 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 6 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 6 && player02.type[0] == 2) { da14 = 1 / 2; }　//炎
            else if (da13 == 6 && player02.type[0] == 3) { da14 = 1 / 2; }　//水
            else if (da13 == 6 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 6 && player02.type[0] == 5) { da14 = 2; }  //草
            else if (da13 == 6 && player02.type[0] == 6) { da14 = 1 / 2; }  //氷
            else if (da13 == 6 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 6 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 6 && player02.type[0] == 9) { da14 = 2; }  //地
            else if (da13 == 6 && player02.type[0] == 10) { da14 = 2; }　//飛
            else if (da13 == 6 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 6 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 6 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 6 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 6 && player02.type[0] == 15) { da14 = 2; }  //竜
            else if (da13 == 6 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 6 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 6 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が格
            else if (da13 == 7 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 7 && player02.type[0] == 1) { da14 = 2; }  //ノ
            else if (da13 == 7 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 7 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 7 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 7 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 7 && player02.type[0] == 6) { da14 = 2; }  //氷
            else if (da13 == 7 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 7 && player02.type[0] == 8) { da14 = 1 / 2; }　//毒
            else if (da13 == 7 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 7 && player02.type[0] == 10) { da14 = 1 / 2; }　//飛
            else if (da13 == 7 && player02.type[0] == 11) { da14 = 1 / 2; }　//超
            else if (da13 == 7 && player02.type[0] == 12) { da14 = 1 / 2; }  //虫
            else if (da13 == 7 && player02.type[0] == 13) { da14 = 2; }  //岩
            else if (da13 == 7 && player02.type[0] == 14) { da14 = 0; }  //霊
            else if (da13 == 7 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 7 && player02.type[0] == 16) { da14 = 2; }  //悪
            else if (da13 == 7 && player02.type[0] == 17) { da14 = 2; }  //鋼
            else if (da13 == 7 && player02.type[0] == 18) { da14 = 1 / 2; } //妖
            //攻撃側が毒
            else if (da13 == 8 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 8 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 8 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 8 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 8 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 8 && player02.type[0] == 5) { da14 = 2; }  //草
            else if (da13 == 8 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 8 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 8 && player02.type[0] == 8) { da14 = 1 / 2; }　//毒
            else if (da13 == 8 && player02.type[0] == 9) { da14 = 1 / 2; }  //地
            else if (da13 == 8 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 8 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 8 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 8 && player02.type[0] == 13) { da14 = 1 / 2; }  //岩
            else if (da13 == 8 && player02.type[0] == 14) { da14 = 1 / 2; }  //霊
            else if (da13 == 8 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 8 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 8 && player02.type[0] == 17) { da14 = 0; }  //鋼
            else if (da13 == 8 && player02.type[0] == 18) { da14 = 2; } //妖
            //攻撃側が地面
            else if (da13 == 9 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 9 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 9 && player02.type[0] == 2) { da14 = 2; }　//炎
            else if (da13 == 9 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 9 && player02.type[0] == 4) { da14 = 2; }　　　//電
            else if (da13 == 9 && player02.type[0] == 5) { da14 = 1 / 2; }  //草
            else if (da13 == 9 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 9 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 9 && player02.type[0] == 8) { da14 = 2; }　//毒
            else if (da13 == 9 && player02.type[0] == 9) { da14 = 2; }  //地
            else if (da13 == 9 && player02.type[0] == 10) { da14 = 0; }　//飛
            else if (da13 == 9 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 9 && player02.type[0] == 12) { da14 = 1 / 2; }  //虫
            else if (da13 == 9 && player02.type[0] == 13) { da14 = 2; }  //岩
            else if (da13 == 9 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 9 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 9 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 9 && player02.type[0] == 17) { da14 = 2; }  //鋼
            else if (da13 == 9 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が飛行
            else if (da13 == 10 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 10 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 10 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 10 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 10 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 10 && player02.type[0] == 5) { da14 = 2; }  //草
            else if (da13 == 10 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 10 && player02.type[0] == 7) { da14 = 2; }　//格
            else if (da13 == 10 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 10 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 10 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 10 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 10 && player02.type[0] == 12) { da14 = 2; }  //虫
            else if (da13 == 10 && player02.type[0] == 13) { da14 = 1 / 2; }  //岩
            else if (da13 == 10 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 10 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 10 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 10 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 10 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が超
            else if (da13 == 11 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 11 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 11 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 11 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 11 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 11 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 11 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 11 && player02.type[0] == 7) { da14 = 2; }　//格
            else if (da13 == 11 && player02.type[0] == 8) { da14 = 2; }　//毒
            else if (da13 == 11 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 11 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 11 && player02.type[0] == 11) { da14 = 1 / 2; }　//超
            else if (da13 == 11 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 11 && player02.type[0] == 13) { da14 = 2; }  //岩
            else if (da13 == 11 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 11 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 11 && player02.type[0] == 16) { da14 = 0; }  //悪
            else if (da13 == 11 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 11 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が虫
            else if (da13 == 12 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 12 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 12 && player02.type[0] == 2) { da14 = 1 / 2; }　//炎
            else if (da13 == 12 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 12 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 12 && player02.type[0] == 5) { da14 = 2; }  //草
            else if (da13 == 12 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 12 && player02.type[0] == 7) { da14 = 1 / 2; }　//格
            else if (da13 == 12 && player02.type[0] == 8) { da14 = 1 / 2; }　//毒
            else if (da13 == 12 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 12 && player02.type[0] == 10) { da14 = 1 / 2; }　//飛
            else if (da13 == 12 && player02.type[0] == 11) { da14 = 2; }　//超
            else if (da13 == 12 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 12 && player02.type[0] == 13) { da14 = 2; }  //岩
            else if (da13 == 12 && player02.type[0] == 14) { da14 = 1 / 2; }  //霊
            else if (da13 == 12 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 12 && player02.type[0] == 16) { da14 = 2; }  //悪
            else if (da13 == 12 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 12 && player02.type[0] == 18) { da14 = 1 / 2; } //妖
            //攻撃側が岩
            else if (da13 == 13 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 13 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 13 && player02.type[0] == 2) { da14 = 2; }　//炎
            else if (da13 == 13 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 13 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 13 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 13 && player02.type[0] == 6) { da14 = 2; }  //氷
            else if (da13 == 13 && player02.type[0] == 7) { da14 = 1 / 2; }　//格
            else if (da13 == 13 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 13 && player02.type[0] == 9) { da14 = 1 / 2; }  //地
            else if (da13 == 13 && player02.type[0] == 10) { da14 = 2; }　//飛
            else if (da13 == 13 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 13 && player02.type[0] == 12) { da14 = 2; }  //虫
            else if (da13 == 13 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 13 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 13 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 13 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 13 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 13 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が霊
            else if (da13 == 14 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 14 && player02.type[0] == 1) { da14 = 0; }  //ノ
            else if (da13 == 14 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 14 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 14 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 14 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 14 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 14 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 14 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 14 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 14 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 14 && player02.type[0] == 11) { da14 = 2; }　//超
            else if (da13 == 14 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 14 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 14 && player02.type[0] == 14) { da14 = 2; }  //霊
            else if (da13 == 14 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 14 && player02.type[0] == 16) { da14 = 1 / 2; }  //悪
            else if (da13 == 14 && player02.type[0] == 17) { da14 = 1; }  //鋼
            else if (da13 == 14 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側が竜
            else if (da13 == 15 && player02.type[0] == 0) { da14 = 1; }  //タイプなし
            else if (da13 == 15 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 15 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 15 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 15 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 15 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 15 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 15 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 15 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 15 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 15 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 15 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 15 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 15 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 15 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 15 && player02.type[0] == 15) { da14 = 2; }  //竜
            else if (da13 == 15 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 15 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 15 && player02.type[0] == 18) { da14 = 0; } //妖
            //攻撃側が悪
            else if (da13 == 16 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 16 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 16 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 16 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 16 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 16 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 16 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 16 && player02.type[0] == 7) { da14 = 1 / 2; }　//格
            else if (da13 == 16 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 16 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 16 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 16 && player02.type[0] == 11) { da14 = 2; }　//超
            else if (da13 == 16 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 16 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 16 && player02.type[0] == 14) { da14 = 2; }  //霊
            else if (da13 == 16 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 16 && player02.type[0] == 16) { da14 = 1 / 2; }  //悪
            else if (da13 == 16 && player02.type[0] == 17) { da14 = 1; }  //鋼
            else if (da13 == 16 && player02.type[0] == 18) { da14 = 1 / 2; } //妖
            //攻撃側が鋼
            else if (da13 == 17 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 17 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 17 && player02.type[0] == 2) { da14 = 1 / 2; }　//炎
            else if (da13 == 17 && player02.type[0] == 3) { da14 = 1 / 2; }　//水
            else if (da13 == 17 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 17 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 17 && player02.type[0] == 6) { da14 = 2; }  //氷
            else if (da13 == 17 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 17 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 17 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 17 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 17 && player02.type[0] == 11) { da14 = 2; }　//超
            else if (da13 == 17 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 17 && player02.type[0] == 13) { da14 = 2; }  //岩
            else if (da13 == 17 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 17 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 17 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 17 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 17 && player02.type[0] == 18) { da14 = 2; } //妖
            //攻撃側が妖
            else if (da13 == 18 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 18 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 18 && player02.type[0] == 2) { da14 = 1 / 2; }　//炎
            else if (da13 == 18 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 18 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 18 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 18 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 18 && player02.type[0] == 7) { da14 = 2; }　//格
            else if (da13 == 18 && player02.type[0] == 8) { da14 = 1 / 2; }　//毒
            else if (da13 == 18 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 18 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 18 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 18 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 18 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 18 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 18 && player02.type[0] == 15) { da14 = 2; }  //竜
            else if (da13 == 18 && player02.type[0] == 16) { da14 = 2; }  //悪
            else if (da13 == 18 && player02.type[0] == 17) { da14 = 1 / 2; }  //鋼
            else if (da13 == 18 && player02.type[0] == 18) { da14 = 1; } //妖
            //攻撃側がタイプなし
            else if (da13 == 19 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
            else if (da13 == 19 && player02.type[0] == 1) { da14 = 1; }  //ノ
            else if (da13 == 19 && player02.type[0] == 2) { da14 = 1; }　//炎
            else if (da13 == 19 && player02.type[0] == 3) { da14 = 1; }　//水
            else if (da13 == 19 && player02.type[0] == 4) { da14 = 1; }　　　//電
            else if (da13 == 19 && player02.type[0] == 5) { da14 = 1; }  //草
            else if (da13 == 19 && player02.type[0] == 6) { da14 = 1; }  //氷
            else if (da13 == 19 && player02.type[0] == 7) { da14 = 1; }　//格
            else if (da13 == 19 && player02.type[0] == 8) { da14 = 1; }　//毒
            else if (da13 == 19 && player02.type[0] == 9) { da14 = 1; }  //地
            else if (da13 == 19 && player02.type[0] == 10) { da14 = 1; }　//飛
            else if (da13 == 19 && player02.type[0] == 11) { da14 = 1; }　//超
            else if (da13 == 19 && player02.type[0] == 12) { da14 = 1; }  //虫
            else if (da13 == 19 && player02.type[0] == 13) { da14 = 1; }  //岩
            else if (da13 == 19 && player02.type[0] == 14) { da14 = 1; }  //霊
            else if (da13 == 19 && player02.type[0] == 15) { da14 = 1; }  //竜
            else if (da13 == 19 && player02.type[0] == 16) { da14 = 1; }  //悪
            else if (da13 == 19 && player02.type[0] == 17) { da14 = 1; }  //鋼
            else if (da13 == 19 && player02.type[0] == 18) { da14 = 1; } //妖

            else { Debug.Log("相性判定1失敗"); };


            //技タイプ→防御タイプ2
            //攻撃側がノーマル
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
            else if (da13 == 1 && player02.type[1] == 13) { da15 = 1 / 2; }    //岩
            else if (da13 == 1 && player02.type[1] == 14) { da15 = 0; }     //霊
            else if (da13 == 1 && player02.type[1] == 15) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 16) { da15 = 1; }
            else if (da13 == 1 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 1 && player02.type[1] == 18) { da15 = 1; }
            //攻撃側が炎
            else if (da13 == 2 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 2 && player02.type[1] == 1) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 2) { da15 = 1 / 2; } //炎
            else if (da13 == 2 && player02.type[1] == 3) { da15 = 1 / 2; } //水
            else if (da13 == 2 && player02.type[1] == 4) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 5) { da15 = 2; }  //草
            else if (da13 == 2 && player02.type[1] == 6) { da15 = 2; }  //氷
            else if (da13 == 2 && player02.type[1] == 7) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 8) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 9) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 10) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 11) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 12) { da15 = 2; }     //虫
            else if (da13 == 2 && player02.type[1] == 13) { da15 = 1 / 2; } //岩
            else if (da13 == 2 && player02.type[1] == 14) { da15 = 1; }     //霊
            else if (da13 == 2 && player02.type[1] == 15) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 16) { da15 = 1; }
            else if (da13 == 2 && player02.type[1] == 17) { da15 = 2; }  //鋼
            else if (da13 == 2 && player02.type[1] == 18) { da15 = 1; }
            //攻撃側が水
            else if (da13 == 3 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 3 && player02.type[1] == 1) { da15 = 1; }
            else if (da13 == 3 && player02.type[1] == 2) { da15 = 2; } //炎
            else if (da13 == 3 && player02.type[1] == 3) { da15 = 1 / 2; } //水
            else if (da13 == 3 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 3 && player02.type[1] == 5) { da15 = 1 / 2; }  //草
            else if (da13 == 3 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 3 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 3 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 3 && player02.type[1] == 9) { da15 = 2; }  //地
            else if (da13 == 3 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 3 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 3 && player02.type[1] == 12) { da15 = 2; }  //虫
            else if (da13 == 3 && player02.type[1] == 13) { da15 = 2; }  //岩
            else if (da13 == 3 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 3 && player02.type[1] == 15) { da15 = 1 / 2; }  //竜
            else if (da13 == 3 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 3 && player02.type[1] == 17) { da15 = 2; }  //鋼
            else if (da13 == 3 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が電
            else if (da13 == 4 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 4 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 4 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 4 && player02.type[1] == 3) { da15 = 2; } //水
            else if (da13 == 4 && player02.type[1] == 4) { da15 = 1 / 2; }   //電
            else if (da13 == 4 && player02.type[1] == 5) { da15 = 1 / 2; }  //草
            else if (da13 == 4 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 4 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 4 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 4 && player02.type[1] == 9) { da15 = 0; }  //地
            else if (da13 == 4 && player02.type[1] == 10) { da15 = 2; } //飛
            else if (da13 == 4 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 4 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 4 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 4 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 4 && player02.type[1] == 15) { da15 = 1 / 2; }  //竜
            else if (da13 == 4 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 4 && player02.type[1] == 17) { da15 = 1; }  //鋼
            else if (da13 == 4 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が草
            else if (da13 == 5 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 5 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 5 && player02.type[1] == 2) { da15 = 1 / 2; } //炎
            else if (da13 == 5 && player02.type[1] == 3) { da15 = 2; } //水
            else if (da13 == 5 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 5 && player02.type[1] == 5) { da15 = 1 / 2; }  //草
            else if (da13 == 5 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 5 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 5 && player02.type[1] == 8) { da15 = 1 / 2; } //毒
            else if (da13 == 5 && player02.type[1] == 9) { da15 = 2; }  //地
            else if (da13 == 5 && player02.type[1] == 10) { da15 = 1 / 2; } //飛
            else if (da13 == 5 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 5 && player02.type[1] == 12) { da15 = 1 / 2; }  //虫
            else if (da13 == 5 && player02.type[1] == 13) { da15 = 2; }  //岩
            else if (da13 == 5 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 5 && player02.type[1] == 15) { da15 = 1 / 2; }  //竜
            else if (da13 == 5 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 5 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 5 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が氷
            else if (da13 == 6 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 6 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 6 && player02.type[1] == 2) { da15 = 1 / 2; } //炎
            else if (da13 == 6 && player02.type[1] == 3) { da15 = 1 / 2; } //水
            else if (da13 == 6 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 6 && player02.type[1] == 5) { da15 = 2; }  //草
            else if (da13 == 6 && player02.type[1] == 6) { da15 = 1 / 2; }  //氷
            else if (da13 == 6 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 6 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 6 && player02.type[1] == 9) { da15 = 2; }  //地
            else if (da13 == 6 && player02.type[1] == 10) { da15 = 2; } //飛
            else if (da13 == 6 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 6 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 6 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 6 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 6 && player02.type[1] == 15) { da15 = 2; }  //竜
            else if (da13 == 6 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 6 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 6 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が格
            else if (da13 == 7 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 7 && player02.type[1] == 1) { da15 = 2; }  //ノ
            else if (da13 == 7 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 7 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 7 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 7 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 7 && player02.type[1] == 6) { da15 = 2; }  //氷
            else if (da13 == 7 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 7 && player02.type[1] == 8) { da15 = 1 / 2; } //毒
            else if (da13 == 7 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 7 && player02.type[1] == 10) { da15 = 1 / 2; } //飛
            else if (da13 == 7 && player02.type[1] == 11) { da15 = 1 / 2; } //超
            else if (da13 == 7 && player02.type[1] == 12) { da15 = 1 / 2; }  //虫
            else if (da13 == 7 && player02.type[1] == 13) { da15 = 2; }  //岩
            else if (da13 == 7 && player02.type[1] == 14) { da15 = 0; }  //霊
            else if (da13 == 7 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 7 && player02.type[1] == 16) { da15 = 2; }  //悪
            else if (da13 == 7 && player02.type[1] == 17) { da15 = 2; }  //鋼
            else if (da13 == 7 && player02.type[1] == 18) { da15 = 1 / 2; } //妖
            //攻撃側が毒
            else if (da13 == 8 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 8 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 8 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 8 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 8 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 8 && player02.type[1] == 5) { da15 = 2; }  //草
            else if (da13 == 8 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 8 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 8 && player02.type[1] == 8) { da15 = 1 / 2; } //毒
            else if (da13 == 8 && player02.type[1] == 9) { da15 = 1 / 2; }  //地
            else if (da13 == 8 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 8 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 8 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 8 && player02.type[1] == 13) { da15 = 1 / 2; }  //岩
            else if (da13 == 8 && player02.type[1] == 14) { da15 = 1 / 2; }  //霊
            else if (da13 == 8 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 8 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 8 && player02.type[1] == 17) { da15 = 0; }  //鋼
            else if (da13 == 8 && player02.type[1] == 18) { da15 = 2; } //妖
            //攻撃側が地面
            else if (da13 == 9 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 9 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 9 && player02.type[1] == 2) { da15 = 2; } //炎
            else if (da13 == 9 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 9 && player02.type[1] == 4) { da15 = 2; }   //電
            else if (da13 == 9 && player02.type[1] == 5) { da15 = 1 / 2; }  //草
            else if (da13 == 9 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 9 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 9 && player02.type[1] == 8) { da15 = 2; } //毒
            else if (da13 == 9 && player02.type[1] == 9) { da15 = 2; }  //地
            else if (da13 == 9 && player02.type[1] == 10) { da15 = 0; } //飛
            else if (da13 == 9 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 9 && player02.type[1] == 12) { da15 = 1 / 2; }  //虫
            else if (da13 == 9 && player02.type[1] == 13) { da15 = 2; }  //岩
            else if (da13 == 9 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 9 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 9 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 9 && player02.type[1] == 17) { da15 = 2; }  //鋼
            else if (da13 == 9 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が飛行
            else if (da13 == 10 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 10 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 10 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 10 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 10 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 10 && player02.type[1] == 5) { da15 = 2; }  //草
            else if (da13 == 10 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 10 && player02.type[1] == 7) { da15 = 2; } //格
            else if (da13 == 10 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 10 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 10 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 10 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 10 && player02.type[1] == 12) { da15 = 2; }  //虫
            else if (da13 == 10 && player02.type[1] == 13) { da15 = 1 / 2; }  //岩
            else if (da13 == 10 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 10 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 10 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 10 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 10 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が超
            else if (da13 == 11 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 11 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 11 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 11 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 11 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 11 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 11 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 11 && player02.type[1] == 7) { da15 = 2; } //格
            else if (da13 == 11 && player02.type[1] == 8) { da15 = 2; } //毒
            else if (da13 == 11 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 11 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 11 && player02.type[1] == 11) { da15 = 1 / 2; } //超
            else if (da13 == 11 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 11 && player02.type[1] == 13) { da15 = 2; }  //岩
            else if (da13 == 11 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 11 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 11 && player02.type[1] == 16) { da15 = 0; }  //悪
            else if (da13 == 11 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 11 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が虫
            else if (da13 == 12 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 12 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 12 && player02.type[1] == 2) { da15 = 1 / 2; } //炎
            else if (da13 == 12 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 12 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 12 && player02.type[1] == 5) { da15 = 2; }  //草
            else if (da13 == 12 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 12 && player02.type[1] == 7) { da15 = 1 / 2; } //格
            else if (da13 == 12 && player02.type[1] == 8) { da15 = 1 / 2; } //毒
            else if (da13 == 12 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 12 && player02.type[1] == 10) { da15 = 1 / 2; } //飛
            else if (da13 == 12 && player02.type[1] == 11) { da15 = 2; } //超
            else if (da13 == 12 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 12 && player02.type[1] == 13) { da15 = 2; }  //岩
            else if (da13 == 12 && player02.type[1] == 14) { da15 = 1 / 2; }  //霊
            else if (da13 == 12 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 12 && player02.type[1] == 16) { da15 = 2; }  //悪
            else if (da13 == 12 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 12 && player02.type[1] == 18) { da15 = 1 / 2; } //妖
            //攻撃側が岩
            else if (da13 == 13 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 13 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 13 && player02.type[1] == 2) { da15 = 2; } //炎
            else if (da13 == 13 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 13 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 13 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 13 && player02.type[1] == 6) { da15 = 2; }  //氷
            else if (da13 == 13 && player02.type[1] == 7) { da15 = 1 / 2; } //格
            else if (da13 == 13 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 13 && player02.type[1] == 9) { da15 = 1 / 2; }  //地
            else if (da13 == 13 && player02.type[1] == 10) { da15 = 2; } //飛
            else if (da13 == 13 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 13 && player02.type[1] == 12) { da15 = 2; }  //虫
            else if (da13 == 13 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 13 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 13 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 13 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 13 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 13 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が霊
            else if (da13 == 14 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 14 && player02.type[1] == 1) { da15 = 0; }  //ノ
            else if (da13 == 14 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 14 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 14 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 14 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 14 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 14 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 14 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 14 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 14 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 14 && player02.type[1] == 11) { da15 = 2; } //超
            else if (da13 == 14 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 14 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 14 && player02.type[1] == 14) { da15 = 2; }  //霊
            else if (da13 == 14 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 14 && player02.type[1] == 16) { da15 = 1 / 2; }  //悪
            else if (da13 == 14 && player02.type[1] == 17) { da15 = 1; }  //鋼
            else if (da13 == 14 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側が竜
            else if (da13 == 15 && player02.type[1] == 0) { da15 = 1; }  //タイプなし
            else if (da13 == 15 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 15 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 15 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 15 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 15 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 15 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 15 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 15 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 15 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 15 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 15 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 15 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 15 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 15 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 15 && player02.type[1] == 15) { da15 = 2; }  //竜
            else if (da13 == 15 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 15 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 15 && player02.type[1] == 18) { da15 = 0; } //妖
            //攻撃側が悪
            else if (da13 == 16 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 16 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 16 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 16 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 16 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 16 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 16 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 16 && player02.type[1] == 7) { da15 = 1 / 2; } //格
            else if (da13 == 16 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 16 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 16 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 16 && player02.type[1] == 11) { da15 = 2; } //超
            else if (da13 == 16 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 16 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 16 && player02.type[1] == 14) { da15 = 2; }  //霊
            else if (da13 == 16 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 16 && player02.type[1] == 16) { da15 = 1 / 2; }  //悪
            else if (da13 == 16 && player02.type[1] == 17) { da15 = 1; }  //鋼
            else if (da13 == 16 && player02.type[1] == 18) { da15 = 1 / 2; } //妖
            //攻撃側が鋼
            else if (da13 == 17 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 17 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 17 && player02.type[1] == 2) { da15 = 1 / 2; } //炎
            else if (da13 == 17 && player02.type[1] == 3) { da15 = 1 / 2; } //水
            else if (da13 == 17 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 17 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 17 && player02.type[1] == 6) { da15 = 2; }  //氷
            else if (da13 == 17 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 17 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 17 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 17 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 17 && player02.type[1] == 11) { da15 = 2; } //超
            else if (da13 == 17 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 17 && player02.type[1] == 13) { da15 = 2; }  //岩
            else if (da13 == 17 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 17 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 17 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 17 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 17 && player02.type[1] == 18) { da15 = 2; } //妖
            //攻撃側が妖
            else if (da13 == 18 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 18 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 18 && player02.type[1] == 2) { da15 = 1 / 2; } //炎
            else if (da13 == 18 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 18 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 18 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 18 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 18 && player02.type[1] == 7) { da15 = 2; } //格
            else if (da13 == 18 && player02.type[1] == 8) { da15 = 1 / 2; } //毒
            else if (da13 == 18 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 18 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 18 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 18 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 18 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 18 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 18 && player02.type[1] == 15) { da15 = 2; }  //竜
            else if (da13 == 18 && player02.type[1] == 16) { da15 = 2; }  //悪
            else if (da13 == 18 && player02.type[1] == 17) { da15 = 1 / 2; }  //鋼
            else if (da13 == 18 && player02.type[1] == 18) { da15 = 1; } //妖
            //攻撃側がタイプなし
            else if (da13 == 19 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
            else if (da13 == 19 && player02.type[1] == 1) { da15 = 1; }  //ノ
            else if (da13 == 19 && player02.type[1] == 2) { da15 = 1; } //炎
            else if (da13 == 19 && player02.type[1] == 3) { da15 = 1; } //水
            else if (da13 == 19 && player02.type[1] == 4) { da15 = 1; }   //電
            else if (da13 == 19 && player02.type[1] == 5) { da15 = 1; }  //草
            else if (da13 == 19 && player02.type[1] == 6) { da15 = 1; }  //氷
            else if (da13 == 19 && player02.type[1] == 7) { da15 = 1; } //格
            else if (da13 == 19 && player02.type[1] == 8) { da15 = 1; } //毒
            else if (da13 == 19 && player02.type[1] == 9) { da15 = 1; }  //地
            else if (da13 == 19 && player02.type[1] == 10) { da15 = 1; } //飛
            else if (da13 == 19 && player02.type[1] == 11) { da15 = 1; } //超
            else if (da13 == 19 && player02.type[1] == 12) { da15 = 1; }  //虫
            else if (da13 == 19 && player02.type[1] == 13) { da15 = 1; }  //岩
            else if (da13 == 19 && player02.type[1] == 14) { da15 = 1; }  //霊
            else if (da13 == 19 && player02.type[1] == 15) { da15 = 1; }  //竜
            else if (da13 == 19 && player02.type[1] == 16) { da15 = 1; }  //悪
            else if (da13 == 19 && player02.type[1] == 17) { da15 = 1; }  //鋼
            else if (da13 == 19 && player02.type[1] == 18) { da15 = 1; } //妖

            else { Debug.Log("相性判定2失敗"); };

            //タイプ相性合計判定
            float da16 = da14 * da15;
            if (da16 == 1) { Debug.Log("相性等倍"); }
            else if (da16 == 2) { Debug.Log("効果は抜群だ(2倍)"); }
            else if (da16 == 0.5f) { Debug.Log("効果はいまひとつのようだ(0.5倍)"); }
            else if (da16 == 0.25f) { Debug.Log("効果はいまひとつのようだ(0.25倍)"); }
            else if (da16 == 0f) { Debug.Log("効果はないようだ"); }
            else { Debug.Log("相性合計判定失敗"); }

            float da17 = Mathf.Floor(da12 * da16);
            Debug.Log("相性判定後" + da17);


            //やけど判定
            float da18=da17 ;

            //M補正(壁補正×ブレインフォース補正×スナイパー補正×
            //いろめがね補正×もふもふほのお補正×Mhalf×Mfilter×
            //フレンドガード補正×たつじんのおび補正×メトロノーム補正×
            //いのちのたま補正×半減の実補正×Mtwice(小数点以下を逐一四捨五入)(最終的に五捨五超入)

            float da19 = Mathf.Ceil(da18-0.5f);

            //Mprotect補正(Zワザ/ダイマックスわざがまもる状態などで軽減されたとき0.25倍)

            float da20 = da19;

            Debug.Log("最終ダメージ関数値" + da20);


　　　　　　//最終ダメージ計算

            player02.HPNow -= da20;

            player02.statusDisplay();

            Debug.Log("モンスター06のHP" + player02.HPNow +"/"+ player02.HPMax);


            //ステイト変更


            if (player02.HPNow < 0)
            {
                Debug.Log("モンスター06は倒れた！");
                UImessage.GetComponent<Text>().text = "モンスター06は倒れた！";

                //プレイヤー02のみモンスター選択画面
                stateNumber = 402;

            }
                 // プレイヤー02が未行動ならステイト312に移動
            if(ActionCheck02 == 0)
            {
                stateNumber = 312;
            }
            
                //プレイヤー02が行動済ならステイト101に移動
            else
            {
                stateNumber = 101;

            }

        }

        //02→01のダメージ計算

        else if (stateNumber == 312)
        {
            //行動確認on
            ActionCheck02 = 1;
            Debug.Log("モンスター06の攻撃！");

            player01.HPNow -= player02.AtRl;

                player01.statusDisplay();

                Debug.Log("モンスター05のHP"+player01.HPNow);


            if (player01.HPNow < 0)
            {
                Debug.Log("モンスター05は倒れた！");
                UImessage.GetComponent<Text>().text = "モンスター05は倒れた！";

                //プレイヤー01のみモンスター選択画面
                stateNumber = 101;

            }
            // プレイヤー01が未行動ならステイト311に移動
            else if (ActionCheck01 == 0)
            {
                stateNumber = 311;
            }

            //プレイヤー01が行動済ならステイト101に移動
            else
            {
                stateNumber = 101;
            }

        }

  
    }

    //コマンド（ボタン）
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
        //ステイト変更
        stateNumber = 102;
        //クリア
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
        //ステイト変更
        stateNumber = 202;
        //クリア
        choiceCommand02 = 0;

    }


}