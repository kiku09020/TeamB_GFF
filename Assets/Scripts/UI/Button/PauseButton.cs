using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : ButtonManager
{
    /* 値 */


    /* コンポーネント取得用 */
    GameManager gm;
    CanvasManager canvas;
    AudioManager aud;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject umObj = gmObj.transform.Find("UIManager").gameObject;
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        gm = gmObj.GetComponent<GameManager>();
        canvas = umObj.GetComponent<CanvasManager>();
        aud = audObj.GetComponent<AudioManager>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    public void Pause(bool pause)
    {
        gm.isPause = pause;     // 停止中フラグ
        canvas.Pause(pause);    // キャンバスのフラグ
        aud.PauseAudio(pause);  // 音声一時停止

        // ポーズ時
        if (pause) {
            Time.timeScale = 0;
            PlayButtonAudio(Audio.Decision);
        }

        // ポーズ終了時
        else {
            Time.timeScale = 1;
            PlayButtonAudio(Audio.Cancel);
        }
    }
}
