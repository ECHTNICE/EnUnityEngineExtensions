using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnApplication.SetTargetFrameRate120();
        EnApplication.LogSystemInfo();
    }

}
