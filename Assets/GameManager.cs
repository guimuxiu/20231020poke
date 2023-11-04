using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;

//UI部品
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    #region ◎オブジェクト等の定義

    //ステイト番号
    private int stateNumber = 0;

    //汎用タイマー
    private float timeCounter = 0.0f;

    //UI メッセージ
    public GameObject UImessage;

    //UI ステイト番号の表示
    public GameObject UIStateNumber;

    //UI モンスターの表示
    public GameObject UIplayer01text;
    public GameObject UIplayer02text;

    //UI モンスターHP
    public GameObject Ul01HPtext;
    public GameObject Ul02HPtext;

    //UI コマンド
    public GameObject UIchoice01;
    public GameObject UIchoice02;

    //UI 技
    public GameObject UIweapon01;
    public GameObject UIweapon02;

    //UIステータス
    public GameObject UIStatus01;
    public GameObject UIStatus02;

    //プレイヤーのUI操作の結果
    //0=未選択、1=こうげき、2=いれかえ 3=ステータス
    private int choiceCommand01 = 0;
    private int choiceCommand02 = 0;

    //プレイヤーの武器選択の結果
    //0=未選択、1=武器1、……
    private int WN01 = 0;
    private int WN02 = 0;


    //モンスターの交替画面
    public GameObject ChangeMonster01;
    public GameObject ChangeMonster02;



    //行動したかどうかの確認
    //0=未行動、1=行動済み
    private int ActionCheck01 = 0;
    private int ActionCheck02 = 0;


    //残りモンスター数
    private int MonsterCount01 = 6;
    private int MonsterCount02 = 6;


    //技テキスト
    public GameObject TextWeapon01Player01;
    public GameObject TextWeapon02Player01;
    public GameObject TextWeapon03Player01;
    public GameObject TextWeapon04Player01;
    public GameObject TextWeapon01Player02;
    public GameObject TextWeapon02Player02;
    public GameObject TextWeapon03Player02;
    public GameObject TextWeapon04Player02;


    //ライフバー
    public GameObject UIHPnow1;
    public GameObject UIHPnow2;


    //現在のモンスターの管理番号
    private int PL01 = 5;
    private int PL02 = 6;


    //モンスターのプレハブ
    public GameObject[] PL01prefab = new GameObject[10];
    public GameObject[] PL02prefab = new GameObject[10];


    //入れ替えボタン
    public GameObject[] PL01changeButton = new GameObject[10];
    public GameObject[] PL02changeButton = new GameObject[10];

    #endregion　◎オブジェクト等の定義
    #region ◎スタート時に生成するもの
    void Start()
    {
        //プレイヤー1側の生成(待機)
        Instantiate(PL01prefab[1]);
        Instantiate(PL01prefab[2]);
        Instantiate(PL01prefab[3]);
        Instantiate(PL01prefab[4]);
        Instantiate(PL01prefab[6]);

        //プレイヤー1側の生成(5)
        Instantiate(PL01prefab[PL01]).GetComponent<Monster01Player01>().stateNumber = 0;

        //プレイヤー1側の生成(待機)
        Instantiate(PL02prefab[1]);
        Instantiate(PL02prefab[2]);
        Instantiate(PL02prefab[3]);
        Instantiate(PL02prefab[4]);
        Instantiate(PL02prefab[5]);

        //プレイヤー2側の生成(6)
        Instantiate(PL02prefab[PL02]).GetComponent<Monster01Player02>().stateNumber = 0;



    }
    #endregion ◎スタート時に生成するもの
    #region　◎アップデート
    #region ●初期設定
    void Update()
    {
        //タイマー
        timeCounter += Time.deltaTime;

        //ステイト番号を表示する
        UIStateNumber.GetComponent<Text>().text = "" + stateNumber;


        //player01,02を定義する

        Monster01Player01 player01;
        player01 = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)").GetComponent<Monster01Player02>();



        //ライフバー (マイナスになったら0にする）
        UIHPnow1.GetComponent<RectTransform>().localScale = new Vector3((player01.HPNow / player01.HPMax), 1.0f, 1.0f);

        if ((player01.HPNow / player01.HPMax) <= 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
        if ((player01.HPNow / player01.HPMax) <= 0.2f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
        if (player01.HPNow <= 0) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }


        UIHPnow2.GetComponent<RectTransform>().localScale = new Vector3((player02.HPNow / player02.HPMax), 1.0f, 1.0f);
        if ((player02.HPNow / player02.HPMax) <= 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
        if ((player02.HPNow / player02.HPMax) <= 0.2f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
        if (player02.HPNow <= 0) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }


        if (player01.gender == 0)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 無性別"; }
        else if (player01.gender == 1)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♂"; }
        else if (player01.gender == 2)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♀"; }

        if (player02.gender == 0)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 無性別"; }
        else if (player02.gender == 1)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♂"; }
        else if (player02.gender == 2)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♀"; }




        //public GameObject UIplayer02text;


        #endregion ●初期設定ButtonBattlePlayer01()
        #region　●ステイト0　開始画面


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

        #endregion　●ステイト0　開始画面
        #region●ステイト100番台　プレイヤー01の選択画面
        else if (stateNumber == 101)
        {


            //HPを表示
            Ul01HPtext.GetComponent<Text>().text = "HP:" + player01.HPNow + "/" + player01.HPMax;
            Ul02HPtext.GetComponent<Text>().text = "HP:" + player02.HPNow + "/" + player02.HPMax;

            //ライフバー (マイナスになったら0にする）
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




                //未選択
                choiceCommand01 = 0;

                

                //行動確認off
                ActionCheck01 = 0;
                ActionCheck02 = 0;

                //
                UImessage.GetComponent<Text>().text = "行動選択";

                //コマンドON
                UIchoice01.SetActive(true);

                //ステイト変更
                stateNumber = 102;
            }
        }



        //コマンドが選択されるまでの待機
        else if (stateNumber == 102)
        {
            
            UIchoice02.SetActive(false);


            if (choiceCommand01 == 1)
            {



                Debug.Log("プレイヤー01の行動選択:たたかうを選んだ");

                //未選択
                WN01 = 0;
                WN02 = 0;


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


            if (choiceCommand01 == 2)
            {

                ChangeMonster01.SetActive(true);


                //ステイト変更→01の技選択画面
                stateNumber = 104;


            }




            if (choiceCommand01 == 3)
            {

                UIStatus01.SetActive(true);


                //ステイト変更
                stateNumber = 105;


            }

        }
        //技選択(プレイヤー01)
        else if (stateNumber == 103)
        {

            //未選択
            choiceCommand02 = 0;


            if (WN01 == 1)
            {
                Debug.Log("プレイヤー01は技" + WN01 + "を選んだ");


                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("プレイヤー02の行動選択");
            }
            else if (WN01 == 2)
            {
                Debug.Log("プレイヤー01は技" + WN01 + "を選んだ");



                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("プレイヤー02の行動選択");
            }
            else if (WN01 == 3)
            {
                Debug.Log("プレイヤー01は技" + WN01 + "を選んだ");



                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("プレイヤー02の行動選択");
            }
            else if (WN01 == 4)
            {
                Debug.Log("プレイヤー01は技" + WN01 + "を選んだ");



                UIchoice02.SetActive(true);
                stateNumber = 202;
                Debug.Log("プレイヤー02の行動選択");
            }


        }


        else if (stateNumber == 104)
        {
            Monster01Player01 monster01;
            monster01 = GameObject.Find("Monster01Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster01.HPNow <= 0)
            {
                //赤
                PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[1].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[1].GetComponent<Button>().enabled = true;
            }


            Monster01Player01 monster02;
            monster02 = GameObject.Find("Monster02Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster02.HPNow <= 0)
            {
                //赤
                PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[2].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[2].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster03;
            monster03 = GameObject.Find("Monster03Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster03.HPNow <= 0)
            {
                //赤
                PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[3].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[3].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster04;
            monster04 = GameObject.Find("Monster04Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster04.HPNow <= 0)
            {
                //赤
                PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[4].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[4].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster05;
            monster05 = GameObject.Find("Monster05Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster05.HPNow <= 0)
            {
                //赤
                PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[5].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[5].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster06;
            monster06 = GameObject.Find("Monster06Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster06.HPNow <= 0)
            {
                //赤
                PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[6].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[6].GetComponent<Button>().enabled = true;

            }



            //交替したモンスターのUIパネル
            if (player01.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 無性別"; }
            else if (player01.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♂"; }
            else if (player01.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♀"; }

            if (player02.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 無性別"; }
            else if (player02.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♂"; }
            else if (player02.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♀"; }



        }




        //ステータス確認画面
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



            ChangeMonster01.SetActive(true);

            Monster01Player01 monster01;
            monster01 = GameObject.Find("Monster01Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster01.HPNow <= 0)
            {
                //赤
                PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[1].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[1].GetComponent<Button>().enabled = true;
            }


            Monster01Player01 monster02;
            monster02 = GameObject.Find("Monster02Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster02.HPNow <= 0)
            {
                //赤
                PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[2].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[2].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster03;
            monster03 = GameObject.Find("Monster03Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster03.HPNow <= 0)
            {
                //赤
                PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[3].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[3].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster04;
            monster04 = GameObject.Find("Monster04Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster04.HPNow <= 0)
            {
                //赤
                PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[4].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[4].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster05;
            monster05 = GameObject.Find("Monster05Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster05.HPNow <= 0)
            {
                //赤
                PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[5].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[5].GetComponent<Button>().enabled = true;

            }

            Monster01Player01 monster06;
            monster06 = GameObject.Find("Monster06Player01(Clone)").GetComponent<Monster01Player01>();

            if (monster06.HPNow <= 0)
            {
                //赤
                PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL01changeButton[6].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL01changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL01changeButton[6].GetComponent<Button>().enabled = true;

            }

            if (player01.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 無性別"; }
            else if (player01.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♂"; }
            else if (player01.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♀"; }

            if (player02.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 無性別"; }
            else if (player02.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♂"; }
            else if (player02.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♀"; }


        }



        #endregion●ステイト100番台　プレイヤー01の選択画面
        #region　●ステイト200番台　プレイヤー02の選択画面
        //行動選択プレイヤー02
        else if (stateNumber == 202)
        {


            if (choiceCommand02 == 1)
            {
                //未選択
                WN02 = 0;
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


            if (choiceCommand02 == 2)
            {

                ChangeMonster02.SetActive(true);



                //ステイト変更
                stateNumber = 204;

            }



            if (choiceCommand02 == 3)
            {

                UIStatus02.SetActive(true);


                //ステイト変更→02の交替画面
                stateNumber = 205;
            }






        }
        //技選択プレイヤー02
        else if (stateNumber == 203)
        {

            if (WN02 != 0)
            {

                //タイマーリセット
                timeCounter = 0.0f;

                stateNumber = 301;
                Debug.Log("プレイヤー02は技を選んだ");
            }
        }

        //モンスター交替
        else if (stateNumber == 204)
        {
            Monster01Player02 monster01;
            monster01 = GameObject.Find("Monster01Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster01.HPNow <= 0)
            {
                //赤
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[1].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[1].GetComponent<Button>().enabled = true;
            }


            Monster01Player02 monster02;
            monster02 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster02.HPNow <= 0)
            {
                //赤
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[2].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[2].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster03;
            monster03 = GameObject.Find("Monster03Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster03.HPNow <= 0)
            {
                //赤
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[3].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[3].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster04;
            monster04 = GameObject.Find("Monster04Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster04.HPNow <= 0)
            {
                //赤
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[4].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[4].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster05;
            monster05 = GameObject.Find("Monster05Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster05.HPNow <= 0)
            {
                //赤
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[5].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[5].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster06;
            monster06 = GameObject.Find("Monster06Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster06.HPNow <= 0)
            {
                //赤
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[6].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[6].GetComponent<Button>().enabled = true;

            }



            //交替したモンスターのUIパネル
            if (player01.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 無性別"; }
            else if (player01.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♂"; }
            else if (player01.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♀"; }

            if (player02.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 無性別"; }
            else if (player02.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♂"; }
            else if (player02.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♀"; }








        }


        //ステータス確認
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


        //行動選択プレイヤー02
        else if (stateNumber == 206)
        {
            ChangeMonster02.SetActive(true);

            Monster01Player02 monster01;
            monster01 = GameObject.Find("Monster01Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster01.HPNow <= 0)
            {
                //赤
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[1].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[1].GetComponent<Button>().enabled = true;
            }


            Monster01Player02 monster02;
            monster02 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster02.HPNow <= 0)
            {
                //赤
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[2].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[2].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster03;
            monster03 = GameObject.Find("Monster03Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster03.HPNow <= 0)
            {
                //赤
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[3].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[3].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster04;
            monster04 = GameObject.Find("Monster04Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster04.HPNow <= 0)
            {
                //赤
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[4].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[4].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster05;
            monster05 = GameObject.Find("Monster05Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster05.HPNow <= 0)
            {
                //赤
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[5].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[5].GetComponent<Button>().enabled = true;

            }

            Monster01Player02 monster06;
            monster06 = GameObject.Find("Monster06Player02(Clone)").GetComponent<Monster01Player02>();

            if (monster06.HPNow <= 0)
            {
                //赤
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                //ボタンを押せなくする
                PL02changeButton[6].GetComponent<Button>().enabled = false;
            }
            else
            {
                //白
                PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                //ボタンを押せる
                PL02changeButton[6].GetComponent<Button>().enabled = true;

            }



            //交替したモンスターのUIパネル
            if (player01.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 無性別"; }
            else if (player01.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♂"; }
            else if (player01.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♀"; }

            if (player02.gender == 0)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 無性別"; }
            else if (player02.gender == 1)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♂"; }
            else if (player02.gender == 2)
            { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♀"; }





        }


        #endregion　●ステイト200番台　プレイヤー02の選択画面
        #region　●ステイト300番台　対戦中
        //戦闘開始

        else if (stateNumber == 301)
        {


            if (timeCounter > 0.5f)
            {
                timeCounter = 0.0f;

                UImessage.GetComponent<Text>().text = "行動開始";

                stateNumber = 304;

            }

        }

        else if (stateNumber == 302)
        {

            if (timeCounter > 1.5f)
            {

                //タイマーリセット
                timeCounter = 0.0f;

                //プレイヤー01の行動に進む
                stateNumber = 311;


            }
        }

        else if (stateNumber == 303)
        {
            if (timeCounter > 1.5f)
            {

                //タイマーリセット
                timeCounter = 0.0f;
                //プレイヤー01の行動に進む
                stateNumber = 312;

            }

        }

        else if (stateNumber == 304)
        {
            if (timeCounter > 1.0f)
            {

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

                    UImessage.GetComponent<Text>().text = ("プレイヤー01の方が速い");

                    //player01から攻撃する
                    stateNumber = 311;

                }

                else if (player01.StRl < player02.StRl)
                {

                    UImessage.GetComponent<Text>().text = ("プレイヤー02の方が速い");

                    //player01から攻撃する
                    stateNumber = 312;

                }

                else
                {
                    //  Debug.Log("同速");

                    //同速乱数
                    if (Random.Range(1, 3) < 1.5f)

                    {
                        UImessage.GetComponent<Text>().text = ("同速でプレイヤー01が優先");
                        stateNumber = 311;
                    }
                    else
                    {
                        UImessage.GetComponent<Text>().text = ("同速でプレイヤー02が優先");
                        stateNumber = 312;
                    }

                }
            }
        }
        //プレイヤー01の攻撃
        else if (stateNumber == 311)
        {
            if (timeCounter > 1.0f)
            {

                //タイマーリセット
                timeCounter = 0.0f;


                //行動確認on
                ActionCheck01 = 1;


                //攻撃モーション


                if (WN01 == 1) { player01.requestAttack(1); }
                else if (WN01 == 2) { player01.requestAttack(2); }
                else if (WN01 == 3) { player01.requestAttack(3); }
                else if (WN01 == 4) { player01.requestAttack(4); }



                //攻撃関数
                PlayerAttack01();



                //ダメージモーション
                player02.requestDamage();


                Ul02HPtext.GetComponent<Text>().text = "HP:" + player02.HPNow + "/" + player02.HPMax;
                if (player02.HPNow <= 0)
                { Ul02HPtext.GetComponent<Text>().text = "HP:ひんし"; }


                //ライフバー (マイナスになったら黒にする）
                if ((player01.HPNow / player01.HPMax) > 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
                if ((player01.HPNow / player01.HPMax) <= 0.5f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
                if ((player01.HPNow / player01.HPMax) <= 0.2f) { UIHPnow1.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
                if (player01.HPNow <= 0) { UIHPnow1.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }



                if ((player02.HPNow / player02.HPMax) > 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 255, 0, 255); ; }
                if ((player02.HPNow / player02.HPMax) <= 0.5f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 255, 0, 255); ; }
                if ((player02.HPNow / player02.HPMax) <= 0.2f) { UIHPnow2.GetComponent<Image>().color = new Color32(255, 0, 0, 255); ; }
                if (player02.HPNow <= 0) { UIHPnow2.GetComponent<Image>().color = new Color32(0, 0, 0, 0); ; }







                //ステイト変更


                if (player02.HPNow <= 0)
                {

                    //プレイヤー02が倒れる
                    player02.requestDeath();

                    //モンスターカウントを-1する
                    MonsterCount02 -= 1;
                    Debug.Log("02側の残数" + this.MonsterCount02);

                    //ゲームクリア画面
                    stateNumber = 401;

                }
                // プレイヤー02が未行動ならステイト312に移動
                else if (ActionCheck02 == 0)
                {

                    //タイマーリセット
                    timeCounter = 0.0f;

                    stateNumber = 303;

                }

                //プレイヤー02が行動済ならステイト101に移動
                else
                {
                    //タイマーリセット
                    timeCounter = 0.0f;

                    stateNumber = 101;

                }
            }
        }

        //02→01のダメージ計算

        else if (stateNumber == 312)
        {
            if (timeCounter > 1.0f)
            {

                //タイマーリセット
                timeCounter = 0.0f;


                //行動確認on
                ActionCheck02 = 1;
                

                // 攻撃モーション
                player02.requestAttack(WN02);


                //ダメージ計算
                if (WN02 == 1)
                {
                    player01.HPNow -= 30;
                    UImessage.GetComponent<Text>().text = "プレイヤー02側の攻撃！\n ダメージ 30";
                }

                else
                {
                    player01.HPNow -= 300;
                    UImessage.GetComponent<Text>().text = "プレイヤー02側の攻撃！\n ダメージ 300";
                }

                //ダメージモーション
                player01.requestDamage();


                Debug.Log("モンスターのHP" + player01.HPNow);


                //HPを表示する
                Ul01HPtext.GetComponent<Text>().text = "HP:" + player01.HPNow + "/" + player01.HPMax;
                if (player01.HPNow <= 0)
                { Ul01HPtext.GetComponent<Text>().text = "HP:ひんし"; }


                //ライフバー (マイナスになったら0にする）
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

                    Debug.Log("プレイヤー01側のモンスターは倒れた！");
                    UImessage.GetComponent<Text>().text = "プレイヤー01側のモンスターは倒れた！";

                    //モンスターカウントを-1する
                    MonsterCount01 -= 1;
                    Debug.Log("01側の残数" + this.MonsterCount01);

                    //モーション：プレイヤー01が倒れる
                    player01.requestDeath();

                    //ゲームオーバー画面
                    stateNumber = 402;




                }
                // プレイヤー01が未行動ならステイト311に移動
                else if (ActionCheck01 == 0)
                {

                    //タイマーリセット
                    timeCounter = 0.0f;
                    //戦闘開始に戻る
                    stateNumber = 302;

                }

                //プレイヤー01が行動済ならステイト101に移動
                else
                {

                    stateNumber = 101;

                }
            }
        }
        #endregion　●対戦中
        #region　●ステイト400番台　対戦終了処理





        else if (stateNumber == 401)
        {




            if (timeCounter > 3.0f)
            {

                UImessage.GetComponent<Text>().text = "プレイヤー02側のモンスターは倒れた！";
                //01側の残数が0のとき404に行く。その他は106に行く
                if (MonsterCount02 <= 0)
                {
                    stateNumber = 403;

                    //タイマーリセット
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

                UImessage.GetComponent<Text>().text = "プレイヤー01側のモンスターは倒れた！";

                //01側の残数が0のとき404に行く。その他は106に行く
                if (MonsterCount01 <= 0)
                { 
                    stateNumber = 404;

                    //タイマーリセット
                    timeCounter = 0.0f;
                }
                else
                { 
                    stateNumber = 106; 
                }

            }



           

        }
        else if (stateNumber == 403)
        {

            if (timeCounter > 3.0f)
            {

                UImessage.GetComponent<Text>().text = "対戦に勝利した";




                if (Input.GetMouseButtonDown(0))
                {

                    //タイマーリセット
                    timeCounter = 0.0f;

                    stateNumber = 0;
                }

            }

        }
        else if (stateNumber == 404)
        {
            if (timeCounter > 3.0f)
            {



                UImessage.GetComponent<Text>().text = "対戦に敗北した";



                if (Input.GetMouseButtonDown(0))
                {
                    //タイマーリセット
                    timeCounter = 0.0f;

                    stateNumber = 0;


                }

            }
        }




        }  //ステイト分岐終了
    #endregion　●ステイト400番台　対戦終了処理
    #endregion　◎アップデート
    #region ◎ボタン
    　　#region ●最初の選択

    //コマンド（ボタン）
    public void ButtonBattlePlayer01()
    {
        Debug.Log("ButtonBattlePlayer01");
        choiceCommand01 = 1;
        UIchoice01.SetActive(false);

    }

    public void ButtonBattlePlayer02()
    {
        Debug.Log("ButtonBattlePlayer02");
        choiceCommand02 = 1;
        UIchoice02.SetActive(false);
    }


    #endregion ●最初の選択
    　　#region●モンスターの交替
   　　　　　 #region 〇交替画面
    //プレイヤー01側
    public void ButtonChangePlayer01()
    {  
        Debug.Log("プレイヤー01のモンスターの交替画面");
        choiceCommand01 = 2;
        UIchoice01.SetActive(false);

    }
    //プレイヤー02側
    public void ButtonChangePlayer02()
    {
       //プレイヤー01側の表記と変える？
        Monster01Player02 monster01;
        monster01 = GameObject.Find("Monster01Player02(Clone)").GetComponent<Monster01Player02>();

        if (monster01.HPNow <= 0)
        {
            //赤
            PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            //ボタンを押せなくする
            PL02changeButton[1].GetComponent<Button>().enabled = false;
        }
        else
        {
            //白
            PL02changeButton[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //ボタンを押せる
            PL02changeButton[1].GetComponent<Button>().enabled = true;
        }


        Monster01Player02 monster02;
        monster02 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

        if (monster02.HPNow <= 0)
        {
            //赤
            PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            //ボタンを押せなくする
            PL02changeButton[2].GetComponent<Button>().enabled = false;
        }
        else
        {
            //白
            PL02changeButton[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //ボタンを押せる
            PL02changeButton[2].GetComponent<Button>().enabled = true;

        }

        Monster01Player02 monster03;
        monster03 = GameObject.Find("Monster03Player02(Clone)").GetComponent<Monster01Player02>();

        if (monster03.HPNow <= 0)
        {
            //赤
            PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            //ボタンを押せなくする
            PL02changeButton[3].GetComponent<Button>().enabled = false;
        }
        else
        {
            //白
            PL02changeButton[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //ボタンを押せる
            PL02changeButton[3].GetComponent<Button>().enabled = true;

        }

        Monster01Player02 monster04;
        monster04 = GameObject.Find("Monster04Player02(Clone)").GetComponent<Monster01Player02>();

        if (monster04.HPNow <= 0)
        {
            //赤
            PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            //ボタンを押せなくする
            PL02changeButton[4].GetComponent<Button>().enabled = false;
        }
        else
        {
            //白
            PL02changeButton[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //ボタンを押せる
            PL02changeButton[4].GetComponent<Button>().enabled = true;

        }

        Monster01Player02 monster05;
        monster05 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

        if (monster05.HPNow <= 0)
        {
            //赤
            PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            //ボタンを押せなくする
            PL02changeButton[5].GetComponent<Button>().enabled = false;
        }
        else
        {
            //白
            PL02changeButton[5].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //ボタンを押せる
            PL02changeButton[5].GetComponent<Button>().enabled = true;

        }

        Monster01Player02 monster06;
        monster06 = GameObject.Find("Monster02Player02(Clone)").GetComponent<Monster01Player02>();

        if (monster06.HPNow <= 0)
        {
            //赤
            PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            //ボタンを押せなくする
            PL02changeButton[6].GetComponent<Button>().enabled = false;
        }
        else
        {
            //白
            PL02changeButton[6].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //ボタンを押せる
            PL02changeButton[6].GetComponent<Button>().enabled = true;

        }

        Debug.Log("プレイヤー02のモンスターの交替画面");
        choiceCommand02 = 2;
        UIchoice02.SetActive(false);

    }




    #endregion 〇交替画面
    　　　　　#region 〇交替ボタン
    public void BackChangeMonster01()
    {
        stateNumber = 101;
        choiceCommand01 = 0;
        ChangeMonster01.SetActive(false);
        UIchoice01.SetActive(true);
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


    }


    public void ChangeMonsterTo01()
    {
        //プレイヤー01側
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 1;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);


        }
        //プレイヤー02側
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 1;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
    }



    public void ChangeMonsterTo02()
    {
        //プレイヤー01側
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 2;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //プレイヤー02側
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 2;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
    }
    public void ChangeMonsterTo03()
    {
        //プレイヤー01側
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 3;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //プレイヤー02側
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 3;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
    }
    public void ChangeMonsterTo04()
    {
        //プレイヤー01側
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 4;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //プレイヤー02側
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 4;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
    }
    public void ChangeMonsterTo05()
    {
        //プレイヤー01側
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 5;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //プレイヤー02側
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 5;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
    }
    public void ChangeMonsterTo06()
    {
        //プレイヤー01側
        if (stateNumber == 104 | stateNumber == 106)
        {
            GameObject objout = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objout.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);

            PL01 = 6;

            GameObject objin = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)");
            objin.transform.position = new Vector3(-4.5f, 0.0f, 0.0f);
        }
        //プレイヤー02側
        else if (stateNumber == 204 | stateNumber == 206)
        {
            GameObject objout = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objout.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

            PL02 = 6;

            GameObject objin = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)");
            objin.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
        }
    }





    #endregion 〇交替ボタン
    #endregion ●モンスターの交替
             #region●武器選択

    public void ButtonStatusPlayer01()
    {
        Debug.Log("ButtonStatusPlayer01");
        choiceCommand01 = 3;
        UIchoice01.SetActive(false);

    }

    public void Weapon01Player01()
    {
        WN01 = 1;
        UIweapon01.SetActive(false);

    }
    public void Weapon02Player01()
    {
        WN01 = 2;
        UIweapon01.SetActive(false);
    }
    public void Weapon03Player01()
    {
        WN01 = 3;
        UIweapon01.SetActive(false);
    }
    public void Weapon04Player01()
    {
        WN01 = 4;
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



    public void ButtonStatusPlayer02()
    {
        Debug.Log("ButtonStatusPlayer02");
        choiceCommand02 = 3;
        UIchoice02.SetActive(false);

    }

    public void Weapon01Player02()
    {
        WN02 = 1;
        UIweapon02.SetActive(false);

    }
    public void Weapon02Player02()
    {
        WN02 = 2;
        UIweapon02.SetActive(false);
    }
    public void Weapon03Player02()
    {
        WN02 = 3;
        UIweapon02.SetActive(false);
    }
    public void Weapon04Player02()
    {
        WN02 = 4;
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
    #endregion●武器選択
    #endregion ◎ボタン
    #region ◎ダメージ計算
             #region ●最初の設定

    //プレイヤー01　→　02
    void PlayerAttack01()
    {
       

        Monster01Player01 player01;
        player01 = GameObject.Find("Monster"+PL01.ToString("D2")+ "Player01(Clone)").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster"+PL02.ToString("D2")+ "Player02(Clone)").GetComponent<Monster01Player02>();



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
        else                { Debug.Log("タイプ取得失敗");}

        Debug.Log("技タイプ"+da13);



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
        else if (da13 == 2 && player02.type[1] == 5) { da15 = 2;  }  //草
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

        Debug.Log("da13=" + da13+",da14=" + da14 + ",da15=" + da15);
        
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