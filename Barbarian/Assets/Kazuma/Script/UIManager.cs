using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("��������L�����N�^�[")]
    [SerializeField]
    public GameObject[] Charactor;//��Ń��X�g�ɂ��邩��

    public int CharaID;

    void Start()
    {

    }

    //�{�^���������ꂽ��
    public void CreateCharactor(int ID)
    {
        Instantiate(Charactor[ID]);
    }
}
