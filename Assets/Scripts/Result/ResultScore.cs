using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    // スコア
    private int score;

    [SerializeField]
    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("SelectData").GetComponent<SelectManager>().GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = score.ToString();
    }
}
