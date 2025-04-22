
public class AbstractController
{
    protected AbstractView _view;
    protected AbstractModel _model;

    public AbstractController(AbstractView view, AbstractModel model)
    {
        _view = view;
        _model = model;
    }

    public void Click()
    {
        _model.SetScore(1);
    }
}
