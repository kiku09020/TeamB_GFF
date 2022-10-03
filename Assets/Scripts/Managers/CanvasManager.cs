using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    /* 値 */

    [Header("Objects")]
    [SerializeField] GameObject mainCanvasPrfb;     // メインのキャンバス
    [SerializeField] GameObject eventSystemObj;     // EventSystem

    GameObject mainCanvasInst;      // インスタンス

    GameObject ctrlCanvas;
    GameObject uiCnavas;
    GameObject pauseCanvas;

    //-------------------------------------------------------------------
    void Start()
    {
        mainCanvasInst = Instantiate(mainCanvasPrfb);       // キャンバスのプレハブをインスタンス化
        Instantiate(eventSystemObj);                        // EventSystemインスタンス化

        /* オブジェクト取得 */
        ctrlCanvas  = mainCanvasInst.transform.Find("ControllerCanvas").gameObject;
        uiCnavas    = mainCanvasInst.transform.Find("GameUICanvas").gameObject;
        pauseCanvas = mainCanvasInst.transform.Find("PauseCanvas").gameObject;

        /* 初期化 */
        pauseCanvas.SetActive(false);
    }

    //-------------------------------------------------------------------
    public void Pause(bool pause)
    {
        // ポーズ時
        if (pause) {
            ctrlCanvas.SetActive(false);
            uiCnavas.SetActive(false);
            pauseCanvas.SetActive(true);
        }

        // ポーズ終了時
        else {
            ctrlCanvas.SetActive(true);
            uiCnavas.SetActive(true);
            pauseCanvas.SetActive(false);
        }
    }
}
