using UnityEngine;

public class Scene_Title : MonoBehaviour
{
    [SerializeField] private float interval_seconds = 10.0f;

    private bool  isSwitched  = false;
    private float erapsedTime = 0.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isSwitched == false)
        {
            GameManager.pInstance.SwitchScene("SCENE_DESCRIPTION");
            isSwitched = true;
        }

        CountTime();
    }

    //放置時間をカウント
    private void CountTime()
    {
        erapsedTime += Time.deltaTime;

        Debug.Log(erapsedTime);
        Debug.Log(interval_seconds);

        if (erapsedTime > interval_seconds || Input.GetKeyDown(KeyCode.K))
        {
            erapsedTime = 0.0f;
            GameManager.pInstance.SwitchScene("SCENE_WAIT");
        }
    }
}
