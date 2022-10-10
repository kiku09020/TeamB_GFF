using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* HP(猫ゲージ)の処理。(GameUICanvas/HP_Back) */
public class HPManager : MonoBehaviour
{
    /* 値 */
    [SerializeField,Tooltip("最大HP")] int hpMax;
    int hpNow;      // 現在のHP

    [SerializeField] GameObject hpPref;         // HPの画像のプレハブ
    [SerializeField] float imgSpace;            // 画像同士の間隔

    /* コンポーネント取得用 */
    RectTransform rect;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        rect = GetComponent<RectTransform>();

        /* 初期化 */
        hpNow = hpMax;      // 現在のHPを最大HPにする
        GenerateHPImage();
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    // 体力に応じた、HP画像の生成
    public void GenerateHPImage()
    {
        // 一旦削除
        for(int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }

        // 生成
        for(int i = 0; i < hpNow; i++) {
            float space = (imgSpace * (i - 1));
            float y = transform.position.y - rect.rect.height / 2;
            Vector3 spaceVec = new Vector3(space, y);
            Vector3 pos = transform.position - spaceVec;

            Instantiate(hpPref,pos,Quaternion.identity,transform);
        }
    }
}
