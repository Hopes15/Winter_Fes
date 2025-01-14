using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Vector3 camOffset;
    [SerializeField] private float   defaultFOV           = 10.0f;
    [SerializeField] private float   maxFOV               = 60.0f;
    [SerializeField] private float   incrementFOVperFrame = 0.01f;

    public struct RimitPos
    {
        public Vector3 leftBottom; //左下座標
        public Vector3 rightTop;   //右上座標
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
    /// スクリーン座標から画面端のWorld座標を取得する
    /// </summary>
    /// <returns>RimitPos</returns>
    public RimitPos GetScreenRimitPos()
    {
        //スクリーン座標からワールド座標を算出
        mRimitPos.leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -camOffset.z));
        mRimitPos.rightTop   = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -camOffset.z));

        return mRimitPos;
    }

    /// <summary>
    /// FOVを拡大させる
    /// </summary>
    private void ChangeFOV()
    {
        if(Camera.main.fieldOfView < maxFOV)
        {
            Camera.main.fieldOfView += incrementFOVperFrame;
        }
    }
}
