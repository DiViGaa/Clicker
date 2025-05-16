using LocalizationTool;
using UnityEngine;
using UnityEngine.UI;

namespace WindowManager.Dialogs
{
    public class SettingDialog : Dialog
    {
		[SerializeField] private Button uabutton;
        [SerializeField] private Button usabutton;
        [SerializeField] private Button backToSettingbutton;

        public void Initialize()
        {
            uabutton.onClick.AddListener(SwitchToUa);
            usabutton.onClick.AddListener(SwitchToUSA);
            backToSettingbutton.onClick.AddListener(BackToSetting);
        }

        private void SwitchToUSA()
        {
            LocalizationSystem.SwitchLanguage(LocalizationSystem.Language.English);
            ReloadSettings();

        }

        private void SwitchToUa()
        {
            LocalizationSystem.SwitchLanguage(LocalizationSystem.Language.Ukrainian);
            ReloadSettings();
        }

        private void ReloadSettings()
        {
            var dialog = DialogManager.ShowDialog<SettingDialog>();
            dialog.Initialize();
            Hide();
        }

        private void BackToSetting()
        {
            var dialog = DialogManager.ShowDialog<MenuScreenDialog>();
            dialog.Initialize();
            Hide();
        }
    }
}
