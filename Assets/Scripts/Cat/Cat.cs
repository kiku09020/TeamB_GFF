using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        OutOfScrn,      // 画面外
        Wait,           // 待機中
        Ready,          // ジャンプ前
        Jumped,         // ジャンプ後
    }

    // ジャンプ後の状態
    public enum JumpedState {
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

    CatParameter par;
    MainCat jump;

//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        aud = audObj.GetComponent<AudioManager>();

        par = gmObj.GetComponent<CatParameter>();
        jump = GetComponent<MainCat>();
        
        /* 初期化 */
    }

//-------------------------------------------------------------------
    void LateUpdate()
    {
        pos = transform.position;

        if (state == State.Ready || state == State.Jumped) {
            vel = rb.velocity;      // 速度取得
        }

        // 主役猫
        if (state == State.Ready) {
            jump.Jump();
        }

        if (state == State.Jumped) {
            jump.Fall();
            isOutScrn = par.CheckOutScrn(pos.y);

            Delete();
        }
    }

    //-------------------------------------------------------------------
    // 効果音再生
    public void PlaySE(AudioEnum.Enm_SE_Chara se)
    {
        aud.PlaySE(AudioEnum.Enm_AudSrc.SE_Chara, (int)se);
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
        if (IsOutScrn) {
            Destroy(gameObject);
        }
    }
}