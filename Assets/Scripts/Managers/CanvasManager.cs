using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    /* 値 */
    GameObject ctrlCnvs;
    GameObject uiCnvs;
    GameObject pauseCnvs;
    GameObject resultCnvs;

    /* プロパティ */
    public GameObject CtrlCanvas    { get => ctrlCnvs; }
    public GameObject GameCanvas    { get => uiCnvs; }
    public GameObject ResultCanvas  { get => resultCnvs; }

    //-------------------------------------------------------------------
    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        Transform parent = mainCanvas.transform;

        /* オブジェクト取得 */
        ctrlCnvs  = parent.Find("ControllerCanvas").gameObject;
        uiCnvs    = parent.Find("GameUICanvas").gameObject;
        pauseCnvs = parent.Find("PauseCanvas").gameObject;
        resultCnvs = parent.Find("ResultCanvas").gameObject;

        /* 初期化 */
        pauseCnvs.SetActive(false);
        resultCnvs.SetActive(false);
    }

    //-------------------------------------------------------------------
    public void Pause(bool pause)
    {
        // ポーズ時
        if (pause) {
            ctrlCnvs.SetActive(false);
            uiCnvs.SetActive(false);
            pauseCnvs.SetActive(true);
        }

        // ポーズ終了時
        else {
            ctrlCnvs.SetActive(true);
            uiCnvs.SetActive(true);
            pauseCnvs.SetActive(false);
        }
    }

    // タイムアップになった瞬間
    public void TimeUp()
    {
        ctrlCnvs.SetActive(false);
	}

    // リザルト画面に遷移するとき
    public void TransitionResult()
    {
        uiCnvs.SetActive(false);
        resultCnvs.SetActive(true);
	}
}
