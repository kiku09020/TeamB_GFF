using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cat_Animation : MonoBehaviour
{
    /* 値 */


    /* フラグ */

    /* Tween */

    /* コンポーネント取得用 */

//-------------------------------------------------------------------
    // 移動
    public void Move(Vector2 pos,float duration)
    {
       transform.DOMove(pos, duration).SetEase(Ease.InOutSine);
    }

    // 移動時の回転
    public void MovingRotate(float duration)
    {
        transform.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360);     // 回転
    }

    // アニメーション停止
    public void StopAnimations()
    {
        transform.DOKill();
    }
}
