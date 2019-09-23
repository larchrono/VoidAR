using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class POIAction : MonoBehaviour , IPointerDownHandler
{
    public POIData data;

    public void OnPointerDown(PointerEventData eventData)
    {
        ARInfoLayout.instance.currentData = data;

        if(data.typeOfPOI == POIData.TypeOfPOI.AR)
            ARInfoLayout.instance.RefreshInfoAR_FromPOI();
        else if (data.typeOfPOI == POIData.TypeOfPOI.OldPicture)
            ARInfoLayout.instance.RefreshInfoOldPhoto_FromPOI();
        else if (data.typeOfPOI == POIData.TypeOfPOI.Bus)
            ARInfoLayout.instance.RefreshInfoBus_FromPOI();
        else if (data.typeOfPOI == POIData.TypeOfPOI.ArtGallery)
            ARInfoLayout.instance.RefreshInfoGallery_FromPOI();

        ARInfoLayout.instance.SetMeterDistanceDisplay(PlayerEvent.instance.GetTargetDistance(data.transform));
        
        ARInfoLayout.instance.OpenSelf(null);
    }
}
