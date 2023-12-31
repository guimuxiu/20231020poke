using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI部品
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    #region ◎ダメージ計算
    #region ●最初の設定

    //プレイヤー01　→　02
    void PlayerAttack01()
    {


        Monster01Player01 player01;
        player01 = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)").GetComponent<Monster01Player02>();



        //技情報の呼び出し
        // タイプ、威力、命中、pp、物特変、優先度

        int[] wf9001 = { 1, 50, 100, 10, 1, 0 };
        int[] wf9002 = { 2, 100, 80, 10, 1, 0 };
        int[] wf9003 = { 3, 80, 100, 10, 2, 0 };
        int[] wf9004 = { 4, 0, 100, 10, 3, 0 };

        #endregion ●最初の設定
        #region●基礎威力


        //01→02のダメージ計算
        //ダメージ = (((レベル×2 / 5 + 2)×威力×A / D)/ 50 + 2)
        //×範囲補正×おやこあい補正×天気補正×急所補正×乱数補正
        //×タイプ一致補正×相性補正×やけど補正×M×Mprotect

        float da01 = player01.Level * 2 / 5 + 2;

        //技威力

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
            Debug.Log("技選択失敗");
        }

        Debug.Log("技威力" + WeaponPower);


        //物理特殊判定

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


            Debug.Log(" 物理特殊の選択失敗");
        }

        Debug.Log("攻撃or特攻の実数値" + da02);
        Debug.Log("特攻or特防の実数値" + da03);
        #endregion●基礎威力
        #region●ランク補正
        //攻撃側ランク補正
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
            Debug.Log(" 物理特殊ランクの選択失敗");

            da02R = 1;
            da03R = 1;

        }
        //最終威力=基礎威力×威力補正/4096
        float da04 = Mathf.Floor(Mathf.Floor(da01 * WeaponPower * da02 * da02R / (da03 * da03R)) / 50 + 2);

        Debug.Log("かっこ内の計算値" + da04);
        #endregion  ●ランク補正
        #region ●範囲補正　親子愛補正　天気補正
        //範囲補正計算

        float da05 = da04;

        //おやこあい補正

        float da06 = da05;

        //天気補正

        float da07 = da06;
        #endregion ●範囲補正　親子愛補正　天気補正
        #region●急所補正　乱数補正
        //急所補正
        //自分の下降ランクと相手の上昇ランク無視はどうしよう？

        float da08 = 0;
        float da08r = Random.Range(1, 25);

        if (da08r == 1)
        {
            Debug.Log("急所に当たった");

            da08 = da07 * 3 / 2;
        }
        else
        {
            da08 = da07;
            Debug.Log("急所に当たらなかった");
        }



        Debug.Log("急所判定込み" + da08);

        //五捨五超入
        float da09 = Mathf.Ceil(da08 - (1 / 2));

        //ダメージ判定用
        //float[] daR01 ={ da09 * 85 / 100, da09 * 86 / 100 , da09 * 87 / 100 ,da09 * 88 / 100 ,
        //                 da09 * 89 / 100 ,da09 * 90 / 100 , da09 * 91 / 100 ,da09 * 92 / 100 ,
        //                 da09 * 93 / 100 ,da09 * 94 / 100 , da09 * 95 / 100 ,da09 * 96 / 100 ,
        //                 da09 * 97 / 100 ,da09 * 98 / 100 , da09 * 99 / 100 ,da09 * 100 / 100 };

        //乱数補正（切り捨て）

        float da10 = Random.Range(85, 101);
        Debug.Log("乱数補正" + da10 + "%");

        float da11 = Mathf.Floor(da09 * da10 / 100);
        Debug.Log("乱数込み" + da11);

        //float[] daR02 = { Mathf.Floor(daR01[0]),Mathf.Floor(daR01[1]),Mathf.Floor(daR01[2]),Mathf.Floor(daR01[3]),
        //                  Mathf.Floor(daR01[4]),Mathf.Floor(daR01[5]),Mathf.Floor(daR01[6]),Mathf.Floor(daR01[7]),
        //                  Mathf.Floor(daR01[8]),Mathf.Floor(daR01[9]),Mathf.Floor(daR01[10]),Mathf.Floor(daR01[11])};

        #endregion●急所補正　乱数補正
        #region ●タイプ補正

        float da13 = 0;     //技タイプ

        if (WN01 == 1) { da13 = wf9001[0]; }
        else if (WN01 == 2) { da13 = wf9002[0]; }
        else if (WN01 == 3) { da13 = wf9003[0]; }
        else if (WN01 == 4) { da13 = wf9004[0]; }
        else { Debug.Log("タイプ取得失敗"); }

        Debug.Log("技タイプ" + da13);



        //タイプ一致補正(五捨五超入)
        float da12 = 1;


        if (da13 == player01.type[0])
        {
            Debug.Log("タイプ一致ON" + da11 * 1.5f);
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
            da12 = Mathf.Ceil(da11);

        }

        Debug.Log("タイプ一致補正込み" + da12);

        //相性補正

        float da14 = 0;



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
        else if (da13 == 1 && player02.type[0] == 13) { da14 = 0.5f; }    //岩
        else if (da13 == 1 && player02.type[0] == 14) { da14 = 0; }     //霊
        else if (da13 == 1 && player02.type[0] == 15) { da14 = 1; }
        else if (da13 == 1 && player02.type[0] == 16) { da14 = 1; }
        else if (da13 == 1 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 1 && player02.type[0] == 18) { da14 = 1; }
        //攻撃側が炎
        else if (da13 == 2 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 2 && player02.type[0] == 1) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 2) { da14 = 0.5f; } //炎
        else if (da13 == 2 && player02.type[0] == 3) { da14 = 0.5f; } //水
        else if (da13 == 2 && player02.type[0] == 4) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 5) { da14 = 2; }  //草
        else if (da13 == 2 && player02.type[0] == 6) { da14 = 2; }  //氷
        else if (da13 == 2 && player02.type[0] == 7) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 8) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 9) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 10) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 11) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 12) { da14 = 2; }     //虫
        else if (da13 == 2 && player02.type[0] == 13) { da14 = 0.5f; } //岩
        else if (da13 == 2 && player02.type[0] == 14) { da14 = 1; }     //霊
        else if (da13 == 2 && player02.type[0] == 15) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 16) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 17) { da14 = 2; }  //鋼
        else if (da13 == 2 && player02.type[0] == 18) { da14 = 1; }
        //攻撃側が水
        else if (da13 == 3 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 3 && player02.type[0] == 1) { da14 = 1; }
        else if (da13 == 3 && player02.type[0] == 2) { da14 = 2; } //炎
        else if (da13 == 3 && player02.type[0] == 3) { da14 = 0.5f; } //水
        else if (da13 == 3 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 3 && player02.type[0] == 5) { da14 = 0.5f; }  //草
        else if (da13 == 3 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 3 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 3 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 3 && player02.type[0] == 9) { da14 = 2; }  //地
        else if (da13 == 3 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 3 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 3 && player02.type[0] == 12) { da14 = 2; }  //虫
        else if (da13 == 3 && player02.type[0] == 13) { da14 = 2; }  //岩
        else if (da13 == 3 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 3 && player02.type[0] == 15) { da14 = 0.5f; }  //竜
        else if (da13 == 3 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 3 && player02.type[0] == 17) { da14 = 2; }  //鋼
        else if (da13 == 3 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                    //攻撃側が電
        else if (da13 == 4 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 4 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 4 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 4 && player02.type[0] == 3) { da14 = 2; } //水
        else if (da13 == 4 && player02.type[0] == 4) { da14 = 0.5f; }   //電
        else if (da13 == 4 && player02.type[0] == 5) { da14 = 0.5f; }  //草
        else if (da13 == 4 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 4 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 4 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 4 && player02.type[0] == 9) { da14 = 0; }  //地
        else if (da13 == 4 && player02.type[0] == 10) { da14 = 2; } //飛
        else if (da13 == 4 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 4 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 4 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 4 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 4 && player02.type[0] == 15) { da14 = 0.5f; }  //竜
        else if (da13 == 4 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 4 && player02.type[0] == 17) { da14 = 1; }  //鋼
        else if (da13 == 4 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                    //攻撃側が草
        else if (da13 == 5 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 5 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 5 && player02.type[0] == 2) { da14 = 0.5f; } //炎
        else if (da13 == 5 && player02.type[0] == 3) { da14 = 2; } //水
        else if (da13 == 5 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 5 && player02.type[0] == 5) { da14 = 0.5f; }  //草
        else if (da13 == 5 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 5 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 5 && player02.type[0] == 8) { da14 = 0.5f; } //毒
        else if (da13 == 5 && player02.type[0] == 9) { da14 = 2; }  //地
        else if (da13 == 5 && player02.type[0] == 10) { da14 = 0.5f; } //飛
        else if (da13 == 5 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 5 && player02.type[0] == 12) { da14 = 0.5f; }  //虫
        else if (da13 == 5 && player02.type[0] == 13) { da14 = 2; }  //岩
        else if (da13 == 5 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 5 && player02.type[0] == 15) { da14 = 0.5f; }  //竜
        else if (da13 == 5 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 5 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 5 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                    //攻撃側が氷
        else if (da13 == 6 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 6 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 6 && player02.type[0] == 2) { da14 = 0.5f; } //炎
        else if (da13 == 6 && player02.type[0] == 3) { da14 = 0.5f; } //水
        else if (da13 == 6 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 6 && player02.type[0] == 5) { da14 = 2; }  //草
        else if (da13 == 6 && player02.type[0] == 6) { da14 = 0.5f; }  //氷
        else if (da13 == 6 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 6 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 6 && player02.type[0] == 9) { da14 = 2; }  //地
        else if (da13 == 6 && player02.type[0] == 10) { da14 = 2; } //飛
        else if (da13 == 6 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 6 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 6 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 6 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 6 && player02.type[0] == 15) { da14 = 2; }  //竜
        else if (da13 == 6 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 6 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 6 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                    //攻撃側が格
        else if (da13 == 7 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 7 && player02.type[0] == 1) { da14 = 2; }  //ノ
        else if (da13 == 7 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 7 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 7 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 7 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 7 && player02.type[0] == 6) { da14 = 2; }  //氷
        else if (da13 == 7 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 7 && player02.type[0] == 8) { da14 = 0.5f; } //毒
        else if (da13 == 7 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 7 && player02.type[0] == 10) { da14 = 0.5f; } //飛
        else if (da13 == 7 && player02.type[0] == 11) { da14 = 0.5f; } //超
        else if (da13 == 7 && player02.type[0] == 12) { da14 = 0.5f; }  //虫
        else if (da13 == 7 && player02.type[0] == 13) { da14 = 2; }  //岩
        else if (da13 == 7 && player02.type[0] == 14) { da14 = 0; }  //霊
        else if (da13 == 7 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 7 && player02.type[0] == 16) { da14 = 2; }  //悪
        else if (da13 == 7 && player02.type[0] == 17) { da14 = 2; }  //鋼
        else if (da13 == 7 && player02.type[0] == 18) { da14 = 0.5f; } //妖
                                                                       //攻撃側が毒
        else if (da13 == 8 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 8 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 8 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 8 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 8 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 8 && player02.type[0] == 5) { da14 = 2; }  //草
        else if (da13 == 8 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 8 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 8 && player02.type[0] == 8) { da14 = 0.5f; } //毒
        else if (da13 == 8 && player02.type[0] == 9) { da14 = 0.5f; }  //地
        else if (da13 == 8 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 8 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 8 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 8 && player02.type[0] == 13) { da14 = 0.5f; }  //岩
        else if (da13 == 8 && player02.type[0] == 14) { da14 = 0.5f; }  //霊
        else if (da13 == 8 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 8 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 8 && player02.type[0] == 17) { da14 = 0; }  //鋼
        else if (da13 == 8 && player02.type[0] == 18) { da14 = 2; } //妖
                                                                    //攻撃側が地面
        else if (da13 == 9 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 9 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 9 && player02.type[0] == 2) { da14 = 2; } //炎
        else if (da13 == 9 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 9 && player02.type[0] == 4) { da14 = 2; }   //電
        else if (da13 == 9 && player02.type[0] == 5) { da14 = 0.5f; }  //草
        else if (da13 == 9 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 9 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 9 && player02.type[0] == 8) { da14 = 2; } //毒
        else if (da13 == 9 && player02.type[0] == 9) { da14 = 2; }  //地
        else if (da13 == 9 && player02.type[0] == 10) { da14 = 0; } //飛
        else if (da13 == 9 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 9 && player02.type[0] == 12) { da14 = 0.5f; }  //虫
        else if (da13 == 9 && player02.type[0] == 13) { da14 = 2; }  //岩
        else if (da13 == 9 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 9 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 9 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 9 && player02.type[0] == 17) { da14 = 2; }  //鋼
        else if (da13 == 9 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                    //攻撃側が飛行
        else if (da13 == 10 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 10 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 10 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 10 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 10 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 10 && player02.type[0] == 5) { da14 = 2; }  //草
        else if (da13 == 10 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 10 && player02.type[0] == 7) { da14 = 2; } //格
        else if (da13 == 10 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 10 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 10 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 10 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 10 && player02.type[0] == 12) { da14 = 2; }  //虫
        else if (da13 == 10 && player02.type[0] == 13) { da14 = 0.5f; }  //岩
        else if (da13 == 10 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 10 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 10 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 10 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 10 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                     //攻撃側が超
        else if (da13 == 11 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 11 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 11 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 11 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 11 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 11 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 11 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 11 && player02.type[0] == 7) { da14 = 2; } //格
        else if (da13 == 11 && player02.type[0] == 8) { da14 = 2; } //毒
        else if (da13 == 11 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 11 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 11 && player02.type[0] == 11) { da14 = 0.5f; } //超
        else if (da13 == 11 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 11 && player02.type[0] == 13) { da14 = 2; }  //岩
        else if (da13 == 11 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 11 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 11 && player02.type[0] == 16) { da14 = 0; }  //悪
        else if (da13 == 11 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 11 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                     //攻撃側が虫
        else if (da13 == 12 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 12 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 12 && player02.type[0] == 2) { da14 = 0.5f; } //炎
        else if (da13 == 12 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 12 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 12 && player02.type[0] == 5) { da14 = 2; }  //草
        else if (da13 == 12 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 12 && player02.type[0] == 7) { da14 = 0.5f; } //格
        else if (da13 == 12 && player02.type[0] == 8) { da14 = 0.5f; } //毒
        else if (da13 == 12 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 12 && player02.type[0] == 10) { da14 = 0.5f; } //飛
        else if (da13 == 12 && player02.type[0] == 11) { da14 = 2; } //超
        else if (da13 == 12 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 12 && player02.type[0] == 13) { da14 = 2; }  //岩
        else if (da13 == 12 && player02.type[0] == 14) { da14 = 0.5f; }  //霊
        else if (da13 == 12 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 12 && player02.type[0] == 16) { da14 = 2; }  //悪
        else if (da13 == 12 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 12 && player02.type[0] == 18) { da14 = 0.5f; } //妖
                                                                        //攻撃側が岩
        else if (da13 == 13 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 13 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 13 && player02.type[0] == 2) { da14 = 2; } //炎
        else if (da13 == 13 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 13 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 13 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 13 && player02.type[0] == 6) { da14 = 2; }  //氷
        else if (da13 == 13 && player02.type[0] == 7) { da14 = 0.5f; } //格
        else if (da13 == 13 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 13 && player02.type[0] == 9) { da14 = 0.5f; }  //地
        else if (da13 == 13 && player02.type[0] == 10) { da14 = 2; } //飛
        else if (da13 == 13 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 13 && player02.type[0] == 12) { da14 = 2; }  //虫
        else if (da13 == 13 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 13 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 13 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 13 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 13 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 13 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                     //攻撃側が霊
        else if (da13 == 14 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 14 && player02.type[0] == 1) { da14 = 0; }  //ノ
        else if (da13 == 14 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 14 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 14 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 14 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 14 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 14 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 14 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 14 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 14 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 14 && player02.type[0] == 11) { da14 = 2; } //超
        else if (da13 == 14 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 14 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 14 && player02.type[0] == 14) { da14 = 2; }  //霊
        else if (da13 == 14 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 14 && player02.type[0] == 16) { da14 = 0.5f; }  //悪
        else if (da13 == 14 && player02.type[0] == 17) { da14 = 1; }  //鋼
        else if (da13 == 14 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                     //攻撃側が竜
        else if (da13 == 15 && player02.type[0] == 0) { da14 = 1; }  //タイプなし
        else if (da13 == 15 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 15 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 15 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 15 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 15 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 15 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 15 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 15 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 15 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 15 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 15 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 15 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 15 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 15 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 15 && player02.type[0] == 15) { da14 = 2; }  //竜
        else if (da13 == 15 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 15 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 15 && player02.type[0] == 18) { da14 = 0; } //妖
                                                                     //攻撃側が悪
        else if (da13 == 16 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 16 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 16 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 16 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 16 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 16 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 16 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 16 && player02.type[0] == 7) { da14 = 0.5f; } //格
        else if (da13 == 16 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 16 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 16 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 16 && player02.type[0] == 11) { da14 = 2; } //超
        else if (da13 == 16 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 16 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 16 && player02.type[0] == 14) { da14 = 2; }  //霊
        else if (da13 == 16 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 16 && player02.type[0] == 16) { da14 = 0.5f; }  //悪
        else if (da13 == 16 && player02.type[0] == 17) { da14 = 1; }  //鋼
        else if (da13 == 16 && player02.type[0] == 18) { da14 = 0.5f; } //妖
                                                                        //攻撃側が鋼
        else if (da13 == 17 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 17 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 17 && player02.type[0] == 2) { da14 = 0.5f; } //炎
        else if (da13 == 17 && player02.type[0] == 3) { da14 = 0.5f; } //水
        else if (da13 == 17 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 17 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 17 && player02.type[0] == 6) { da14 = 2; }  //氷
        else if (da13 == 17 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 17 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 17 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 17 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 17 && player02.type[0] == 11) { da14 = 2; } //超
        else if (da13 == 17 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 17 && player02.type[0] == 13) { da14 = 2; }  //岩
        else if (da13 == 17 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 17 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 17 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 17 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 17 && player02.type[0] == 18) { da14 = 2; } //妖
                                                                     //攻撃側が妖
        else if (da13 == 18 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 18 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 18 && player02.type[0] == 2) { da14 = 0.5f; } //炎
        else if (da13 == 18 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 18 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 18 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 18 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 18 && player02.type[0] == 7) { da14 = 2; } //格
        else if (da13 == 18 && player02.type[0] == 8) { da14 = 0.5f; } //毒
        else if (da13 == 18 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 18 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 18 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 18 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 18 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 18 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 18 && player02.type[0] == 15) { da14 = 2; }  //竜
        else if (da13 == 18 && player02.type[0] == 16) { da14 = 2; }  //悪
        else if (da13 == 18 && player02.type[0] == 17) { da14 = 0.5f; }  //鋼
        else if (da13 == 18 && player02.type[0] == 18) { da14 = 1; } //妖
                                                                     //攻撃側がタイプなし
        else if (da13 == 19 && player02.type[0] == 0) { da14 = 1; }      //タイプなし
        else if (da13 == 19 && player02.type[0] == 1) { da14 = 1; }  //ノ
        else if (da13 == 19 && player02.type[0] == 2) { da14 = 1; } //炎
        else if (da13 == 19 && player02.type[0] == 3) { da14 = 1; } //水
        else if (da13 == 19 && player02.type[0] == 4) { da14 = 1; }   //電
        else if (da13 == 19 && player02.type[0] == 5) { da14 = 1; }  //草
        else if (da13 == 19 && player02.type[0] == 6) { da14 = 1; }  //氷
        else if (da13 == 19 && player02.type[0] == 7) { da14 = 1; } //格
        else if (da13 == 19 && player02.type[0] == 8) { da14 = 1; } //毒
        else if (da13 == 19 && player02.type[0] == 9) { da14 = 1; }  //地
        else if (da13 == 19 && player02.type[0] == 10) { da14 = 1; } //飛
        else if (da13 == 19 && player02.type[0] == 11) { da14 = 1; } //超
        else if (da13 == 19 && player02.type[0] == 12) { da14 = 1; }  //虫
        else if (da13 == 19 && player02.type[0] == 13) { da14 = 1; }  //岩
        else if (da13 == 19 && player02.type[0] == 14) { da14 = 1; }  //霊
        else if (da13 == 19 && player02.type[0] == 15) { da14 = 1; }  //竜
        else if (da13 == 19 && player02.type[0] == 16) { da14 = 1; }  //悪
        else if (da13 == 19 && player02.type[0] == 17) { da14 = 1; }  //鋼
        else if (da13 == 19 && player02.type[0] == 18) { da14 = 1; } //妖

        else { Debug.Log("相性判定1失敗"); };





        //技タイプ→防御タイプ2

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
        else if (da13 == 1 && player02.type[1] == 13) { da15 = 0.5f; }    //岩
        else if (da13 == 1 && player02.type[1] == 14) { da15 = 0; Debug.Log("1→14"); }     //霊
        else if (da13 == 1 && player02.type[1] == 15) { da15 = 1; }
        else if (da13 == 1 && player02.type[1] == 16) { da15 = 1; }
        else if (da13 == 1 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
        else if (da13 == 1 && player02.type[1] == 18) { da15 = 1; }
        //攻撃側が炎
        else if (da13 == 2 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 2 && player02.type[1] == 1) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 2) { da15 = 0.5f; } //炎
        else if (da13 == 2 && player02.type[1] == 3) { da15 = 0.5f; } //水
        else if (da13 == 2 && player02.type[1] == 4) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 5) { da15 = 2; }  //草
        else if (da13 == 2 && player02.type[1] == 6) { da15 = 2; }  //氷
        else if (da13 == 2 && player02.type[1] == 7) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 8) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 9) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 10) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 11) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 12) { da15 = 2; }     //虫
        else if (da13 == 2 && player02.type[1] == 13) { da15 = 0.5f; } //岩
        else if (da13 == 2 && player02.type[1] == 14) { da15 = 1; }     //霊
        else if (da13 == 2 && player02.type[1] == 15) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 16) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 17) { da15 = 2; }  //鋼
        else if (da13 == 2 && player02.type[1] == 18) { da15 = 1; }
        //攻撃側が水
        else if (da13 == 3 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 3 && player02.type[1] == 1) { da15 = 1; }
        else if (da13 == 3 && player02.type[1] == 2) { da15 = 2; } //炎
        else if (da13 == 3 && player02.type[1] == 3) { da15 = 0.5f; } //水
        else if (da13 == 3 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 3 && player02.type[1] == 5) { da15 = 0.5f; Debug.Log("ここ？"); }  //草
        else if (da13 == 3 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 3 && player02.type[1] == 7) { da15 = 1; } //格
        else if (da13 == 3 && player02.type[1] == 8) { da15 = 1; } //毒
        else if (da13 == 3 && player02.type[1] == 9) { da15 = 2; }  //地
        else if (da13 == 3 && player02.type[1] == 10) { da15 = 1; } //飛
        else if (da13 == 3 && player02.type[1] == 11) { da15 = 1; } //超
        else if (da13 == 3 && player02.type[1] == 12) { da15 = 2; }  //虫
        else if (da13 == 3 && player02.type[1] == 13) { da15 = 2; }  //岩
        else if (da13 == 3 && player02.type[1] == 14) { da15 = 1; }  //霊
        else if (da13 == 3 && player02.type[1] == 15) { da15 = 0.5f; }  //竜
        else if (da13 == 3 && player02.type[1] == 16) { da15 = 1; }  //悪
        else if (da13 == 3 && player02.type[1] == 17) { da15 = 2; }  //鋼
        else if (da13 == 3 && player02.type[1] == 18) { da15 = 1; } //妖
        //攻撃側が電
        else if (da13 == 4 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 4 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 4 && player02.type[1] == 2) { da15 = 1; } //炎
        else if (da13 == 4 && player02.type[1] == 3) { da15 = 2; } //水
        else if (da13 == 4 && player02.type[1] == 4) { da15 = 0.5f; }   //電
        else if (da13 == 4 && player02.type[1] == 5) { da15 = 0.5f; }  //草
        else if (da13 == 4 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 4 && player02.type[1] == 7) { da15 = 1; } //格
        else if (da13 == 4 && player02.type[1] == 8) { da15 = 1; } //毒
        else if (da13 == 4 && player02.type[1] == 9) { da15 = 0; Debug.Log("4→9"); }  //地
        else if (da13 == 4 && player02.type[1] == 10) { da15 = 2; } //飛
        else if (da13 == 4 && player02.type[1] == 11) { da15 = 1; } //超
        else if (da13 == 4 && player02.type[1] == 12) { da15 = 1; }  //虫
        else if (da13 == 4 && player02.type[1] == 13) { da15 = 1; }  //岩
        else if (da13 == 4 && player02.type[1] == 14) { da15 = 1; }  //霊
        else if (da13 == 4 && player02.type[1] == 15) { da15 = 0.5f; }  //竜
        else if (da13 == 4 && player02.type[1] == 16) { da15 = 1; }  //悪
        else if (da13 == 4 && player02.type[1] == 17) { da15 = 1; }  //鋼
        else if (da13 == 4 && player02.type[1] == 18) { da15 = 1; } //妖
        //攻撃側が草
        else if (da13 == 5 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 5 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 5 && player02.type[1] == 2) { da15 = 0.5f; } //炎
        else if (da13 == 5 && player02.type[1] == 3) { da15 = 2; } //水
        else if (da13 == 5 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 5 && player02.type[1] == 5) { da15 = 0.5f; }  //草
        else if (da13 == 5 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 5 && player02.type[1] == 7) { da15 = 1; } //格
        else if (da13 == 5 && player02.type[1] == 8) { da15 = 0.5f; } //毒
        else if (da13 == 5 && player02.type[1] == 9) { da15 = 2; }  //地
        else if (da13 == 5 && player02.type[1] == 10) { da15 = 0.5f; } //飛
        else if (da13 == 5 && player02.type[1] == 11) { da15 = 1; } //超
        else if (da13 == 5 && player02.type[1] == 12) { da15 = 0.5f; }  //虫
        else if (da13 == 5 && player02.type[1] == 13) { da15 = 2; }  //岩
        else if (da13 == 5 && player02.type[1] == 14) { da15 = 1; }  //霊
        else if (da13 == 5 && player02.type[1] == 15) { da15 = 0.5f; }  //竜
        else if (da13 == 5 && player02.type[1] == 16) { da15 = 1; }  //悪
        else if (da13 == 5 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
        else if (da13 == 5 && player02.type[1] == 18) { da15 = 1; } //妖
        //攻撃側が氷
        else if (da13 == 6 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 6 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 6 && player02.type[1] == 2) { da15 = 0.5f; } //炎
        else if (da13 == 6 && player02.type[1] == 3) { da15 = 0.5f; } //水
        else if (da13 == 6 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 6 && player02.type[1] == 5) { da15 = 2; }  //草
        else if (da13 == 6 && player02.type[1] == 6) { da15 = 0.5f; }  //氷
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
        else if (da13 == 6 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
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
        else if (da13 == 7 && player02.type[1] == 8) { da15 = 0.5f; } //毒
        else if (da13 == 7 && player02.type[1] == 9) { da15 = 1; }  //地
        else if (da13 == 7 && player02.type[1] == 10) { da15 = 0.5f; } //飛
        else if (da13 == 7 && player02.type[1] == 11) { da15 = 0.5f; } //超
        else if (da13 == 7 && player02.type[1] == 12) { da15 = 0.5f; }  //虫
        else if (da13 == 7 && player02.type[1] == 13) { da15 = 2; }  //岩
        else if (da13 == 7 && player02.type[1] == 14) { da15 = 0; Debug.Log("7→14"); }  //霊
        else if (da13 == 7 && player02.type[1] == 15) { da15 = 1; }  //竜
        else if (da13 == 7 && player02.type[1] == 16) { da15 = 2; }  //悪
        else if (da13 == 7 && player02.type[1] == 17) { da15 = 2; }  //鋼
        else if (da13 == 7 && player02.type[1] == 18) { da15 = 0.5f; } //妖
        //攻撃側が毒
        else if (da13 == 8 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 8 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 8 && player02.type[1] == 2) { da15 = 1; } //炎
        else if (da13 == 8 && player02.type[1] == 3) { da15 = 1; } //水
        else if (da13 == 8 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 8 && player02.type[1] == 5) { da15 = 2; }  //草
        else if (da13 == 8 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 8 && player02.type[1] == 7) { da15 = 1; } //格
        else if (da13 == 8 && player02.type[1] == 8) { da15 = 0.5f; } //毒
        else if (da13 == 8 && player02.type[1] == 9) { da15 = 0.5f; }  //地
        else if (da13 == 8 && player02.type[1] == 10) { da15 = 1; } //飛
        else if (da13 == 8 && player02.type[1] == 11) { da15 = 1; } //超
        else if (da13 == 8 && player02.type[1] == 12) { da15 = 1; }  //虫
        else if (da13 == 8 && player02.type[1] == 13) { da15 = 0.5f; }  //岩
        else if (da13 == 8 && player02.type[1] == 14) { da15 = 0.5f; }  //霊
        else if (da13 == 8 && player02.type[1] == 15) { da15 = 1; }  //竜
        else if (da13 == 8 && player02.type[1] == 16) { da15 = 1; }  //悪
        else if (da13 == 8 && player02.type[1] == 17) { da15 = 0; Debug.Log("8→17"); }  //鋼
        else if (da13 == 8 && player02.type[1] == 18) { da15 = 2; } //妖
        //攻撃側が地面
        else if (da13 == 9 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 9 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 9 && player02.type[1] == 2) { da15 = 2; } //炎
        else if (da13 == 9 && player02.type[1] == 3) { da15 = 1; } //水
        else if (da13 == 9 && player02.type[1] == 4) { da15 = 2; }   //電
        else if (da13 == 9 && player02.type[1] == 5) { da15 = 0.5f; }  //草
        else if (da13 == 9 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 9 && player02.type[1] == 7) { da15 = 1; } //格
        else if (da13 == 9 && player02.type[1] == 8) { da15 = 2; } //毒
        else if (da13 == 9 && player02.type[1] == 9) { da15 = 2; }  //地
        else if (da13 == 9 && player02.type[1] == 10) { da15 = 0; Debug.Log("9→10"); } //飛
        else if (da13 == 9 && player02.type[1] == 11) { da15 = 1; } //超
        else if (da13 == 9 && player02.type[1] == 12) { da15 = 0.5f; }  //虫
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
        else if (da13 == 10 && player02.type[1] == 13) { da15 = 0.5f; }  //岩
        else if (da13 == 10 && player02.type[1] == 14) { da15 = 1; }  //霊
        else if (da13 == 10 && player02.type[1] == 15) { da15 = 1; }  //竜
        else if (da13 == 10 && player02.type[1] == 16) { da15 = 1; }  //悪
        else if (da13 == 10 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
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
        else if (da13 == 11 && player02.type[1] == 11) { da15 = 0.5f; } //超
        else if (da13 == 11 && player02.type[1] == 12) { da15 = 1; }  //虫
        else if (da13 == 11 && player02.type[1] == 13) { da15 = 2; }  //岩
        else if (da13 == 11 && player02.type[1] == 14) { da15 = 1; }  //霊
        else if (da13 == 11 && player02.type[1] == 15) { da15 = 1; }  //竜
        else if (da13 == 11 && player02.type[1] == 16) { da15 = 0; Debug.Log("11→16"); }  //悪
        else if (da13 == 11 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
        else if (da13 == 11 && player02.type[1] == 18) { da15 = 1; } //妖
        //攻撃側が虫
        else if (da13 == 12 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 12 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 12 && player02.type[1] == 2) { da15 = 0.5f; } //炎
        else if (da13 == 12 && player02.type[1] == 3) { da15 = 1; } //水
        else if (da13 == 12 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 12 && player02.type[1] == 5) { da15 = 2; }  //草
        else if (da13 == 12 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 12 && player02.type[1] == 7) { da15 = 0.5f; } //格
        else if (da13 == 12 && player02.type[1] == 8) { da15 = 0.5f; } //毒
        else if (da13 == 12 && player02.type[1] == 9) { da15 = 1; }  //地
        else if (da13 == 12 && player02.type[1] == 10) { da15 = 0.5f; } //飛
        else if (da13 == 12 && player02.type[1] == 11) { da15 = 2; } //超
        else if (da13 == 12 && player02.type[1] == 12) { da15 = 1; }  //虫
        else if (da13 == 12 && player02.type[1] == 13) { da15 = 2; }  //岩
        else if (da13 == 12 && player02.type[1] == 14) { da15 = 0.5f; }  //霊
        else if (da13 == 12 && player02.type[1] == 15) { da15 = 1; }  //竜
        else if (da13 == 12 && player02.type[1] == 16) { da15 = 2; }  //悪
        else if (da13 == 12 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
        else if (da13 == 12 && player02.type[1] == 18) { da15 = 0.5f; } //妖
        //攻撃側が岩
        else if (da13 == 13 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 13 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 13 && player02.type[1] == 2) { da15 = 2; } //炎
        else if (da13 == 13 && player02.type[1] == 3) { da15 = 1; } //水
        else if (da13 == 13 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 13 && player02.type[1] == 5) { da15 = 1; }  //草
        else if (da13 == 13 && player02.type[1] == 6) { da15 = 2; }  //氷
        else if (da13 == 13 && player02.type[1] == 7) { da15 = 0.5f; } //格
        else if (da13 == 13 && player02.type[1] == 8) { da15 = 1; } //毒
        else if (da13 == 13 && player02.type[1] == 9) { da15 = 0.5f; }  //地
        else if (da13 == 13 && player02.type[1] == 10) { da15 = 2; } //飛
        else if (da13 == 13 && player02.type[1] == 11) { da15 = 1; } //超
        else if (da13 == 13 && player02.type[1] == 12) { da15 = 2; }  //虫
        else if (da13 == 13 && player02.type[1] == 13) { da15 = 1; }  //岩
        else if (da13 == 13 && player02.type[1] == 14) { da15 = 1; }  //霊
        else if (da13 == 13 && player02.type[1] == 15) { da15 = 1; }  //竜
        else if (da13 == 13 && player02.type[1] == 16) { da15 = 1; }  //悪
        else if (da13 == 13 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
        else if (da13 == 13 && player02.type[1] == 18) { da15 = 1; } //妖
        //攻撃側が霊
        else if (da13 == 14 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 14 && player02.type[1] == 1) { da15 = 0; Debug.Log("14→1"); }  //ノ
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
        else if (da13 == 14 && player02.type[1] == 16) { da15 = 0.5f; }  //悪
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
        else if (da13 == 15 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
        else if (da13 == 15 && player02.type[1] == 18) { da15 = 0; Debug.Log("15→18"); } //妖
        //攻撃側が悪
        else if (da13 == 16 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 16 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 16 && player02.type[1] == 2) { da15 = 1; } //炎
        else if (da13 == 16 && player02.type[1] == 3) { da15 = 1; } //水
        else if (da13 == 16 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 16 && player02.type[1] == 5) { da15 = 1; }  //草
        else if (da13 == 16 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 16 && player02.type[1] == 7) { da15 = 0.5f; } //格
        else if (da13 == 16 && player02.type[1] == 8) { da15 = 1; } //毒
        else if (da13 == 16 && player02.type[1] == 9) { da15 = 1; }  //地
        else if (da13 == 16 && player02.type[1] == 10) { da15 = 1; } //飛
        else if (da13 == 16 && player02.type[1] == 11) { da15 = 2; } //超
        else if (da13 == 16 && player02.type[1] == 12) { da15 = 1; }  //虫
        else if (da13 == 16 && player02.type[1] == 13) { da15 = 1; }  //岩
        else if (da13 == 16 && player02.type[1] == 14) { da15 = 2; }  //霊
        else if (da13 == 16 && player02.type[1] == 15) { da15 = 1; }  //竜
        else if (da13 == 16 && player02.type[1] == 16) { da15 = 0.5f; }  //悪
        else if (da13 == 16 && player02.type[1] == 17) { da15 = 1; }  //鋼
        else if (da13 == 16 && player02.type[1] == 18) { da15 = 0.5f; } //妖
        //攻撃側が鋼
        else if (da13 == 17 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 17 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 17 && player02.type[1] == 2) { da15 = 0.5f; } //炎
        else if (da13 == 17 && player02.type[1] == 3) { da15 = 0.5f; } //水
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
        else if (da13 == 17 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
        else if (da13 == 17 && player02.type[1] == 18) { da15 = 2; } //妖
        //攻撃側が妖
        else if (da13 == 18 && player02.type[1] == 0) { da15 = 1; }      //タイプなし
        else if (da13 == 18 && player02.type[1] == 1) { da15 = 1; }  //ノ
        else if (da13 == 18 && player02.type[1] == 2) { da15 = 0.5f; } //炎
        else if (da13 == 18 && player02.type[1] == 3) { da15 = 1; } //水
        else if (da13 == 18 && player02.type[1] == 4) { da15 = 1; }   //電
        else if (da13 == 18 && player02.type[1] == 5) { da15 = 1; }  //草
        else if (da13 == 18 && player02.type[1] == 6) { da15 = 1; }  //氷
        else if (da13 == 18 && player02.type[1] == 7) { da15 = 2; } //格
        else if (da13 == 18 && player02.type[1] == 8) { da15 = 0.5f; } //毒
        else if (da13 == 18 && player02.type[1] == 9) { da15 = 1; }  //地
        else if (da13 == 18 && player02.type[1] == 10) { da15 = 1; } //飛
        else if (da13 == 18 && player02.type[1] == 11) { da15 = 1; } //超
        else if (da13 == 18 && player02.type[1] == 12) { da15 = 1; }  //虫
        else if (da13 == 18 && player02.type[1] == 13) { da15 = 1; }  //岩
        else if (da13 == 18 && player02.type[1] == 14) { da15 = 1; }  //霊
        else if (da13 == 18 && player02.type[1] == 15) { da15 = 2; }  //竜
        else if (da13 == 18 && player02.type[1] == 16) { da15 = 2; }  //悪
        else if (da13 == 18 && player02.type[1] == 17) { da15 = 0.5f; }  //鋼
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

        Debug.Log("da13=" + da13 + ",da14=" + da14 + ",da15=" + da15);

        //タイプ相性合計判定
        float da16 = da14 * da15;
        if (da16 == 1) { Debug.Log("相性等倍"); }
        else if (da16 == 4) { Debug.Log("効果は抜群だ(4倍)"); }
        else if (da16 == 2) { Debug.Log("効果は抜群だ(2倍)"); }
        else if (da16 == 0.5f) { Debug.Log("効果はいまひとつのようだ(0.5倍)"); }
        else if (da16 == 0.25f) { Debug.Log("効果はいまひとつのようだ(0.25倍)"); }
        else if (da16 == 0f) { Debug.Log("効果はないようだ"); }
        else { Debug.Log("相性合計判定失敗"); }

        float da17 = Mathf.Floor(da12 * da16);
        Debug.Log("相性判定後" + da17);

        #endregion ●タイプ補正
        #region ●火傷　M補正
        //やけど判定
        float da18 = da17;

        //M補正(壁補正×ブレインフォース補正×スナイパー補正×
        //いろめがね補正×もふもふほのお補正×Mhalf×Mfilter×
        //フレンドガード補正×たつじんのおび補正×メトロノーム補正×
        //いのちのたま補正×半減の実補正×Mtwice(小数点以下を逐一四捨五入)(最終的に五捨五超入)

        float da19 = Mathf.Ceil(da18 - 0.5f);

        //Mprotect補正(Zワザ/ダイマックスわざがまもる状態などで軽減されたとき0.25倍)

        float da20 = da19;

        Debug.Log("最終ダメージ関数値" + da20);
        #endregion ●火傷　M補正
        #region ●最終ダメージ計算
        //最終ダメージ計算

        player02.HPNow -= da20;

        player02.statusDisplay();

        Debug.Log("プレイヤー02のモンスターのHP" + player02.HPNow + "/" + player02.HPMax);


        string WNlog = "";

        if (WN01 == 1) { WNlog = "きりかかる"; }
        else if (WN01 == 2) { WNlog = "おそいかかる"; }
        else if (WN01 == 3) { WNlog = "とびどうぐ"; }
        else if (WN01 == 4) { WNlog = "きあい"; }


        UImessage.GetComponent<Text>().text =
        "プレイヤー01のモンスターの攻撃！  " + WNlog + "!! \n" +
        "急所乱数" + da08r + "/24 \n " +
        "乱数補正" + da10 + "% \n" +
        "タイプ相性" + da16 + "倍 \n" +
        "ダメージ" + da20;


    }
    //ダメージ計算式
    #endregion ●最終ダメージ計算
    #endregion ◎ダメージ計算
}
