using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private Vector3 mVelocity   = new Vector3(0, 5, 5); //�����x
    [SerializeField] private float   mImpactTime = 1.5f;                 //��������

    private GameObject mTarget   = null;
    private Vector3    mDistance = Vector3.zero;

    private void Update()
    {
        ToChimney();
    }

    /// <summary>
    /// �^�[�Q�b�g�ɂ���I�u�W�F�N�g���Z�b�g����
    /// </summary>
    /// <param name="target">GameObject �^�[�Q�b�g�Ώ�</param>
    public void SetTargetOBJ(GameObject target)
    {
        mTarget = target;
    }

    //���˂ɔ�΂����\�b�h
    private void ToChimney()
    {
        //���ݍ��W�ƃ^�[�Q�b�g�Ƃ̍�
        mDistance = mTarget.transform.position - transform.position;

        //�����x��������
        var acceleration = Vector3.zero;
        //�����x�v�Z
        acceleration += (mDistance - mVelocity * mImpactTime) * 2.0f / (mImpactTime * mImpactTime);

        //�������Ԃ����炷
        mImpactTime -= Time.deltaTime;
        if (mImpactTime < 0.0f) 
        {
            //���˂ɒ��e�����̂ŃX�R�A�ǉ�
            GameManager.pInstance.AddScore();

            ///�`�[�����C�g�̃R�[�h/////////////////////////////////////////////////
            GameObject.FindWithTag("Audio").GetComponent<PlayAudio>().PlaySE(2);
            ////////////////////////////////////////////////////////////////////////

            //�v���C���[��Good�N���X�̃C���X�^���X�擾
            var good = GameObject.FindWithTag("Player").GetComponent<Good>();
            good.RiseHands();

            Debug.Log("Good");
            //�I�u�W�F�N�g����
            Destroy(gameObject);
        } 

        //���x���v�Z
        mVelocity          += acceleration * Time.deltaTime;
        //���x x ����
        transform.position += mVelocity    * Time.deltaTime;
    }
}
