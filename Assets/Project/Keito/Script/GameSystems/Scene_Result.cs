using UnityEngine;

public class Scene_Result : MonoBehaviour
{
    private bool isSwitched = false;

    ///チームメイトのコード/////////////////////////////////////////////////
    private bool isSEPlayed = false;
    ////////////////////////////////////////////////////////////////////////

    private void Update()
    {
        ///チームメイトのコード/////////////////////////////////////////////////
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

            ///チームメイトのコード/////////////////////////////////////////////////
            isSEPlayed = false;
            ////////////////////////////////////////////////////////////////////////
        }
    }
}
