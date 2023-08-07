﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MarkerClick : MonoBehaviour , IPointerDownHandler
{
    [HimeLib.HelpBox] public string tip = "務必於Camera上添加<Physics Raycaster>";
    POI.MarkerHelper marker;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(marker == null)
            marker = GetComponentInParent<POI.MarkerHelper>();

        marker.OnMarkerClick?.Invoke();
    }
}
