using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2018_3 && UNITY_ANDROID
using UnityEngine.Android;
#endif

public class DaneiCenter : MonoBehaviour
{

    private void Awake() {
#if UNITY_2018_3_OR_NEWER && UNITY_ANDROID
        /* Since 2018.3, Unity doesn't automatically handle permissions on Android, so as soon as
         * the menu is displayed, ask for camera permissions. */
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.Camera)) {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.Camera);
        }
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
