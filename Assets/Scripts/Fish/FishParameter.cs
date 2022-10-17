using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishParameter : MonoBehaviour
{
    /* 値 */
    [SerializeField,Tooltip("最初の落下速度")]      float fallSpdStart;
    [SerializeField,Tooltip("削除するY座標")] float delY;

    /* プロパティ */
    public float FallSpdStart   { get => fallSpdStart; }
    public float DelY           { get => delY; }

    /* コンポーネント取得用 */



//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */ 


        /* コンポーネント取得 */     


        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------

}
