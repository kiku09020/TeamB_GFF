using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 猫の移動 */
public class Cat_Moving : MonoBehaviour
{
    /* 値 */


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
        if (cat.state == Cat.State.OutScrn && !par.existMainCat) {
            transform.position = Vector2.MoveTowards(cat.Pos, par.IdlePos,par.MoveSpd);     // 移動(仮)

            // 目的地についたとき
            if (cat.Pos.x == par.IdlePos.x) {
                cat.state = Cat.State.Wait;         // 状態遷移
                gen.Generate();                     // 生成
            }
        }

        // 待ち猫
        else if (cat.state == Cat.State.Wait && !par.existMainCat) {
            transform.position = Vector2.MoveTowards(cat.Pos, par.JumpPos, par.MoveSpd);

            // ついたとき
            if (cat.Pos.x == par.JumpPos.x) {
                cat.state = Cat.State.Ready;
                par.existMainCat = true;
            }
        }
    }

//-------------------------------------------------------------------
}
