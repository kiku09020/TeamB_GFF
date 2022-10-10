using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ジャンプの矢印
public class JumpArrow : MonoBehaviour
{
    /* タップ座標 */
    Vector2 nowTapPos;              // 現在のタップ座標
    Vector2 tapDownPos;             // タップした瞬間の座標

    /* ワールド座標 */
    Vector2 nowTapPos_World;        // 現在
    Vector2 tapDownPos_World;       // タップした瞬間

    /* 他 */
    Vector2 tapVector;              // 加えるベクトル

    /* プロパティ */
    public Vector2 TapVector { get => tapVector; }

    /* コンポーネント取得用 */
    CatParameter par;
    

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        /* コンポーネント取得 */
        par = charaObj.GetComponent<CatParameter>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void Update()
    {
        Tapping();
        TapDown();
        TapUp();
    }

//-------------------------------------------------------------------
    // 入力中の処理
    void Tapping()
    {
        // 入力中
        if (Input.GetMouseButton(0)) {
            nowTapPos = Input.mousePosition;        // 現在のマウス位置

            // ワールド座標に変換
            nowTapPos_World = Camera.main.ScreenToWorldPoint(nowTapPos);
            tapDownPos_World = Camera.main.ScreenToWorldPoint(tapDownPos);

            // ベクトル計算
            tapVector = tapDownPos - nowTapPos;
            Debug.DrawLine(tapDownPos_World, nowTapPos_World);      // ワールド座標に描画
        }
    }

    // タップした瞬間
    void TapDown()
    {
        // 押した瞬間
        if (Input.GetMouseButtonDown(0)) {
            tapDownPos = Input.mousePosition;       // 押した瞬間のタップ座標取得
        }
    }

    // タップ離した瞬間
    void TapUp()
    {
        if (Input.GetMouseButtonUp(0)) {
            tapDownPos = Vector2.zero;              // 押した瞬間の座標リセット

            if (tapVector.y < par.MinJumpY) {
                tapVector.y = par.MinJumpY;
            }

            print(tapVector);
        }
    }
}
