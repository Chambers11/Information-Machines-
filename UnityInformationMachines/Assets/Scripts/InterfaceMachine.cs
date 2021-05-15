using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using System;
using UnityEngine.UI; 

public class InterfaceMachine : MonoBehaviour
{
    private OPCUA_Interface oPCUA_Interface;
    private TrackingPalettes trackingPalettes;

    public Text paletteNumber; 
    
    public string NodeID, NodeValue;


    public Transform conveyerStartTrans;
    public Transform conveyerEndTrans;

    // Start is called before the first frame update
    void Start()
    {
        oPCUA_Interface = GetComponent<OPCUA_Interface>();
        trackingPalettes = FindObjectOfType<TrackingPalettes>();

        oPCUA_Interface.EventOnReconnecting.AddListener(OnReconnecting);
        oPCUA_Interface.EventOnConnected.AddListener(OnConnected);
        oPCUA_Interface.EventOnDisconnected.AddListener(OnDisconnected);

    }

    private void OnReconnecting()
    {
        Debug.Log("Reconnecting");
    }
    private void OnConnected()
    {
        Debug.Log("Connected");
        var subscription = oPCUA_Interface.Subscribe(NodeID, NodeChanged);
    }

    private void NodeChanged(OPCUANodeSubscription sub, object value)
    {
        Debug.Log(value.ToString());
        NodeValue = value.ToString();


        paletteNumber.text = NodeValue; 

        int paletteID = Int32.Parse(value.ToString());
        trackingPalettes.Palettes[paletteID].transform.position = conveyerStartTrans.position;
        trackingPalettes.Palettes[paletteID].GetComponent<Palette>().Move(conveyerEndTrans.position);

    }


    private void OnDisconnected()
    {
        Debug.Log("Disconnected");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
