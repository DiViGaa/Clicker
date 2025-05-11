using Abstract;
using WindowManager;

public class Controller : AbstractController
{
    public Controller(Dialog view, ScoreModel scoreModel) : base(view, scoreModel)
    {
    }
    
    public void Click()
    {
        ScoreModel.SetScore(1);
    }
}
