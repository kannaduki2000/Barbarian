using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public int obj;
    public int dmj;
    public Text objtext;
    public Text dmjtext;
    public TimerDemo timer;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objtext.text = obj.ToString();
        dmjtext.text = dmj.ToString();
        if(timer.CountDownTime <= 0.01f)
        {
            Panel.SetActive (true);
        }
    }
}
