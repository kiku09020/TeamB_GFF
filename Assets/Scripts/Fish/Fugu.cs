using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fugu : Fish
{
    /* 値 */


    /* コンポーネント取得用 */
    HPManager hp;


    //-------------------------------------------------------------------
    protected override void Start()
    {
        base.Start();

        GameObject hpObj = GameObject.Find("HP_Back");
        hp = hpObj.GetComponent<HPManager>();
    }


    // フグ：捕食されたら、ダメージ与える
    protected override void Eaten()
    {
        PlayEatenSound(AudioEnum.SE_Fish.damage);

        hp.Damage();

        Destroy(gameObject);
    }

    //-------------------------------------------------------------------

}
