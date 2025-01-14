using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;

    private InputActions mInputActions = null;
    private Movement     mMovement     = null;
    private GivePresents mGivePresents = null;

    public Rigidbody  pRigidBody       { get; private set; }
    public GameObject pHouse           { get; private set; }
    public float      pInputX          { get; set; }
    public float      pInputY          { get; set; }
    public bool       pInputSpace      { get; set; } = false;
    public bool       pCanThrowPresent { get; set; } = false;
    public float      pSpeed           { get => speed; set => speed = value; }

    private void Start()
    {
        pRigidBody    = GetComponent<Rigidbody>();
        mInputActions = new InputActions(this);
        mMovement     = new Movement(this);
        mGivePresents = GetComponent<GivePresents>();
        mGivePresents.SetPlayerInstance(this);

        NullCheck();
    }

    private void Update()
    {     
        mInputActions._Update();
        mGivePresents._Update();
    }

    private void FixedUpdate()
    {
        mMovement._FixedUpdate();
    }

    private void NullCheck()
    {
        //Null�`�F�b�N
        if (mInputActions == null) Debug.Log("mInputActions��null�ł���");
        if (mMovement     == null) Debug.Log("mMovement��null�ł���");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chimney")
        {
            pCanThrowPresent = true;

            //�n�E�X�I�u�W�F�N�g�̍X�V
            pHouse = other.gameObject;

        }
        else if (other.gameObject.tag == "Object")
        {
            ///�`�[�����C�g�̃R�[�h/////////////////////////////////////////////////
            GameObject.FindWithTag("Audio").GetComponent<PlayAudio>().PlaySE(4);
            ////////////////////////////////////////////////////////////////////////
            
            GameManager.pInstance.SwitchScene("SCENE_RESULT");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Chimney")
        {
            pCanThrowPresent = false;
        }
    }
}
