using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private float impulsePow = 0.0f;

    private Rigidbody mRigidbody = null;

    private void Update()
    {
        //���̍��W�𒴂�����폜
        if (transform.position.z < -20.0f) Destroy(gameObject);
    }

    /// <summary>
    /// �O������I�u�W�F�N�g�𐶐����ꂽ�ۂ�RigidBody���A�^�b�`����
    /// </summary>
    public void AttachRigidbody()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �I�u�W�F�N�g�������o��
    /// </summary>
    public void Fire()
    {
        mRigidbody.AddForce(new Vector3(0, 0, -impulsePow), ForceMode.Impulse);
    }
}
