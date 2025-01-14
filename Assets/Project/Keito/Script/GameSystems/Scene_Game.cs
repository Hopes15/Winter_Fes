using UnityEngine;

public class Scene_Game : MonoBehaviour
{
    [SerializeField] private float remainedTime = 30.0f;

    private void Update()
    {
        //�c�莞�Ԃ��݂ăV�[�����ړ����邩���f����
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
    /// �c�莞�Ԃ��擾
    /// </summary>
    /// <returns>float remainedTime</returns>
    public float GetRemainedTime()
    {
        return remainedTime;
    }
}
