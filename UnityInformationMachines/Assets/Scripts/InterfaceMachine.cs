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

    private void OnDisconnected()
    {
        Debug.Log("Disconnected");
    }

    private void NodeChanged(OPCUANodeSubscription Sub, object value)
    {
        int PaletteID = int.Parse(value.ToString());
        trackingPalettes.Palettes[PaletteID].GetComponent<Palette>().Move(conveyerStartTrans, conveyerEndTrans, PaletteID);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
