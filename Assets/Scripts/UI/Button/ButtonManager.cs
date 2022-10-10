using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    /* 値 */

    public enum Audio {
        Decision,       // 決定音
        Cancel,         // キャンセル音
    }

    /* コンポーネント取得用 */
    AudioManager aud;


    //-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        aud = audObj.GetComponent<AudioManager>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    // クリック時の音声再生
    public void PlayButtonAudio(Audio audType)
    {
        switch (audType) {
            case Audio.Decision:
                aud.PlaySE(AudioEnum.AudSrc.SE_UI, (int)AudioEnum.SE_UI.click);
                break;

            case Audio.Cancel:
                aud.PlaySE(AudioEnum.AudSrc.SE_UI, (int)AudioEnum.SE_UI.cancel);
                break;
        }
    }
}
