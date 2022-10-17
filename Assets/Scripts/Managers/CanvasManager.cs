using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    /* 値 */
    GameObject ctrlCnvs;
    GameObject uiCnvs;
    GameObject pauseCnvs;
    GameObject gmovCnvs;

    /* プロパティ */
    public GameObject CtrlCanvas { get => ctrlCnvs; }
    public GameObject GameCanvas { get => uiCnvs; }

    //-------------------------------------------------------------------
    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        Transform parent = mainCanvas.transform;

        /* オブジェクト取得 */
        ctrlCnvs  = parent.Find("ControllerCanvas").gameObject;
        uiCnvs    = parent.Find("GameUICanvas").gameObject;
        pauseCnvs = parent.Find("PauseCanvas").gameObject;
        gmovCnvs  = parent.Find("GameOverCanvas").gameObject;

        /* 初期化 */
        pauseCnvs.SetActive(false);
        gmovCnvs.SetActive(false);
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

    public void GameOver()
    {
        ctrlCnvs.SetActive(false);
        uiCnvs.SetActive(false);
        gmovCnvs.SetActive(true);
    }
}
