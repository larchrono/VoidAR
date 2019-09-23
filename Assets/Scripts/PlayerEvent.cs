using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEvent : MonoBehaviour
{
    public static PlayerEvent instance;

    GetDistance distanceTool;

    public Action<double> OnUpdateDistance;

    void Awake(){
        instance = this;
    }

    void Start()
    {
        distanceTool = GetComponent<GetDistance>();
        StartCoroutine(DoSendDistance(distanceTool.updateRate));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTargetGoal(Transform target){
        distanceTool.waypoints[1] = target;
    }

    public void ClearTargetGoal(){
        distanceTool.waypoints[1] = transform;
    }

    public IEnumerator DoSendDistance(float rate){
        while(true){
            OnUpdateDistance?.Invoke(distanceTool.metersDist);
            yield return new WaitForSeconds(rate);
        }
    }

    public double GetTargetDistance(Transform target){
        return distanceTool.GetSingleDistance(transform, target);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "POI")
        {
            other.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            other.gameObject.GetComponent<POIData>().CanStartAR = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "POI")
        {
            other.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
            other.gameObject.GetComponent<POIData>().CanStartAR = false;
        }
    }
}
