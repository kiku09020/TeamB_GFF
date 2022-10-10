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

    /* コンポーネント取得用 */
    CatParameter par;

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        /* コンポーネント取得 */
        par = charaObj.GetComponent<CatParameter>();

        /* 初期化 */
        Generate();
    }

//-------------------------------------------------------------------
    public void Generate()
    {
        Instantiate(catPref, par.GenPos, Quaternion.identity);
    }
}
