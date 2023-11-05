using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster01Player02 : MonoBehaviour
{

    //状態番号
    public int stateNumber = -1;

    //汎用タイマー
    private float timeCounter = 0.0f;


    //モンスター名前
    public string Name = "未定義";

    public int MonNommber = 9999;  //モンスターの図鑑ナンバー
    public int Monform = 006;       //モンスターのフォルムナンバー
    public int gender = 1;         //モンスターの性別　1=♂　2=♀　0=なし
    public int[] type = { 4, 5, 0 };      //タイプ4　電気   タイプ5　草  タイプ3　なし
    public int teratype = 6;　 //テラスタイプ　氷
    public float[] nature = { 0, 0.9f, 1.1f, 1.0f, 1.0f, 1.0f }; //性格　
    public int ability = 0002; //特性0002　あめふらし
    public int item = 002;     //アイテム002　アイスメモリ
    public int Level = 50;
    public int[] MonBaV = { 100, 20, 60, 50, 40, 30 }; //種族値100-20-60-50-40-30
    public int[] MonInV = { 31, 31, 31, 31, 31, 31 };    //個体値31-31-31-31-31-31-31
    public int[] MonEfV = { 252, 0, 252, 0, 0, 4 };      //努力値252-252-0-0-0-4
    public float[] MonRealV = { 0, 0, 0, 0, 0, 0 };        //実数値0-0-0-0-0-0
    public int[] WeaponSet = {0, 9001, 9002, 9003, 9004 };  //技構成



    public float HPMax;  //HP最大値
    public float HPNow;   //HP現在値
    public float AtRl;　　//物理攻撃実数値
    public float BtRl; 　 //物理防御実数値
    public float CtRl; 　 //特殊攻撃実数値
    public float DtRl;    //特殊防御実数値
    public float StRl;    //素早さ実数値

    public int AtRa = 0;　　//物理攻撃ランク
    public int BtRa = 0; 　 //物理防御ランク
    public int CtRa = 0; 　 //特殊攻撃ランク
    public int DtRa = 0;    //特殊防御ランク
    public int StRa = 0;    //素早さランク

    //効果音
    public AudioClip SEattack01;
    public AudioClip SEattack02;
    public AudioClip SEattack03;
    public AudioClip SEattack04;
    public AudioClip SEDEath;


    //public int lv = 1;
    //public int HP = 100;
    //public int At = 10;






    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log("プレイヤー02種族値" + this.MonBaV[0] + "," + this.MonBaV[1] + "," + this.MonBaV[2] + "," + this.MonBaV[3] + "," + this.MonBaV[4] + "," + this.MonBaV[5]);
        //Debug.Log("プレイヤー02個体値" + this.MonInV[0] + "," + this.MonInV[1] + "," + this.MonInV[2] + "," + this.MonInV[3] + "," + this.MonInV[4] + "," + this.MonInV[5]);
        //Debug.Log("プレイヤー02努力値" + this.MonEfV[0] + "," + this.MonEfV[1] + "," + this.MonEfV[2] + "," + this.MonEfV[3] + "," + this.MonEfV[4] + "," + this.MonEfV[5]);




        //HP実数値:(種族値×2+個体値+努力値÷4)×レベル÷100+レベル+10) ※小数点以下は計算のたびに切り捨て
        HPMax = Mathf.Floor((((MonBaV[0] * 2 + MonInV[0]
                + Mathf.Floor(MonEfV[0] / 4))
                ) * Level) / 100) + Level + 10;

        //Debug.Log("02側モンスターのH実数値" + this.HPMax);

        HPNow = HPMax;



        //A実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        AtRl = Mathf.Floor((Mathf.Floor((((MonBaV[1] * 2 + MonInV[1]
               + Mathf.Floor(MonEfV[1] / 4))
               ) * Level) / 100) + 5) * nature[1]);

        //Debug.Log("02側モンスターのA実数値" + this.AtRl);

        //B実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        BtRl = Mathf.Floor((Mathf.Floor((((MonBaV[2] * 2 + MonInV[2]
               + Mathf.Floor(MonEfV[2] / 4))
               ) * Level) / 100) + 5) * nature[2]);

        //Debug.Log("02側モンスターのB実数値" + this.BtRl);

        //C実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        CtRl = Mathf.Floor((Mathf.Floor((((MonBaV[3] * 2 + MonInV[3]
               + Mathf.Floor(MonEfV[3] / 4))
               ) * Level) / 100) + 5) * nature[3]);

        //Debug.Log("02側モンスターのC実数値" + this.CtRl);

        //D実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て
        DtRl = Mathf.Floor((Mathf.Floor((((MonBaV[4] * 2 + MonInV[4]
               + Mathf.Floor(MonEfV[4] / 4))
               ) * Level) / 100) + 5) * nature[4]);

        //Debug.Log("02側モンスターのD実数値" + this.DtRl);


        //S実数値:{(種族値×2+個体値+努力値÷4)×レベル÷100+5}×性格補正 ※小数点以下は計算のたびに切り捨て

       

        StRl = Mathf.Floor((Mathf.Floor((((MonBaV[5] * 2 + MonInV[5]
               + Mathf.Floor(MonEfV[5] / 4))
               ) * Level) / 100) + 5) * nature[5]);

       // Debug.Log("02側モンスターのS実数値" + this.StRl);

    }

    // Update is called once per frame
    void Update()
    {
        //タイマー
        timeCounter += Time.deltaTime;

        if (stateNumber == 0)
        {
            this.transform.position += new Vector3(-1f * Time.deltaTime, 0f, 0f);

            if (this.transform.position.x <= 4.5f)
            {
                stateNumber = 1;
            }


        }



    }
    public void requestAttack(int number)
    {
         if(number == 01)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack01);
            GetComponent<Animator>().SetTrigger("Attack01");
        }
        else if (number == 02)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack02);
            GetComponent<Animator>().SetTrigger("Attack02");
        }
        else if (number == 03)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack03);
            GetComponent<Animator>().SetTrigger("Attack03");
        }
        else if (number == 04)
        {
            GetComponent<AudioSource>().PlayOneShot(SEattack04);
            GetComponent<Animator>().SetTrigger("Attack03");
        }

    }

    public void requestDamage()
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }
    public void requestDeath()
    {
        GetComponent<Animator>().SetTrigger("Death");
    
    
    }

    public void requestRelive()
    {
        GetComponent<Animator>().SetTrigger("Relive");
    }



    public void statusDisplay()
    {
        //Player2側のステータスを更新




    }




}
