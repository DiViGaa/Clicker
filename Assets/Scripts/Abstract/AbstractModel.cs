public class AbstractModel
{
    protected View _view;
    protected int _score;

    public AbstractModel(View view)
    {
        _view = view;
        _score = 0;
    }

    public void SetScore(int newScore)
    {
        _score += newScore;
        _view.ViewScore(_score);
    }
}
