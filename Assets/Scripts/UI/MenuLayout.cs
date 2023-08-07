using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLayout : PanelExtendtion
{
    public Button BTNAR;
    public Button BTNNews;
    public Button BTNExhibition;
    public Button BTNArtBus;
    public Button BTNActivity;
    public Button BTNAbout;
    public WorkTabLayout workTabLayout;
    void Start()
    {
        BTNAR.onClick.          AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAR); workTabLayout.ToAR();});
        BTNNews.onClick.        AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelNew); workTabLayout.ToNews();});
        BTNExhibition.onClick.  AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelExhibition); });
        BTNArtBus.onClick.      AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelArtBus); });
        BTNActivity.onClick.    AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelActivity); });
        BTNAbout.onClick.       AddListener(() => { SwitchToPanel(UITabCenter.instance.PanelAbout); });

        //OpenSelf(null);
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
