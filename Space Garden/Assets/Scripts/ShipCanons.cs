using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipCanons : MonoBehaviour
{
    public int range=100;
    public GameObject canonLeft=null;
    public GameObject canonRight=null;
    public GameObject leftHandTarget=null;
    public GameObject rightHandTarget=null;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        leftHandTarget.transform.Translate (new Vector3 (0,0,range));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCanonLeft();
        UpdateCanonRight();
        
    }

    void UpdateCanonLeft(){
        canonLeft.transform.LookAt(leftHandTarget.transform);
        canonLeft.transform.Rotate(new Vector3 (0,90,0));

        //Physics.Raycast(leftHand.transform.position,leftHand.transform.TransformDirection(Vector3.forward), out leftHit, Mathf.Infinity);   

    }
    
    void UpdateCanonRight(){
        canonRight.transform.LookAt(rightHandTarget.transform);
        canonRight.transform.Rotate(new Vector3 (0,90,0));
        

    }
    
    
}
