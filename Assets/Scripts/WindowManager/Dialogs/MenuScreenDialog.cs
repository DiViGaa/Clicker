using Locator;
using Sound;
using UnityEngine;
using UnityEngine.UI;

namespace WindowManager.Dialogs
{
    public class MenuScreenDialog : Dialog
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button exitButton;

        public void Initialize()
        {
            resumeButton.onClick.AddListener(BackToMainScreen);
            settingButton.onClick.AddListener(ShowSettings);
            exitButton.onClick.AddListener(Exit);
        }

        private void ShowSettings()
        {
            var dialog = DialogManager.ShowDialog<SettingDialog>();
            ServiceLocator.Current.Get<SoundManager>().PlaySound("ui", "UI");
            dialog.Initialize();
            Hide();
        }

        private void BackToMainScreen()
        {
            var dialog = DialogManager.ShowDialog<MainScreenDialog>();
            ServiceLocator.Current.Get<SoundManager>().PlaySound("ui", "UI");
            dialog.Initialize();
            Hide();
        }

        private void Exit()
        {
            Application.Quit();
        }

        public override void Dispose()
        {
            resumeButton.onClick.RemoveAllListeners();
            settingButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }
        
    }
}
