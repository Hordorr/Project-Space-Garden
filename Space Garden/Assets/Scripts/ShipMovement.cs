using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    public float MovementSpeed=1;
    public float rotationSpeed=100;
    public float resetRollSpeed=1;
    public float maxVelocity=10;
    public InputActionReference MovementPlaneRef=null;
    public InputActionReference MoveUpRef=null;
    public InputActionReference MoveDownRef=null;
    public InputActionReference Rotationref=null;
    
    
    private Transform ShipTransform=null;
    private Rigidbody shipRigidBody=null;
    private Quaternion baseHandRotationOnActivation;
    private bool rotationByHandGate=true;
    // Start is called before the first frame update
    private void Awake() {
        ShipTransform = GetComponent<Transform>();
        shipRigidBody = GetComponent<Rigidbody>();
    }   
    // Update is called once per frame
    void Update(){
        
        
        Vector2 MovementPlaneValue = MovementPlaneRef.action.ReadValue<Vector2>();        
        Vector2 RotationValue= Rotationref.action.ReadValue<Vector2>();

        float MoveUpValue = -MoveUpRef.action.ReadValue<float>();
        float MoveDownValue = MoveDownRef.action.ReadValue<float>();
        float horizontaleMoveValue = MoveDownValue+MoveUpValue;

        UpdateLocation(MovementPlaneValue, horizontaleMoveValue);
        UpdateRotation(RotationValue);
        
        //Debug.Log("Movement Value = "+MovementPlaneValue.ToString()+" RotationValue = "+RotationValue.ToString()+" MoveUp Value = "+MoveUpValue.ToString()+" MoveDown Value = "+MoveDownValue.ToString());

    }
    void UpdateLocation(Vector2 horizontalValue,float verticalValue){
        // ShipTransform.Translate(new Vector3(-horizontalValue.y, verticalValue , horizontalValue.x) * Time.deltaTime * MovementSpeed);
        
        if (shipRigidBody.velocity.magnitude < maxVelocity){
        shipRigidBody.AddForce(ShipTransform.forward* horizontalValue.y *Time.deltaTime*MovementSpeed);
        shipRigidBody.AddForce(ShipTransform.right* horizontalValue.x * Time.deltaTime*MovementSpeed);

        }
        //reduce veolcity when to holding stick        
        shipRigidBody.velocity = shipRigidBody.velocity/1.01F;
        
    }
    void UpdateRotation(Vector2 rotationValue){
        
        shipRigidBody.AddRelativeTorque(new Vector3 (-rotationValue.y,rotationValue.x,0)*Time.deltaTime*rotationSpeed);
        shipRigidBody.angularVelocity = shipRigidBody.angularVelocity/1.02F;
        
        
    }
    
}
