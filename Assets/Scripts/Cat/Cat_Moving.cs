using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/* 猫の移動 */
public class Cat_Moving : MonoBehaviour
{
    /* 値 */
    bool moveOnce_Idle;
    bool moveOnce_jump;

    /* コンポーネント取得用 */
    Cat cat;
    CatGenerater gen;
    CatParameter par;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        /* コンポーネント取得 */
        cat = GetComponent<Cat>();
        gen = charaObj.GetComponent<CatGenerater>();
        par = charaObj.GetComponent<CatParameter>();

        /* 初期化 */
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        // 範囲外の猫
        if (cat.state == Cat.State.OffScrn && !par.existMainCat) {
            if (!moveOnce_Idle) {
                Move();
            }

            // 目的地についたとき
            if (cat.Pos.x == par.IdlePos.x) {
                cat.state = Cat.State.Wait;         // 状態遷移
                gen.Generate();                     // 生成
            }
        }

        // 待ち猫
        else if (cat.state == Cat.State.Wait && !par.existMainCat) {
            if (!moveOnce_jump) {
                Move();
            }

            // ついたとき
            if (cat.Pos.x == par.JumpPos.x) {
                cat.state = Cat.State.Ready;        // 待ち状態にする
                par.existMainCat = true;
            }
        }
    }

//-------------------------------------------------------------------
    // 移動
    void Move()
    {
        Vector2 pos = Vector2.zero;     // 目的座標

        switch (cat.state) {
            case Cat.State.OffScrn:
                pos = par.IdlePos;
                moveOnce_Idle = true;

                break;
            case Cat.State.Wait:
                pos = par.JumpPos;
                moveOnce_jump = true;
                break;
        }

        transform.DOMove(pos, par.MoveTime).SetEase(Ease.InOutSine);                            // 移動
        transform.DORotate(new Vector3(0, 0, 360), par.MoveTime, RotateMode.FastBeyond360);     // 回転
    }
}
