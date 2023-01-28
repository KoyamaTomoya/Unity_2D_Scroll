using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChanger : MonoBehaviour
{
    // フェード用フラグ
    private bool once = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (once)
            {
                SceneNavigator.Instance.Change("Select");
                once = false;
            }
        }
    }
}
