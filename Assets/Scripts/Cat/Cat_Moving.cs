using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        /* コンポーネント取得 */
        cat = GetComponent<Cat>();
        gen = gmObj.GetComponent<CatGenerater>();
        par = gmObj.GetComponent<CatParameter>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        // 範囲外の猫
        if (cat.state == Cat.State.OutOfScrn) {
            if (!par.existMainCat) {
                transform.position = Vector2.MoveTowards(cat.Pos, par.IdlePos,par.MoveSpd);     // 移動(仮)
            }

            // 目的地についたとき
            if (cat.Pos.x == par.IdlePos.x) {
                cat.state = Cat.State.Wait;         // 状態遷移
                gen.Generate();                     // 生成
            }
        }

        // 待ち猫
        else if (cat.state == Cat.State.Wait && !par.existMainCat) {
            transform.position = Vector2.MoveTowards(cat.Pos, par.JumpPos, par.MoveSpd);

            if (cat.Pos.x == par.JumpPos.x) {
                cat.state = Cat.State.Ready;
                par.existMainCat = true;
            }
        }
    }

//-------------------------------------------------------------------
}
