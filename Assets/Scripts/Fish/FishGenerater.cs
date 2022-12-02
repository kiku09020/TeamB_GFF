using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerater : MonoBehaviour
{
    /* 値 */
    [Header("生成インターバル")]
    [SerializeField, Tooltip("開始時の生成インターバル")]   float intervalStart;
    [SerializeField, Tooltip("最小の生成インターバル")]     float genIntvlMin;
    [SerializeField, Tooltip("生成インターバルを減らす量")] float intvlDecVal;
    float nowGenIntvl;      // 現在の生成インターバル
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
    [SerializeField] float genProb_Fugu_IncVal;
    [SerializeField] float genProb_Rare;

    // 生成するオブジェクトの親
    Transform parent;

    /* プロパティ */

    /* コンポーネント取得用 */
    GameManager gm;
    FishParameter par;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = transform.parent.gameObject;
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        parent = GameObject.Find("Fish").transform;

        /* コンポーネント取得 */
        gm = gmObj.GetComponent<GameManager>();
        par = charaObj.GetComponent<FishParameter>();

        /* 初期化 */
        nowGenIntvl = intervalStart;

        SetGenProb();
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        Generate();

        // タイムアップ時の処理
        if (gm.isTimeUp) {
            foreach (Transform child in parent) {
                Destroy(child.gameObject);
            }
        }
    }

//-------------------------------------------------------------------
    // 魚の生成
    void Generate()
    {
        if (timer >= nowGenIntvl && !gm.isTimeUp) {
            // 生成位置
            genPosX = Random.Range(-genXRange, genXRange);
            genPos = new Vector2(genPosX, genPosY);

            // 確率に応じて生成
            Instantiate(genPrefs[(int)SetGenProb()], genPos, Quaternion.identity, parent);

            timer = 0;
        }

        // タイマー加算
        timer += Time.deltaTime;
    }

    // 生成確率の指定
    Fish.FishType SetGenProb()
    {
        Fish.FishType genFishType;        // 生成する魚のタイプ

        float random = Random.value;            // 確率

        // レア魚
        if (random <= genProb_Rare) {
            genFishType = Fish.FishType.rare;
        }

        // フグ
        else if (random + genProb_Rare <= genProb_Fugu) {
            genFishType = Fish.FishType.fugu;
        }

        else {
            genFishType = Fish.FishType.normal;
        }

        return genFishType;
    }

    // 落下速度と生成インターバルの変更
    public void ChangeSpd()
    {
        if (nowGenIntvl > genIntvlMin) {
            nowGenIntvl -= intvlDecVal;
            genProb_Fugu += genProb_Fugu_IncVal;

            print("InterVal = "+ nowGenIntvl);
        }

        par.ChangeFallSpd();
	}
}
