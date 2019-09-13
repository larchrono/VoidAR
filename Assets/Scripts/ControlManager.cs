using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public List<GameObject> allModel;
    public GameObject currentObject;
    public int CurrentIndex;

    void Start(){
        CurrentIndex = 0;
        OpenModel(CurrentIndex);
    }

    void OpenModel(int index){
        foreach (var item in allModel)
        {
            item.SetActive(false);
        }
        allModel[index].SetActive(true);
        currentObject = allModel[index];
    }

    public void LeftShift(){
        CurrentIndex = (CurrentIndex - 1 ) < 0 ? allModel.Count - 1 : CurrentIndex - 1;
        OpenModel(CurrentIndex);
    }

    public void RightShift(){
        CurrentIndex = (CurrentIndex + 1 ) % allModel.Count;
        OpenModel(CurrentIndex);
    }
}
