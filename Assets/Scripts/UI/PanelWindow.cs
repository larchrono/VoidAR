using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelWindow : PanelExtendtion
{
    public Button BTNCloseSelf;
    void Start()
    {
        BTNCloseSelf.onClick.AddListener(DoClose);
    }

    void DoClose(){
        UITabCenter.instance.flowWindows.Remove(this);
        CloseSelf(KillSelf);
    }

    public void KillSelf(){
        Destroy(gameObject);
    }
}
