using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /* 値 */
    int     nowScore;       // 現在のスコア

    // 目標スコア
    int     targScore;      // 目標スコア
    [SerializeField] int targScoreVal;      // 目標スコア～次の目標スコアの間の値

    // 表示スコア
    int     dispScore;      // 表示用スコア
    int     dispScoreVal;   // 表示用スコアを増減させる値

    /* フラグ */
    bool    isScoreAdding;      // スコア加算中か
    bool    isAchievedTarg;     // 目標スコア達成したか

    /* プロパティ */
    public int NowScore { get => nowScore; }
    public bool IsAchievedTarg { get => isAchievedTarg; set => isAchievedTarg = value; }

    /* テキスト */
    Text dispScoreText;     // 表示用スコアのテキスト

    /* コンポーネント取得用 */
    CanvasManager canvas;

    FishGenerater fishGen;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        /* コンポーネント取得 */
        canvas = uiObj.GetComponent<CanvasManager>();
        fishGen = charaObj.GetComponent<FishGenerater>();

        /* 初期化 */
        GameObject scoreTextObj = canvas.GameCanvas.transform.Find("TotalScoreText").gameObject;
        dispScoreText = scoreTextObj.GetComponent<Text>();

        targScore += targScoreVal;      // 目標スコア初期化
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
			}
			else {                              // そろえる
                dispScore = nowScore;
                isScoreAdding = false;
			}

            dispScoreText.text = "Score:" + dispScore.ToString("D8");
        }
	}

    // スコア加算
    public void AddScore(int score)
	{
        isScoreAdding = true;           // 表示スコア加算フラグ

        nowScore += score;              // スコア加算
        dispScoreVal = score / 10;      // 表示スコアの増加量指定

        CheckTargetScore();             // 目標スコア達成したかどうか
	}

    // 目標スコアに到達したかどうかを確認する
    void CheckTargetScore()
    {
        // 目標スコアに到達したとき
        if (targScore <= nowScore) {
            targScore += targScoreVal;      // 次の目標スコアを指定

            fishGen.ChangeSpd();
        }
    }
}
