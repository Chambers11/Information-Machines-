using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    public float smoothTime;
    public int PaletteNo;
    public TextMeshProUGUI paletteText;
    public MeshRenderer sphereRenderer;
    public Canvas paletteCanvas; 


    private Vector3 targetPostion;
    private Vector3 velocity = Vector3.zero;

    private bool isMoving; 
    public void Move(Transform StartTransform, Transform EndTransform, int ID)
    {
        transform.position = StartTransform.position; 
        targetPostion = EndTransform.position;
        PaletteNo = ID;
        paletteText.text = ID.ToString();
        isMoving = true;

        Debug.Log("Palette has gone throguh");
        

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
            transform.LookAt(targetPostion);
        }
    }

    public void ToggleMeshRendererOnAndOff()
    {
        if (sphereRenderer.enabled == true)
        {
            sphereRenderer.enabled = false;
            paletteCanvas.enabled = false;
        }
        else
        {
            sphereRenderer.enabled = true;
            paletteCanvas.enabled = true;
        }
    }
}
