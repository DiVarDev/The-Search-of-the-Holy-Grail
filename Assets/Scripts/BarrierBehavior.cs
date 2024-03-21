using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBehavior : MonoBehaviour
{
    // Variables
    public GameObject key;
    public bool isKeyTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key").gameObject;
        isKeyTaken = key.activeInHierarchy;
    }

    // Update is called once per frame
    void Update()
    {
        isKeyTaken = key.activeInHierarchy;
        if (!isKeyTaken)
        {
            Destroy(gameObject);
        }
    }

    // Functions
}
