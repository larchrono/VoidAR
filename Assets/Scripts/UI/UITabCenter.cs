using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabCenter : MonoBehaviour
{
    public static UITabCenter instance;

    void Awake() {
        instance = this;
    }

    void Start(){
        PanelMenu.interactable = true;
        PanelMenu.alpha = 1;
        PanelMenu.blocksRaycasts = true;

        // Panel_MenuTab.interactable = true;
        // Panel_MenuTab.alpha = 1;
        // Panel_MenuTab.blocksRaycasts = true;
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

    public RectTransform PanelWarnningLocation;
    public RectTransform PanelWarnningCamera;


    public ArtistLayout Prefab_ArtistFlowWindow;

    public PanelDebug DebugPanel;
    public AR2DLayout AR2DPanel;
    public AR3DLayout AR3DPanel;
}
