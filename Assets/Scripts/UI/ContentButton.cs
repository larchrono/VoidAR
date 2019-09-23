using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentButton : MonoBehaviour
{
    Button button;
    public Image Icon;
    public Text Title;
    public Text Content;

    public Sprite useIcon;
    public string useTitle;
    [TextArea] public string useContent;
    void Start()
    {
        button = GetComponent<Button>();
    }

    public void OpenFlowWindow(GameObject prefab) {
        GameObject flowWindow = Instantiate(prefab, UITabCenter.instance.parentCanvas.transform);
        UITabCenter.instance.flowWindows.Add(flowWindow.GetComponent<PanelWindow>());
    }
}
