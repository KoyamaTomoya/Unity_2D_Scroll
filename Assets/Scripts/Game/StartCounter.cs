using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCounter : MonoBehaviour
{
    // 定数
    private const string READY_TXT = "Ready ?";
    private const string GO_TXT = "GO !";
    private const float WAIT_TIME = 4.0f;
    private const float TRANS_POINT = 0.0f;


    private bool textEnable;
    private int sec;
    private float totalTimer = WAIT_TIME;

    [SerializeField]
    private Text txt;


    // Start is called before the first frame update
    void Start()
    {
        textEnable = false;
    }

    // Update is called once per frame
    void Update()
    {

        totalTimer -= Time.deltaTime;
        sec = (int)totalTimer;

        // カウント中はカウント値を代入 "0"でテキスト有効化
        if(sec > 0) { txt.text = sec.ToString(); }
        else if(sec == 0) { textEnable = true; }

        if(textEnable)
        {
            txt.text = GO_TXT.ToString();
            
            // カウント0で非表示化
            if(totalTimer < TRANS_POINT)
            {
                txt.enabled = false;
            }
        }
    }

    public bool StartEnable()
    {
        //if (debugObj.GetDebugMode_StartCounter()) { return txt.enabled; }
        return txt.enabled;
    }
}
