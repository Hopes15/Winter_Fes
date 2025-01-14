using UnityEngine;

public class Movement
{
    private Player        mPlayer    = null;
    private Rigidbody     mRigidbody = null;
    private CameraHandler mCamH      = null;

    /// <summary>
    /// Playerクラスのインスタンスをセット
    /// </summary>
    /// <param name="plaeyr">Player player</param>
    public Movement(Player plaeyr)
    {
        mPlayer    = plaeyr;
        mRigidbody = mPlayer.pRigidBody;
        mCamH      = GameObject.FindWithTag("MainCamera").GetComponent<CameraHandler>();

        NullCheck();
    }

    /// <summary>
    /// Playerクラスから呼ぶためのFixedUpdateメソッド
    /// </summary>
    public void _FixedUpdate()
    {
        var xSpeed = mPlayer.pSpeed * mPlayer.pInputX;
        var ySpeed = mPlayer.pSpeed * mPlayer.pInputY;

        mRigidbody.velocity = new Vector3(xSpeed, ySpeed, 0.0f);

        ClampPosition();
    }

    //Playerの座標をクランプする
    private void ClampPosition()
    {
        var playerPos = mPlayer.transform.position;

        //X, Y座標を制限
        var clampedX = Mathf.Clamp(playerPos.x, mCamH.GetScreenRimitPos().leftBottom.x, mCamH.GetScreenRimitPos().rightTop.x);
        var clampedY = Mathf.Clamp(playerPos.y, mCamH.GetScreenRimitPos().leftBottom.y, mCamH.GetScreenRimitPos().rightTop.y);

        mPlayer.transform.position = new Vector3(clampedX, clampedY, playerPos.z);
    }

    private void NullCheck()
    {
        //Nullチェック
        if (mPlayer    == null) Debug.Log("mPlayerがnullでした");
        if (mRigidbody == null) Debug.Log("mRigidbodyがnullでした");
        if (mCamH      == null) Debug.Log("mCamHがnullでした");
    }
}
