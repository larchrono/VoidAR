using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDebug : MonoBehaviour
{
    public static PanelDebug instance;
    void Awake() {
        instance = this;
    }
}
