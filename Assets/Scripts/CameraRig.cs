using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public float damping = 1.5f;
    public Transform player;

    private Vector2 offset;
    private int lastX;
    private bool faceLeft;

    void Start ()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
    }

    void Update () 
    {
        int currentX = Mathf.RoundToInt(player.position.x);
        
        faceLeft = !(currentX > lastX);

        lastX = Mathf.RoundToInt(player.position.x);
        
        var target = faceLeft ? 
            new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z) : 
            new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        
        transform.position = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
    }
}
