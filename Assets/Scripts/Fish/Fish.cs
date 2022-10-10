using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 普通の魚、ふぐ、レア魚の親クラスです
public abstract class Fish : MonoBehaviour
{
    /* 値 */
    [SerializeField] protected int score;       // スコア
    [SerializeField] protected Type type;       // タイプ

    // 魚の種類
    protected enum Type {
        normal,     // 通常
        fugu,       // ふぐ
        rare,       // レア
    }

    /* フラグ */
    bool isoutScrn;

    /* コンポーネント取得用 */
    AudioManager aud;

    FishGenerater gen;


    //-------------------------------------------------------------------
    protected void Init()
    {
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        aud = audObj.GetComponent<AudioManager>();

        gen = charaObj.GetComponent<FishGenerater>();
    }

    // 落下処理
    protected void Fall()
    {
        transform.Translate(new Vector2(0, -gen.FallSpd));
    }

    // 画面外判定
    protected void CheckOutScrn()
    {
        
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
        if (col.gameObject.tag == "Cat") {
            Eaten();
        }
    }
}
