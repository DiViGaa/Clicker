 
namespace Abstract
{
    public class AbstractController
    {
        protected Dialog _view;
        protected Model _model;

        public AbstractController(Dialog view, Model model)
        {
            _view = view;
            _model = model;
        }

        
    }
}
