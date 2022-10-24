using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishParameter : MonoBehaviour
{
    /* 値 */
    [SerializeField, Tooltip("最初の落下速度")]     float fallSpdStart;
    [SerializeField, Tooltip("落下速度を増やす値")] float fallSpdIncVal;
    [SerializeField, Tooltip("最大落下速度")]       float fallSpdMax;
    float fallSpdNow;

    [SerializeField,Tooltip("削除するY座標")] float delY;

    /* プロパティ */
    public float FallSpd   { get => fallSpdNow; }
    public float DelY           { get => delY; }

    /* コンポーネント取得用 */



//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */


        /* 初期化 */
        fallSpdNow = fallSpdStart;
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    public void ChangeFallSpd()
	{
        if (fallSpdNow < fallSpdMax) {
            fallSpdNow += fallSpdIncVal;

            print("FallSpd = " + fallSpdNow);
        }
	}
}
