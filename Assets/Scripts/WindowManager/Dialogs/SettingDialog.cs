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
            throw new System.NotImplementedException();
        }

        private void SwitchToUa()
        {
            throw new System.NotImplementedException();
        }

        private void BackToSetting()
        {
            var dialog = DialogManager.ShowDialog<SettingDialog>();
            dialog.Initialize();
            Hide();
        }
    }
}
