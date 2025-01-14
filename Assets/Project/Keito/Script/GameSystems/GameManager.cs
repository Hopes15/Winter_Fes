using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;

    //スコア
    private static int score = 0;

    //シングルトンインスタンス
    private static GameManager instance = null;

    private void Awake()
    {
        //FPSをセット
        Application.targetFrameRate = targetFPS;

        //シングルトンインスタンスを初期化
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// スコアを取得
    /// </summary>
    /// <returns>int score</returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// スコアをリセット
    /// </summary>
    private void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// スコアを加算
    /// </summary>
    public void AddScore()
    {
        score++;
    }

    /// <summary>
    /// シーンを変える
    /// </summary>
    /// <param name="sceneName"> 移動先のシーン名</param>
    public void SwitchScene(string sceneName)
    {
        //TITLEに戻る場合のみスコアをリセットする
        if (sceneName == "SCENE_TITLE") ResetScore();

        SceneManager.LoadScene(sceneName);
    }

    public static GameManager pInstance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }

            return instance;
        }
    }

    /// <summary>
    /// シングルトンインスタンスをセットアップ
    /// GameManagerクラスがシーンになければオブジェクトを生成し、
    /// ゲームマネージャーのインスタンスを取得する
    /// </summary>
    private static void SetupInstance()
    {
        instance = FindObjectOfType<GameManager>();

        if (instance == null)
        {
            GameObject gameOBJ = new GameObject();
            gameOBJ.name       = "GameManager";
            instance           = gameOBJ.AddComponent<GameManager>();

            DontDestroyOnLoad(gameOBJ);
        }
    }
}
