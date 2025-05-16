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
            exitButton.onClick.AddListener(Exit);
        }

        private void BackToMainScreen()
        {
            var dialog = DialogManager.ShowDialog<MainScreenDialog>();
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
