using LocalizationTool;
using Locator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

namespace WindowManager.Dialogs
{
    public class UpgradeDialog : Dialog
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button buyButton;
        [SerializeField] private TextMeshProUGUI lvlText;
        [SerializeField] private TextMeshProUGUI detailsText;
        [SerializeField] private Image upgradeImage;
        [SerializeField] private TextLocaliserUI upgradeTextLocaliser;

        public void Initialize(Image upgradeImage, Upgrade upgrade)
        {
            closeButton.onClick.AddListener(HideDialog); 
            this.upgradeImage.sprite = upgradeImage.sprite;
            lvlText.text = upgrade.CurrentLevel.ToString();
            detailsText.text = upgrade.Description;
            upgradeTextLocaliser.SetKey(upgrade.LocalizationKey);
        }

        private void HideDialog()
        {
            Hide();
            var dialog = DialogManager.ShowDialog<ShopScreenDialog>();
            dialog.Initialize();
        }
    }
}
