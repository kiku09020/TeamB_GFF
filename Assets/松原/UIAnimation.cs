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
}
