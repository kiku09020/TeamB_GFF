using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* 値 */
    [HideInInspector] public bool gameOver;     // ゲームオーバー
    [HideInInspector] public bool isPause;      // ポーズ中か

    /* コンポーネント取得用 */


    /* プロパティ */
    CanvasManager cnvs;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        cnvs = transform.Find("UIManager").GetComponent<CanvasManager>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        if (gameOver) {
            GameOver();
        }
    }

//-------------------------------------------------------------------
    // ゲームオーバー時の処理
    void GameOver()
    {
        cnvs.GameOver();

        Time.timeScale = 0;
    }
}
