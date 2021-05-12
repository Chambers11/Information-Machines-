using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;


public class ReadInterfaces : MonoBehaviour
{
    public OPCUA_Interface StorageInterface ;

    public string NodeID;
    public string LastPaletteInterface1;
    public string CurrentPaletteInterface1;

    public Transform[] interaceStartPos;

    public string LastPaletteInterface2;

    public GameObject[] pallettes; 

     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPaletteInterface1 = StorageInterface.ReadNodeValue(NodeID).ToString();

        if (CurrentPaletteInterface1 != LastPaletteInterface1)
        {
            LastPaletteInterface1 = CurrentPaletteInterface1;
            AnimatePallete(5);

        }
    }

    public void AnimatePallete(int number)
    {
      //  pallettes[5].transform.position = interaceStartPos[1];
        // pallette.StartMove;
    }



}
