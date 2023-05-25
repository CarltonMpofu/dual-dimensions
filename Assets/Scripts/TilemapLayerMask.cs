using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapLayerMask : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LayerMask GetLayerMask()
    {
        return layerMask;
    }
}
