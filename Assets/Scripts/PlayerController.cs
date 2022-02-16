using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody playerRigidBody;
    private float movementX;
    private float movementZ;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnMove(InputValue force)
    {
        Vector2 movementVec = force.Get<Vector2>();
        movementX = movementVec.x;
        movementZ = movementVec.y;
    }

    void FixedUpdate()
    {
        playerRigidBody.AddForce(new Vector3(movementX,0.0f,movementZ)*speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
        
    }
}
