using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /* 値 */
    int nowScore;                           // 現在のスコア

    // 目標スコア
    int targScore;                          // 目標スコア
    int targScorePrev;                      // 一つ前の目標スコア
    int targScoreDiff;                      // 前の目標スコアと現在の目標スコアの差
    int spdUpCnt;                           // 速度アップした回数
    [SerializeField] int spdUpCnt_Thrshld;  // タイム減らす速度を上昇の閾値
    [SerializeField] int incThrshld;        // 等速的・加速度的増加の閾値
    [SerializeField] int targScoreVal;      // 目標スコア～次の目標スコアの間の値

    // 表示スコア
    int dispScore;                          // 表示用スコア
    int dispScoreVal;                       // 表示用スコアを増減させる値

    /* フラグ */


    /* プロパティ */
    public int NowScore { get => nowScore; }

    /* UI */
    GameObject scoreTextObj;

    Text dispScoreText;     // 表示用スコアのテキスト
    Image scoreImage;       // 目標スコアと現在スコアの比較用画像

    /* コンポーネント取得用 */
    GameManager gm;
    CanvasManager canvas;
    TextGenerater txtGen;
    UIAnimation anim;

    FishGenerater fishGen;
    SaveData data;

    AudioManager aud;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        gm = GetComponent<GameManager>();
        canvas = uiObj.GetComponent<CanvasManager>();
        txtGen = uiObj.GetComponent<TextGenerater>();
        anim = uiObj.GetComponent<UIAnimation>();
        fishGen = charaObj.GetComponent<FishGenerater>();
        data = GetComponent<DataManager>().data;
        aud = audObj.GetComponent<AudioManager>();

        /* 初期化 */
        GameObject scoreObj = canvas.GameCanvas.transform.Find("Back").gameObject;
        scoreTextObj = scoreObj.transform.Find("TotalScoreText").gameObject;
        GameObject scoreImgObj = scoreObj.transform.Find("Image").gameObject;

        dispScoreText = scoreTextObj.GetComponent<Text>();
        scoreImage = scoreImgObj.GetComponent<Image>();

        targScore += targScoreVal;      // 目標スコア初期化
        targScoreDiff = targScoreVal;
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        DispScore();

        if(gm.isTimeUp){
            if(data.highScore<nowScore){
                data.highScore = nowScore;
			}
		}
    }

    //-------------------------------------------------------------------
    // スコア表示
    void DispScore()
    {
        if (dispScore < nowScore) {         // 加算
            dispScore += dispScoreVal;
        }
        else {                              // そろえる
            dispScore = nowScore;
        }

        dispScoreText.text = "Score:" + dispScore.ToString("D8");

        scoreImage.fillAmount = (float)(dispScore - targScorePrev) / targScoreDiff;
    }

    // スコア加算
    public void AddScore(int score)
	{
        nowScore += score;              // スコア加算
        dispScoreVal = score / 10;      // 表示スコアの増加量指定

        CheckTargetScore();             // 目標スコア達成したかどうか

        anim.TotalScore(scoreTextObj);
	}

    // 目標スコアに到達したかどうかを確認する
    void CheckTargetScore()
    {
        // 目標スコアに到達したとき
        if (targScore <= nowScore) {
            spdUpCnt++;                         // 速度アップ数増やす
            targScorePrev = targScore;          // 現在の目標スコアを、前の目標スコアとして保存

            // 等速的増加
            if (targScore < incThrshld) {
                targScore += targScoreVal;      // 次の目標スコアを指定
            }

            // 加速度的増加
            else {
                int incVal = targScoreVal * (int)Mathf.Pow(2, spdUpCnt - (incThrshld / 1000));
                targScore += incVal;
                print(targScore);
            }

            targScoreDiff = targScore - targScorePrev;      // 現在と前の目標スコアの差

            fishGen.ChangeSpd();                // 速度変更
            txtGen.GenSpdupText();              // 速度アップテキスト生成

            aud.PlaySE(AudioEnum.AudSrc.SE_UI, (int)AudioEnum.SE_UI.spd);
        }
    }
}
