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
    float nowGenInterval;      // 現在の生成インターバル
    float timer;

    [Header("生成位置")]
    [SerializeField,Tooltip("生成範囲(X)")] float genXRange;
    [SerializeField,Tooltip("生成するY座標")] float genPosY;
    float genPosX;      // 生成するX座標
    Vector2 genPos;     // (genPosX, genPosY)

    [Header("生成物")]
    [SerializeField,Tooltip("生成するもの")] List<GameObject> genPrefs;

    [Header("生成確率")]
    [SerializeField] float genProb_Fugu;
    [SerializeField] float genProb_Rare;
    

    /* プロパティ */

    /* コンポーネント取得用 */


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        

        /* 初期化 */
        nowGenInterval = intervalStart;

        SetGenProb();
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        Generate();
    }

//-------------------------------------------------------------------
    // 魚の生成
    void Generate()
    {
        if (timer >= nowGenInterval) {
            // 生成位置
            genPosX = Random.Range(-genXRange, genXRange);
            genPos = new Vector2(genPosX, genPosY);

            // 確率に応じて生成
            Instantiate(genPrefs[(int)SetGenProb()], genPos, Quaternion.identity);

            timer = 0;
        }

        // タイマー加算
        timer += Time.deltaTime;
    }

    // 生成確率の指定
    Fish.Type SetGenProb()
    {
        Fish.Type genFishType;        // 生成する魚のタイプ

        float random = Random.value;            // 確率

        // レア魚
        if (random <= genProb_Rare) {
            genFishType = Fish.Type.rare;
        }

        // フグ
        else if (random + genProb_Rare <= genProb_Fugu) {
            genFishType = Fish.Type.fugu;
        }

        else {
            genFishType = Fish.Type.normal;
        }

        return genFishType;
    }

    // 落下速度の変更
    void ChangeFallSpd()
    {
        
	}
}
