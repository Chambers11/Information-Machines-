using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPalettes : MonoBehaviour
{

    public GameObject PalettePrefab;
    public int NumberOfPaletts;
    public GameObject[] Palettes;

    public Transform paletteWaitingArea;
    // Start is called before the first frame update
    void Start()
    {
        Palettes = new GameObject[NumberOfPaletts];
        for (int i = 0; i < NumberOfPaletts; i++)
        {
            Palettes[i] = Instantiate(PalettePrefab);
            Palettes[i].name = "Palette " + i; 
        }
    }

    public void ToggleAllPalettesOnAndOff()
    {
        for (int i = 0; i < Palettes.Length; i++)
        {
            Palettes[i].GetComponent<Palette>().ToggleMeshRendererOnAndOff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
