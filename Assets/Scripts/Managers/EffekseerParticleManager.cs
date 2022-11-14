using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effekseer;

public class EffekseerParticleManager : MonoBehaviour
{
    /* 値 */
    [SerializeField] List<EffekseerEffectAsset> effects = new List<EffekseerEffectAsset>();
    [SerializeField, Range(0, 2)] float speed;

    /* コンポーネント取得用 */
    EffekseerHandle handle;
    FishParameter fishPar;

    // タイプ名
    public enum EffectType{
        water,
	}

//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject charaObj = gmObj.transform.Find("CharaManager").gameObject;

        /* コンポーネント取得 */
        fishPar = charaObj.GetComponent<FishParameter>();

        /* 初期化 */
        
    }

    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    public void PlayEffect(EffectType type,Vector2 pos)
    {
        handle = EffekseerSystem.PlayEffect(effects[(int)type], pos);
        handle.speed = speed * ( 1 + fishPar.FallSpd * 5 ) ;
    }
}
