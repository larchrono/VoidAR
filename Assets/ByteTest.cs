using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteTest : MonoBehaviour
{
    public TextAsset imageAsset;

    // Start is called before the first frame update
    void Start()
    {
        do
        {
            Debug.Log("1");
            Debug.Log("2");
            break;
            Debug.Log("3");

        } while (false);

        Debug.Log("Finished");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
