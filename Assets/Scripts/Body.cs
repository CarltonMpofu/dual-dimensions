using UnityEngine;

public class Body : MonoBehaviour
{ /*
    public Vector2 checkSize = new Vector2(1f, 0.1f);
    public LayerMask collisionLayer;

    private CircleCollider2D myCollider;

    private void Awake() {
        myCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        bool isAnythingOnTop = CheckForCollision();
        Debug.Log("Is anything on top? " + isAnythingOnTop);
    }

    private bool CheckForCollision()
    {
        Vector2 checkPosition = (Vector2)transform.position + myCollider.offset;

        RaycastHit2D hit = Physics2D.BoxCast(checkPosition, checkSize, 0f, Vector2.up, checkSize.y, collisionLayer);
        //RaycastHit2D hitt = Physics2D.BoxCast(checkPosition, checkSize,)

        if (hit.collider != null && hit.collider != myCollider)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        myCollider = GetComponent<CircleCollider2D>();
        Vector2 checkPosition = (Vector2)transform.position + myCollider.offset;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(checkPosition, checkSize);
    } */
}
