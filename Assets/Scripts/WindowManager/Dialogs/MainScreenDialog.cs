using System;
using Abstract;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace WindowManager.Dialogs
{
    public class MainScreenDialog : Dialog, IDisposable
    {
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private Button clickButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button shopButton;
        
        private Controller _controller;
        
        public void Init()
        {
            Model model = new Model(scoreView);
            _controller = new Controller(scoreView, model);

            menuButton.onClick.AddListener(MenuScreenDialog);
            shopButton.onClick.AddListener(ShopScreenDialog);
            
            clickButton.onClick.AddListener(ControllerClick);
        }

        private void ShopScreenDialog()
        {
             var dialog = WindowManager.DialogManager.ShowDialog<ShopScreenDialog>();
             
             Hide();
        }

        private void MenuScreenDialog()
        {
            var dialog = WindowManager.DialogManager.ShowDialog<MenuScreenDialog>();
            
             Hide();
        }
        
        private void ControllerClick()
        {
            _controller.Click();
        }

        private void OnDisable() => Dispose();

        public void Dispose()
        {
            clickButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
            shopButton.onClick.RemoveAllListeners();
        }
    }
}
