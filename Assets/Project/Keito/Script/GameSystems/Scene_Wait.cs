using UnityEngine;

public class Scene_Wait : MonoBehaviour
{
    private bool isSwitched = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isSwitched == false)
        {
            GameManager.pInstance.SwitchScene("SCENE_TITLE");
            isSwitched = true;
        }
    }
}
