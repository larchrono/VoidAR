using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchAreaConfig : MonoBehaviour
{
    public static bool useTouchColor = false;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();

        if(useTouchColor)
            image.color = new Color(AssetConfig.Instance.TouchAreaColor.r, AssetConfig.Instance.TouchAreaColor.g, AssetConfig.Instance.TouchAreaColor.b, 0.35f);
        else
            image.color = new Color(0, 0, 0, 0);
    }
}
