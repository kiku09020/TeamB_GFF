using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 普通の魚、ふぐ、レア魚の親クラスです
public abstract class Fish : MonoBehaviour
{
    /* 値 */
    [SerializeField] protected int      score;      // スコア
    [SerializeField] protected float    time;       // 増加、減少するタイム
    [SerializeField] protected FishType     type;       // タイプ

    // 魚の種類
    public enum FishType {
        normal,     // 通常
        fugu,       // ふぐ
        rare,       // レア
    }

    /* プロパティ */
    public int AddedScore { get => score; }
    public float AddedTime { get => time; }
    public FishType Type { get => type; }

    /* コンポーネント取得用 */
    AudioManager aud;
    ParticleManager part;

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
        aud     = audObj.GetComponent<AudioManager>();


        par     = charaObj.GetComponent<FishParameter>();

        /* 初期化 */
    }

    // 落下処理
    protected void Fall()
    {
        transform.Translate(new Vector2(0, -par.FallSpd));
    }

    // 画面外判定
    protected void CheckOutScrn()
    {
        if (transform.position.y < par.DelY) {
            Destroy(gameObject);
        }
	}

    // 効果音の指定
    void PlayEatenSound()
    {
        aud.PlaySE(AudioEnum.AudSrc.SE_Fish, (int)type);
    }

    // パーティクルの指定
    void PlayEatenParticle()
    {

    }

    //-------------------------------------------------------------------
    // 捕食
    public void Eaten()
    {
        PlayEatenSound();
        PlayEatenParticle();
    }
}
