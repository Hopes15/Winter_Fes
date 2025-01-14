using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text mScoreText = null;

    private void Start()
    {
        mScoreText      = GetComponent<Text>();
        var score       = GameManager.pInstance.GetScore();
        mScoreText.text = "‚Æ‚Ç‚¯‚½ƒvƒŒƒ[ƒ“ƒg‚Ì‚©‚¸F" + score.ToString() + "‚±";
    }
}
