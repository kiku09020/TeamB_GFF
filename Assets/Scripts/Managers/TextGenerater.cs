using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* テキストの生成 */
public class TextGenerater : MonoBehaviour
{
    /* 値 */
    [SerializeField] float destTime;            // テキスト削除までの時間

    public enum TextType {
        score,
        time,
    }

    /* フラグ */


    /* テキスト */
    [SerializeField] GameObject scoreText;      // 追加されるスコアのテキスト
    [SerializeField] GameObject timeText;       // 追加されるタイムのテキスト

    /* プロパティ */


    /* コンポーネント取得用 */
    CanvasManager canvas;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        canvas = GetComponent<CanvasManager>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    // スコアテキストの生成
    public void GenelateText(TextType type,float value,Vector2 pos)
    {
        GameObject text = null;
        Vector2 scrnPos = Camera.main.WorldToScreenPoint(pos);      // ワールドからスクリーンに変換
        Transform parent = canvas.GameCanvas.transform; ;           // 親キャンバス

        // 生成するテキスト指定
        switch (type) {
            case TextType.score:
                scoreText.GetComponent<Text>().text = "+" + value.ToString();
                text = scoreText;   break;

            case TextType.time:
                timeText.GetComponent<Text>().text = "+" + value.ToString()+"s\n";
                text = timeText;    break;
        }

        GameObject inst = Instantiate(text, scrnPos, Quaternion.identity, parent);      // 生成
        Destroy(inst, destTime);                                                        // 削除
    }
}
