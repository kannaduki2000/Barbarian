using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("生成するキャラクター")]
    [SerializeField]
    public GameObject[] Charactor;//後でリストにするかも

    public int CharaID;

    void Start()
    {

    }

    //ボタンを押されたら
    public void CreateCharactor(int ID)
    {
        Instantiate(Charactor[ID]);
    }
}
