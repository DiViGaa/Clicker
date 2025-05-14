using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WindowManager;
using WindowManager.Dialogs;

namespace Upgrades
{
    public class UpgradeButton : MonoBehaviour, IDisposable
    {
        [SerializeField] private Button upgradeButton;
        
        [SerializeField] private Image upgradeImage;
        [SerializeField] private TextMeshProUGUI  upgradeNameText;
        [SerializeField] private TextMeshProUGUI  costText;
        
        private Upgrade _upgrade;
        public void AddListener(UnityAction listener) => upgradeButton.onClick.AddListener(listener);
        
        public void Initialize(Upgrade upgradeData)
        {
            _upgrade = upgradeData;
            upgradeButton.onClick.AddListener(ShowUpgradeInfo);
            upgradeImage.sprite = Resources.Load<Sprite>(upgradeData.ImageName);
            upgradeNameText.text = upgradeData.Name;
            costText.text = upgradeData.Cost.ToString();
        }

        private void ShowUpgradeInfo()
        {
            var dialog =  DialogManager.ShowDialog<UpgradeDialog>();
            dialog.Initialize(upgradeImage, _upgrade);
            ShopScreenDialog.OnCloseDialog.Invoke(); //TEMP
        }
        
        public void Dispose()
        {
            upgradeButton.onClick.RemoveListener(ShowUpgradeInfo);
        }
    }
}
