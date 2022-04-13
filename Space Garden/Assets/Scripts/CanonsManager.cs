using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonsManager : MonoBehaviour
{
    
    public int range=10000;
    public float leftCanonRotationSpeed = 10;
    public float rightCanonRotationSpeed = 10;
    public GameObject canonLeft=null;
    public GameObject canonRight=null;
    public GameObject leftHandTarget=null;
    public GameObject rightHandTarget=null;
    public float leftCanonCooldown=0.5F;
    public float rightCanonCooldown=0.5F;
    private float leftCanonTimer=0;
    private float rightCanonTimer=0;
    private GameObject leftHand;
    private GameObject rightHand;
    
    public InputActionReference ShotLeft=null;
    public InputActionReference ShotRight=null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        leftHandTarget.transform.Translate (new Vector3 (0,0,range));
        leftHand = GameObject.FindGameObjectWithTag("LeftHand");
        rightHand = GameObject.FindGameObjectWithTag("RightHand");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCanonLeft();
        UpdateCanonRight();
        if (leftCanonTimer < leftCanonCooldown){
            leftCanonTimer+=Time.deltaTime;
        }if (rightCanonTimer < rightCanonCooldown){
            rightCanonTimer+=Time.deltaTime;
        }

        if (ShotLeft.action.ReadValue<float>() > 0){
            if (leftCanonTimer >= leftCanonCooldown){
                ShootCanon(ShotLeft);
                leftCanonTimer = 0;
            }
        }
        
        
        if(ShotRight.action.ReadValue<float>() > 0){
            if (rightCanonTimer >= rightCanonCooldown){
                ShootCanon(ShotRight);    
                rightCanonTimer = 0;            
            }
        }
        
        
    }

    void UpdateCanonLeft(){
        Vector3 direction = leftHand.transform.forward; 
        Debug.DrawRay(leftHand.transform.position, direction,Color.cyan,0.0f,false);
        RaycastHit hit;
        Vector3 target = Vector3.zero;
        
        if (Physics.Raycast(leftHand.transform.position, direction, out hit, range)){
            // Debug.Log ("touché");
            
            target = hit.point;
            
        }
        else {
            target = leftHandTarget.transform.position;
            
        }
        
        Quaternion targetRotation = Quaternion.LookRotation(target - canonLeft.transform.position);
        canonLeft.transform.rotation = Quaternion.Slerp (canonLeft.transform.rotation,targetRotation,Time.deltaTime*leftCanonRotationSpeed);
        

        

    }
    
    
    void UpdateCanonRight(){
        Vector3 direction = rightHand.transform.forward; 
        Debug.DrawRay(rightHand.transform.position, direction,Color.cyan,0.0f,false);
        RaycastHit hit;
        Vector3 target = Vector3.zero;
        
        if (Physics.Raycast(rightHand.transform.position, direction, out hit, range)){
            // Debug.Log ("touché");
            
            target = hit.point;
            
        }
        else {
            target = rightHandTarget.transform.position;
            
        }
        
        Quaternion targetRotation = Quaternion.LookRotation(target - canonRight.transform.position);
        canonRight.transform.rotation = Quaternion.Slerp (canonRight.transform.rotation,targetRotation,Time.deltaTime*rightCanonRotationSpeed);
        // canonRight.transform.LookAt(rightHandTarget.transform);
        // canonRight.transform.Rotate(new Vector3 (0,90,0));
        

    }
    void ShootCanon(InputActionReference Canon){
        // Debug.Log(Canon.name);
        if (Canon.name == "ShipControls/LeftHandShot")
        {            
            canonLeft.GetComponent<CanonShoot>().Shoot();
                
        }
        if (Canon.name == "ShipControls/RightHandShot")
        {            
            canonRight.GetComponent<CanonShoot>().Shoot();
            
        }
    }
    
    
    
}
