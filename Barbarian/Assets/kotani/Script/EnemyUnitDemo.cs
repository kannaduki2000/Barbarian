using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitDemo : PlayerUnitBase
{
    ////////////////////////////////////
    ///〇試験用に仮で作ったエネミーです
    ///将来的に消す予定なんで使わないほうが吉
    ////////////////////////////////////
    // Start is called before the first frame update
    // Update is called once per frame
    public int MaxHp;
    [SerializeField]
    private CostDemoScript costDemoScript;
    void Awake()
    {
        costDemoScript = GameObject.Find("PlayerUnitSpawnSystem").GetComponent<CostDemoScript>();
        MaxHp = Hp;
        Hp = MaxHp;
    }
    void Update()
    {
        if(Hp <= 0)
        {
            costDemoScript.NowCost = costDemoScript.NowCost+Cost;
            Destroy (this.gameObject);
        }
    }
}
