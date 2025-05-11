using UI;

public class ScoreModel : AbstractModel
{
    public ScoreModel(ScoreView scoreView) : base(scoreView)
    {
        
    }
    public void SetScore(int newScore)
    {
        _score += newScore;
        scoreView.ViewScore(_score);
    }
}
