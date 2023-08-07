using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POI
{
    public class UserCollision : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("POI"))
            {
                var markerHelper = other.GetComponent<POI.MarkerHelper>();

                markerHelper?.TrigUserArriveMarker();

                //Shake Device
                //Handheld.Vibrate();

                if (other.gameObject.transform.childCount == 0)
                    return;

                Transform child = other.gameObject.transform.GetChild(0);
                if (child != null)
                    child.GetComponent<Renderer>().material.color = POIManager.instance.UserCollisionColor;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("POI"))
            {
                var markerHelper = other.GetComponent<POI.MarkerHelper>();

                markerHelper?.LeavePOI();

                if (other.gameObject.transform.childCount == 0)
                    return;

                Transform child = other.gameObject.transform.GetChild(0);
                if (child != null)
                    child.GetComponent<Renderer>().material.color = Color.white;

            }
        }
    }
}