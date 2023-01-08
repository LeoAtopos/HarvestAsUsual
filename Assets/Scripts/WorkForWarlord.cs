using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkForWarlord : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        HarvestGameController.Instance.WorkForWarlord();
        Debug.Log("clicked");
    }

}
