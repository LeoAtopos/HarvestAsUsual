using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ActionButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        string act = HarvestGameController.Instance.action.GetComponent<TextMeshProUGUI>().text;
        if (act == "Plough")
            HarvestGameController.Instance.PloughDone();
        if (act == "Sow")
            HarvestGameController.Instance.SowDone();
        if (act == "Water")
            HarvestGameController.Instance.WaterDone();
        if (act == "Weed")
            HarvestGameController.Instance.WeedDone();
        if (act == "Harvest")
            HarvestGameController.Instance.HarvestDone();
        if (act == "Sell")
            HarvestGameController.Instance.SellDone();
        if (act == "Survive")
            HarvestGameController.Instance.SurviveDone();
        if (act == "Rent")
            HarvestGameController.Instance.RentDone();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
