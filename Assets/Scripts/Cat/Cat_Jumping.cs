using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ジャンプする猫の処理 */
public class Cat_Jumping : MonoBehaviour
{
    /* 値 */

    /* コンポーネント取得用 */
    Cat cat;
    JumpArrow arrow;
    CatParameter par;

    Collider2D col;
    Rigidbody2D rb;

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        /* コンポーネント取得 */
        arrow = transform.Find("Arrow").gameObject.GetComponent<JumpArrow>();
        cat = GetComponent<Cat>();
        par = charaObj.GetComponent<CatParameter>();

        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();


        /* 初期化 */

    }

    //-------------------------------------------------------------------
    // ジャンプ処理
    public void Jump()
    {
        // 離した瞬間
        if (Input.GetMouseButtonUp(0)) {
            cat.state = Cat.State.Jumping;
            cat.jumpState = Cat.JumpedState.Jump;
            par.existMainCat = false;

            rb.AddForce(arrow.TapVector);            // ぶっ飛ばす
            cat.PlaySE(AudioEnum.SE_Cat.jump);
        }
    }

    // 落ちるときの処理
    public void Fall()
    {
        // 当たり判定なくす
        if (cat.Vel.y < 0) {
            cat.jumpState = Cat.JumpedState.Fall;
            col.isTrigger = true;
        }
    }

    // ジャンプ中の回転
    public void Rotate(float value)
    {
        var rotSpd = Mathf.Abs(value) / 10;
        transform.Rotate(0, 0, rotSpd);
    }

    // ジャンプ準備
    public void PrepareJumping()
    {
        
    }
}
