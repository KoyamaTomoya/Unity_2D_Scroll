using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    // カメラスクロール速度　基本-2.0  高速-50
    private const float MAX_SCROLL_SPEED = -2.0f;

    // スクロールの最大値
    private const float MAX_CAMERA_POS = -190.0f;

    //カメラの初期位置
    private Vector3 startCameraPos { get { return new Vector3(0f, 0f, -20f); } }

    // スタートカウンタ
    [SerializeField]
    private StartCounter sc;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startCameraPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > MAX_CAMERA_POS && !sc.StartEnable())
        {
            transform.Translate(MAX_SCROLL_SPEED * Time.deltaTime, 0, 0);
        }
    }
}
