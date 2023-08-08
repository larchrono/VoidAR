using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetConfig : MonoBehaviour
{
    public static AssetConfig Instance;

    void Awake(){
        Instance = this;
    }

    public bool UseTouchColor = true;
    public Color TouchAreaColor = Color.green;

    public GameObject prefab_flowWindow;

}
