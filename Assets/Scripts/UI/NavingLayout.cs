using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavingLayout : PanelExtendtion
{
    public Button BTNClose;
    void Start()
    {
        BTNClose.onClick.AddListener(DoBTNClose);

        CloseSelf();
    }

    void DoBTNClose(){
        CloseSelf();
        ARInfoLayout.instance.Stop2DGo();
        ARInfoLayout.instance.OpenSelf(null);
    }

    public void FinishedNaving(POIData data, double distance){
        CloseSelf();
        ARInfoLayout.instance.Stop2DGo();
        ARInfoLayout.instance.OpenPanelRegular(data, distance);
    }
}
