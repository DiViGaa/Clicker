using System;
using Ads;
using Locator;
using UI;
using UnityEngine;
using WindowManager;
using WindowManager.Dialogs;

public class EnterPoint : MonoBehaviour,IDisposable
{
    [SerializeField] private GUIHolder guiHolder;
    private AdsInitializer  _adsInitializer;
    private InterstitialAd _interstitialAd;
    
    private MainScreenDialog _mainScreenDialog;
    private void Start()
    {
        _adsInitializer = new AdsInitializer();
        _interstitialAd = new InterstitialAd();
        
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
    }

    private void Initialize()
    {
        _adsInitializer.Initialize();
        _interstitialAd.Initialize();
    }

    private void OnDisable() => Dispose();

    public void Dispose()
    {
        _mainScreenDialog.Dispose();
    }
}
