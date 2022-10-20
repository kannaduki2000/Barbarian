using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //プレハブを入れる配列
    [SerializeField]
    private List<GameObject> EnemyPrehub = new List<GameObject>();
    private Transform EnemyPrehubParent;
    // Start is called before the first frame update
    void Start()
    {
        EnemyPrehubParent = this.transform;
        //スタート時にランダムでどのPrefabを出現させるか決める
        int rnd = Random.Range(0, 3);
        var obj = Instantiate(EnemyPrehub[rnd]);
        obj.transform.SetParent(EnemyPrehubParent,false);
        obj.transform.position = EnemyPrehubParent.position;
    }
}
