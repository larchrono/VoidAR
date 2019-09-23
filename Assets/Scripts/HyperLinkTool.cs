using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLinkTool : MonoBehaviour
{
    public void OpenHyperLink(string link){
        Application.OpenURL(link);
    }
}
