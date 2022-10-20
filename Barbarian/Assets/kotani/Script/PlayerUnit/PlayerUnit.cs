using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUnit : PlayerUnitBase
{
    //////////////////////////////////////
    ///〇Unitの動きを作るクラス
    ///  Unitの移動、攻撃、停止を命じる
    ///
    ///  ローカル変数   ...ローワーキャメル
    ///  パブリック変数 ...アッパーキャメル
    ///  ローカル関数   ...アッパーキャメル
    ///  パブリック関数 ...アッパーキャメル
    //////////////////////////////////////

    #region 変数の定義
    //内部処理だけで使う（予定の）変数
    private bool unitStopFlag = false;//unitの歩行を停止させる用
    private GameObject unitObj = null;     //自分のオブジェクト格納用
    private Rigidbody2D unitRb = null;  //自分のRigtBody2d格納用
    private GameObject enemyObj = null;
    private bool attackStackFlag = false;
    private DamagePopUp damagePopUp;

    #endregion

    void Start()
    {
        try{
        unitObj = this.gameObject;
        unitRb = unitObj.GetComponent<Rigidbody2D>();
        //timeManager = GameObject.Find ("HitStopManager").GetComponent<HitStopTimeManager>();
        damagePopUp = GameObject.Find ("DamagePopUp").GetComponent<DamagePopUp>();
        }catch(Exception e)
        {
            Console.WriteLine(e);

            //もし例外が起きたら変な挙動をしないように非アクティブにする
            this.gameObject.SetActive (false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UnitMove();
    }

    //子オブジェクトのisTriggerの判定を拾ってる
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            unitRb.velocity = Vector3.zero;
            unitStopFlag = true;
            enemyObj = collision.gameObject;
        }
    }

    private void UnitMove()
    {
        if(unitStopFlag)//ユニットが止まっている場合の処理
        {
            //敵を倒した＝敵がdestroyしたと仮定
            //敵をobjectpool等で使いまわす場合は別途処理を追加予定
            if(enemyObj != null)
            {
                if(attackStackFlag == false)
                {
                    StartCoroutine(UnitAttack());//一定間隔で攻撃する
                }
            }
            else
            {
                unitStopFlag = false;
            }

        }
        else//ユニットが止まっていないときの処理
        {
            //velocityで定速移動
            unitRb.velocity = new Vector3(MoveSpeed,0,0);
        }
    }

    private IEnumerator UnitAttack()
    {
        attackStackFlag = true;
        //yield return new WaitForSeconds(AtkSpeed);

        //もしエネミーが健在なら攻撃する
        if(enemyObj.GetComponent<EnemyUnitDemo>().Hp >= 0)//.enemyObj != null)
        {
            enemyObj.GetComponent<EnemyUnitDemo>().Hp -= Atk;
            damagePopUp.CreatePopUp(Atk,enemyObj);
        }
        yield return new WaitForSeconds(AtkSpeed);
        attackStackFlag = false;
    }

}
