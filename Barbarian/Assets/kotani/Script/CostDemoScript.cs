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
    public int NowCost { get { return nowCost; } set { nowCost = value; } }
    private float timeleft;

    [SerializeField]
    private int fastCost;
    [SerializeField]
    private Text CostText;
    [SerializeField]
    private Transform PlayerUnitPrefabParent;
    
    [SerializeField]
    private List<GameObject> PlayerUnitPrefabList = new List<GameObject>();
    void Awake()
    {
        nowCost = fastCost;
        CostText.text = nowCost.ToString();
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
    }

    public void FastPlayerUnitSpawn()
    {
        //出撃ボタンが押されたときの処理
        PlayerUnitSpawn(PlayerUnitPrefabList[0]);
    }
    public void SecondPlayerUnitSpawn()
    {
        //出撃ボタンが押されたときの処理
        PlayerUnitSpawn(PlayerUnitPrefabList[1]);
    }
    public void ThirdPlayerUnitSpawn()
    {
        //出撃ボタンが押されたときの処理
        PlayerUnitSpawn(PlayerUnitPrefabList[2]);
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
