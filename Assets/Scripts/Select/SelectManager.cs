using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    // 一時保存用スクリプト



    // 選択したフロア番号
    private int selectFloor;

    // スコアの格納
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        selectFloor = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int num) { score = num; }
    public void SetFloorNumber(int num) { selectFloor = num; }
    public int GetFloorNumber() { return selectFloor; }
    public int GetScore() { return score; }
}
