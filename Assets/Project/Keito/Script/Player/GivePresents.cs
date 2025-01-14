using System.Collections.Generic;
using UnityEngine;

public class GivePresents : MonoBehaviour
{
    [SerializeField] private List<GameObject> presents = new List<GameObject>();

    private Player  mPlayer  = null;
    private Present mPresent = null;

    /// <summary>
    /// �v���C���[�̃C���X�^���X���Z�b�g
    /// </summary>
    /// <param name="player">Player player</param>
    public void SetPlayerInstance(Player player)
    {
        mPlayer = player;
    }

    /// <summary>
    /// Player�N���X����ĂԂ��߂�Update���\�b�h
    /// </summary>
    public void _Update()
    {
        //�v���[���g�𓊂����邩�̔���
        if (mPlayer.pInputSpace && mPlayer.pCanThrowPresent)
        {
            ThrowPresent();

            ///�`�[�����C�g�̃R�[�h/////////////////////////////////////////////////
            GameObject.FindWithTag("Audio").GetComponent<PlayAudio>().PlaySE(1);
            ////////////////////////////////////////////////////////////////////////

            mPlayer.pCanThrowPresent = false;
        } 
    }

    private void ThrowPresent()
    {
        //�v���[���g�������_���ɑI��
        var randIdx = Random.Range(0, presents.Count);
        //�C���X�^���X����
        var clone = Instantiate(presents[randIdx], mPlayer.transform.position, Quaternion.identity);
        mPresent  = clone.GetComponent<Present>();
        mPresent.SetTargetOBJ(mPlayer.pHouse);
    }
}
