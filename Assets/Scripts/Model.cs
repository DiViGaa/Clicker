using UI;

public class Model : AbstractModel
{
    public Model(ScoreView scoreView) : base(scoreView)
    {
        
    }
    public void SetScore(int newScore)
    {
        _score += newScore;
        scoreView.ViewScore(_score);
    }
}
