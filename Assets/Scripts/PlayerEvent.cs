using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEvent : MonoBehaviour
{
    public static PlayerEvent instance;
    public Transform FollowNavegater;

    //GetDistance distanceTool;

    public Action<double> OnUpdateDistance;
    
    public List<POIData> arrivePOI = new List<POIData>();

    void Awake(){
        instance = this;
    }

    void Start()
    {
        //distanceTool = GetComponent<GetDistance>();
        //StartCoroutine(DoSendDistance(distanceTool.updateRate));

        StartCoroutine(DelayOpenCollider());
    }

    IEnumerator DelayOpenCollider(){
        yield return new WaitForSeconds(1.0f);
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FollowNavegater.position;
    }

    public void SetTargetGoal(Transform target){
        //distanceTool.waypoints[1] = target;
    }

    public void ClearTargetGoal(){
        //distanceTool.waypoints[1] = transform;
    }

    public IEnumerator DoSendDistance(float rate){
        while(true){
            //OnUpdateDistance?.Invoke(distanceTool.metersDist);
            yield return new WaitForSeconds(rate);
        }
    }

    public double GetTargetDistance(Transform target){
        //return distanceTool.GetSingleDistance(transform, target);
        return 0;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering~ ");
        if (other.tag == "POI")
        {
            var poi = other.GetComponent<POIData>();
            arrivePOI.Add(poi);
            ARInfoLayout.instance.PanelNaving.FinishedNaving(poi, GetTargetDistance(poi.transform));

            //Shake Device
            Handheld.Vibrate();


            if(other.gameObject.transform.childCount == 0)
                return;

            Transform child = other.gameObject.transform.GetChild(0);
            if(child != null)
                child.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "POI")
        {
            //arrivePOI = null;
            var poi = other.GetComponent<POIData>();
            arrivePOI.Remove(poi);

            if(other.gameObject.transform.childCount == 0)
                return;

            Transform child = other.gameObject.transform.GetChild(0);
            if(child != null)
                child.GetComponent<Renderer>().material.color = Color.white;
            
        }
    }
}
