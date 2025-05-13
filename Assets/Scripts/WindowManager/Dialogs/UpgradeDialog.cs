using Locator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WindowManager.Dialogs
{
    public class UpgradeDialog : Dialog
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button buyButton;
        [SerializeField] private TextMeshProUGUI lvlText;
        [SerializeField] private TextMeshProUGUI detailsText;
        [SerializeField] private Image upgradeImage;

        public void Initialize(Image upgradeImage)
        {
            closeButton.onClick.AddListener(HideDialog); 
            this.upgradeImage.sprite = upgradeImage.sprite;
        }

        private void HideDialog()
        {
            Hide();
            var dialog = DialogManager.ShowDialog<ShopScreenDialog>();
            dialog.Initialize();
        }
    }
}
