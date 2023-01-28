using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChanger : MonoBehaviour
{
    // フェード用フラグ
    private bool once = true;

    [SerializeField]
    private GameObject selectDataObj;

    [SerializeField]
    private SelectManager sm;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(selectDataObj);
        sm.SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(once)
            {
                // フロア選択を0にテスト固定
                // GameChangerでテストモードになっていないか確認
                // 0-10:Star　11-20:Cave　21-30:HELL
                sm.SetFloorNumber(0);

                SceneNavigator.Instance.Change("Game");
                once = false;
            }
        }
        
    }
}
