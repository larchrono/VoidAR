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

    List<Button> TabBTNS; 
    void Awake(){
        TabBTNS = new List<Button>();
        TabBTNS.Add(TABNews);
        TabBTNS.Add(TABExhibition);
        TabBTNS.Add(TABAR);
        TabBTNS.Add(TABARBus);
        TabBTNS.Add(TABActivity);
        TabBTNS.Add(TABAbout);
    }

    public void ToAR(){
        foreach (var item in TabBTNS)
        {
            item.interactable = true;
        }
        TABAR.interactable = false;
    }
    public void ToNews(){
        foreach (var item in TabBTNS)
        {
            item.interactable = true;
        }
        TABNews.interactable = false;
    }

    void Start()
    {
        TABNews.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelNew, TABNews); });
        TABExhibition.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelExhibition, TABExhibition); });
        TABAR.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAR, TABAR); });
        TABARBus.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelArtBus, TABARBus); });
        TABActivity.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelActivity, TABActivity); });
        TABAbout.onClick.AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAbout, TABAbout); });

        CloseSelfImmediate();
    }

    void SwitchToPanel(PageBehaviour targetPanel, Button tapBTN)
    {
        foreach (var item in TabBTNS)
        {
            item.interactable = true;
        }
        tapBTN.interactable = false;

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
