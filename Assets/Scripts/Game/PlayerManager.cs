using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private const float PLAYER_SPEED = 4.5f;
    private const float APLHA_THRESHOLD = 0.5f;
    private const float DAMAGE_EFFECT_SPEED = 6.0f;
    private const int PLAYER_MAX_LIFE = 3;

    private Vector2 MAX_MOVE_XY { get { return new Vector2(8.27f, 4.0f); } }

    [SerializeField]
    public GameObject mainCamera;

    [SerializeField]
    private StartCounter sc;

    [SerializeField]
    private GameChanger gc;

    [SerializeField]
    private GameObject angel;
    [SerializeField]
    private GameObject holy_Sircle;
    [SerializeField]
    private GameObject devil;

    // スコア
    public int score;

    // ダメージフラグ
    private bool damage;

    // クリアフラグ
    private bool clear;


    // Start is called before the first frame update
    void Start()
    {
        int currentFloor = gc.GetFloorNum();

        score = 0;
        clear = false;

        // 階層に応じてプレイヤーのテクスチャを変更       
        // 0-10 Easy
        if (currentFloor >= 0 && currentFloor <= GameChanger.MAX_EASY_FLOOR)
        {
            angel.SetActive(true);
            devil.SetActive(false);
        }

        // 11-20 Normal
        if (currentFloor >= GameChanger.MAX_EASY_FLOOR + 1 &&
            currentFloor <= GameChanger.MAX_NORMAL_FLOOR)
        {
            devil.SetActive(false);
            angel.SetActive(true);
            holy_Sircle.SetActive(false);
        }

        // 21-30 Hard
        if (currentFloor >= GameChanger.MAX_NORMAL_FLOOR + 1 &&
            currentFloor <= GameChanger.MAX_FLOOR_NUM)
        {
            devil.SetActive(true);
            angel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // キー入力
        KeyInput();


    }

    // キー入力
    private void KeyInput()
    {
        if (sc.StartEnable()) { return; }

        // [W]キー or [↑]
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            if (transform.position.y < MAX_MOVE_XY.y)
            {
                Vector3 v = transform.position;
                v.y += (Time.deltaTime * PLAYER_SPEED);
                transform.position = v;

            }
        }

        // [S]キー or [↓]
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            if (transform.position.y > -MAX_MOVE_XY.y)
            {
                Vector3 v = transform.position;
                v.y -= (Time.deltaTime * PLAYER_SPEED);
                transform.position = v;
            }
        }

        // [A]キー or [←]
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            if (transform.position.x > mainCamera.transform.position.x - MAX_MOVE_XY.x)
            {
                Vector3 v = transform.position;
                v.x -= (Time.deltaTime * PLAYER_SPEED);
                transform.position = v;

            }
        }

        // [D]キー or [→]
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            if (transform.position.x < mainCamera.transform.position.x + MAX_MOVE_XY.x)
            {
                Vector3 v = transform.position;
                v.x += (Time.deltaTime * PLAYER_SPEED);
                transform.position = v;
            }
        }
    }

    // 衝突処理
    void OnTriggerEnter2D(Collider2D other)
    {
        // エネミーオブジェクトとの衝突処理 [hitで常時]　動確済み
        if (other.gameObject.tag == "EnemyObj")
        {
            //コライダーを切ってダメージ２度付け禁止にする
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // ライフ残機の確認
            damage = true;
        }

        if (other.gameObject.tag == "EnemyObj_Virus" || other.gameObject.tag == "EnemyObj_Ghost")
        {
            //コライダーを切ってダメージ２度付け禁止にする
            other.gameObject.GetComponent<CircleCollider2D>().enabled = false;

            // ライフ残機の確認
            damage = true;
        }

        // アイテムオブジェクトとの衝突・加点処理
        if (other.gameObject.tag == "ItemObj")
        { 
            score++;
            Destroy(other.gameObject);

            // ゲットSE
        }

        // ステージクリア
        if(other.gameObject.tag == "Gate")
        {
            // DontDestroyのオブジェクトにスコアを保持させる
            GameObject.Find("SelectData").GetComponent<SelectManager>().SetScore(score);
            clear = true;
        }

    }


    public int GetScore() { return score; }
    public bool GetDamageFlag() { return damage; }
    public void SetDamageFlag(bool f) { damage = f; }
    public bool GetClearFlag() { return clear; }
}