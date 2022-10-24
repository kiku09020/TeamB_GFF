using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 猫の生成について (GameManager) */
public class CatGenerater : MonoBehaviour
{
    /* 値 */
    [Header("オブジェクト")]
    [SerializeField] int catCnt;            // 出現させる猫の数
    [SerializeField] GameObject catPref;    // プレハブ

    Transform parent;

    /* コンポーネント取得用 */
    CatParameter par;
    GameManager gm;

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        parent = GameObject.Find("Cats").transform;

        /* コンポーネント取得 */
        gm = gmObj.GetComponent<GameManager>();
        par = charaObj.GetComponent<CatParameter>();

        /* 初期化 */
        Generate();
    }

//-------------------------------------------------------------------
    public void Generate()
    {
        if (!gm.timeUp) {
            Instantiate(catPref, par.GenPos, Quaternion.identity, parent);
        }
    }
}
