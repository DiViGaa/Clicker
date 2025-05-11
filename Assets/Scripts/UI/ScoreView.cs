using TMPro;
using UnityEngine;
using WindowManager;

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
