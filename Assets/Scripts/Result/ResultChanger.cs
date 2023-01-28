using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultChanger : MonoBehaviour
{
    // 連続フェード防止フラグ
    private bool once = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // もう一度 or セレクト or タイトルへ遷移

        if(Input.GetKey(KeyCode.Space))
        {
            if(once)
            {
                // もう一度 or セレクト or タイトル

                // ゲームに戻る
                SceneNavigator.Instance.Change("Game");
                once = false;

                //SceneNavigator.Instance.Change("");
            }
        }

        if(Input.GetKey(KeyCode.Return))
        {
            if(once)
            {
                SceneNavigator.Instance.Change("Title");
                once = false;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (once)
            {
                SceneNavigator.Instance.Change("Select");
                once = false;
            }
        }
    }
}
