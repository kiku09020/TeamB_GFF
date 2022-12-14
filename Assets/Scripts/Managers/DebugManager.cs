using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    /* 値 */


    /* コンポーネント取得用 */
    SceneController scene;
    ParticleManager part;

    ScoreManager score;
    TimeManager time;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = transform.parent.gameObject;
        GameObject partObj = gmObj.transform.Find("ParticleManager").gameObject;

        /* コンポーネント取得 */
        scene = gmObj.GetComponent<SceneController>();
        part = partObj.GetComponent<ParticleManager>();

        score = gmObj.GetComponent<ScoreManager>();
        time = gmObj.GetComponent<TimeManager>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void Update()
    {
        Key();
        Log();
    }

    //-------------------------------------------------------------------
    // キー操作
    void Key()
    {
        // シーン再読み込み
        if (Input.GetKeyDown(KeyCode.R)) {
            scene.ReloadScene();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            part.PlayPart(ParticleManager.PartNames.circle, Vector2.zero);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            score.AddScore(1000);
        }

        if (Input.GetKeyDown(KeyCode.End)) {
            time.Timer = 12;
        }
    }

    // ログ出力
    void Log()
    {

    }
}
