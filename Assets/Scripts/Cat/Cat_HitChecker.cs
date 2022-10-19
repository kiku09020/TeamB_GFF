using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_HitChecker : MonoBehaviour
{
    /* 値 */


    /* フラグ */


    /* プロパティ */


    /* コンポーネント取得用 */
    TextGenerater txtGen;
    ScoreManager score;
    TimeManager time;

    Cat cat;

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;

        /* コンポーネント取得 */
        txtGen = uiObj.GetComponent<TextGenerater>();
        score = gmObj.GetComponent<ScoreManager>();
        time = gmObj.GetComponent<TimeManager>();

        cat = transform.parent.GetComponent<Cat>();

        /* 初期化 */

    }

    //-------------------------------------------------------------------
    void OnTriggerEnter2D(Collider2D col)
    {
        // ジャンプ中の猫にのみ適用
        if (col.gameObject.tag == "Fish" && cat.state == Cat.State.Jumped) {
            Fish fish = col.gameObject.GetComponent<Fish>();

            // スコア、タイム加算
            score.AddScore(fish.AddedScore);
            time.AddTime(fish.AddedTime);

            // テキスト生成
            txtGen.GenelateText(TextGenerater.TextType.score, fish.AddedScore, col.gameObject.transform.position);
            txtGen.GenelateText(TextGenerater.TextType.time, fish.AddedTime, col.gameObject.transform.position);

            fish.Eaten();
            Destroy(col.gameObject,0.1f);
        }
    }
}
