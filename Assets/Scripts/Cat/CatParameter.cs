using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 猫のパラメーター。(GameManager) */
public class CatParameter : MonoBehaviour
{
    /* 値 */
    [Header("位置")]
    [SerializeField, Tooltip("猫のY座標")]     float catPosY;
    [SerializeField, Tooltip("生成X座標")]     float genPosX;
    [SerializeField, Tooltip("待機X座標")]     float idlePosX;
    [SerializeField, Tooltip("ジャンプX座標")] float jumpPosX;

    [Header("画面外")]
    [SerializeField, Tooltip("画面外(下)")]    float outScrnDown;
    [SerializeField, Tooltip("画面外(上)")]    float outScrnUp;

    [Header("速度")]
    [SerializeField, Tooltip("移動時間")] float moveTime;
    [SerializeField, Tooltip("最小ジャンプ力(Y)")] float jumpForceMin;

    /* フラグ */
    public bool existMainCat;      // 準備中の猫がいるかどうが
    
    /* プロパティ */
    public Vector2 GenPos  { get => new Vector2(genPosX, catPosY); }        // 生成位置
    public Vector2 IdlePos { get => new Vector2(idlePosX, catPosY); }       // 待機位置
    public Vector2 JumpPos { get => new Vector2(jumpPosX, catPosY); }       // ジャンプ位置

    public float MoveTime{ get => moveTime; }

    public float MinJumpY { get => jumpForceMin; }

    /* コンポーネント取得用 */


//-------------------------------------------------------------------
    // 画面外判定
    public bool CheckOutScrn(float nowPosY)
    {
        // 画面外出たとき
        if (nowPosY < outScrnDown || nowPosY > outScrnUp) {
            return true;
        }

        return false;
    }
}
