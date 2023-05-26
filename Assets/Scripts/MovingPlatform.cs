using UnityEngine;

public class MovingPlatform : MonoBehaviour
{ 
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float travelDistance = 2f;

    [SerializeField] Direction platformDirection = Direction.Up;

    private Vector3 initialPosition;
    private Vector3 direction;

    enum Direction
    {
        Right, Left, Up, Down
    }

    private void Start()
    {
        initialPosition = transform.position;

        if(platformDirection == Direction.Up)
        {
            direction = Vector3.up;
        }
        else if(platformDirection == Direction.Down)
        {
            direction = Vector3.down;
        }
        else if(platformDirection == Direction.Right)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
    }

    private void Update()
    {
        float newPosition = Mathf.PingPong(Time.time * movementSpeed, travelDistance);
        transform.position = initialPosition + direction * newPosition;
    }


}
