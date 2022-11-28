using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    /* 値 */

    [SerializeField] List<GameObject> partPrfbs;

    // パーティクル一覧
    public enum PartNames {
        circle,
        get,
    }

    /* コンポーネント取得用 */

//-------------------------------------------------------------------
    // パーティクル生成(シンプル)
    public void PlayPart(PartNames name,Vector2 position)
    {
        GameObject prfb     = partPrfbs[(int)name];                                     // プレハブ
        GameObject inst     = Instantiate(prfb, position, Quaternion.identity);         // インスタンス
        ParticleSystem part = inst.GetComponent<ParticleSystem>();                      // パーティクル

        part.Play();    // 再生
    }

    // パーティクル生成(親オブジェクト指定)
    public void PlayPart(PartNames name, Vector2 position,Transform parent)
    {
        GameObject prfb     = partPrfbs[(int)name];                                    
        GameObject inst     = Instantiate(prfb, position, Quaternion.identity, parent);
        ParticleSystem part = inst.GetComponent<ParticleSystem>();                     

        part.Play();
    }
}
