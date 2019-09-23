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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
