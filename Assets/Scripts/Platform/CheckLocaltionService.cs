﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLocaltionService : MonoBehaviour
{
	[HimeLib.HelpBox] public string tip ="檢查是否有GPS";

	public System.Action OnApplicationRestartRequire;
    IEnumerator Start()
    {
        // Wait until service initializes
        int maxWait = 20;
        // Wait until service initializes
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		// Service didn't initialize in 30 seconds
		if (maxWait < 1) {
			print("Unable to initialize location services.\nPlease check your location settings and restart the App");

			yield return StopApplication();
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			print("Unable to determine your location.\nPlease check your location setting and restart this App");

			yield return StopApplication();
		}
    }

    IEnumerator StopApplication(){
		OnApplicationRestartRequire?.Invoke();
		Debug.Log("In Quit Application");

		while(true){
			yield return new WaitForSeconds(5);
		}
	}
}
