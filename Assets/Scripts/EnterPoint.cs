using System;
using Ads;
using Locator;
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
    
    private MainScreenDialog _mainScreenDialog;
    private void Start()
    {
        _adsInitializer = new AdsInitializer();
        _interstitialAd = new InterstitialAd();
        _upgradeCreator = new UpgradeCreator();
        
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
    }

    private void Initialize()
    {
        _adsInitializer.Initialize();
        _interstitialAd.Initialize();
        _upgradeCreator.Init();
    }

    private void OnDisable() => Dispose();

    public void Dispose()
    {
        _mainScreenDialog.Dispose();
    }
}
