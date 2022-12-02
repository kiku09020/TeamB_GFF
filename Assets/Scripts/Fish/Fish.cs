using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// 普通の魚、ふぐ、レア魚の親クラスです
public abstract class Fish : MonoBehaviour
{
    /* 値 */
    [SerializeField] int      score;      // スコア
    [SerializeField] float    time;       // 増加、減少するタイム
    [SerializeField] FishType type;       // タイプ

    // 魚の種類
    public enum FishType {
        normal,     // 通常
        fugu,       // ふぐ
        rare,       // レア
    }

    /* プロパティ */
    public int AddedScore   { get => score; }
    public float AddedTime  { get => time; }
    public FishType Type    { get => type; }

    /* コンポーネント取得用 */
    FishAudio aud;
    ParticleManager part;
    EffekseerParticleManager esPart;

    FishParameter par;

    //-------------------------------------------------------------------
    protected void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;
        GameObject partObj = gmObj.transform.Find("ParticleManager").gameObject;
        esPart = partObj.GetComponent<EffekseerParticleManager>();

        /* コンポーネント取得 */

        aud = GetComponent<FishAudio>();
        part = partObj.GetComponent<ParticleManager>();
        par = charaObj.GetComponent<FishParameter>();

        /* 初期化 */
    }

    void FixedUpdate()
    {
        Fall();
        InWater();
    }

    //-------------------------------------------------------------------
    // 落下処理
    void Fall()
    {
        transform.Translate(new Vector2(0, -par.FallSpd));
    }

    // 画面外判定
    void InWater()
    {
        if (transform.position.y < par.DelY) {
            PlayEatenParticle(EffekseerParticleManager.EffectType.water, transform.position);
            Destroy(gameObject);
        }
	}

    //-------------------------------------------------------------------

    // パーティクルの指定
    void PlayEatenParticle(EffekseerParticleManager.EffectType type,Vector2 pos)
    {
        esPart.PlayEffect(type, pos);
    }

    //-------------------------------------------------------------------
    // 捕食
    protected abstract void EatenComboProc(ComboManager combo,TextGenerater txtGen);       // 捕食時のコンボ処理

    // 捕食時の処理
    public void Eaten(ComboManager combo,TextGenerater txtGen)
    {
        aud.PlayEatenAudio(type);
        part.PlayPart(ParticleManager.PartNames.get, transform.position);

        EatenComboProc(combo, txtGen);

        transform.DOScale(Vector2.zero, 0.3f);
        Destroy(gameObject, 0.5f);
    }
}
