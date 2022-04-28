using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMatScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ressource = null;
    private GameObject RessourceSpawnPointPos;
    void Start()
    {
        RessourceSpawnPointPos = transform.GetChild (1).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropMat(){
        GameObject ressourceInstance = Instantiate(ressource, RessourceSpawnPointPos.transform.position, RessourceSpawnPointPos.transform.rotation);
        ressourceInstance.GetComponent<Rigidbody>().AddForce(ressourceInstance.transform.up + new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f)) *50);
    }
    
    
}
