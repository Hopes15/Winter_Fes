using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private float defaultTime = 60.0f;
    [SerializeField] private float blinkTime   = 30.0f;
    [SerializeField] private float sleepTime   = 90.0f;
    [SerializeField] private float smileTime   = 15.0f;

    private Animator mAnimator_EYE   = null;
    private Animator mAnimator_MOUTH = null;
    private float mErapsedTime       = 0.0f;

    //�\��̏�Ԓ�`
    private enum FACE_STATE
    {
        DEFAULT,
        BLINK,
        SLEEP,
        SMILE,
    }

    private FACE_STATE state = FACE_STATE.DEFAULT;

    private void Start()
    {
        //�����ݒ�
        mAnimator_EYE   = GameObject.FindWithTag("Eye"  ).GetComponent<Animator>();
        mAnimator_MOUTH = GameObject.FindWithTag("Mouth").GetComponent<Animator>();

        mAnimator_EYE.  SetInteger("FACE_STATE", (int)FACE_STATE.DEFAULT);
        mAnimator_MOUTH.SetInteger("FACE_STATE", (int)FACE_STATE.DEFAULT);
    }

    private void Update()
    {
        //��ԑJ��
        switch (state)
        {
            case FACE_STATE.DEFAULT:
                SwitchState(defaultTime, FACE_STATE.BLINK,   FACE_STATE.SMILE);

                break;
            case FACE_STATE.BLINK:
                SwitchState(blinkTime,   FACE_STATE.DEFAULT, FACE_STATE.SLEEP);

                break;
            case FACE_STATE.SLEEP:
                SwitchState(sleepTime,   FACE_STATE.BLINK);

                break;
            case FACE_STATE.SMILE:
                SwitchState(smileTime,   FACE_STATE.DEFAULT);

                break;
        }
    }  

    //��ԑJ�ڃ��\�b�h
    private void SwitchState(float interval, FACE_STATE face_state)
    {
        mErapsedTime += Time.deltaTime;

        if (mErapsedTime > interval)
        {
            state = face_state;
            mAnimator_EYE.  SetInteger("FACE_STATE", (int)face_state);
            mAnimator_MOUTH.SetInteger("FACE_STATE", (int)face_state);
            mErapsedTime = 0.0f;
        }
    }

    //��ԑJ�ڃ��\�b�h(�I�[�o�[���[�h)
    private void SwitchState(float interval, FACE_STATE face_state1, FACE_STATE face_state2)
    {
        mErapsedTime += Time.deltaTime;

        if (mErapsedTime > interval)
        {
            //���̃X�e�[�g�������_���ɑI��
            var rand = Random.Range(0, 2);

            ///�`�[�����C�g�̃R�[�h/////////////////////////////////////////////////
            GameObject.FindWithTag("Audio").GetComponent<MyaAudio>().PlayNeko(Random.Range(0, 3));
            ////////////////////////////////////////////////////////////////////////
            
            if (rand == 0)
            {
                state = face_state1;
                mAnimator_EYE.  SetInteger("FACE_STATE", (int)face_state1);
                mAnimator_MOUTH.SetInteger("FACE_STATE", (int)face_state1);
            }
            else
            {
                state = face_state2;
                mAnimator_EYE.  SetInteger("FACE_STATE", (int)face_state2);
                mAnimator_MOUTH.SetInteger("FACE_STATE", (int)face_state2);
            }
            
            mErapsedTime = 0.0f;
        }
    }
}