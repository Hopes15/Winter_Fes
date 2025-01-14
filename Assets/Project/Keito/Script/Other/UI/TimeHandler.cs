using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    private Text mRemainedTime    = null;
    private Scene_Game scene_Game = null;

    private void Start()
    {
        mRemainedTime = GetComponent<Text>();
        scene_Game    = GameObject.FindWithTag("SCENE_GAME").GetComponent<Scene_Game>();
    }

    private void Update()
    {
        //floatをintにキャストしてから表示する(小数点以下を非表示に)
        var remainedTime   = (int)scene_Game.GetRemainedTime();
        mRemainedTime.text = "のこりじかん : " + remainedTime.ToString();
    }
}
