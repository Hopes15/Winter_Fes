using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Vector3 camOffset;
    [SerializeField] private float   defaultFOV           = 10.0f;
    [SerializeField] private float   maxFOV               = 60.0f;
    [SerializeField] private float   incrementFOVperFrame = 0.01f;

    public struct RimitPos
    {
        public Vector3 leftBottom; //�������W
        public Vector3 rightTop;   //�E����W
    }

    public RimitPos mRimitPos = new RimitPos();

    private void Start()
    {
        Camera.main.fieldOfView = defaultFOV;
    }

    private void Update()
    {
        ChangeFOV();
    }

    /// <summary>
    /// �X�N���[�����W�����ʒ[��World���W���擾����
    /// </summary>
    /// <returns>RimitPos</returns>
    public RimitPos GetScreenRimitPos()
    {
        //�X�N���[�����W���烏�[���h���W���Z�o
        mRimitPos.leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -camOffset.z));
        mRimitPos.rightTop   = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -camOffset.z));

        return mRimitPos;
    }

    /// <summary>
    /// FOV���g�傳����
    /// </summary>
    private void ChangeFOV()
    {
        if(Camera.main.fieldOfView < maxFOV)
        {
            Camera.main.fieldOfView += incrementFOVperFrame;
        }
    }
}
