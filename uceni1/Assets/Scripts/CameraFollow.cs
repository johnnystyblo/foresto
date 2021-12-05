using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private float minX, maxX, minY, maxY;

    private Transform player;
    private Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;

        /*tempPos = transform.position;
        tempPos.y = player.position.y;
        if (tempPos.y < minY)
            tempPos.y = minY;
        if (tempPos.y > maxY)
            tempPos.y = maxY;

        transform.position = tempPos;*/
    }
}
