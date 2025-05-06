using Abstract;

public class Controller : AbstractController
{
    public Controller(Dialog view, Model model) : base(view, model)
    {
    }
    
    public void Click()
    {
        _model.SetScore(1);
    }
}
