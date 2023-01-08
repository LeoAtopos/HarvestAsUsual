using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStartButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject endlistPrefab;
    public GameObject endList;
    public TextMeshProUGUI badEndText;
    public TextMeshProUGUI theEndText;
    public TextMeshProUGUI trueEndText;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Game");
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject e = GameObject.Find("EndList(Clone)");
        if (e != null) endList = e;
        else
        {
            if (endList == null)
            {
                endList = Instantiate(endlistPrefab);
                DontDestroyOnLoad(endList);
            }
        }
        if(endList != null)
        {
            int badEndNum = 0;
            if (endList.GetComponent<EndListController>().isBadEndDieInWarGet) badEndNum++;
            if (endList.GetComponent<EndListController>().isBadEndStarveGet) badEndNum++;
            if (endList.GetComponent<EndListController>().isBadEndStrayGet) badEndNum++;
            if (endList.GetComponent<EndListController>().isBadEndSuicideGet) badEndNum++;
            if (endList.GetComponent<EndListController>().isTheEndGet) theEndText.text = "1"; else theEndText.text = "0";
            if (endList.GetComponent<EndListController>().isTrueEndGet) trueEndText.text = "1"; else trueEndText.text = "0";
            badEndText.text = badEndNum.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
