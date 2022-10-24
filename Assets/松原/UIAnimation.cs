using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonDown()
    {
        transform.DOScale(2, 0.1f);
    }

    public void ButtonUp()
    {
        transform.DOScale(1, 0.1f);
    }

    public void TotalScore(GameObject obj)
    {
        obj.transform.DOScale(1.5f, 0.1f);
        obj.transform.DOScale(1, 0.5f);
    }

    public void SpeedUp(GameObject obj)
    {
        var sequence = DOTween.Sequence();

        var centerPosX = Camera.main.WorldToScreenPoint(Vector2.zero).x;      // 中央のスクリーン座標
        var leftPosX = Camera.main.WorldToScreenPoint(new Vector2(-20, 0)).x; // 左端のスクリーン座標

        sequence.Append(obj.transform.DOMoveX(centerPosX, 0.75f).SetEase(Ease.OutQuart));
        sequence.Append(obj.transform.DOMoveX(leftPosX, 0.5f).SetEase(Ease.InQuart).SetDelay(0.25f));
    }

    public void ScoreUp(GameObject obj,Vector2 scrnPos)
    {
        var sequence = DOTween.Sequence();

        var posY = scrnPos.y + 100;

        sequence.Append(obj.transform.DOMoveY(posY, 0.5f).SetEase(Ease.InCubic));
        sequence.Append(obj.transform.DOScale(0, 0.5f));
    }
}
