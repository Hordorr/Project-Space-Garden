using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRangeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject GatherRangeGo;
    void Start()
    {
       GatherRangeGo =  transform.parent.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
