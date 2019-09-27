using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2018_3 && UNITY_ANDROID
using UnityEngine.Android;
#endif

public class RequirePermissions : MonoBehaviour
{
    public GameObject GoogleMap;

    void Awake()
    {
        #if UNITY_2018_3_OR_NEWER && UNITY_ANDROID
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation))
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);
        #endif
    }

    IEnumerator Start(){
        #if UNITY_2018_3_OR_NEWER && UNITY_ANDROID
        /* Since 2018.3, Unity doesn't automatically handle permissions on Android, so as soon as
         * the menu is displayed, ask for camera permissions. */
         while(true){
             int totalRequest = 0;

            if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.Camera)) {
                UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.Camera);
            } else totalRequest++;
            if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation)) {
                UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);
            } else totalRequest++;
            if(!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.ExternalStorageWrite)){
                UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.ExternalStorageWrite);
            } else totalRequest++;
            if(!UnityEngine.Android.Permission.HasUserAuthorizedPermission("android.permission.INTERNET")){
                UnityEngine.Android.Permission.RequestUserPermission("android.permission.INTERNET");
            } else totalRequest++;

            yield return new WaitForSeconds(1.0f);

            if(totalRequest >= 4)
                break;
         }
        #endif
        GoogleMap.SetActive(true);
        yield return null;
    }
}
