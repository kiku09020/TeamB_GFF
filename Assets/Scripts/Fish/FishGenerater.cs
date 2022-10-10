using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerater : MonoBehaviour
{
    /* 値 */
    [Header("生成インターバル")]
    [SerializeField, Tooltip("開始時の生成インターバル")]   float intervalStart;
    [SerializeField, Tooltip("最小の生成インターバル")]     float intervalMin;
    [SerializeField, Tooltip("生成インターバルを減らす量")] float intervalDecVal;
    float intervalNow;      // 現在の生成インターバル
    float timer;

    [Header("生成位置")]
    [SerializeField,Tooltip("生成範囲(X)")] float genXRange;
    [SerializeField,Tooltip("生成するY座標")] float genPosY;
    float genPosX;      // 生成するX座標
    Vector2 genPos;     // (genPosX, genPosY)

    [Header("生成物")]
    [SerializeField,Tooltip("生成するもの")] List<GameObject> genPrefs;
    [SerializeField, Tooltip("落下速度")] float fallSpd;

    /* コンポーネント取得用 */



//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */


        /* 初期化 */
        intervalNow = intervalStart;

        print(intervalNow);
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        Generate();
    }

//-------------------------------------------------------------------

    void Generate()
    {
        if (timer >= intervalNow) {
            // 生成位置
            genPosX = Random.Range(-genXRange, genXRange);
            genPos = new Vector2(genPosX, genPosY);

            // 生成するものの番号
            int genObjNum = Random.Range(0, genPrefs.Count);

            // 生成
            Instantiate(genPrefs[genObjNum], genPos, Quaternion.identity);

            timer = 0;
        }

        // タイマー加算
        timer += Time.deltaTime;
    }
}
