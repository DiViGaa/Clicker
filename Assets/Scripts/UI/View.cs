using TMPro;
using UnityEngine;

public class View : AbstractView
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public override void ViewScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
