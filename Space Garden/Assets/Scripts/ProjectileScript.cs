using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    private CapsuleCollider ProjectileCollider;
    public float lifeSpan;
    private float lifeTime = 0;
    public GameObject ExplosionFx=null;
    public GameObject Initiator=null;
    public int Damages;
    void Start()
    {
        ProjectileCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        lifeTime += Time.deltaTime;
        
        if (lifeTime > lifeSpan){
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (!other.gameObject.CompareTag("Projectile")){
              GameObject newExplo = Instantiate(ExplosionFx,transform.position,Quaternion.Euler(other.contacts[0].normal));
            
        }
        
        if (other.gameObject.CompareTag("BreakablePart")){
            other.gameObject.GetComponent<BreakablePartScript>().Hit(Damages, Initiator);

        }
        Destroy(this.gameObject);
    }
}
