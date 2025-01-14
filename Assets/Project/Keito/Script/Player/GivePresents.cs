using System.Collections.Generic;
using UnityEngine;

public class GivePresents : MonoBehaviour
{
    [SerializeField] private List<GameObject> presents = new List<GameObject>();

    private Player  mPlayer  = null;
    private Present mPresent = null;

    /// <summary>
    /// プレイヤーのインスタンスをセット
    /// </summary>
    /// <param name="player">Player player</param>
    public void SetPlayerInstance(Player player)
    {
        mPlayer = player;
    }

    /// <summary>
    /// Playerクラスから呼ぶためのUpdateメソッド
    /// </summary>
    public void _Update()
    {
        //プレゼントを投げられるかの判定
        if (mPlayer.pInputSpace && mPlayer.pCanThrowPresent)
        {
            ThrowPresent();

            ///チームメイトのコード/////////////////////////////////////////////////
            GameObject.FindWithTag("Audio").GetComponent<PlayAudio>().PlaySE(1);
            ////////////////////////////////////////////////////////////////////////

            mPlayer.pCanThrowPresent = false;
        } 
    }

    private void ThrowPresent()
    {
        //プレゼントをランダムに選ぶ
        var randIdx = Random.Range(0, presents.Count);
        //インスタンス生成
        var clone = Instantiate(presents[randIdx], mPlayer.transform.position, Quaternion.identity);
        mPresent  = clone.GetComponent<Present>();
        mPresent.SetTargetOBJ(mPlayer.pHouse);
    }
}
