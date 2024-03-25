using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float xOffset;
    private float yOffset;
    private float zOffset;

    [SerializeField] Transform player;

    private void Start()
    {
        xOffset = 0;
        yOffset = 1;
        zOffset = 0;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(xOffset, yOffset, -zOffset);
    }
}
