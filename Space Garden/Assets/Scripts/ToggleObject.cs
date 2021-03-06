using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleObject : MonoBehaviour
{
    public InputActionReference toggleReference=null;

    private void Awake() {
        toggleReference.action.started += Toggle;
        
    }
    // Start is called before the first frame update
    private void OnDestroy() {
        toggleReference.action.started -= Toggle;
        
    }

    // Update is called once per frame
    private void Toggle(InputAction.CallbackContext context){
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);

    }
}
