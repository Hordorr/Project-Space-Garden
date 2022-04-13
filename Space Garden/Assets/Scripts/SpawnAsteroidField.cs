using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroidField : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject asteroide = null;
    public GameObject miningAsteroide = null;
    void Start()
    {
        for(int i=0; i<100; i++){
            Vector3 AsteroidePosition = new Vector3(Random.Range(-100.0f,100.0f),Random.Range(-100.0f,100.0f),Random.Range(-100.0f,100.0f));
            Quaternion AsteroideRotation = new Quaternion(0,Random.Range(-100.0f,100.0f),Random.Range(-100.0f,100.0f),Random.Range(-100.0f,100.0f));
            int rand = Random.Range(0,5);
            if (rand == 0){
                Instantiate (miningAsteroide , AsteroidePosition, AsteroideRotation);
            }
            else{
                Instantiate (asteroide , AsteroidePosition, AsteroideRotation);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
