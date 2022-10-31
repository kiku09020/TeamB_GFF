using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ジャンプの矢印
public class JumpArrow : MonoBehaviour
{
    /* タップ座標 */
    Vector2 tappingPos;              // 現在のタップ座標
    Vector2 tapDownPos;             // タップした瞬間の座標

    /* ワールド座標 */
    Vector2 tappingPos_World;        // 現在
    Vector2 tapDownPos_World;       // タップした瞬間

    /* 他 */
    Vector3 tapVector;              // 加えるベクトル

    /* プロパティ */
    public Vector2 TapVector { get => tapVector; }

    /* コンポーネント取得用 */
    LineRenderer line;

    GameManager gm;
    CatParameter par;
    Cat cat;
    

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        GameObject catObj = transform.parent.gameObject;

        /* コンポーネント取得 */
        line = GetComponent<LineRenderer>();

        gm = gmObj.GetComponent<GameManager>();

        par = charaObj.GetComponent<CatParameter>();
        cat = catObj.GetComponent<Cat>();
        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void Update()
    {
        if (!gm.isTimeUp) {
            TapDown();

            if (cat.state == Cat.State.Pulled || cat.state == Cat.State.Ready) {
                Tapping();
                TapUp();
            }
        }

        else{
            line.enabled = false;
            tapVector = Vector2.zero;
		}
    }

//-------------------------------------------------------------------


    // タップした瞬間
    void TapDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            tapDownPos = Input.mousePosition;                                   // タップ座標取得
            tapDownPos_World = Camera.main.ScreenToWorldPoint(tapDownPos);      // ワールド座標に変換

            // 矢印
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position);
        }
    }

    // 入力中の処理
    void Tapping()
    {
        // 入力中
        if (Input.GetMouseButton(0)) {
            // 中央の猫を引っ張り状態にする
            cat.state = Cat.State.Pulled;

            tappingPos = Input.mousePosition;                                   // 現在のマウス位置
            tappingPos_World = Camera.main.ScreenToWorldPoint(tappingPos);      // ワールド座標に変換

            tapVector = tapDownPos - tappingPos;                                // ベクトル計算
            Vector3 tapVector_World = tapDownPos_World - tappingPos_World;

            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + tapVector_World);

            Debug.DrawLine(tapDownPos_World, tappingPos_World);                 // ワールド座標に描画

        }
    }

    // タップ離した瞬間
    void TapUp()
    {
        if (Input.GetMouseButtonUp(0)) {
            line.enabled = false;

            // 小さすぎたら、最小のジャンプ力分飛ぶ
            if (tapVector.y < par.MinJumpY) {
                tapVector.y = par.MinJumpY;
            }
        }
    }
}
