using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    /* 値 */
    [SerializeField] float startTime;           // 開始時の時間
    float timer;                                // タイマー

    /* フラグ */


    /* プロパティ */


    /* コンポーネント取得用 */
    Text timerText;
    CanvasManager canvas;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject uiObj = transform.Find("UIManager").gameObject;
        GameObject canvasObj= canvas.GameCanvas.transform.Find("TimerText_Time").gameObject;

        /* コンポーネント取得 */
        canvas = uiObj.GetComponent<CanvasManager>();

        /* 初期化 */
        timerText = canvasObj.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        CountDown();

        DispTimer();
    }

//-------------------------------------------------------------------
    // カウントダウン
    void CountDown()
    {
        timer -= Time.deltaTime;
	}

    // タイマー表示
	void DispTimer()
	{
        timerText.text = timer.ToString("F8");
	}
}
