using System;
using Ads;
using JSON;
using Locator;
using Setting;
using Sound;
using UI;
using UnityEngine;
using Upgrades;
using WindowManager;
using WindowManager.Dialogs;

public class EnterPoint : MonoBehaviour,IDisposable
{
    [SerializeField] private GUIHolder guiHolder;
    private AdsInitializer  _adsInitializer;
    private InterstitialAd _interstitialAd;
    private UpgradeCreator  _upgradeCreator;
    private SoundManager  _soundManager;
    private SettingManager  _settingManager;
    private JsonSetting _settingData;
    
    private MainScreenDialog _mainScreenDialog;
    private void Start()
    {
        _adsInitializer = new AdsInitializer();
        _interstitialAd = new InterstitialAd();
        _upgradeCreator = new UpgradeCreator();
        _soundManager = new SoundManager();
        _settingManager = new SettingManager(_soundManager);
        _settingData = new JsonSetting();
        
        Register();
        CreateMainScreenDialog();
        Initialize();
    }
    
    private void CreateMainScreenDialog()
    {
        _mainScreenDialog = DialogManager.ShowDialog<MainScreenDialog>();
        _mainScreenDialog.Initialize();
    }

    private void Register()
    {
        ServiceLocator.Initialize();
        
        ServiceLocator.Current.Register<GUIHolder>(guiHolder);
        ServiceLocator.Current.Register<AdsInitializer>(_adsInitializer);
        ServiceLocator.Current.Register<InterstitialAd>(_interstitialAd);
        ServiceLocator.Current.Register<UpgradeCreator>(_upgradeCreator);
        ServiceLocator.Current.Register<SoundManager>(_soundManager);
        ServiceLocator.Current.Register<SettingManager>(_settingManager);
        ServiceLocator.Current.Register<JsonSetting>(_settingData);

    }

    private void Initialize()
    {
        _adsInitializer.Initialize();
        _interstitialAd.Initialize();
        _upgradeCreator.Initialize();
        _settingManager.Initialize();
        
    }

    private void OnDisable() => Dispose();

    public void Dispose()
    {
        _mainScreenDialog.Dispose();
    }
}
