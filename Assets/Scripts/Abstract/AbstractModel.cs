using UI;

public class AbstractModel
{
    protected ScoreView scoreView;
    protected int _score;

    public AbstractModel(ScoreView scoreView)
    {
        this.scoreView = scoreView;
        _score = 0;
    }
    
}
