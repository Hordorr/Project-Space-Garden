using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    public float MovementSpeed=1;
    public float resetRollSpeed=1;
    public InputActionReference MovementPlaneRef=null;
    public InputActionReference MoveUpRef=null;
    public InputActionReference MoveDownRef=null;
    public InputActionReference Rotationref=null;
    private Transform ShipTransform=null;
    private Rigidbody shipRigidBody=null;
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
        Debug.Log(ShipTransform.forward.ToString());
        shipRigidBody.AddForce(ShipTransform.right* -horizontalValue.y *Time.deltaTime*MovementSpeed);
        if (horizontalValue.x < 0.1 && horizontalValue.y<0.1 && verticalValue <0.1){
            shipRigidBody.velocity = shipRigidBody.velocity/float 1.1;
        }
    }
    void UpdateRotation(Vector2 rotationValue){
        ShipTransform.Rotate(0, rotationValue.x,-rotationValue.y);
        ResetRollRotation();
    }
    void ResetRollRotation(){        
        ShipTransform.Rotate(ShipTransform.rotation.x*2,0,0);
            

        
        
    }
}
