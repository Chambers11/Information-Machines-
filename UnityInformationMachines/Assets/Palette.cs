using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    public float smoothTime = 0.1f;

    private Vector3 targetPostion;
    private Vector3 velocity = Vector3.zero;

    private bool isMoving; 
    public void Move(Vector3 NewPosition)
    {
        targetPostion = NewPosition;
        isMoving = true; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPostion, ref velocity, smoothTime);
        }
    }
}
