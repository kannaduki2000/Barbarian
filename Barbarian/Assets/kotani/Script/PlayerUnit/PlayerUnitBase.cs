using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitBase : MonoBehaviour
{
    //////////////////////////////////////
    ///〇Unitの共通情報を入れる継承用のクラス
    ///  今回はとりあえず自分が使うだけなので
    ///  ステータスを入れるだけのところ
    //////////////////////////////////////

    #region ステータスの宣言
    [SerializeField]
    private int cost;            //キャラのコスト
    [SerializeField]
    private int atk;            //キャラの攻撃力
    [SerializeField]
    private float moveSpeed;    //キャラの歩行速度(1が遅め10が速めになるように調整)
    [SerializeField]
    private float atkSpeed;     //キャラの攻撃速度(Second換算なので 攻撃→n[s]待機→攻撃になる)
    [SerializeField]
    private int hp;             //試験動作用のかかし用に用意（のちに消します）
    
    #endregion

    #region get,set
    public int Cost { get { return cost; } set { cost = value; } }
    public int Hp { get { return hp; } set { hp = value; } }
    public int Atk { get { return atk; } set { atk = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float AtkSpeed { get { return atkSpeed; } set { atkSpeed = value; } }
    #endregion
}
