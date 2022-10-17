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
        OutScrn,      // 画面外
        Wait,           // 待機中
        Ready,          // ジャンプ前
        Jumped,         // ジャンプ後
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
    AudioManager aud;

    GameManager gm;
    CatParameter par;
    MainCat jump;

//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();
        aud = audObj.GetComponent<AudioManager>();

        gm = gmObj.GetComponent<GameManager>();
        par = charaObj.GetComponent<CatParameter>();
        jump = GetComponent<MainCat>();

        /* 初期化 */

    }

//-------------------------------------------------------------------
    void LateUpdate()
    {
        if (!gm.timeUp) {
            pos = transform.position;
            StateProc();
        }
    }

    //-------------------------------------------------------------------
    // 状態ごとの処理
    void StateProc()
    {
        // ジャンプ中
        if (state == State.Jumped && jumpState == JumpedState.Jump) {
            vel = rb.velocity;      // 速度取得
        }

        // 主役猫
        if (state == State.Ready && jumpState == JumpedState.None) {
            jump.Jump();
        }

        if (state == State.Jumped) {
            jump.Fall();
            isOutScrn = par.CheckOutScrn(pos.y);

            Delete();
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

        else if (col.gameObject.tag == "Fish"){
            
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
        if (IsOutScrn) {
            Destroy(gameObject);
        }
    }
}
