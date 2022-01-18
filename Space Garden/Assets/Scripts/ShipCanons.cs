using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipCanons : MonoBehaviour
{
    public GameObject canonLeft=null;
    public GameObject canonRight=null;    
    public InputActionReference canonLeftPositionRef=null;
    public InputActionReference canonRightPositionRef=null;
    public InputActionReference canonLeftRotationRef=null;
    public InputActionReference canonRightRotationRef=null;
    private Vector3 canonLeftBasePosition;
    private Vector3 canonRightBasePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        canonLeftBasePosition=canonLeft.transform.localPosition;
        canonRightBasePosition=canonRight.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void UpdateCanonTransform(){
        
        
       

        

    }
    
}
