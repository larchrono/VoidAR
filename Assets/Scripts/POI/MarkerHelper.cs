using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POI
{
    [RequireComponent(typeof(SphereCollider))]
    public class MarkerHelper : MonoBehaviour
    {
        public SpriteRenderer useSprite;
        public Transform GizmoColliRange;
        
        [Header("Runtime data")]
        public POIData data;
        public global::POIData oldData;
        

        public Action OnMarkerClick;
        SphereCollider eventCollider;
        float defaultSize;
        void Awake()
        {
            eventCollider = GetComponent<SphereCollider>();
            defaultSize = eventCollider.radius;
        }

        void Start(){
            useSprite.sprite = POI.POIManager.instance.POISprites[(int)oldData.typeOfPOI];
        }

        public void SetGizmoRange(float src){
            eventCollider.radius = defaultSize * src;

            if(GizmoColliRange)
                GizmoColliRange.localScale = new Vector3(defaultSize * src * 2, defaultSize * src * 2, defaultSize * src * 2);
        }

        public void TrigUserArriveMarker(){
            data.isNear = true;
            POIManager.instance.OnUserArrivedPoi?.Invoke(data);
        }

        public void LeavePOI(){
            data.isNear = false;
        }
    }
}