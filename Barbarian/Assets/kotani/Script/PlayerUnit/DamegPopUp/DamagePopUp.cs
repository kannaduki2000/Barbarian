using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopUp : MonoBehaviour
{
    public GameObject TextBoxPrefab;//表示するダメージのテキスト
    public GameObject canvas;
    public GameObject enemy;
    Transform bullets;//プーリングするオブジェクト

    void Start()
    {
        bullets = new GameObject("EnemyDamegeText").transform;
        bullets.SetParent(canvas.transform,false);
    }

    public void CreatePopUp(float damage)
    {
        CreateDamageText(transform.position,damage);
    }

    //enemyの上にダメージを表示する
    void CreateDamageText(Vector3 enemyPoj , float damage)//表示位置と表示数値を入れる
    {
        float rnd = Random.Range(-1f, 1f);
        enemyPoj = enemy.GetComponent<Transform>().position;

        foreach (Transform t in bullets)
        {
            if (!t.gameObject.activeSelf)
            {
                //非アクティブなオブジェクトの位置を設定
                t.position = enemyPoj + new Vector3(rnd,0,0);
                //t.position = enemyPoj;
                //アクティブにする
                t.gameObject.SetActive(true);
                t.gameObject.GetComponent<UnityEngine.UI.Text>().text = damage.ToString();
                return;
            }
        }

        GameObject prefab = (GameObject)Instantiate(TextBoxPrefab, bullets);
        prefab.transform.position = enemyPoj + new Vector3(rnd,0,0);
        prefab.GetComponent<UnityEngine.UI.Text>().text = damage.ToString();
        //Debug.Log(prefab.transform.position);
    }
}
