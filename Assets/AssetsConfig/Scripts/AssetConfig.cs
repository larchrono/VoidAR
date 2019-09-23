using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Utilities;

[GlobalConfig("Resources/")]
public class AssetConfig : GlobalConfig<AssetConfig>
{
    public bool UseTouchColor = true;
    public Color TouchAreaColor = Color.green;

    public GameObject prefab_flowWindow;

}
