using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChanger : MonoBehaviour
{
    private const int MAX_FLOOR_NUM = 30;
    private const int MAX_EASY_FLOOR = 10;
    private const int MAX_NORMAL_FLOOR = 20;

    private enum BG_NUM
    {
        DARK_SKY = 0,
        CAVE,
        HELL
    };

    private Vector3 SET_BG_VEC { get { return new Vector3(428.905f, 365.915f, 1f); } }
    private Vector3 SET_ENEMY_VEC { get { return new Vector3(-2.116365f, 2.492496f, 15f);} }
    private Vector3 SET_ITEM_VEC { get { return new Vector3(5.634145f, -0.8499594f, 9.954765f); } }

    // テスト用フラグ
    [SerializeField]
    private bool Test_Mode;

    [SerializeField]
    private int T_setFloor;

    // BGの配列
    [SerializeField]
    private GameObject[] BackGround_Data;

    // 敵の配列(最大数はインスペから要変更)
    [SerializeField]
    private GameObject[] EnemyObj;

    // アイテムの配列(最大数はインスペから要変更)
    [SerializeField]
    private GameObject[] ItemObj;

    [SerializeField]
    private PlayerManager pm;

    // フェード用フラグ
    private bool once = true;

    // フロア番号
    public int floorNumber;

    // Start is called before the first frame update
    void Start()
    {
        // シリアライズのテストフラグを上げて階層を指定すると固定できる
        // フラグを下げた場合　セレクトから選択しないと固定できない
        // セレクトチェンジャーに階層の変数を受け渡してもらってる
        if(Test_Mode)
        {
            // テストモード
            floorNumber = T_setFloor;
        }
        else
        {
            // 選択されたフロアナンバーを取得(直接ゲームシーンを起動する場合はコメントアウト)
            floorNumber = GameObject.Find("SelectData").GetComponent<SelectManager>().GetFloorNumber();
        }

        // 選択されたフロアナンバーを取得(直接ゲームシーンを起動する場合はコメントアウト)
        //floorNumber = GameObject.Find("SelectData").GetComponent<SelectManager>().GetFloorNumber();


        // 0-10:Star 11-20:Cave 21-30:Hell

        // 各オブジェクトの配置
        for(int i =MAX_FLOOR_NUM; i >= 0; i--)
        {
            if(i == floorNumber)
            {
                // 21:30
                if (i >= MAX_NORMAL_FLOOR + 1 && i <= MAX_FLOOR_NUM)
                {
                    BackGround_Data[(int)BG_NUM.DARK_SKY].SetActive(false);
                    BackGround_Data[(int)BG_NUM.CAVE].SetActive(false);
                    BackGround_Data[(int)BG_NUM.HELL].SetActive(true);


                    Debug.Log("HARD : " + floorNumber);
                }

                // 11-20
                if (i >= MAX_EASY_FLOOR + 1 && i <= MAX_NORMAL_FLOOR)
                {
                    BackGround_Data[(int)BG_NUM.DARK_SKY].SetActive(false);
                    BackGround_Data[(int)BG_NUM.CAVE].SetActive(true);
                    BackGround_Data[(int)BG_NUM.HELL].SetActive(false);

                    Debug.Log("NORMAL :" + floorNumber);
                }

                // 0-10
                if (i >= 0 && i <= MAX_EASY_FLOOR)
                {
                    BackGround_Data[(int)BG_NUM.DARK_SKY].SetActive(true);
                    BackGround_Data[(int)BG_NUM.CAVE].SetActive(false);
                    BackGround_Data[(int)BG_NUM.HELL].SetActive(false);

                    Debug.Log("EASY :"+floorNumber);
                }

                // 敵・アイテムの配置
                Instantiate(EnemyObj[i], SET_ENEMY_VEC, Quaternion.identity);
                Instantiate(ItemObj[i], SET_ITEM_VEC, Quaternion.identity);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.GetClearFlag())
        {
            if(once)
            {
                SceneNavigator.Instance.Change("Result");
                once = false;
            }
        }
    }
}
