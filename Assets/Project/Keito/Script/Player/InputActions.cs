using UnityEngine;

public class InputActions
{
    private Player mPlayer = null;

    /// <summary>
    /// Playerクラスのインスタンスをセット
    /// </summary>
    /// <param name="player">Player player</param>
    public InputActions(Player player)
    {
        mPlayer = player;
    }

    /// <summary>
    /// Playerクラスから呼ぶためのUpdateメソッド
    /// </summary>
    public void _Update()
    {
        mPlayer.pInputX     = Input.GetAxisRaw("Horizontal");
        mPlayer.pInputY     = Input.GetAxisRaw("Vertical");
        mPlayer.pInputSpace = Input.GetKeyDown(KeyCode.Space);
    }
}
