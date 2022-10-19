using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /* 値 */
    int     nowScore;           // 現在のスコア
    int   dispScore;          // 表示用スコア

    int   dispScoreVal;       // 表示用スコアを増減させる値

    /* フラグ */
    bool    isScoreAdding;      // スコア加算中か

    /* プロパティ */
    public int NowScore { get => nowScore; }

    /* テキスト */
    Text dispScoreText;

    /* コンポーネント取得用 */
    CanvasManager canvas;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;


        /* コンポーネント取得 */
        canvas = uiObj.GetComponent<CanvasManager>();

        /* 初期化 */
        GameObject scoreTextObj = canvas.GameCanvas.transform.Find("TotalScoreText").gameObject;
        dispScoreText = scoreTextObj.GetComponent<Text>();
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        DispScore();
    }

//-------------------------------------------------------------------
    // スコア表示
    void DispScore()
	{
		if (isScoreAdding) {
			if (dispScore < nowScore) {         // 加算
                dispScore += dispScoreVal;
                dispScoreText.text = "Score:" + dispScore.ToString("D8");
			}
			else {                              // そろえる
                dispScore = nowScore;
                isScoreAdding = false;
			}
		}
	}

    // スコア加算
    public void AddScore(int score)
	{
        isScoreAdding = true;           // 表示スコア加算フラグ

        nowScore += score;              // スコア加算
        dispScoreVal = score / 10;      // 表示スコアの増加量指定
	}
}
