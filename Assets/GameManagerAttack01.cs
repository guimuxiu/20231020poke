using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI•”•i
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    #region ƒ_ƒ[ƒWŒvZ
    #region œÅ‰‚Ìİ’è

    //ƒvƒŒƒCƒ„[01@¨@02
    void PlayerAttack01()
    {


        Monster01Player01 player01;
        player01 = GameObject.Find("Monster" + PL01.ToString("D2") + "Player01(Clone)").GetComponent<Monster01Player01>();

        Monster01Player02 player02;
        player02 = GameObject.Find("Monster" + PL02.ToString("D2") + "Player02(Clone)").GetComponent<Monster01Player02>();



        //‹Zî•ñ‚ÌŒÄ‚Ño‚µ
        // ƒ^ƒCƒvAˆĞ—ÍA–½’†AppA•¨“Á•ÏA—Dæ“x

        int[] wf9001 = { 1, 50, 100, 10, 1, 0 };
        int[] wf9002 = { 2, 100, 80, 10, 1, 0 };
        int[] wf9003 = { 3, 80, 100, 10, 2, 0 };
        int[] wf9004 = { 4, 0, 100, 10, 3, 0 };

        #endregion œÅ‰‚Ìİ’è
        #regionœŠî‘bˆĞ—Í


        //01¨02‚Ìƒ_ƒ[ƒWŒvZ
        //ƒ_ƒ[ƒW = (((ƒŒƒxƒ‹~2 / 5 + 2)~ˆĞ—Í~A / D)/ 50 + 2)
        //~”ÍˆÍ•â³~‚¨‚â‚±‚ ‚¢•â³~“V‹C•â³~‹}Š•â³~—”•â³
        //~ƒ^ƒCƒvˆê’v•â³~‘Š«•â³~‚â‚¯‚Ç•â³~M~Mprotect

        float da01 = player01.Level * 2 / 5 + 2;

        //‹ZˆĞ—Í

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
            Debug.Log("‹Z‘I‘ğ¸”s");
        }

        Debug.Log("‹ZˆĞ—Í" + WeaponPower);


        //•¨—“Áê”»’è

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


            Debug.Log(" •¨—“Áê‚Ì‘I‘ğ¸”s");
        }

        Debug.Log("UŒ‚or“ÁU‚ÌÀ”’l" + da02);
        Debug.Log("“ÁUor“Á–h‚ÌÀ”’l" + da03);
        #endregionœŠî‘bˆĞ—Í
        #regionœƒ‰ƒ“ƒN•â³
        //UŒ‚‘¤ƒ‰ƒ“ƒN•â³
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
        else { Debug.Log(" Aƒ‰ƒ“ƒNŒvZ¸”s"); }

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
        else { Debug.Log(" Cƒ‰ƒ“ƒNŒvZ¸”s"); }

        //–hŒä‘¤ƒ‰ƒ“ƒN•â³

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
        else { Debug.Log(" Bƒ‰ƒ“ƒNŒvZ¸”s"); }

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
        else { Debug.Log(" Dƒ‰ƒ“ƒNŒvZ¸”s"); }


        //ƒ‰ƒ“ƒN•â³Œã‚ÌˆĞ—Í

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
            Debug.Log(" •¨—“Áêƒ‰ƒ“ƒN‚Ì‘I‘ğ¸”s");

            da02R = 1;
            da03R = 1;

        }
        //ÅIˆĞ—Í=Šî‘bˆĞ—Í~ˆĞ—Í•â³/4096
        float da04 = Mathf.Floor(Mathf.Floor(da01 * WeaponPower * da02 * da02R / (da03 * da03R)) / 50 + 2);

        Debug.Log("‚©‚Á‚±“à‚ÌŒvZ’l" + da04);
        #endregion  œƒ‰ƒ“ƒN•â³
        #region œ”ÍˆÍ•â³@eqˆ¤•â³@“V‹C•â³
        //”ÍˆÍ•â³ŒvZ

        float da05 = da04;

        //‚¨‚â‚±‚ ‚¢•â³

        float da06 = da05;

        //“V‹C•â³

        float da07 = da06;
        #endregion œ”ÍˆÍ•â³@eqˆ¤•â³@“V‹C•â³
        #regionœ‹}Š•â³@—”•â³
        //‹}Š•â³
        //©•ª‚Ì‰º~ƒ‰ƒ“ƒN‚Æ‘Šè‚Ìã¸ƒ‰ƒ“ƒN–³‹‚Í‚Ç‚¤‚µ‚æ‚¤H

        float da08 = 0;
        float da08r = Random.Range(1, 25);

        if (da08r == 1)
        {
            Debug.Log("‹}Š‚É“–‚½‚Á‚½");

            da08 = da07 * 3 / 2;
        }
        else
        {
            da08 = da07;
            Debug.Log("‹}Š‚É“–‚½‚ç‚È‚©‚Á‚½");
        }



        Debug.Log("‹}Š”»’è‚İ" + da08);

        //ŒÜÌŒÜ’´“ü
        float da09 = Mathf.Ceil(da08 - (1 / 2));

        //ƒ_ƒ[ƒW”»’è—p
        //float[] daR01 ={ da09 * 85 / 100, da09 * 86 / 100 , da09 * 87 / 100 ,da09 * 88 / 100 ,
        //                 da09 * 89 / 100 ,da09 * 90 / 100 , da09 * 91 / 100 ,da09 * 92 / 100 ,
        //                 da09 * 93 / 100 ,da09 * 94 / 100 , da09 * 95 / 100 ,da09 * 96 / 100 ,
        //                 da09 * 97 / 100 ,da09 * 98 / 100 , da09 * 99 / 100 ,da09 * 100 / 100 };

        //—”•â³iØ‚èÌ‚Äj

        float da10 = Random.Range(85, 101);
        Debug.Log("—”•â³" + da10 + "%");

        float da11 = Mathf.Floor(da09 * da10 / 100);
        Debug.Log("—”‚İ" + da11);

        //float[] daR02 = { Mathf.Floor(daR01[0]),Mathf.Floor(daR01[1]),Mathf.Floor(daR01[2]),Mathf.Floor(daR01[3]),
        //                  Mathf.Floor(daR01[4]),Mathf.Floor(daR01[5]),Mathf.Floor(daR01[6]),Mathf.Floor(daR01[7]),
        //                  Mathf.Floor(daR01[8]),Mathf.Floor(daR01[9]),Mathf.Floor(daR01[10]),Mathf.Floor(daR01[11])};

        #endregionœ‹}Š•â³@—”•â³
        #region œƒ^ƒCƒv•â³

        float da13 = 0;     //‹Zƒ^ƒCƒv

        if (WN01 == 1) { da13 = wf9001[0]; }
        else if (WN01 == 2) { da13 = wf9002[0]; }
        else if (WN01 == 3) { da13 = wf9003[0]; }
        else if (WN01 == 4) { da13 = wf9004[0]; }
        else { Debug.Log("ƒ^ƒCƒvæ“¾¸”s"); }

        Debug.Log("‹Zƒ^ƒCƒv" + da13);



        //ƒ^ƒCƒvˆê’v•â³(ŒÜÌŒÜ’´“ü)
        float da12 = 1;


        if (da13 == player01.type[0])
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 1.5f);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else if (da13 == player01.type[1])
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 3 / 2);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else if (da13 == player01.type[0])
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 3 / 2);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else if (da13 == player01.type[1])
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 3 / 2);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else if (da13 == player01.type[0])
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 3 / 2);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else if (da13 == player01.type[1])
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 3 / 2);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else if ((da13 == player01.type[0]))
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 3 / 2);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else if (da13 == player01.type[1])
        {
            Debug.Log("ƒ^ƒCƒvˆê’vON" + da11 * 3 / 2);
            da12 = Mathf.Ceil(da11 * 1.5f - 0.5f);
        }
        else
        {
            Debug.Log("ƒ^ƒCƒv•sˆê’v");
            da12 = Mathf.Ceil(da11);

        }

        Debug.Log("ƒ^ƒCƒvˆê’v•â³‚İ" + da12);

        //‘Š«•â³

        float da14 = 0;



        //‹Zƒ^ƒCƒv¨–hŒäƒ^ƒCƒv1
        //UŒ‚‘¤‚ªƒm[ƒ}ƒ‹
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
        else if (da13 == 1 && player02.type[0] == 13) { da14 = 0.5f; }    //Šâ
        else if (da13 == 1 && player02.type[0] == 14) { da14 = 0; }     //—ì
        else if (da13 == 1 && player02.type[0] == 15) { da14 = 1; }
        else if (da13 == 1 && player02.type[0] == 16) { da14 = 1; }
        else if (da13 == 1 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 1 && player02.type[0] == 18) { da14 = 1; }
        //UŒ‚‘¤‚ª‰Š
        else if (da13 == 2 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 2 && player02.type[0] == 1) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 2) { da14 = 0.5f; } //‰Š
        else if (da13 == 2 && player02.type[0] == 3) { da14 = 0.5f; } //…
        else if (da13 == 2 && player02.type[0] == 4) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 5) { da14 = 2; }  //‘
        else if (da13 == 2 && player02.type[0] == 6) { da14 = 2; }  //•X
        else if (da13 == 2 && player02.type[0] == 7) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 8) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 9) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 10) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 11) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 12) { da14 = 2; }     //’
        else if (da13 == 2 && player02.type[0] == 13) { da14 = 0.5f; } //Šâ
        else if (da13 == 2 && player02.type[0] == 14) { da14 = 1; }     //—ì
        else if (da13 == 2 && player02.type[0] == 15) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 16) { da14 = 1; }
        else if (da13 == 2 && player02.type[0] == 17) { da14 = 2; }  //|
        else if (da13 == 2 && player02.type[0] == 18) { da14 = 1; }
        //UŒ‚‘¤‚ª…
        else if (da13 == 3 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 3 && player02.type[0] == 1) { da14 = 1; }
        else if (da13 == 3 && player02.type[0] == 2) { da14 = 2; } //‰Š
        else if (da13 == 3 && player02.type[0] == 3) { da14 = 0.5f; } //…
        else if (da13 == 3 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 3 && player02.type[0] == 5) { da14 = 0.5f; }  //‘
        else if (da13 == 3 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 3 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 3 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 3 && player02.type[0] == 9) { da14 = 2; }  //’n
        else if (da13 == 3 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 3 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 3 && player02.type[0] == 12) { da14 = 2; }  //’
        else if (da13 == 3 && player02.type[0] == 13) { da14 = 2; }  //Šâ
        else if (da13 == 3 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 3 && player02.type[0] == 15) { da14 = 0.5f; }  //—³
        else if (da13 == 3 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 3 && player02.type[0] == 17) { da14 = 2; }  //|
        else if (da13 == 3 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                    //UŒ‚‘¤‚ª“d
        else if (da13 == 4 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 4 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 4 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 4 && player02.type[0] == 3) { da14 = 2; } //…
        else if (da13 == 4 && player02.type[0] == 4) { da14 = 0.5f; }   //“d
        else if (da13 == 4 && player02.type[0] == 5) { da14 = 0.5f; }  //‘
        else if (da13 == 4 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 4 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 4 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 4 && player02.type[0] == 9) { da14 = 0; }  //’n
        else if (da13 == 4 && player02.type[0] == 10) { da14 = 2; } //”ò
        else if (da13 == 4 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 4 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 4 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 4 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 4 && player02.type[0] == 15) { da14 = 0.5f; }  //—³
        else if (da13 == 4 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 4 && player02.type[0] == 17) { da14 = 1; }  //|
        else if (da13 == 4 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                    //UŒ‚‘¤‚ª‘
        else if (da13 == 5 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 5 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 5 && player02.type[0] == 2) { da14 = 0.5f; } //‰Š
        else if (da13 == 5 && player02.type[0] == 3) { da14 = 2; } //…
        else if (da13 == 5 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 5 && player02.type[0] == 5) { da14 = 0.5f; }  //‘
        else if (da13 == 5 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 5 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 5 && player02.type[0] == 8) { da14 = 0.5f; } //“Å
        else if (da13 == 5 && player02.type[0] == 9) { da14 = 2; }  //’n
        else if (da13 == 5 && player02.type[0] == 10) { da14 = 0.5f; } //”ò
        else if (da13 == 5 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 5 && player02.type[0] == 12) { da14 = 0.5f; }  //’
        else if (da13 == 5 && player02.type[0] == 13) { da14 = 2; }  //Šâ
        else if (da13 == 5 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 5 && player02.type[0] == 15) { da14 = 0.5f; }  //—³
        else if (da13 == 5 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 5 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 5 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                    //UŒ‚‘¤‚ª•X
        else if (da13 == 6 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 6 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 6 && player02.type[0] == 2) { da14 = 0.5f; } //‰Š
        else if (da13 == 6 && player02.type[0] == 3) { da14 = 0.5f; } //…
        else if (da13 == 6 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 6 && player02.type[0] == 5) { da14 = 2; }  //‘
        else if (da13 == 6 && player02.type[0] == 6) { da14 = 0.5f; }  //•X
        else if (da13 == 6 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 6 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 6 && player02.type[0] == 9) { da14 = 2; }  //’n
        else if (da13 == 6 && player02.type[0] == 10) { da14 = 2; } //”ò
        else if (da13 == 6 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 6 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 6 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 6 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 6 && player02.type[0] == 15) { da14 = 2; }  //—³
        else if (da13 == 6 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 6 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 6 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                    //UŒ‚‘¤‚ªŠi
        else if (da13 == 7 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 7 && player02.type[0] == 1) { da14 = 2; }  //ƒm
        else if (da13 == 7 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 7 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 7 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 7 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 7 && player02.type[0] == 6) { da14 = 2; }  //•X
        else if (da13 == 7 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 7 && player02.type[0] == 8) { da14 = 0.5f; } //“Å
        else if (da13 == 7 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 7 && player02.type[0] == 10) { da14 = 0.5f; } //”ò
        else if (da13 == 7 && player02.type[0] == 11) { da14 = 0.5f; } //’´
        else if (da13 == 7 && player02.type[0] == 12) { da14 = 0.5f; }  //’
        else if (da13 == 7 && player02.type[0] == 13) { da14 = 2; }  //Šâ
        else if (da13 == 7 && player02.type[0] == 14) { da14 = 0; }  //—ì
        else if (da13 == 7 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 7 && player02.type[0] == 16) { da14 = 2; }  //ˆ«
        else if (da13 == 7 && player02.type[0] == 17) { da14 = 2; }  //|
        else if (da13 == 7 && player02.type[0] == 18) { da14 = 0.5f; } //—d
                                                                       //UŒ‚‘¤‚ª“Å
        else if (da13 == 8 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 8 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 8 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 8 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 8 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 8 && player02.type[0] == 5) { da14 = 2; }  //‘
        else if (da13 == 8 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 8 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 8 && player02.type[0] == 8) { da14 = 0.5f; } //“Å
        else if (da13 == 8 && player02.type[0] == 9) { da14 = 0.5f; }  //’n
        else if (da13 == 8 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 8 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 8 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 8 && player02.type[0] == 13) { da14 = 0.5f; }  //Šâ
        else if (da13 == 8 && player02.type[0] == 14) { da14 = 0.5f; }  //—ì
        else if (da13 == 8 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 8 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 8 && player02.type[0] == 17) { da14 = 0; }  //|
        else if (da13 == 8 && player02.type[0] == 18) { da14 = 2; } //—d
                                                                    //UŒ‚‘¤‚ª’n–Ê
        else if (da13 == 9 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 9 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 9 && player02.type[0] == 2) { da14 = 2; } //‰Š
        else if (da13 == 9 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 9 && player02.type[0] == 4) { da14 = 2; }   //“d
        else if (da13 == 9 && player02.type[0] == 5) { da14 = 0.5f; }  //‘
        else if (da13 == 9 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 9 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 9 && player02.type[0] == 8) { da14 = 2; } //“Å
        else if (da13 == 9 && player02.type[0] == 9) { da14 = 2; }  //’n
        else if (da13 == 9 && player02.type[0] == 10) { da14 = 0; } //”ò
        else if (da13 == 9 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 9 && player02.type[0] == 12) { da14 = 0.5f; }  //’
        else if (da13 == 9 && player02.type[0] == 13) { da14 = 2; }  //Šâ
        else if (da13 == 9 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 9 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 9 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 9 && player02.type[0] == 17) { da14 = 2; }  //|
        else if (da13 == 9 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                    //UŒ‚‘¤‚ª”òs
        else if (da13 == 10 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 10 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 10 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 10 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 10 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 10 && player02.type[0] == 5) { da14 = 2; }  //‘
        else if (da13 == 10 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 10 && player02.type[0] == 7) { da14 = 2; } //Ši
        else if (da13 == 10 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 10 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 10 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 10 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 10 && player02.type[0] == 12) { da14 = 2; }  //’
        else if (da13 == 10 && player02.type[0] == 13) { da14 = 0.5f; }  //Šâ
        else if (da13 == 10 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 10 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 10 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 10 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 10 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                     //UŒ‚‘¤‚ª’´
        else if (da13 == 11 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 11 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 11 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 11 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 11 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 11 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 11 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 11 && player02.type[0] == 7) { da14 = 2; } //Ši
        else if (da13 == 11 && player02.type[0] == 8) { da14 = 2; } //“Å
        else if (da13 == 11 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 11 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 11 && player02.type[0] == 11) { da14 = 0.5f; } //’´
        else if (da13 == 11 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 11 && player02.type[0] == 13) { da14 = 2; }  //Šâ
        else if (da13 == 11 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 11 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 11 && player02.type[0] == 16) { da14 = 0; }  //ˆ«
        else if (da13 == 11 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 11 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                     //UŒ‚‘¤‚ª’
        else if (da13 == 12 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 12 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 12 && player02.type[0] == 2) { da14 = 0.5f; } //‰Š
        else if (da13 == 12 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 12 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 12 && player02.type[0] == 5) { da14 = 2; }  //‘
        else if (da13 == 12 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 12 && player02.type[0] == 7) { da14 = 0.5f; } //Ši
        else if (da13 == 12 && player02.type[0] == 8) { da14 = 0.5f; } //“Å
        else if (da13 == 12 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 12 && player02.type[0] == 10) { da14 = 0.5f; } //”ò
        else if (da13 == 12 && player02.type[0] == 11) { da14 = 2; } //’´
        else if (da13 == 12 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 12 && player02.type[0] == 13) { da14 = 2; }  //Šâ
        else if (da13 == 12 && player02.type[0] == 14) { da14 = 0.5f; }  //—ì
        else if (da13 == 12 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 12 && player02.type[0] == 16) { da14 = 2; }  //ˆ«
        else if (da13 == 12 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 12 && player02.type[0] == 18) { da14 = 0.5f; } //—d
                                                                        //UŒ‚‘¤‚ªŠâ
        else if (da13 == 13 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 13 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 13 && player02.type[0] == 2) { da14 = 2; } //‰Š
        else if (da13 == 13 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 13 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 13 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 13 && player02.type[0] == 6) { da14 = 2; }  //•X
        else if (da13 == 13 && player02.type[0] == 7) { da14 = 0.5f; } //Ši
        else if (da13 == 13 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 13 && player02.type[0] == 9) { da14 = 0.5f; }  //’n
        else if (da13 == 13 && player02.type[0] == 10) { da14 = 2; } //”ò
        else if (da13 == 13 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 13 && player02.type[0] == 12) { da14 = 2; }  //’
        else if (da13 == 13 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 13 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 13 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 13 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 13 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 13 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                     //UŒ‚‘¤‚ª—ì
        else if (da13 == 14 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 14 && player02.type[0] == 1) { da14 = 0; }  //ƒm
        else if (da13 == 14 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 14 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 14 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 14 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 14 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 14 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 14 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 14 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 14 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 14 && player02.type[0] == 11) { da14 = 2; } //’´
        else if (da13 == 14 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 14 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 14 && player02.type[0] == 14) { da14 = 2; }  //—ì
        else if (da13 == 14 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 14 && player02.type[0] == 16) { da14 = 0.5f; }  //ˆ«
        else if (da13 == 14 && player02.type[0] == 17) { da14 = 1; }  //|
        else if (da13 == 14 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                     //UŒ‚‘¤‚ª—³
        else if (da13 == 15 && player02.type[0] == 0) { da14 = 1; }  //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 15 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 15 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 15 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 15 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 15 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 15 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 15 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 15 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 15 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 15 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 15 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 15 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 15 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 15 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 15 && player02.type[0] == 15) { da14 = 2; }  //—³
        else if (da13 == 15 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 15 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 15 && player02.type[0] == 18) { da14 = 0; } //—d
                                                                     //UŒ‚‘¤‚ªˆ«
        else if (da13 == 16 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 16 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 16 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 16 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 16 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 16 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 16 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 16 && player02.type[0] == 7) { da14 = 0.5f; } //Ši
        else if (da13 == 16 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 16 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 16 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 16 && player02.type[0] == 11) { da14 = 2; } //’´
        else if (da13 == 16 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 16 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 16 && player02.type[0] == 14) { da14 = 2; }  //—ì
        else if (da13 == 16 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 16 && player02.type[0] == 16) { da14 = 0.5f; }  //ˆ«
        else if (da13 == 16 && player02.type[0] == 17) { da14 = 1; }  //|
        else if (da13 == 16 && player02.type[0] == 18) { da14 = 0.5f; } //—d
                                                                        //UŒ‚‘¤‚ª|
        else if (da13 == 17 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 17 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 17 && player02.type[0] == 2) { da14 = 0.5f; } //‰Š
        else if (da13 == 17 && player02.type[0] == 3) { da14 = 0.5f; } //…
        else if (da13 == 17 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 17 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 17 && player02.type[0] == 6) { da14 = 2; }  //•X
        else if (da13 == 17 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 17 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 17 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 17 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 17 && player02.type[0] == 11) { da14 = 2; } //’´
        else if (da13 == 17 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 17 && player02.type[0] == 13) { da14 = 2; }  //Šâ
        else if (da13 == 17 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 17 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 17 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 17 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 17 && player02.type[0] == 18) { da14 = 2; } //—d
                                                                     //UŒ‚‘¤‚ª—d
        else if (da13 == 18 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 18 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 18 && player02.type[0] == 2) { da14 = 0.5f; } //‰Š
        else if (da13 == 18 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 18 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 18 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 18 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 18 && player02.type[0] == 7) { da14 = 2; } //Ši
        else if (da13 == 18 && player02.type[0] == 8) { da14 = 0.5f; } //“Å
        else if (da13 == 18 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 18 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 18 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 18 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 18 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 18 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 18 && player02.type[0] == 15) { da14 = 2; }  //—³
        else if (da13 == 18 && player02.type[0] == 16) { da14 = 2; }  //ˆ«
        else if (da13 == 18 && player02.type[0] == 17) { da14 = 0.5f; }  //|
        else if (da13 == 18 && player02.type[0] == 18) { da14 = 1; } //—d
                                                                     //UŒ‚‘¤‚ªƒ^ƒCƒv‚È‚µ
        else if (da13 == 19 && player02.type[0] == 0) { da14 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 19 && player02.type[0] == 1) { da14 = 1; }  //ƒm
        else if (da13 == 19 && player02.type[0] == 2) { da14 = 1; } //‰Š
        else if (da13 == 19 && player02.type[0] == 3) { da14 = 1; } //…
        else if (da13 == 19 && player02.type[0] == 4) { da14 = 1; }   //“d
        else if (da13 == 19 && player02.type[0] == 5) { da14 = 1; }  //‘
        else if (da13 == 19 && player02.type[0] == 6) { da14 = 1; }  //•X
        else if (da13 == 19 && player02.type[0] == 7) { da14 = 1; } //Ši
        else if (da13 == 19 && player02.type[0] == 8) { da14 = 1; } //“Å
        else if (da13 == 19 && player02.type[0] == 9) { da14 = 1; }  //’n
        else if (da13 == 19 && player02.type[0] == 10) { da14 = 1; } //”ò
        else if (da13 == 19 && player02.type[0] == 11) { da14 = 1; } //’´
        else if (da13 == 19 && player02.type[0] == 12) { da14 = 1; }  //’
        else if (da13 == 19 && player02.type[0] == 13) { da14 = 1; }  //Šâ
        else if (da13 == 19 && player02.type[0] == 14) { da14 = 1; }  //—ì
        else if (da13 == 19 && player02.type[0] == 15) { da14 = 1; }  //—³
        else if (da13 == 19 && player02.type[0] == 16) { da14 = 1; }  //ˆ«
        else if (da13 == 19 && player02.type[0] == 17) { da14 = 1; }  //|
        else if (da13 == 19 && player02.type[0] == 18) { da14 = 1; } //—d

        else { Debug.Log("‘Š«”»’è1¸”s"); };





        //‹Zƒ^ƒCƒv¨–hŒäƒ^ƒCƒv2

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
        else if (da13 == 1 && player02.type[1] == 13) { da15 = 0.5f; }    //Šâ
        else if (da13 == 1 && player02.type[1] == 14) { da15 = 0; Debug.Log("1¨14"); }     //—ì
        else if (da13 == 1 && player02.type[1] == 15) { da15 = 1; }
        else if (da13 == 1 && player02.type[1] == 16) { da15 = 1; }
        else if (da13 == 1 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 1 && player02.type[1] == 18) { da15 = 1; }
        //UŒ‚‘¤‚ª‰Š
        else if (da13 == 2 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 2 && player02.type[1] == 1) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 2) { da15 = 0.5f; } //‰Š
        else if (da13 == 2 && player02.type[1] == 3) { da15 = 0.5f; } //…
        else if (da13 == 2 && player02.type[1] == 4) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 5) { da15 = 2; }  //‘
        else if (da13 == 2 && player02.type[1] == 6) { da15 = 2; }  //•X
        else if (da13 == 2 && player02.type[1] == 7) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 8) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 9) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 10) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 11) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 12) { da15 = 2; }     //’
        else if (da13 == 2 && player02.type[1] == 13) { da15 = 0.5f; } //Šâ
        else if (da13 == 2 && player02.type[1] == 14) { da15 = 1; }     //—ì
        else if (da13 == 2 && player02.type[1] == 15) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 16) { da15 = 1; }
        else if (da13 == 2 && player02.type[1] == 17) { da15 = 2; }  //|
        else if (da13 == 2 && player02.type[1] == 18) { da15 = 1; }
        //UŒ‚‘¤‚ª…
        else if (da13 == 3 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 3 && player02.type[1] == 1) { da15 = 1; }
        else if (da13 == 3 && player02.type[1] == 2) { da15 = 2; } //‰Š
        else if (da13 == 3 && player02.type[1] == 3) { da15 = 0.5f; } //…
        else if (da13 == 3 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 3 && player02.type[1] == 5) { da15 = 0.5f; Debug.Log("‚±‚±H"); }  //‘
        else if (da13 == 3 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 3 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 3 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 3 && player02.type[1] == 9) { da15 = 2; }  //’n
        else if (da13 == 3 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 3 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 3 && player02.type[1] == 12) { da15 = 2; }  //’
        else if (da13 == 3 && player02.type[1] == 13) { da15 = 2; }  //Šâ
        else if (da13 == 3 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 3 && player02.type[1] == 15) { da15 = 0.5f; }  //—³
        else if (da13 == 3 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 3 && player02.type[1] == 17) { da15 = 2; }  //|
        else if (da13 == 3 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª“d
        else if (da13 == 4 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 4 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 4 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 4 && player02.type[1] == 3) { da15 = 2; } //…
        else if (da13 == 4 && player02.type[1] == 4) { da15 = 0.5f; }   //“d
        else if (da13 == 4 && player02.type[1] == 5) { da15 = 0.5f; }  //‘
        else if (da13 == 4 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 4 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 4 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 4 && player02.type[1] == 9) { da15 = 0; Debug.Log("4¨9"); }  //’n
        else if (da13 == 4 && player02.type[1] == 10) { da15 = 2; } //”ò
        else if (da13 == 4 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 4 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 4 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 4 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 4 && player02.type[1] == 15) { da15 = 0.5f; }  //—³
        else if (da13 == 4 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 4 && player02.type[1] == 17) { da15 = 1; }  //|
        else if (da13 == 4 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª‘
        else if (da13 == 5 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 5 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 5 && player02.type[1] == 2) { da15 = 0.5f; } //‰Š
        else if (da13 == 5 && player02.type[1] == 3) { da15 = 2; } //…
        else if (da13 == 5 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 5 && player02.type[1] == 5) { da15 = 0.5f; }  //‘
        else if (da13 == 5 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 5 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 5 && player02.type[1] == 8) { da15 = 0.5f; } //“Å
        else if (da13 == 5 && player02.type[1] == 9) { da15 = 2; }  //’n
        else if (da13 == 5 && player02.type[1] == 10) { da15 = 0.5f; } //”ò
        else if (da13 == 5 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 5 && player02.type[1] == 12) { da15 = 0.5f; }  //’
        else if (da13 == 5 && player02.type[1] == 13) { da15 = 2; }  //Šâ
        else if (da13 == 5 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 5 && player02.type[1] == 15) { da15 = 0.5f; }  //—³
        else if (da13 == 5 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 5 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 5 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª•X
        else if (da13 == 6 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 6 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 6 && player02.type[1] == 2) { da15 = 0.5f; } //‰Š
        else if (da13 == 6 && player02.type[1] == 3) { da15 = 0.5f; } //…
        else if (da13 == 6 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 6 && player02.type[1] == 5) { da15 = 2; }  //‘
        else if (da13 == 6 && player02.type[1] == 6) { da15 = 0.5f; }  //•X
        else if (da13 == 6 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 6 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 6 && player02.type[1] == 9) { da15 = 2; }  //’n
        else if (da13 == 6 && player02.type[1] == 10) { da15 = 2; } //”ò
        else if (da13 == 6 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 6 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 6 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 6 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 6 && player02.type[1] == 15) { da15 = 2; }  //—³
        else if (da13 == 6 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 6 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 6 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ªŠi
        else if (da13 == 7 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 7 && player02.type[1] == 1) { da15 = 2; }  //ƒm
        else if (da13 == 7 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 7 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 7 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 7 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 7 && player02.type[1] == 6) { da15 = 2; }  //•X
        else if (da13 == 7 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 7 && player02.type[1] == 8) { da15 = 0.5f; } //“Å
        else if (da13 == 7 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 7 && player02.type[1] == 10) { da15 = 0.5f; } //”ò
        else if (da13 == 7 && player02.type[1] == 11) { da15 = 0.5f; } //’´
        else if (da13 == 7 && player02.type[1] == 12) { da15 = 0.5f; }  //’
        else if (da13 == 7 && player02.type[1] == 13) { da15 = 2; }  //Šâ
        else if (da13 == 7 && player02.type[1] == 14) { da15 = 0; Debug.Log("7¨14"); }  //—ì
        else if (da13 == 7 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 7 && player02.type[1] == 16) { da15 = 2; }  //ˆ«
        else if (da13 == 7 && player02.type[1] == 17) { da15 = 2; }  //|
        else if (da13 == 7 && player02.type[1] == 18) { da15 = 0.5f; } //—d
        //UŒ‚‘¤‚ª“Å
        else if (da13 == 8 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 8 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 8 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 8 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 8 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 8 && player02.type[1] == 5) { da15 = 2; }  //‘
        else if (da13 == 8 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 8 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 8 && player02.type[1] == 8) { da15 = 0.5f; } //“Å
        else if (da13 == 8 && player02.type[1] == 9) { da15 = 0.5f; }  //’n
        else if (da13 == 8 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 8 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 8 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 8 && player02.type[1] == 13) { da15 = 0.5f; }  //Šâ
        else if (da13 == 8 && player02.type[1] == 14) { da15 = 0.5f; }  //—ì
        else if (da13 == 8 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 8 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 8 && player02.type[1] == 17) { da15 = 0; Debug.Log("8¨17"); }  //|
        else if (da13 == 8 && player02.type[1] == 18) { da15 = 2; } //—d
        //UŒ‚‘¤‚ª’n–Ê
        else if (da13 == 9 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 9 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 9 && player02.type[1] == 2) { da15 = 2; } //‰Š
        else if (da13 == 9 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 9 && player02.type[1] == 4) { da15 = 2; }   //“d
        else if (da13 == 9 && player02.type[1] == 5) { da15 = 0.5f; }  //‘
        else if (da13 == 9 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 9 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 9 && player02.type[1] == 8) { da15 = 2; } //“Å
        else if (da13 == 9 && player02.type[1] == 9) { da15 = 2; }  //’n
        else if (da13 == 9 && player02.type[1] == 10) { da15 = 0; Debug.Log("9¨10"); } //”ò
        else if (da13 == 9 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 9 && player02.type[1] == 12) { da15 = 0.5f; }  //’
        else if (da13 == 9 && player02.type[1] == 13) { da15 = 2; }  //Šâ
        else if (da13 == 9 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 9 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 9 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 9 && player02.type[1] == 17) { da15 = 2; }  //|
        else if (da13 == 9 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª”òs
        else if (da13 == 10 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 10 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 10 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 10 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 10 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 10 && player02.type[1] == 5) { da15 = 2; }  //‘
        else if (da13 == 10 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 10 && player02.type[1] == 7) { da15 = 2; } //Ši
        else if (da13 == 10 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 10 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 10 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 10 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 10 && player02.type[1] == 12) { da15 = 2; }  //’
        else if (da13 == 10 && player02.type[1] == 13) { da15 = 0.5f; }  //Šâ
        else if (da13 == 10 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 10 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 10 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 10 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 10 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª’´
        else if (da13 == 11 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 11 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 11 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 11 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 11 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 11 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 11 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 11 && player02.type[1] == 7) { da15 = 2; } //Ši
        else if (da13 == 11 && player02.type[1] == 8) { da15 = 2; } //“Å
        else if (da13 == 11 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 11 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 11 && player02.type[1] == 11) { da15 = 0.5f; } //’´
        else if (da13 == 11 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 11 && player02.type[1] == 13) { da15 = 2; }  //Šâ
        else if (da13 == 11 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 11 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 11 && player02.type[1] == 16) { da15 = 0; Debug.Log("11¨16"); }  //ˆ«
        else if (da13 == 11 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 11 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª’
        else if (da13 == 12 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 12 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 12 && player02.type[1] == 2) { da15 = 0.5f; } //‰Š
        else if (da13 == 12 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 12 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 12 && player02.type[1] == 5) { da15 = 2; }  //‘
        else if (da13 == 12 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 12 && player02.type[1] == 7) { da15 = 0.5f; } //Ši
        else if (da13 == 12 && player02.type[1] == 8) { da15 = 0.5f; } //“Å
        else if (da13 == 12 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 12 && player02.type[1] == 10) { da15 = 0.5f; } //”ò
        else if (da13 == 12 && player02.type[1] == 11) { da15 = 2; } //’´
        else if (da13 == 12 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 12 && player02.type[1] == 13) { da15 = 2; }  //Šâ
        else if (da13 == 12 && player02.type[1] == 14) { da15 = 0.5f; }  //—ì
        else if (da13 == 12 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 12 && player02.type[1] == 16) { da15 = 2; }  //ˆ«
        else if (da13 == 12 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 12 && player02.type[1] == 18) { da15 = 0.5f; } //—d
        //UŒ‚‘¤‚ªŠâ
        else if (da13 == 13 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 13 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 13 && player02.type[1] == 2) { da15 = 2; } //‰Š
        else if (da13 == 13 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 13 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 13 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 13 && player02.type[1] == 6) { da15 = 2; }  //•X
        else if (da13 == 13 && player02.type[1] == 7) { da15 = 0.5f; } //Ši
        else if (da13 == 13 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 13 && player02.type[1] == 9) { da15 = 0.5f; }  //’n
        else if (da13 == 13 && player02.type[1] == 10) { da15 = 2; } //”ò
        else if (da13 == 13 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 13 && player02.type[1] == 12) { da15 = 2; }  //’
        else if (da13 == 13 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 13 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 13 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 13 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 13 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 13 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª—ì
        else if (da13 == 14 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 14 && player02.type[1] == 1) { da15 = 0; Debug.Log("14¨1"); }  //ƒm
        else if (da13 == 14 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 14 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 14 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 14 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 14 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 14 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 14 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 14 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 14 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 14 && player02.type[1] == 11) { da15 = 2; } //’´
        else if (da13 == 14 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 14 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 14 && player02.type[1] == 14) { da15 = 2; }  //—ì
        else if (da13 == 14 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 14 && player02.type[1] == 16) { da15 = 0.5f; }  //ˆ«
        else if (da13 == 14 && player02.type[1] == 17) { da15 = 1; }  //|
        else if (da13 == 14 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ª—³
        else if (da13 == 15 && player02.type[1] == 0) { da15 = 1; }  //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 15 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 15 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 15 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 15 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 15 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 15 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 15 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 15 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 15 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 15 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 15 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 15 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 15 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 15 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 15 && player02.type[1] == 15) { da15 = 2; }  //—³
        else if (da13 == 15 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 15 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 15 && player02.type[1] == 18) { da15 = 0; Debug.Log("15¨18"); } //—d
        //UŒ‚‘¤‚ªˆ«
        else if (da13 == 16 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 16 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 16 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 16 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 16 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 16 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 16 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 16 && player02.type[1] == 7) { da15 = 0.5f; } //Ši
        else if (da13 == 16 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 16 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 16 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 16 && player02.type[1] == 11) { da15 = 2; } //’´
        else if (da13 == 16 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 16 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 16 && player02.type[1] == 14) { da15 = 2; }  //—ì
        else if (da13 == 16 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 16 && player02.type[1] == 16) { da15 = 0.5f; }  //ˆ«
        else if (da13 == 16 && player02.type[1] == 17) { da15 = 1; }  //|
        else if (da13 == 16 && player02.type[1] == 18) { da15 = 0.5f; } //—d
        //UŒ‚‘¤‚ª|
        else if (da13 == 17 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 17 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 17 && player02.type[1] == 2) { da15 = 0.5f; } //‰Š
        else if (da13 == 17 && player02.type[1] == 3) { da15 = 0.5f; } //…
        else if (da13 == 17 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 17 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 17 && player02.type[1] == 6) { da15 = 2; }  //•X
        else if (da13 == 17 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 17 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 17 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 17 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 17 && player02.type[1] == 11) { da15 = 2; } //’´
        else if (da13 == 17 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 17 && player02.type[1] == 13) { da15 = 2; }  //Šâ
        else if (da13 == 17 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 17 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 17 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 17 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 17 && player02.type[1] == 18) { da15 = 2; } //—d
        //UŒ‚‘¤‚ª—d
        else if (da13 == 18 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 18 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 18 && player02.type[1] == 2) { da15 = 0.5f; } //‰Š
        else if (da13 == 18 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 18 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 18 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 18 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 18 && player02.type[1] == 7) { da15 = 2; } //Ši
        else if (da13 == 18 && player02.type[1] == 8) { da15 = 0.5f; } //“Å
        else if (da13 == 18 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 18 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 18 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 18 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 18 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 18 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 18 && player02.type[1] == 15) { da15 = 2; }  //—³
        else if (da13 == 18 && player02.type[1] == 16) { da15 = 2; }  //ˆ«
        else if (da13 == 18 && player02.type[1] == 17) { da15 = 0.5f; }  //|
        else if (da13 == 18 && player02.type[1] == 18) { da15 = 1; } //—d
        //UŒ‚‘¤‚ªƒ^ƒCƒv‚È‚µ
        else if (da13 == 19 && player02.type[1] == 0) { da15 = 1; }      //ƒ^ƒCƒv‚È‚µ
        else if (da13 == 19 && player02.type[1] == 1) { da15 = 1; }  //ƒm
        else if (da13 == 19 && player02.type[1] == 2) { da15 = 1; } //‰Š
        else if (da13 == 19 && player02.type[1] == 3) { da15 = 1; } //…
        else if (da13 == 19 && player02.type[1] == 4) { da15 = 1; }   //“d
        else if (da13 == 19 && player02.type[1] == 5) { da15 = 1; }  //‘
        else if (da13 == 19 && player02.type[1] == 6) { da15 = 1; }  //•X
        else if (da13 == 19 && player02.type[1] == 7) { da15 = 1; } //Ši
        else if (da13 == 19 && player02.type[1] == 8) { da15 = 1; } //“Å
        else if (da13 == 19 && player02.type[1] == 9) { da15 = 1; }  //’n
        else if (da13 == 19 && player02.type[1] == 10) { da15 = 1; } //”ò
        else if (da13 == 19 && player02.type[1] == 11) { da15 = 1; } //’´
        else if (da13 == 19 && player02.type[1] == 12) { da15 = 1; }  //’
        else if (da13 == 19 && player02.type[1] == 13) { da15 = 1; }  //Šâ
        else if (da13 == 19 && player02.type[1] == 14) { da15 = 1; }  //—ì
        else if (da13 == 19 && player02.type[1] == 15) { da15 = 1; }  //—³
        else if (da13 == 19 && player02.type[1] == 16) { da15 = 1; }  //ˆ«
        else if (da13 == 19 && player02.type[1] == 17) { da15 = 1; }  //|
        else if (da13 == 19 && player02.type[1] == 18) { da15 = 1; } //—d

        else { Debug.Log("‘Š«”»’è2¸”s"); };

        Debug.Log("da13=" + da13 + ",da14=" + da14 + ",da15=" + da15);

        //ƒ^ƒCƒv‘Š«‡Œv”»’è
        float da16 = da14 * da15;
        if (da16 == 1) { Debug.Log("‘Š«“™”{"); }
        else if (da16 == 4) { Debug.Log("Œø‰Ê‚Í”²ŒQ‚¾(4”{)"); }
        else if (da16 == 2) { Debug.Log("Œø‰Ê‚Í”²ŒQ‚¾(2”{)"); }
        else if (da16 == 0.5f) { Debug.Log("Œø‰Ê‚Í‚¢‚Ü‚Ğ‚Æ‚Â‚Ì‚æ‚¤‚¾(0.5”{)"); }
        else if (da16 == 0.25f) { Debug.Log("Œø‰Ê‚Í‚¢‚Ü‚Ğ‚Æ‚Â‚Ì‚æ‚¤‚¾(0.25”{)"); }
        else if (da16 == 0f) { Debug.Log("Œø‰Ê‚Í‚È‚¢‚æ‚¤‚¾"); }
        else { Debug.Log("‘Š«‡Œv”»’è¸”s"); }

        float da17 = Mathf.Floor(da12 * da16);
        Debug.Log("‘Š«”»’èŒã" + da17);

        #endregion œƒ^ƒCƒv•â³
        #region œ‰Î@M•â³
        //‚â‚¯‚Ç”»’è
        float da18 = da17;

        //M•â³(•Ç•â³~ƒuƒŒƒCƒ“ƒtƒH[ƒX•â³~ƒXƒiƒCƒp[•â³~
        //‚¢‚ë‚ß‚ª‚Ë•â³~‚à‚Ó‚à‚Ó‚Ù‚Ì‚¨•â³~Mhalf~Mfilter~
        //ƒtƒŒƒ“ƒhƒK[ƒh•â³~‚½‚Â‚¶‚ñ‚Ì‚¨‚Ñ•â³~ƒƒgƒƒm[ƒ€•â³~
        //‚¢‚Ì‚¿‚Ì‚½‚Ü•â³~”¼Œ¸‚ÌÀ•â³~Mtwice(¬”“_ˆÈ‰º‚ğ’€ˆêlÌŒÜ“ü)(ÅI“I‚ÉŒÜÌŒÜ’´“ü)

        float da19 = Mathf.Ceil(da18 - 0.5f);

        //Mprotect•â³(ZƒƒU/ƒ_ƒCƒ}ƒbƒNƒX‚í‚´‚ª‚Ü‚à‚éó‘Ô‚È‚Ç‚ÅŒyŒ¸‚³‚ê‚½‚Æ‚«0.25”{)

        float da20 = da19;

        Debug.Log("ÅIƒ_ƒ[ƒWŠÖ”’l" + da20);
        #endregion œ‰Î@M•â³
        #region œÅIƒ_ƒ[ƒWŒvZ
        //ÅIƒ_ƒ[ƒWŒvZ

        player02.HPNow -= da20;

        player02.statusDisplay();

        Debug.Log("ƒvƒŒƒCƒ„[02‚Ìƒ‚ƒ“ƒXƒ^[‚ÌHP" + player02.HPNow + "/" + player02.HPMax);


        string WNlog = "";

        if (WN01 == 1) { WNlog = "‚«‚è‚©‚©‚é"; }
        else if (WN01 == 2) { WNlog = "‚¨‚»‚¢‚©‚©‚é"; }
        else if (WN01 == 3) { WNlog = "‚Æ‚Ñ‚Ç‚¤‚®"; }
        else if (WN01 == 4) { WNlog = "‚«‚ ‚¢"; }


        UImessage.GetComponent<Text>().text =
        "ƒvƒŒƒCƒ„[01‚Ìƒ‚ƒ“ƒXƒ^[‚ÌUŒ‚I  " + WNlog + "!! \n" +
        "‹}Š—”" + da08r + "/24 \n " +
        "—”•â³" + da10 + "% \n" +
        "ƒ^ƒCƒv‘Š«" + da16 + "”{ \n" +
        "ƒ_ƒ[ƒW" + da20;


    }
    //ƒ_ƒ[ƒWŒvZ®
    #endregion œÅIƒ_ƒ[ƒWŒvZ
    #endregion ƒ_ƒ[ƒWŒvZ
}
