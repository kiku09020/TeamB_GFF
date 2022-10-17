using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fugu : Fish
{
    /* 値 */


    /* コンポーネント取得用 */

    //-------------------------------------------------------------------
    // フグ：捕食されたら、ダメージ与える
    protected override void Eaten()
    {
        PlayEatenSound(AudioEnum.SE_Fish.damage);

        Destroy(gameObject);
    }

    //-------------------------------------------------------------------

}
