using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 OffsetVector;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        OffsetVector = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + OffsetVector;
    }
}
