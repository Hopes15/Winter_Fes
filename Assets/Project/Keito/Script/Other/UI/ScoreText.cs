using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text mScoreText = null;

    private void Start()
    {
        mScoreText      = GetComponent<Text>();
        var score       = GameManager.pInstance.GetScore();
        mScoreText.text = "とどけたプレゼントのかず：" + score.ToString() + "こ";
    }
}
