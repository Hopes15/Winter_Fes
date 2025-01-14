using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private Vector3 mVelocity   = new Vector3(0, 5, 5); //初速度
    [SerializeField] private float   mImpactTime = 1.5f;                 //到着時間

    private GameObject mTarget   = null;
    private Vector3    mDistance = Vector3.zero;

    private void Update()
    {
        ToChimney();
    }

    /// <summary>
    /// ターゲットにするオブジェクトをセットする
    /// </summary>
    /// <param name="target">GameObject ターゲット対象</param>
    public void SetTargetOBJ(GameObject target)
    {
        mTarget = target;
    }

    //煙突に飛ばすメソッド
    private void ToChimney()
    {
        //現在座標とターゲットとの差
        mDistance = mTarget.transform.position - transform.position;

        //加速度を初期化
        var acceleration = Vector3.zero;
        //加速度計算
        acceleration += (mDistance - mVelocity * mImpactTime) * 2.0f / (mImpactTime * mImpactTime);

        //到着時間を減らす
        mImpactTime -= Time.deltaTime;
        if (mImpactTime < 0.0f) 
        {
            //煙突に着弾したのでスコア追加
            GameManager.pInstance.AddScore();

            ///チームメイトのコード/////////////////////////////////////////////////
            GameObject.FindWithTag("Audio").GetComponent<PlayAudio>().PlaySE(2);
            ////////////////////////////////////////////////////////////////////////

            //プレイヤーのGoodクラスのインスタンス取得
            var good = GameObject.FindWithTag("Player").GetComponent<Good>();
            good.RiseHands();

            Debug.Log("Good");
            //オブジェクト消去
            Destroy(gameObject);
        } 

        //速度を計算
        mVelocity          += acceleration * Time.deltaTime;
        //速度 x 時間
        transform.position += mVelocity    * Time.deltaTime;
    }
}
