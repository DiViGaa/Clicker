using System;
using Ads;
using Locator;
using UnityEngine;
using UnityEngine.UI;

namespace WindowManager.Dialogs
{
    public class ShopScreenDialog : Dialog, IDisposable
    {
       [SerializeField] private Button backButton;
       [SerializeField] private Button addButton;
       
       [SerializeField] private GridLayoutGroup gridLayoutGroup;

       public void Initialize()
       {
           backButton.onClick.AddListener(BackToMainScreen);
           addButton.onClick.AddListener(ShowAdd);
       }

       private void BackToMainScreen()
       {
           var dialog = DialogManager.ShowDialog<MainScreenDialog>();
           dialog.Initialize();
           Hide();
       }

       private void ShowAdd()
       {
           ServiceLocator.Current.Get<InterstitialAd>().ShowAd();
       }
       
       public override void Dispose()
       {
           backButton.onClick.RemoveListener(BackToMainScreen);
           addButton.onClick.RemoveAllListeners();
       }
    }
}
