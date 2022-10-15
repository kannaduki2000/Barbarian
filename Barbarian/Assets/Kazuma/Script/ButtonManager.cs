using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("キャラクターID")]
    [SerializeField]
    public int Chara_ID;

    [Header("クールタイム")]
    [SerializeField]
    private float CoolTime;

    [Header("スキルが使用可能か")]
    [SerializeField]
    private bool Possible;

    private float Timebox;

    [Header("UIマネージャー")]
    [SerializeField]
    public GameObject UIManager;

    

    void Update()
    {
        //スキルが使用可能でないとき、クールタイムをカウントする
        if (!Possible)
        {
            Timebox -= Time.deltaTime;
        }

        //クールタイムのカウントが終わったら
        if (Timebox <= 0)
        {
            Possible = true;
        }
    }

    public void ButtonClick()
    {
        //クールタイムを終えている場合
        if (Possible)
        {
            //UIマネージャーが持ってるキャラ生成処理を、自分の持つIDを代入して処理
            UIManager.GetComponent<UIManager>().CreateCharactor(Chara_ID);

            Timebox = CoolTime;
            Possible = false;
        }
    }
}
