using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("ジャンプ")]
    [SerializeField,Tooltip("最大ジャンプ力")] float maxJumpForce;

    Vector2 nowTapPos;              // 現在のタップ座標
    Vector2 tapDownPos;             // タップした座標

    Vector2 tapVector;

    /* コンポーネント取得用 */
    Collider2D col;
    Rigidbody2D rb;

    AudioManager aud;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        aud = audObj.GetComponent<AudioManager>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void Update()
    {
        
    }

//-------------------------------------------------------------------
    // プレイヤー飛ばす処理
    void Jump()
    {
        // 入力中
        if (Input.GetMouseButton(0)){
            nowTapPos = Input.mousePosition;        // 現在のマウス位置

            // ワールド座標に変換
            var nowTapPos_World  = Camera.main.ScreenToWorldPoint(nowTapPos);
            var tapDownPos_World = Camera.main.ScreenToWorldPoint(tapDownPos);

            tapVector = tapDownPos - nowTapPos;  // ベクトル計算
            Debug.DrawLine(tapDownPos_World, nowTapPos_World);
        }

        // 押した瞬間
        if(Input.GetMouseButtonDown(0)){
            tapDownPos = Input.mousePosition;       // 押した瞬間のタップ座標取得
		}

        // 離した瞬間
        if(Input.GetMouseButtonUp(0)){
            tapDownPos = Vector2.zero;              // 押した瞬間の座標リセット

            aud.PlaySE(AudioEnum.Enm_AudSrc.SE_Chara, (int)AudioEnum.Enm_SE_Chara.jump);
            rb.AddForce(tapVector);                 // ぶっ飛ばす
		}
	}

    // 床に触れてるとき
	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag=="Stage"){
            Jump();

            print("col");
		}
	}
}
