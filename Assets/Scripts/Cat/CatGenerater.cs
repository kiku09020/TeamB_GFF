using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerater : MonoBehaviour
{
    /* 値 */
    [Header("オブジェクト")]
    [SerializeField] int catCnt;            // 出現させる猫の数
    [SerializeField] GameObject catPref;    // プレハブ
    GameObject catInst;                     // インスタンス

    CatParameter par;

    /* コンポーネント取得用 */

    //-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");

        /* コンポーネント取得 */
        par = gmObj.GetComponent<CatParameter>();

        /* 初期化 */
        Generate();
    }

//-------------------------------------------------------------------
    public void Generate()
    {
        catInst = Instantiate(catPref, par.GenPos, Quaternion.identity);
    }
}
