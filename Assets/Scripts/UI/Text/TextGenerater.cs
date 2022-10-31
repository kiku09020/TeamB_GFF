using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* テキストの生成 */
public class TextGenerater : MonoBehaviour
{
    /* 値 */
    [Header("テキスト削除までの時間")]
    [SerializeField] float destTime_score;      // スコアテキスト
    [SerializeField] float destTime_spdUp;      // 速度アップテキスト
    [SerializeField] float destTime_fugu;       // ふぐテキスト

    // スコアテキストの種類
    public enum ScoreTextType
    {
        score,
        time,
    }

    /* フラグ */


    /* テキスト */
    [SerializeField] GameObject scoreText;      // 追加されるスコアのテキスト
    [SerializeField] GameObject timeText;       // 追加されるタイムのテキスト

    [SerializeField] GameObject spdUpText;      // 速度アップテキスト
    [SerializeField] GameObject cautText;

    Transform prnt_game;                        // GameUICanvas
    Transform prnt_ctrl;                        // ControllerCanvas

    /* プロパティ */


    /* コンポーネント取得用 */
    CanvasManager canvas;
    UIAnimation anim;


    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        canvas = GetComponent<CanvasManager>();
        anim = GetComponent<UIAnimation>();

        /* 初期化 */
        prnt_game = canvas.GameCanvas.transform;
        prnt_ctrl = canvas.CtrlCanvas.transform;
    }

    //-------------------------------------------------------------------
    string TextSetup(float value)
    {
        // 符号判定
        string signStr = null;
        if (Mathf.Sign(value) == 1) {
            signStr = "+";
        }
        else {
            signStr = "-";
        }

        // 生成するテキスト指定
        string textStr = signStr + Mathf.Abs(value).ToString();
        return textStr;
    }

    void InstantiateText(GameObject obj,Vector2 pos)
    {
        Vector2 scrnPos = Camera.main.WorldToScreenPoint(pos);      // ワールドからスクリーンに変換

        GameObject inst = Instantiate(obj, scrnPos, Quaternion.identity, prnt_game);    // 生成
        anim.ScoreUp(inst, scrnPos);                                                    // アニメーション
        Destroy(inst, destTime_score);                                                        // 削除
    }

    // スコアテキストの生成
    public void GenScoreText(float value, Vector2 pos)
    {
        scoreText.GetComponent<Text>().text = TextSetup(value);     // テキスト設定
        InstantiateText(scoreText, pos);
    }

    // タイムテキストの生成
    public void GenTimeText(float value, Vector2 pos)
    {
        timeText.GetComponent<Text>().text = TextSetup(value)+"s";

        pos += new Vector2(0, 1f);
        InstantiateText(timeText, pos);
    }

    // 速度アップテキストの生成
    public void GenSpdupText()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(new Vector2(15, 0));

        GameObject inst = Instantiate(spdUpText, pos, Quaternion.identity, prnt_game);
        anim.SpeedUp(inst);
        Destroy(inst, destTime_spdUp);
    }

    // ふぐの警告テキストの生成
    public void GenFuguCaution(float posX)
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(new Vector2(posX, 15));

        GameObject inst = Instantiate(cautText, pos, Quaternion.identity, prnt_game);
        anim.FuguCaution(inst);
        Destroy(inst, destTime_fugu);
    }
}

    
