using Locator;
using Sound;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace WindowManager.Dialogs
{
    public class MainScreenDialog : Dialog
    {
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private Button clickButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button shopButton;
        
        private Controller _controller;
        
        public void Initialize()
        {
            ScoreModel scoreModel = new ScoreModel(scoreView);
            _controller = new Controller(scoreView, scoreModel);

            menuButton.onClick.AddListener(MenuScreenDialog);
            shopButton.onClick.AddListener(ShopScreenDialog);
            
            clickButton.onClick.AddListener(ControllerClick);
        }

        private void ShopScreenDialog()
        {
             var dialog = DialogManager.ShowDialog<ShopScreenDialog>();
             dialog.Initialize();
             Hide();
             ServiceLocator.Current.Get<SoundManager>().PlaySound("ui", "UI");
        }

        private void MenuScreenDialog()
        {
            var dialog = DialogManager.ShowDialog<MenuScreenDialog>();
            dialog.Initialize();
            Hide();
            ServiceLocator.Current.Get<SoundManager>().PlaySound("ui", "UI");
        }
        
        private void ControllerClick()
        {
            _controller.Click();
            ServiceLocator.Current.Get<SoundManager>().PlaySound("ui", "UI");
        }
        
        public override void Dispose()
        {
            clickButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
            shopButton.onClick.RemoveAllListeners();
        }
    }
}
