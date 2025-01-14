using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;

    //�X�R�A
    private static int score = 0;

    //�V���O���g���C���X�^���X
    private static GameManager instance = null;

    private void Awake()
    {
        //FPS���Z�b�g
        Application.targetFrameRate = targetFPS;

        //�V���O���g���C���X�^���X��������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �X�R�A���擾
    /// </summary>
    /// <returns>int score</returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// �X�R�A�����Z�b�g
    /// </summary>
    private void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// �X�R�A�����Z
    /// </summary>
    public void AddScore()
    {
        score++;
    }

    /// <summary>
    /// �V�[����ς���
    /// </summary>
    /// <param name="sceneName"> �ړ���̃V�[����</param>
    public void SwitchScene(string sceneName)
    {
        //TITLE�ɖ߂�ꍇ�̂݃X�R�A�����Z�b�g����
        if (sceneName == "SCENE_TITLE") ResetScore();

        SceneManager.LoadScene(sceneName);
    }

    public static GameManager pInstance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }

            return instance;
        }
    }

    /// <summary>
    /// �V���O���g���C���X�^���X���Z�b�g�A�b�v
    /// GameManager�N���X���V�[���ɂȂ���΃I�u�W�F�N�g�𐶐����A
    /// �Q�[���}�l�[�W���[�̃C���X�^���X���擾����
    /// </summary>
    private static void SetupInstance()
    {
        instance = FindObjectOfType<GameManager>();

        if (instance == null)
        {
            GameObject gameOBJ = new GameObject();
            gameOBJ.name       = "GameManager";
            instance           = gameOBJ.AddComponent<GameManager>();

            DontDestroyOnLoad(gameOBJ);
        }
    }
}
