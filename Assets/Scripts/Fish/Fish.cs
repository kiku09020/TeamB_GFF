using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 普通の魚、ふぐ、レア魚の親クラスです
public abstract class Fish : MonoBehaviour
{
    /* 値 */
    [SerializeField] protected int score;        // スコア
    [SerializeField] protected Type type;        // タイプ
    protected float spd;        // 速度

    // 魚の種類
    protected enum Type {
        normal,     // 通常
        fugu,       // ふぐ
        rare,       // レア
    }

    /* コンポーネント取得用 */
    AudioManager aud;

    //-------------------------------------------------------------------
    protected void Init()
    {
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        aud = audObj.GetComponent<AudioManager>();
    }

    // 落下処理
    protected void Fall()
    {
        transform.Translate(new Vector2(0, -0.1f));
    }

    // 効果音の指定
    protected void PlayEatenSound(AudioEnum.SE_Fish se)
    {
        aud.PlaySE(AudioEnum.AudSrc.SE_Fish, (int)se);
    }

    // 猫に食われたときの処理
    protected virtual void Eaten()
    {
        PlayEatenSound(AudioEnum.SE_Fish.eaten);

        Destroy(gameObject);
    }

    // 衝突時
	protected void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Cat") {
            Eaten();
        }
    }
}
