using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject PlayerShip;
    [SerializeField]
    private float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = GameObject.FindGameObjectWithTag("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = PlayerShip.transform.position - transform.position;
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, targetPosition, RotationSpeed*Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }
}
