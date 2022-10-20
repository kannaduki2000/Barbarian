using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraWork : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxDragPiont;
    private Vector3 fastpoj;

    // Start is called before the first frame update
    void Start()
    {
        fastpoj = Camera.localPosition;
        Debug.Log(fastpoj.x+MaxDragPiont);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Drag/DragEnd
    //ドラッグ始め
    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        //positionとdeltaが取得可能
        //positionは場所の座標(vec)
        //deltaはXY軸どっちに動いたか上なら＋右なら＋
        //Debug.Log(pointerEventData.delta);
        //Debug.Log("押された");
    }
    //ドラッグ中
    public void OnDrag(PointerEventData pointerEventData)
    {
        //Debug.Log(pointerEventData);//ドラッグした方向にCameraを動かすCameraを動かす
        Camera.localPosition += new Vector3(-1.5f*pointerEventData.delta.x,0,0);
        if(fastpoj.x >= Camera.localPosition.x)
        {
            Camera.localPosition = fastpoj;
        }
        else if(MaxDragPiont <= Camera.localPosition.x)
        {
            Camera.localPosition = new Vector3(MaxDragPiont,0,fastpoj.z);
        }
        //Debug.Log("移動中...");
    }
    //ドラッグ終わり
    public void OnEndDrag(PointerEventData pointerEventData)
    {
        //Debug.Log(pointerEventData.delta);
        //Debug.Log("離された");
    }
    #endregion
}
