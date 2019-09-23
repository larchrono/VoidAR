using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeLayout : PanelExtendtion
{
    public Button BTNHome;
    
    void Start()
    {
        BTNHome.onClick.AddListener(GoToMenu);
    }

    void GoToMenu(){
        CloseSelf();
        OpenPanel(UITabCenter.instance.PanelMenu, null);
    }
}
