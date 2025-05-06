using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : Dialog
    {
        [SerializeField] private TextMeshProUGUI scoreText;
    
        public void ViewScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
