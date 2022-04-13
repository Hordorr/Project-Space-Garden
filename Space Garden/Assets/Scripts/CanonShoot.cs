using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ProjectileSpawnPoint=null;
    public GameObject Projectile=null;
    private GameObject projectileInstance=null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(){
        projectileInstance = Instantiate(Projectile, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
        projectileInstance.GetComponent<ProjectileScript>().lifeSpan= 1.0F;
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Impulse);
        projectileInstance.GetComponent<ProjectileScript>().Initiator = this.gameObject;
        projectileInstance.GetComponent<ProjectileScript>().Damages = 10;
    }
}
