using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("�L�����N�^�[ID")]
    [SerializeField]
    public int Chara_ID;

    [Header("�N�[���^�C��")]
    [SerializeField]
    private float CoolTime;

    [Header("�X�L�����g�p�\��")]
    [SerializeField]
    private bool Possible;

    private float Timebox;

    [Header("UI�}�l�[�W���[")]
    [SerializeField]
    public GameObject UIManager;

    

    void Update()
    {
        //�X�L�����g�p�\�łȂ��Ƃ��A�N�[���^�C�����J�E���g����
        if (!Possible)
        {
            Timebox -= Time.deltaTime;
        }

        //�N�[���^�C���̃J�E���g���I�������
        if (Timebox <= 0)
        {
            Possible = true;
        }
    }

    public void ButtonClick()
    {
        //�N�[���^�C�����I���Ă���ꍇ
        if (Possible)
        {
            //UI�}�l�[�W���[�������Ă�L���������������A�����̎���ID�������ď���
            UIManager.GetComponent<UIManager>().CreateCharactor(Chara_ID);

            Timebox = CoolTime;
            Possible = false;
        }
    }
}
