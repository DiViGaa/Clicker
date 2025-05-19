using JSON;
using LocalizationTool;
using Locator;
using Setting;
using Sound;
using UnityEngine;
using UnityEngine.UI;

namespace WindowManager.Dialogs
{
    public class SettingDialog : Dialog
    {
		[SerializeField] private Button uabutton;
        [SerializeField] private Button usabutton;
        [SerializeField] private Button backToSettingbutton;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private Slider musicSlider;

        public void Initialize()
        {
            uabutton.onClick.AddListener(SwitchToUaButton);
            usabutton.onClick.AddListener(SwitchToEnButton);
            backToSettingbutton.onClick.AddListener(BackToMenu);
            
            SetSliderVolume();
            
            soundSlider.onValueChanged.AddListener(ChangeUiSlider);
            musicSlider.onValueChanged.AddListener(ChangeMusicSlider);
        }

        private void ChangeUiSlider(float value)
        {
            ServiceLocator.Current.Get<SettingManager>().SetUiVolume(value);
        }

        private void ChangeMusicSlider(float value)
        {
            ServiceLocator.Current.Get<SettingManager>().SetMusicVolume(value);
        }

        private void SetSliderVolume()
        {
            soundSlider.value = ServiceLocator.Current.Get<SoundManager>().UIVolume;
            musicSlider.value = ServiceLocator.Current.Get<SoundManager>().MusicVolume;
        }

        private void SwitchToEnButton()
        {
            LocalizationSystem.SetLanguageByEnum(LocalizationSystem.Language.English);
            ServiceLocator.Current.Get<SettingManager>().SwitchLanguage(1);
            ReloadSettings();
        }

        private void SwitchToUaButton()
        {
            ServiceLocator.Current.Get<SettingManager>().SwitchLanguage(0);
            ServiceLocator.Current.Get<SoundManager>().PlaySound("ui", "UI");
            ReloadSettings();
        }

        private void ReloadSettings()
        {
            var dialog = DialogManager.ShowDialog<SettingDialog>();
            dialog.Initialize();
            Hide();
        }

        private void BackToMenu()
        {
            var dialog = DialogManager.ShowDialog<MenuScreenDialog>();
            ServiceLocator.Current.Get<SoundManager>().PlaySound("ui", "UI");
            ServiceLocator.Current.Get<SettingManager>().Save();
            dialog.Initialize();
            Hide();
        }
    }
}
