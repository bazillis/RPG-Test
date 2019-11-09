using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;
        transform.position = new Vector3(playerPos.x-7f, playerPos.y+4f, playerPos.z );
    }
}
