using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class POIAction : MonoBehaviour , IPointerDownHandler
{
    public POIData data;

    public void OnPointerDown(PointerEventData eventData)
    {
        ARInfoLayout.instance.OpenPanelRegular(data, PlayerEvent.instance.GetTargetDistance(data.transform));
    }
}
