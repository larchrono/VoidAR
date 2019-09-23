using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLayout : PanelExtendtion
{
    public Button BTNNews;
    public Button BTNExhibition;
    public Button BTNAR;
    public Button BTNArtBus;
    public Button BTNActivity;
    public Button BTNAbout;
    void Start()
    {
        BTNNews.onClick.        AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelNew); });
        BTNExhibition.onClick.  AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelExhibition); });
        BTNAR.onClick.          AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAR); });
        BTNArtBus.onClick.      AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelArtBus); });
        BTNActivity.onClick.    AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelActivity); });
        BTNAbout.onClick.       AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAbout); });

        OpenSelf(null);
    }

    void SwitchToPanel(PageBehaviour targetPanel)
    {
        CloseSelf();
        OpenPanel(UITabCenter.instance.Panel_MenuTab, null);
        OpenPanel(targetPanel.canvas, ()=>{
            targetPanel.DoPageOpen();
        });
        UITabCenter.instance.currentPanel = targetPanel;
    }


}
