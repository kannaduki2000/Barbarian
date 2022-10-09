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
    void Awake()
    {
        MaxHp = Hp;
        Hp = MaxHp;
    }
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy (this.gameObject);
        }
    }
}
