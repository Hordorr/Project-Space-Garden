using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherRangeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ressourcesInRangeList;
    private GameObject RessourcesGatherer;
    void Start()
    {
        RessourcesGatherer = transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        ressourcesInRangeList.Add(other.gameObject);
        RessourcesGatherer.GetComponent<RessourceGatherer>().AttractRessource(ressourcesInRangeList);        
    }
    private void OnTriggerExit(Collider other) {
        
        if (ressourcesInRangeList.Contains(other.gameObject)){
            ressourcesInRangeList.Remove(other.gameObject);

        }
    }
}
