using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    enum Direction
    {
        Horizontal, Vertical
    }

    [SerializeField] Direction transporterDirection = Direction.Horizontal;

    [SerializeField] float transporterSpeed = 1f;

    [SerializeField] float transporterDistance = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
