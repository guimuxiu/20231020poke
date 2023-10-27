using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //メモ
    //追加したいもの:接触、範囲、音、風



    //ウエポンナンバー9001　きりかかる 
    // ノーマル、威力50、命中100、pp10、物理、優先度0
    public string wn9001="きりかかる" ;
    public int[] wf9001 = { 1, 50, 100, 10, 1, 0 };


    //ウエポンナンバー9002　おそいかかる 
    // 炎、威力100、命中80、pp10、物理、優先度0
    public string wn9002 =  "おそいかかる" ;
    public int[] wf9002 = { 2, 100, 80, 10, 1, 0 };

    //ウエポンナンバー9003　とびどうぐ 
    // 水、威力80、命中100、pp10、特殊、優先度0
    public string wn9003 =  "とびどうぐ" ;
    public int[] wf9003 = { 3, 80, 100, 10, 2, 0 };

    //ウエポンナンバー9004　きあい 
    // 電、威力0、命中100、pp10、変化、優先度0
    //自分の攻撃ランクを1段階あげる
    public string wn9004 =  "きあい" ;
    public int[] wf9004 = { 4, 0, 100, 10, 2, 0 };


}
