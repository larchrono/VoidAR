using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabCenter : MonoBehaviour
{
    public static UITabCenter instance;

    void Awake() {
        instance = this;
    }

    [HideInInspector] public PageBehaviour currentPanel;
    public List<PanelWindow> flowWindows;

    public Canvas parentCanvas;
    public CanvasGroup PanelHome;
    public CanvasGroup PanelMenu;
    public CanvasGroup Panel_MenuTab;
    public PageBehaviour PanelNew;
    public PageBehaviour PanelExhibition;
    public PageBehaviour PanelAR;
    public PageBehaviour PanelArtBus;
    public PageBehaviour PanelActivity;
    public PageBehaviour PanelAbout;


    public ArtistLayout Prefab_ArtistFlowWindow;
}
