using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_HitChecker : MonoBehaviour
{
    /* 値 */
    [SerializeField] float stopTime;

    /* フラグ */


    /* プロパティ */


    /* コンポーネント取得用 */
    TextGenerater txtGen;

    ComboManager combo;
    Cat cat;

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;

        /* コンポーネント取得 */
        txtGen = uiObj.GetComponent<TextGenerater>();

        cat = transform.parent.GetComponent<Cat>();
        combo = GetComponent<ComboManager>();

        /* 初期化 */

    }

    //-------------------------------------------------------------------
    void OnTriggerEnter2D(Collider2D col)
    {
        // ジャンプ中の猫にのみ適用
        if (col.gameObject.tag == "Fish" && cat.state == Cat.State.Jumped) {
            Fish fish = col.gameObject.GetComponent<Fish>();
            float score = 0;    float time = 0;

            // フグ以外はコンボする
            if (fish.Type == Fish.FishType.fugu) {
                combo.Combo(0, fish.AddedTime);

                score = fish.AddedScore;
                time = combo.CombodTime;
            }

            // フグはコンボしない
            else {
                combo.Combo(fish.AddedScore, fish.AddedTime);        // コンボ

                score = combo.CombodScore;
                time = combo.CombodTime;
            }

            // テキスト生成
            txtGen.GenScoreText(TextGenerater.ScoreTextType.score, score, col.gameObject.transform.position);
            txtGen.GenScoreText(TextGenerater.ScoreTextType.time, time, col.gameObject.transform.position);

            fish.Eaten();
            Destroy(col.gameObject,0.1f);
        }
    }
}
