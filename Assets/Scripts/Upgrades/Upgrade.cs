using System;
using UnityEngine;
using UnityEngine.UI;
using WindowManager;
using WindowManager.Dialogs;

namespace Upgrades
{
    public class Upgrade : MonoBehaviour, IDisposable
    {
        [SerializeField] private Button upgradeButton;
        [SerializeField] private Image upgradeImage;
        
        public void Initialize()
        {
            upgradeButton.onClick.AddListener(ShowUpgradeInfo);
        }

        private void ShowUpgradeInfo()
        {
            var dialog =  DialogManager.ShowDialog<UpgradeDialog>();
            dialog.Initialize(upgradeImage);
        }
        
        public void Dispose()
        {
            upgradeButton.onClick.RemoveListener(ShowUpgradeInfo);
        }
    }
}
