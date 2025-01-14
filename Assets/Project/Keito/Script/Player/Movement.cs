using UnityEngine;

public class Movement
{
    private Player        mPlayer    = null;
    private Rigidbody     mRigidbody = null;
    private CameraHandler mCamH      = null;

    /// <summary>
    /// Player�N���X�̃C���X�^���X���Z�b�g
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
    /// Player�N���X����ĂԂ��߂�FixedUpdate���\�b�h
    /// </summary>
    public void _FixedUpdate()
    {
        var xSpeed = mPlayer.pSpeed * mPlayer.pInputX;
        var ySpeed = mPlayer.pSpeed * mPlayer.pInputY;

        mRigidbody.velocity = new Vector3(xSpeed, ySpeed, 0.0f);

        ClampPosition();
    }

    //Player�̍��W���N�����v����
    private void ClampPosition()
    {
        var playerPos = mPlayer.transform.position;

        //X, Y���W�𐧌�
        var clampedX = Mathf.Clamp(playerPos.x, mCamH.GetScreenRimitPos().leftBottom.x, mCamH.GetScreenRimitPos().rightTop.x);
        var clampedY = Mathf.Clamp(playerPos.y, mCamH.GetScreenRimitPos().leftBottom.y, mCamH.GetScreenRimitPos().rightTop.y);

        mPlayer.transform.position = new Vector3(clampedX, clampedY, playerPos.z);
    }

    private void NullCheck()
    {
        //Null�`�F�b�N
        if (mPlayer    == null) Debug.Log("mPlayer��null�ł���");
        if (mRigidbody == null) Debug.Log("mRigidbody��null�ł���");
        if (mCamH      == null) Debug.Log("mCamH��null�ł���");
    }
}
