using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster01Player01 : MonoBehaviour
{

    //状態番号
    private int stateNumber = 0;

    //汎用タイマー
    private float timeCounter = 0.0f;

    public int MonNommber = 9999;  //モンスターの図鑑ナンバー
    public int Monform = 005;       //モンスターのフォルムナンバー
    public int gender = 2;         //モンスターの性別　1=♂　2=♀　0=なし
    public int[] type = { 1, 2, 0 };      //タイプ1　ノーマル   タイプ2　炎  タイプ3　なし
    public int teratype = 3;　 //テラスタイプ　水
    public float[] nature = { 0, 1.1f, 0.9f, 1.0f, 1.0f, 1.0f }; //性格　さみしがり
    public int ability = 0001; //特性0001　あくしゅう
    public int item = 001;     //アイテム001　あいいろのたま
    public int Level = 50;
    public int[] MonBaV = { 100, 60, 50, 40, 30, 30 }; //種族値100-60-50-40-30-20
    public int[] MonInV = { 31, 31, 31, 31, 31, 31 };    //個体値31-31-31-31-31-31
    public int[] MonEfV = { 252, 252, 0, 0, 0, 4 };      //努力値252-252-0-0-0-4
    public float[] MonRealV = { 0, 0, 0, 0, 0, 0};        //実数値0-0-0-0-0-0
    public int[] WeaponSet = { 0,9001, 9002, 9003, 9004 };  //技構成


    public float HPMax ;  //HP最大値
    public float HPNow;   //HP現在値
    public float AtRl ;　　//物理攻撃実数値
    public float BtRl ; 　 //物理防御実数値
    public float CtRl ; 　 //特殊攻撃実数値
    public float DtRl ;    //特殊防御実数値
    public float StRl ;    //素早さ実数値

    public int AtRa;　　//物理攻撃ランク
    public int BtRa; 　 //物理防御ランク
    public int CtRa; 　 //特殊攻撃ランク
    public int DtRa;    //特殊防御ランク
    public int StRa;    //素早さランク






    //public int HP = 100;
    //public int HPNow = 0;
    //public int At = 10;




    // Start is called before the first frame update
    void Start()
    {

        
        //Debug.Log("プレイヤー01種族値" + this.MonBaV[0]+","+ this.MonBaV[1] + "," + this.MonBaV[2] + "," + this.MonBaV[3] + "," + this.MonBaV[4] + "," + this.MonBaV[5]);
        //Debug.Log("プレイヤー01個体値" + this.MonInV[0]+ "," + this.MonInV[1] + "," + this.MonInV[2] + "," + this.MonInV[3] + "," + this.MonInV[4] + "," + this.MonInV[5]);
        //Debug.Log("プレイヤー01努力値" + this.MonEfV[0] + "," + this.MonEfV[1] + "," + this.MonEfV[2] + "," + this.MonEfV[3] + "," + this.MonEfV[4] + "," + this.MonEfV[5]);




        //HP実数値:(種族値×2+個体値+努力値÷4)×レベル÷100+レベル+10) ※小数点以下は計算のたびに切り捨て
        HPMax = Mathf.Floor((((MonBaV[0] * 2 + MonInV[0]
                + Mathf.Floor(MonEfV[0] / 4))
                ) * Level) /100)+ Level +10;

        //Debug.Log("01側モンスターのH実数値" + this.HPMax);

        HPNow = HPMax;

        //A実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
         AtRl= Mathf.Floor((Mathf.Floor((((MonBaV[1] * 2 + MonInV[1]
                + Mathf.Floor(MonEfV[1] / 4))
                ) * Level) / 100) + 5)* nature[1]);

        //Debug.Log("01側モンスターのA実数値" + this.AtRl);

        //B実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        BtRl = Mathf.Floor((Mathf.Floor((((MonBaV[2] * 2 + MonInV[2]
               + Mathf.Floor(MonEfV[2] / 4))
               ) * Level) / 100) + 5) * nature[2]);

        //Debug.Log("01側モンスターのB実数値" + this.BtRl);

        //C実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        CtRl = Mathf.Floor((Mathf.Floor((((MonBaV[3] * 2 + MonInV[3]
               + Mathf.Floor(MonEfV[3] / 4))
               ) * Level) / 100) + 5) * nature[3]);

        //Debug.Log("01側モンスターのC実数値" + this.CtRl);

        //D実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        DtRl = Mathf.Floor((Mathf.Floor((((MonBaV[4] * 2 + MonInV[4]
               + Mathf.Floor(MonEfV[4] / 4))
               ) * Level) / 100) + 5) * nature[4]);

        //Debug.Log("01側モンスターのD実数値" + this.DtRl);


        //S実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        StRl = Mathf.Floor((Mathf.Floor((((MonBaV[5] * 2 + MonInV[5]
               + Mathf.Floor(MonEfV[5] / 4))
               ) * Level) / 100) + 5) * nature[5]);

       // Debug.Log("01側モンスターのS実数値" + this.StRl);

    }







    // Update is called once per frame
    void Update()
    {
        //タイマー
        timeCounter += Time.deltaTime;


        // ゲーム開始時にモンスターが画面左から中央に寄ってくる

        if (stateNumber == 0)
        {
            this.transform.position += new Vector3(1f*Time.deltaTime, 0f,0f);

            //x座標が-4.5fを過ぎるとstateNumber = 1に移動する
            if (this.transform.position.x >= -4.5f) 
            {
                
                stateNumber = 1;
            }
        
        }


    }


   

    //攻撃をするための関数
    public void requestAttack (int number)
    {
        GetComponent<Animator>().SetTrigger("Attack0" + number);
    }


    public void requestDamage ()
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }

    public void statusDisplay()
    {
　　　//Player1側のステータスを更新


    }


}


