using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkTabLayout : PanelExtendtion
{
    public Button TABNews;
    public Button TABExhibition;
    public Button TABAR;
    public Button TABARBus;
    public Button TABActivity;
    public Button TABAbout;

    void Start()
    {
        TABNews.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelNew); });
        TABExhibition.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelExhibition); });
        TABAR.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAR); });
        TABARBus.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelArtBus); });
        TABActivity.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelActivity); });
        TABAbout.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAbout); });

        CloseSelfImmediate();
    }

    void SwitchToPanel(PageBehaviour targetPanel)
    {
        PageBehaviour currentPanel = UITabCenter.instance.currentPanel;
        ClosePanelImmediate(currentPanel.canvas, ()=>{
            currentPanel.DoPageClose();
        });
        OpenPanelImmediate(targetPanel.canvas, ()=>{
            targetPanel.DoPageOpen();
        });
        UITabCenter.instance.currentPanel = targetPanel;

        //Kill all Flow window
        foreach (var item in UITabCenter.instance.flowWindows)
        {
            item.KillSelf();
        }
        UITabCenter.instance.flowWindows.Clear();
    }
}
