using System.Collections;
using UnityEngine;

public class Good : MonoBehaviour
{
    [SerializeField] private float      time_count = 0.5f;
    [SerializeField] private GameObject good       = null;

    /// <summary>
    /// Good�̃A�C�R����\������
    /// </summary>
    public void RiseHands()
    {
        StartCoroutine(CountTime(time_count, good));
    }

    //Good��\�����鎞�Ԃ��J�E���g
    IEnumerator CountTime(float time, GameObject good)
    {
        good.SetActive(true);

        yield return new WaitForSeconds(time);

        good.SetActive(false);
    }
}
