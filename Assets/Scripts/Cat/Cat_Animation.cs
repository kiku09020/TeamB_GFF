using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cat_Animation : MonoBehaviour
{
    /* 値 */


    /* フラグ */
    bool shakeOnce;

    /* Tween */
    Tween moveTween;
    Tween rotateTween;
    Tween shakeTween;

    /* コンポーネント取得用 */

//-------------------------------------------------------------------
    // 移動
    public void Move(Vector2 pos,float duration)
    {
       moveTween = transform.DOMove(pos, duration).SetEase(Ease.InOutSine);
    }

    // 移動時の回転
    public void MovingRotate(float duration)
    {
        rotateTween = transform.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360);     // 回転
    }

    // ジャンプ前の揺れ
    public void Shake()
    {
        if (!shakeOnce) {
            shakeOnce = true;
            shakeTween = transform.DOPunchPosition(Vector2.right * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    // 揺れ停止
    public void StopShaking()
    {
        if (shakeOnce) {
            shakeOnce = false;
            shakeTween.Kill();
        }
    }

    // アニメーション停止
    public void StopAnimations()
    {
        transform.DOKill();
    }
}
