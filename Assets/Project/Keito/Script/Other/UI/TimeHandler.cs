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
        //float��int�ɃL���X�g���Ă���\������(�����_�ȉ����\����)
        var remainedTime   = (int)scene_Game.GetRemainedTime();
        mRemainedTime.text = "�̂��肶���� : " + remainedTime.ToString();
    }
}
