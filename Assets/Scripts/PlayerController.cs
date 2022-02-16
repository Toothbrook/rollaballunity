using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    private int count = 0;
    private Rigidbody playerRigidBody;
    private float movementX;
    private float movementZ;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        WinTextObject.SetActive(false);
        setCountText();
    }

    // Update is called once per frame
    void OnMove(InputValue force)
    {
        Vector2 movementVec = force.Get<Vector2>();
        movementX = movementVec.x;
        movementZ = movementVec.y;
    }

    void setCountText()
    {
        countText.text = "Gold cubes collected: " + count;
        if (count>13)
        {
            WinTextObject.SetActive(true);
        }
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
            count++;
            setCountText();
        }
        
    }
}
