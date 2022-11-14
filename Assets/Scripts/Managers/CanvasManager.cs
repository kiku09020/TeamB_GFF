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
    GameObject startingCnvs;

    /* プロパティ */
    public GameObject CtrlCanvas => ctrlCnvs;
    public GameObject GameCanvas => uiCnvs;
    public GameObject ResultCanvas => resultCnvs;
    public GameObject StartingCanvas => startingCnvs;

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
        startingCnvs = parent.Find("StartingCanvas").gameObject;

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

    // スタート時のカウントダウン
    public void StartingTimerExit()
    {
        startingCnvs.SetActive(false);
	}
}
