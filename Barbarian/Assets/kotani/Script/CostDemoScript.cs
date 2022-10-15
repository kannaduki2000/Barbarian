using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class CostDemoScript : MonoBehaviour
{
    ///////////////////////////////////////////
    ///〇コスト処理確認用
    ///Enemyと同じく後で消すので使わないほうが吉
    ///////////////////////////////////////////

    private int MaxCost = 10000;
    private int nowCost=0;
    private float timeleft;

    [SerializeField]
    private int fastCost;
    [SerializeField]
    private Text CostText;
    [SerializeField]
    private Transform PlayerUnitPrefabParent;

    [SerializeField]
    private List<GameObject> PlayerUnitPrefabList = new List<GameObject>();

    [Header("ボタン")]
    [SerializeField]
    private Image[] Button_obj;

    [Header("クールタイム(設定用)")]
    [SerializeField]
    private float[] CoolTime;

    [Header("クールタイム(実機)")]
    [SerializeField]
    private float[] Timebox;

    [Header("出撃が可能か")]
    [SerializeField]
    private bool[] Possible;

    void Awake()
    {
        nowCost = fastCost;
        CostText.text = nowCost.ToString();
    }

    void Start()
    {
        //出撃のスイッチを処理
        for (int i = 0; i < Timebox.Length; i++)
        {
            Timebox[i] = CoolTime[i];

            Possible[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 1.0f;
            if(MaxCost-1 >= nowCost)
            {
                nowCost += 1;
                CostText.text = nowCost.ToString();
            }   
        }

        //各リストのクールタイムを進める
        for (int i = 0; i < Timebox.Length; i++)
        {
            Timebox[i] -= Time.deltaTime;

            Button_obj[i].fillAmount = 1 - (float)Timebox[i] / (float)CoolTime[i];//カウントをボタンに反映

            //クールタイムが進め終わったら
            if (Timebox[i] <= 0)
            {
                Possible[i] = true;
            }
        }
    }

    //出撃ボタンが押されたときの処理
    public void FastPlayerUnitSpawn()
    {
        if(Possible[0])
        {
            PlayerUnitSpawn(PlayerUnitPrefabList[0]);
            Timebox[0] = CoolTime[0];
            Possible[0] = false;
        }
    }

    //出撃ボタンが押されたときの処理
    public void SecondPlayerUnitSpawn()
    {
        if (Possible[1])
        {
            PlayerUnitSpawn(PlayerUnitPrefabList[1]);
            Timebox[1] = CoolTime[1];
            Possible[1] = false;
        }
    }

    //出撃ボタンが押されたときの処理
    public void ThirdPlayerUnitSpawn()
    {
        if (Possible[2])
        {
            PlayerUnitSpawn(PlayerUnitPrefabList[2]);
            Timebox[2] = CoolTime[2];
            Possible[2] = false;
        }
    }

    private void PlayerUnitSpawn(GameObject PlayerUnit)
    {
        if(nowCost >= PlayerUnit.GetComponent<PlayerUnit>().Cost)
        {
            nowCost -=PlayerUnit.GetComponent<PlayerUnit>().Cost;
            CostText.text = nowCost.ToString();
            var obj = Instantiate(PlayerUnit);
            obj.transform.SetParent(PlayerUnitPrefabParent,false);
            obj.transform.position = PlayerUnitPrefabParent.position;
        }
    }
}
