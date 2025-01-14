using UnityEngine;

public class Scene_Desc : MonoBehaviour
{
    [SerializeField] private GameObject desc_1 = null;
    [SerializeField] private GameObject desc_2 = null;

    private int  state      = 0;
    private bool isSwitched = false;

    private void Update()
    {
        //‘€ìà–¾‚ÌØ‚è‘Ö‚¦‚ÆƒV[ƒ“‚ÌˆÚ“®
        if (Input.GetKeyDown(KeyCode.Space)) state++;

        switch (state)
        {
            case 0:
                desc_1.SetActive(true);
                desc_2.SetActive(false);
                break;

            case 1:
                desc_1.SetActive(false);
                desc_2.SetActive(true);
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.Space) && isSwitched == false)
                {
                    GameManager.pInstance.SwitchScene("SCENE_GAME");
                    isSwitched = true;
                }
                break;
        }
    }
}
