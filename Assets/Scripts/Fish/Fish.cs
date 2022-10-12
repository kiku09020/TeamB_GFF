using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 普通の魚、ふぐ、レア魚の親クラスです
public abstract class Fish : MonoBehaviour
{
    /* 値 */
    [SerializeField] protected int score;       // スコア
    [SerializeField] protected Type type;       // タイプ

    float nowFallSpd;                           // 現在の落下速度

    // 魚の種類
    public enum Type {
        normal,     // 通常
        fugu,       // ふぐ
        rare,       // レア
    }

    /* コンポーネント取得用 */
    AudioManager aud;

    FishParameter par;


    //-------------------------------------------------------------------
    protected virtual void Start()
    {
        Init();
    }

    void FixedUpdate()
    {
        Fall();
        CheckOutScrn();
    }

    protected void Init()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        /* コンポーネント取得 */
        aud = audObj.GetComponent<AudioManager>();

        par = charaObj.GetComponent<FishParameter>();

        /* 初期化 */
        nowFallSpd = par.FallSpdStart;      // 落下速度
    }

    // 落下処理
    protected void Fall()
    {
        transform.Translate(new Vector2(0, -nowFallSpd));
    }

    // 画面外判定
    protected void CheckOutScrn()
    {
        if (transform.position.y < par.DelY) {
            Destroy(gameObject);
        }
	}

    // 効果音の指定
    protected void PlayEatenSound(AudioEnum.SE_Fish se)
    {
        aud.PlaySE(AudioEnum.AudSrc.SE_Fish, (int)se);
    }

    //-------------------------------------------------------------------
    // 猫に食われたときの処理
    protected virtual void Eaten()
    {
        PlayEatenSound(AudioEnum.SE_Fish.eaten);

        Destroy(gameObject);
    }

    // 衝突時
    void OnTriggerEnter2D(Collider2D col)
	{
        Cat.State catState = col.gameObject.GetComponent<Cat>().state;

        // ジャンプしてるネコに当たったときのみ
        if (col.gameObject.tag == "Cat" && catState == Cat.State.Jumped) {
            Eaten();
        }
    }
}
