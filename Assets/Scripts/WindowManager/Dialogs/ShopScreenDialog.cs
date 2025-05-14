using Ads;
using Locator;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Upgrades;

namespace WindowManager.Dialogs
{
    public class ShopScreenDialog : Dialog
    {
       [SerializeField] private Button backButton;
       [SerializeField] private Button addButton;
       
       [SerializeField] private GridLayoutGroup gridLayoutGroup;
       
       [SerializeField] private GameObject upgradeParent;
       
       private UpgradeButton[] _upgrades;

       public static UnityAction OnCloseDialog; //TEMP

       public void Initialize()
       {
           backButton.onClick.AddListener(BackToMainScreen);
           addButton.onClick.AddListener(ShowAdd);
           ServiceLocator.Current.Get<UpgradeCreator>().CreateUpgradeButtons(upgradeParent);
           OnCloseDialog += Hide; //TEMP
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
           OnCloseDialog -= Hide; //TEMP
       }
       
    }
}
