using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamegeTextMove : MonoBehaviour
{
    [SerializeField]
    private float textMoveSpeed;

    [SerializeField]
    private float maxTime;//制限時間の上限とカウント開始時間 のち非シリアライズ
    [SerializeField]
    private Text textColor;//制限時間の上限とカウント開始時間 のち非シリアライズ
    
    private bool timerStop;//タイマーが動いてるかの判断
    private float totalTime =0;//経過時間計測

    void Start()
    {
        maxTime = maxTime+1;
        totalTime = maxTime;
        timerStop = false;
        transform.position += transform.up * 1;//ちょっと高めに出す
        int rnd = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
		if (totalTime >= 1 && timerStop == false)
		{
			totalTime -= Time.deltaTime;
            transform.position += transform.up *textMoveSpeed* Time.deltaTime;
        }
		else
		{
			timerStop = true;
		}

		if (timerStop == true)//時間が０になったら消滅する
		{
            gameObject.SetActive(false);
        }
	}

    void OnEnable()
    {
        totalTime = maxTime;
        timerStop = false;
    }

}
