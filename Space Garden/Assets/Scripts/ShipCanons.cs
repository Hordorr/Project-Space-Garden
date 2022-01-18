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
        UpdateCanonTransform();

    }
    void UpdateCanonTransform(){
        Vector3 canonLeftPosition = canonLeftPositionRef.action.ReadValue<Vector3>();
        
        Vector3 canonRightPosition = canonRightPositionRef.action.ReadValue<Vector3>();
        Quaternion canonLeftRotation = canonLeftRotationRef.action.ReadValue<Quaternion>();
        Quaternion canonRightRotation = canonRightRotationRef.action.ReadValue<Quaternion>();

        Debug.Log(canonLeftPosition.ToString());
        canonLeftPosition = Quaternion.AngleAxis(-90, Vector3.up) * canonLeftPosition;
        canonRightPosition = Quaternion.AngleAxis(-90, Vector3.up)* canonRightPosition;

        canonLeft.transform.localPosition=canonLeftPosition + canonLeftBasePosition;
        Debug.Log(canonLeftPosition.ToString());
        //canonLeft.transform.localRotation=canonLeftRotation;
        canonRight.transform.localPosition=canonRightPosition + canonRightBasePosition;
        //canonRight.transform.localRotation=canonRightRotation;

       

        

    }
    
}
