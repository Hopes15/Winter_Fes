using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private float impulsePow = 0.0f;

    private Rigidbody mRigidbody = null;

    private void Update()
    {
        //一定の座標を超えたら削除
        if (transform.position.z < -20.0f) Destroy(gameObject);
    }

    /// <summary>
    /// 外部からオブジェクトを生成された際にRigidBodyをアタッチする
    /// </summary>
    public void AttachRigidbody()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// オブジェクトを押し出す
    /// </summary>
    public void Fire()
    {
        mRigidbody.AddForce(new Vector3(0, 0, -impulsePow), ForceMode.Impulse);
    }
}
