using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ColorObject : MonoBehaviour
{
    public InputActionReference colorReference=null;
    private MeshRenderer meshRenderer = null;
    // Start is called before the first frame update
    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update() {
        float value = colorReference.action.ReadValue<float>();
        UpdateColor(value);
    }
    private void UpdateColor(float value){
        meshRenderer.material.color=new Color(0,value,value);
    }
}
