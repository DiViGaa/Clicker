using Ads;
using Locator;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

namespace WindowManager.Dialogs
{
    public class ShopScreenDialog : Dialog
    {
       [SerializeField] private Button backButton;
       [SerializeField] private Button addButton;
       
       [SerializeField] private GridLayoutGroup gridLayoutGroup;
       
       private UpgradeButton[] _upgrades;

       public void Initialize()
       {
           backButton.onClick.AddListener(BackToMainScreen);
           addButton.onClick.AddListener(ShowAdd);
           FillGridList();
           InitializeUpgrades();
       }

       private void InitializeUpgrades()
       {
           foreach (var upgrade in _upgrades)
           {
               upgrade.Initialize();
               upgrade.AddListener(Hide);
           }
       }

       private void FillGridList()
       {
           _upgrades = gridLayoutGroup.gameObject.GetComponentsInChildren<UpgradeButton>();
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
           DisposeUpgrades();
       }

       private void DisposeUpgrades()
       {
           foreach (var upgrade in _upgrades)
               upgrade.Dispose();
       }
    }
}
