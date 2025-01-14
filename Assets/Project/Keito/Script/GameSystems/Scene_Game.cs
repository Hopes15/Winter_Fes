using UnityEngine;

public class Scene_Game : MonoBehaviour
{
    [SerializeField] private float remainedTime = 30.0f;

    private void Update()
    {
        //残り時間をみてシーンを移動するか判断する
        if (remainedTime <= 0.0f)
        {
            remainedTime = 0.0f;
            GameManager.pInstance.SwitchScene("SCENE_RESULT");
        }
        else
        {
            remainedTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// 残り時間を取得
    /// </summary>
    /// <returns>float remainedTime</returns>
    public float GetRemainedTime()
    {
        return remainedTime;
    }
}
