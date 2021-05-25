using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentOrdersDisplay : MonoBehaviour
{
    private float updateTimer;

    public TextMeshProUGUI currntOrdersText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer > 1f)
        {
            GetCurrentOrderData();
            updateTimer = 0f;

        }
        else
        {
            updateTimer += Time.deltaTime; 
        }
        
    }

    private void GetCurrentOrderData()
    {

    }

}
