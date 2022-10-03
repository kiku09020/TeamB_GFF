using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /* 値 */
    NowScene nowScene;      // 現在のシーン

    int sceneCnt;           // シーンの数

    // ロードパターン
    public enum Load {
        Now,        // 現在のシーン
        Next,       // 次
        Prev,       // 前
	}

    // エラーパターン
    enum Error {
        IndexOver,      // シーン番号が大きい
        IndexLess,      // シーン番号が小さい
	}

//-------------------------------------------------------------------
    void Awake()
    {
        nowScene = new NowScene();

        nowScene.Scene = SceneManager.GetActiveScene();
        nowScene.SetInfo();
    }

//-------------------------------------------------------------------
    // 次のシーンを読み込む
    void LoadNextScene() 
    {
        var index = nowScene.Index;

        // シーン番号が合計のシーン数より小さいとき、読み込み
        if (index < sceneCnt) {
            SceneManager.LoadScene(index + 1);
        }

        // 範囲外のシーン番号が指定された場合、エラー処理
		else {
            LoadErrorProc(Error.IndexOver);
        }
    }

    // 前のシーンを読み込む
    void LoadPrevScene() {
        var index = nowScene.Index;

        // シーン番号が0より大きいとき、読み込む
		if (index > 0) {
            SceneManager.LoadScene(index - 1);
		}

        // 範囲外のシーン番号が指定された場合、エラー処理
        else {
            LoadErrorProc(Error.IndexLess);
		}
    }

    //-------------------------------------------------------------------
    // ロード番号に応じたシーンのロード
    public void LoadScene(Load loadNum)
    {
        switch (loadNum) {
            case Load.Now:
                SceneManager.LoadScene(nowScene.Index);
                break;

            case Load.Next:
                LoadNextScene();
                break;

            case Load.Prev:
                LoadPrevScene();
                break;
        }
    }

    // シーン名指定して読み込む
    public void LoadScene(string sceneName) 
    { 
        SceneManager.LoadScene(sceneName); 
    }

    // シーン番号指定して読み込む
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); 
    }

    //-------------------------------------------------------------------
    // エラー時の処理
    void LoadErrorProc(Error errorNum)
	{
        string errorMessage = null;

		switch (errorNum) {
            case Error.IndexOver:
                errorMessage = "指定したシーン番号が、大きすぎます";
                break;

            case Error.IndexLess:
                errorMessage = "指定したシーン番号が、小さすぎます";
                break;
		}

        // エラーメッセージ
        Debug.LogError(errorMessage);

        // エディタ上で停止させる
        Debug.Break();
    }
}

// 現在のシーン
public class NowScene 
{
    /* 変数 */
    Scene  nowScene;            // 現在のシーン
    int    nowSceneIndex;       // シーン番号
    string nowSceneName;        // シーン名

    /* 関数 */
    // 現在のシーン情報をセット
    public void SetInfo()
	{
        nowSceneIndex = nowScene.buildIndex;
        nowSceneName = nowScene.name;
	}

    /* プロパティ */
    public Scene Scene
    {
        get { return nowScene; }
        set { nowScene = value; }
    }

    public int    Index { get { return nowSceneIndex; } }
    public string Name  { get { return nowSceneName; } }
}
