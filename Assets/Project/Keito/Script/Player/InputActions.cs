using UnityEngine;

public class InputActions
{
    private Player mPlayer = null;

    /// <summary>
    /// Player�N���X�̃C���X�^���X���Z�b�g
    /// </summary>
    /// <param name="player">Player player</param>
    public InputActions(Player player)
    {
        mPlayer = player;
    }

    /// <summary>
    /// Player�N���X����ĂԂ��߂�Update���\�b�h
    /// </summary>
    public void _Update()
    {
        mPlayer.pInputX     = Input.GetAxisRaw("Horizontal");
        mPlayer.pInputY     = Input.GetAxisRaw("Vertical");
        mPlayer.pInputSpace = Input.GetKeyDown(KeyCode.Space);
    }
}
