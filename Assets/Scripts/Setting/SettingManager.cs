using JSON;
using LocalizationTool;
using Locator;
using Sound;

namespace Setting
{
    public class SettingManager : IService
    {
        private SettingData _settingData;
        private readonly SoundManager _soundManager;

        public SettingManager(SoundManager soundManager)
        {
            _soundManager = soundManager;
        }

        public void Initialize()
        {
            _settingData = ServiceLocator.Current.Get<JsonSetting>().LoadJson("Setting.json");

            LocalizationSystem.SetLanguageByIndex(_settingData.LanguageIndex);
            _soundManager.Initialize(_settingData.MusicVolume, _settingData.UIVolume);
        }

        public void Save()
        {
            ServiceLocator.Current.Get<JsonSetting>().SaveJson("Setting.json", _settingData);
        }

        public void SwitchLanguage(int languageIndex)
        {
            LocalizationSystem.SetLanguageByIndex(languageIndex);
            _settingData.LanguageIndex = languageIndex;
        }

        public void SetMusicVolume(float musicVolume)
        {
            _settingData.MusicVolume = musicVolume;
            _soundManager.ChangeMusicVolume(musicVolume);
        }

        public void SetUiVolume(float uiVolume)
        {
            _settingData.UIVolume = uiVolume;
            _soundManager.ChangeUiVolume(uiVolume);
        }
    }
}