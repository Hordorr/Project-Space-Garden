using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    bool isDead=false;
    Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(int Damages, GameObject Initiator){
        if (!isDead){
            HP-= Damages;
        }
        if (HP<=0){
            isDead = true;
            Debug.Log("Le "+ this.gameObject.name + " a été détruit par "+ Initiator.name);
            material.SetColor("_EmisionColor",Color.black);
            Destroy(this.gameObject);

        }

    }
}
