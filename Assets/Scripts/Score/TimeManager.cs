using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    /* 値 */
    [SerializeField] float startTime;           // 開始時の時間
    float timer;                                // タイマー

    [SerializeField] float transitionTime;      // リザルト画面までの遷移時間

    /* フラグ */
    bool onceFlg;
    bool timeOnceFlg;

    /* プロパティ */
    public float Timer { get => timer; set => timer = value; }


    /* コンポーネント取得用 */
    GameObject timerTextObj;
    Text timerText;
    CanvasManager canvas;
    UIAnimation anim;

    GameManager gm;
    AudioManager aud;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject uiObj = transform.Find("UIManager").gameObject;
        GameObject audObj = transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        gm = GetComponent<GameManager>();
        aud = audObj.GetComponent<AudioManager>();
        anim = uiObj.GetComponent<UIAnimation>();

        canvas = uiObj.GetComponent<CanvasManager>();
        timerTextObj= canvas.GameCanvas.transform.Find("TimerText_Time").gameObject;
        timerText = timerTextObj.GetComponent<Text>();

        /* 初期化 */
        // 開始時の時間に設定
        timer = startTime;
    }

    void FixedUpdate()
    {
        CountDown();

        DispTimer();

        // 結果遷移
        if(gm.isTimeUp){
            TransitionToResult();
		}
    }

//-------------------------------------------------------------------
    // カウントダウン
    void CountDown()
    {
        // カウントダウン
        if (timer > 1){
            timer -= Time.deltaTime;
        }

        // タイマー終了
        else {
            gm.isTimeUp = true;
		}
	}

    // タイマー表示
	void DispTimer()
	{
        // カウントダウン
        if (timer > 1) {
            int timerInt = (int)timer;
            timerText.text = timerInt.ToString();

            if (timer <= 11 && !timeOnceFlg)
            {
                timeOnceFlg = true;
                anim.TimerIn(timerTextObj,timerText);
            }

            else
            {
                timeOnceFlg = false;
                anim.TimerOut(timerTextObj,timerText);
            }
        }

        // 終了
        else{
            timerText.text = "終了!";
		}
	}

    // 結果画面への遷移
    void TransitionToResult()
    {
        if(!onceFlg){
            onceFlg = true;
            StartCoroutine(Wait());
		}
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(transitionTime);
        gm.isResult = true;
        gm.isTimeUp = false;
        aud.PauseAudio(true);
    }

    //-------------------------------------------------------------------
    // タイム増加
    public void AddTime(float time)
    {
        timer += time;
	}
}
