using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 全ての猫の処理 */
public class Cat : MonoBehaviour
{
    /* 値 */
    Vector2 pos;
    Vector2 vel;            // 現在の速度

    // 状態
    public State state;
    public JumpedState jumpState;

    // 猫の状態
    public enum State {
        OffScrn,        // 画面外
        Wait,           // 待機中
        Ready,          // ジャンプ前
        Pulled,         // 引っ張られてる状態
        Jumping,        // ジャンプ中
    }

    // ジャンプ後の状態
    public enum JumpedState {
        None,           // ジャンプしてない
        Jump,           // ジャンプ中
        Fall,           // 落下
        Damage,         // ダメージ
    }

    /* フラグ */
    bool isLanding;     // 着地中か
    bool isOutScrn;     // 画面外かどうか

    /* プロパティ */
    public Vector2 Vel { get => vel; }
    public Vector2 Pos { get => pos; }

    public bool IsLanding { get => isLanding; }
    public bool IsOutScrn { get => isOutScrn; }

    /* コンポーネント取得用 */
    Rigidbody2D rb;
    GameManager gm;
    AudioManager aud;
    Cat_Animation anim;

    CatParameter par;
    Cat_Jumping jump;

//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();
        gm = gmObj.GetComponent<GameManager>();
        aud = audObj.GetComponent<AudioManager>();
        anim = GetComponent<Cat_Animation>();

        par = charaObj.GetComponent<CatParameter>();
        jump = GetComponent<Cat_Jumping>();

        /* 初期化 */

    }

//-------------------------------------------------------------------
    void LateUpdate()
    {
        if (!gm.isTimeUp && !gm.isStarting) {
            pos = transform.position;
            StateProc();
        }
    }

    //-------------------------------------------------------------------
    // 状態ごとの処理
    void StateProc()
    {
        switch (state) {
            case State.Pulled:
                jump.PrepareJumping();
                jump.Jump();            // ジャンプ
                break;

            case State.Jumping:
                vel = rb.velocity;      // 速度取得

                if (jumpState == JumpedState.Jump && !gm.isPause) {
                    jump.Rotate(vel.y);     // 回転
                    jump.Fall();            // 落下
                }

                Delete();               // 削除
                break;
        }
    }

    // 効果音再生
    public void PlaySE(AudioEnum.SE_Cat se)
    {
        aud.PlaySE(AudioEnum.AudSrc.SE_Cat, (int)se);
    }

//-------------------------------------------------------------------
    // 触れた瞬間
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stage") {
            isLanding = true;
        }
    }

    // 離れた瞬間
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stage") {
            isLanding = false;
        }
    }

    // 削除
    void Delete()
    {
        isOutScrn = par.CheckOutScrn(pos.y);        // 画面外判定

        if (isOutScrn) {
            anim.StopAnimations();          // アニメーション停止
            Destroy(gameObject);            // 削除
        }
    }
}
