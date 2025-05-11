 
using WindowManager;

namespace Abstract
{
    public class AbstractController
    {
        protected Dialog _view;
        protected ScoreModel ScoreModel;

        public AbstractController(Dialog view, ScoreModel scoreModel)
        {
            _view = view;
            ScoreModel = scoreModel;
        }

        
    }
}
