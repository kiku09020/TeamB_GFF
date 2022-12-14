using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    /* 値 */
    [SerializeField] int comboAddLimitCnt;         // 加算する限界コンボ数

    int comboCnt;

    int combodScore;
    float combodTime;

    /* プロパティ */
    public int CombodScore { get => combodScore; }
    public float CombodTime { get => combodTime; }

    /* コンポーネント取得用 */
    ScoreManager score;
    TimeManager time;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");

        /* コンポーネント取得 */
        score = gmObj.GetComponent<ScoreManager>();
        time = gmObj.GetComponent<TimeManager>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    // スコアのコンボ処理
    void ComboScore(int score)
    {
        // スコア加算コンボ数の限界以下のみ
        if (comboCnt < comboAddLimitCnt) {
            combodScore = (int)( score * Mathf.Pow(2, comboCnt - 1) );
        }
        else{
            combodScore = (int)( score * Mathf.Pow(2, comboAddLimitCnt - 1) );
        }

        this.score.AddScore(combodScore);
    }

    // タイムのコンボ処理
    void ComboTime(float time)
    {
        combodTime = time * comboCnt;
        this.time.AddTime(combodTime);
    }

    // コンボ処理本体
    public void Combo(int score,float time)
    {
        comboCnt++;             // コンボ数追加

        ComboScore(score);      // スコアのコンボ
        ComboTime(time);        // タイムのコンボ
    }

    // コンボリセット
    public void ResetCombo()
    {
        comboCnt = 0;
        combodScore = 0;
        combodTime = 0;
    }
}
