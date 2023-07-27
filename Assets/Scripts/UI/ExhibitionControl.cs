using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExhibitionControl : MonoBehaviour
{
    public Button BTN_Back;
    public Button BTN_EX_Main;
    public Button BTN_EX_AR;
    public Button BTN_Mum1;
    public Button BTN_Mum2;
    public Button BTN_Mum3;

    public PanelExtendtion PL_Theme;
    public PanelExtendtion PL_Street;
    public PanelExtendtion PL_MUM1;
    public PanelExtendtion PL_MUM2;
    public PanelExtendtion PL_MUM3;

    public Stack<PanelExtendtion> stackPanel = new Stack<PanelExtendtion>();
    void Start()
    {
        BTN_Back.gameObject.SetActive(false);
        BTN_Back.onClick.AddListener(BackPage);

        BTN_EX_Main.onClick.AddListener(ShowBack);
        BTN_EX_AR.onClick.AddListener(ShowBack);
        BTN_EX_Main.onClick.AddListener(delegate{ShowPlanel(PL_Theme);});
        BTN_EX_AR.onClick.AddListener(delegate{ShowPlanel(PL_Street);});

        BTN_Mum1.onClick.AddListener(delegate{ShowPlanel(PL_MUM1);});
        BTN_Mum2.onClick.AddListener(delegate{ShowPlanel(PL_MUM2);});
        BTN_Mum3.onClick.AddListener(delegate{ShowPlanel(PL_MUM3);});


        PL_Theme.CloseSelfImmediate();
        PL_Street.CloseSelfImmediate();
        PL_MUM1.CloseSelfImmediate();
        PL_MUM2.CloseSelfImmediate();
        PL_MUM3.CloseSelfImmediate();
    }

    void BackPage(){
        var pl = PopPanel();
        pl.CloseSelf(null);

        if(stackPanel.Count == 0){
            BTN_Back.gameObject.SetActive(false);
        }
    }

    void ShowPlanel(PanelExtendtion panel){
        panel.OpenSelf(null);
        StackPanel(panel);
    }

    void ShowBack(){
        BTN_Back.gameObject.SetActive(true);
    }

    void StackPanel(PanelExtendtion panel){
        stackPanel.Push(panel);
    }

    PanelExtendtion PopPanel(){
        return stackPanel.Pop();
    }
}
