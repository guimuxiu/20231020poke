using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI部品
using UnityEngine.UI;



public partial class GameManager : MonoBehaviour
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

    //SE
    public AudioClip SESystem;
   

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

        //モンスター名前
        if (player01.gender == 0)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 無性別"; }
        else if (player01.gender == 1)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♂"; }
        else if (player01.gender == 2)
        { UIplayer01text.GetComponent<Text>().text = "モンスター" + PL01.ToString("D2") + "　Lv:50 ♀"; }

        if (player02.gender == 0)
        { UIplayer02text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 無性別"; }
        else if (player02.gender == 1)
        { UIplayer02text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♂"; }
        else if (player02.gender == 2)
        { UIplayer02text.GetComponent<Text>().text = "モンスター" + PL02.ToString("D2") + "　Lv:50 ♀"; }




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


            if (timeCounter > 3.0f)
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
                //string wn9001 = "きりかかる";
                //int[] wf9001 = { 1, 50, 100, 10, 1, 0 };

                //string wn9002 = "おそいかかる";
                //int[] wf9002 = { 2, 100, 80, 10, 1, 0 };

                //string wn9003 = "とびどうぐ";
                //int[] wf9003 = { 3, 80, 100, 10, 2, 0 };

                //string wn9004 = "きあい";
                //int[] wf9004 = { 4, 0, 100, 10, 2, 0 };

                TextWeapon01Player02.GetComponent<Text>().text = "固定30" ;
                TextWeapon02Player02.GetComponent<Text>().text = "固定100" ;
                TextWeapon03Player02.GetComponent<Text>().text = "固定200";
                TextWeapon04Player02.GetComponent<Text>().text = "固定300";

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

                else　if(WN02 ==2)
                {
                    player01.HPNow -= 100;
                    UImessage.GetComponent<Text>().text = "プレイヤー02側の攻撃！\n ダメージ 100";
                }

                else if (WN02 == 3)
                {
                    player01.HPNow -= 200;
                    UImessage.GetComponent<Text>().text = "プレイヤー02側の攻撃！\n ダメージ 200";
                }

                else if (WN02 == 4)
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

                Debug.Log("プレイヤー01側のモンスターは倒れた！");
               

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

                    //タイマーリセット
                    timeCounter = 0.0f;

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




    }
}//ステイト分岐終了
    #endregion　●ステイト400番台　対戦終了処理
    #endregion　◎アップデート

