using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* 値 */
    [HideInInspector] public bool timeUp;     // タイムアップ
    [HideInInspector] public bool isPause;      // ポーズ中か

    /* コンポーネント取得用 */
    CanvasManager cnvs;
    AudioManager aud;


    /* プロパティ */

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */

        /* コンポーネント取得 */
        cnvs = transform.Find("UIManager").GetComponent<CanvasManager>();
        aud = transform.Find("AudioManager").GetComponent<AudioManager>();
        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {

    }

//-------------------------------------------------------------------
}
