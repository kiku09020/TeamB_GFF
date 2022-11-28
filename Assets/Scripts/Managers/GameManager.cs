using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /* 値 */


    /* フラグ */
    [HideInInspector] public bool isStarting;   // スタート時
    [HideInInspector] public bool isTimeUp;     // タイムアップ
    [HideInInspector] public bool isPause;      // ポーズ中か
    [HideInInspector] public bool isResult;     // リザルト画面中か

    bool timeupOnce;
    bool rsltOnce;

    /* コンポーネント取得用 */
    CanvasManager cnvs;
    AudioManager aud;

    ScoreManager score;
    SaveData data;

    Text scoreText;
    Text highScoreText;

    /* プロパティ */

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */

        /* コンポーネント取得 */
        cnvs = transform.Find("UIManager").GetComponent<CanvasManager>();
        aud = transform.Find("AudioManager").GetComponent<AudioManager>();

        score = GetComponent<ScoreManager>();
        data = GetComponent<DataManager>().data;

        /* 初期化 */
        Transform resultCnvs = cnvs.ResultCanvas.transform;
        scoreText = resultCnvs.Find("TextScore").GetComponent<Text>();
        highScoreText = resultCnvs.Find("TextHighScore").GetComponent<Text>();

        isStarting = true;
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        if (isTimeUp && !timeupOnce){
            cnvs.TimeUp();
            aud.PlaySE(AudioEnum.AudSrc.SE_UI, (int) AudioEnum.SE_UI.hue);

            timeupOnce = true;
		}

        if (isResult && !rsltOnce){
            scoreText.text = score.NowScore.ToString();
            highScoreText.text = data.highScore.ToString();
            cnvs.TransitionResult();

            rsltOnce = true;        // 一度のみ
		}
    }

//-------------------------------------------------------------------
}
