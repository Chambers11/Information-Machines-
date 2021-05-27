using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking; 

public class CurrentOrdersDisplay : MonoBehaviour
{
    private float updateTimer;
    public CurrentOrderJSON[] currentOrderJSONArray;
    public FinishedOrderJSON[] finishedOrderJSONs; 

    public TextMeshProUGUI recentCurrentOrderNumber;
    public TextMeshProUGUI currentOrderPlannedStart;
    public TextMeshProUGUI currentOrderPlannedEnd;
    public TextMeshProUGUI currentOrderStatus; 

    public TextMeshProUGUI recentFinishedOrderNumber;
    public TextMeshProUGUI recentFinishedOrderStart;
    public TextMeshProUGUI recentFinishedOrderEnd;
    public TextMeshProUGUI recentFinishedOrderStatus;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer > 5f)
        {
            StartCoroutine(GetRequest("http://172.21.0.90/SQLData.php?Command=currentOrders"));
            StartCoroutine(GetRequestFinishedOrder("http://172.21.0.90/SQLData.php?Command=finishedOrders"));
            updateTimer = 0f;

        }
        else
        {
            updateTimer += Time.deltaTime; 
        }
        
    }



    

   
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    ReceieveData(webRequest.downloadHandler.text);
                    Debug.LogError("Current Orders Success");

                    break;
            }
        }
    }
    IEnumerator GetRequestFinishedOrder(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    ReceieveDataFinshedOrder(webRequest.downloadHandler.text);
                    Debug.LogError("Current Orders Success");

                    break;
            }
        }
    }
    private void ReceieveData(string CurrrentOrder)
    {
        string fixedJASONString = fixJson(CurrrentOrder);
        currentOrderJSONArray = JsonHelper.FromJson<CurrentOrderJSON>(fixedJASONString);

        if(currentOrderJSONArray.Length > 0)
        {
            recentCurrentOrderNumber.text = currentOrderJSONArray[currentOrderJSONArray.Length - 1].ONo.ToString();
            Debug.Log("Test JSON" + currentOrderJSONArray[0].ONo);
            currentOrderPlannedStart.text = currentOrderJSONArray[currentOrderJSONArray.Length - 1].PlannedStart.ToString();
            currentOrderPlannedEnd.text = currentOrderJSONArray[currentOrderJSONArray.Length - 1].PlannedEnd.ToString();
            currentOrderStatus.text = currentOrderJSONArray[currentOrderJSONArray.Length - 1].State.ToString();

        }


    }
    private void ReceieveDataFinshedOrder(string FinishedOrder)
    {
        string fixedJASONString = fixJson(FinishedOrder);
        finishedOrderJSONs = JsonHelper.FromJson<FinishedOrderJSON>(fixedJASONString);

        if (finishedOrderJSONs.Length > 0)
        {
            recentFinishedOrderNumber.text = finishedOrderJSONs[finishedOrderJSONs.Length - 1].FinONo.ToString();
            recentFinishedOrderStart.text = finishedOrderJSONs[finishedOrderJSONs.Length - 1].Start.ToString();
            recentFinishedOrderEnd.text = finishedOrderJSONs[finishedOrderJSONs.Length - 1].End.ToString();
            recentFinishedOrderStatus.text = finishedOrderJSONs[finishedOrderJSONs.Length - 1].State.ToString();
        }


    }
    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }
}
