using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WindowManager;
using WindowManager.Dialogs;

namespace Upgrades
{
    public class UpgradeButton : MonoBehaviour, IDisposable
    {
        [SerializeField] private Button upgradeButton;
        [SerializeField] private Image upgradeImage;
        public void AddListener(UnityAction listener) => upgradeButton.onClick.AddListener(listener);
        
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
