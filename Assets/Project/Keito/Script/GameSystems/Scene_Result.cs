using UnityEngine;

public class Scene_Result : MonoBehaviour
{
    private bool isSwitched = false;

    ///�`�[�����C�g�̃R�[�h/////////////////////////////////////////////////
    private bool isSEPlayed = false;
    ////////////////////////////////////////////////////////////////////////

    private void Update()
    {
        ///�`�[�����C�g�̃R�[�h/////////////////////////////////////////////////
        if(isSEPlayed == false)
        {
            GameObject.FindWithTag("Audio").GetComponent<PlayAudio>().PlaySE(4);
            isSEPlayed = true;
        }
        ////////////////////////////////////////////////////////////////////////
        
        if (Input.GetKeyDown(KeyCode.Space) && isSwitched == false)
        {
            GameManager.pInstance.SwitchScene("SCENE_TITLE");
            isSwitched = true;

            ///�`�[�����C�g�̃R�[�h/////////////////////////////////////////////////
            isSEPlayed = false;
            ////////////////////////////////////////////////////////////////////////
        }
    }
}
