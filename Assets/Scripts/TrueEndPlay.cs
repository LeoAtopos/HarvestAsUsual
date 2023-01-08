using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class TrueEndPlay : MonoBehaviour
{
    public GameObject movingHandle;
    public GameObject cropsTileNew;
    public GameObject merchant;
    public GameObject merchantLine;
    public TextMeshProUGUI merchantLineText;
    public GameObject landLord;
    public GameObject landLordLine;
    public TextMeshProUGUI landLordLineText;
    public GameObject kid;
    public GameObject kidLine;
    public GameObject army;
    public TextMeshProUGUI kidLineText;
    public GameObject endPanel;
    public TextMeshProUGUI endLineText;
    // Start is called before the first frame update
    void Start()
    {
        cropsTileNew.SetActive(false);
        merchantLine.SetActive(false);
        landLordLine.SetActive(false);
        kidLine.SetActive(false);
        movingHandle.transform.DOLocalMove(new Vector3(-6, -37, 0), 5f).OnComplete(() => MoveDone());
        merchant.transform.DOShakePosition(5f, 10, 5, 20, false, false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void MoveDone()
    {
        Invoke("DropCrops", 1f);
    }
    void DropCrops()
    {
        cropsTileNew.SetActive(true);
        Invoke("LandLordAsk", 1.5f);
    }
    void LandLordAsk()
    {
        landLordLineText.text = "Harvest?";
        landLordLine.SetActive(true);
        Invoke("MerchantAns", 3f);
    }
    void MerchantAns()
    {
        merchantLineText.text = "Yes, PaPa";
        merchantLine.SetActive(true);
        Invoke("HideMerchantLine", 4.5f);
        Invoke("MerchantAns2", 5.5f);
    }
    void HideMerchantLine()
    {
        merchantLine.SetActive(false);
    }
    void MerchantAns2()
    {
        merchantLineText.text = "As Usual";
        merchantLine.SetActive(true);
        Invoke("LandLordTurn", 5.5f);
    }
    void LandLordTurn()
    {
        landLordLine.SetActive(false);
        Invoke("LandLordLastLine", 1.5f);
    }
    void LandLordLastLine()
    {
        landLordLineText.text = "I'll go get'em";
        landLordLine.SetActive(true);
        Invoke("KidRushIn", 5.0f);
    }
    void KidRushIn()
    {
        kid.transform.DOLocalMove(new Vector3(504, 33, 0), 1f);
        Invoke("KidLine", 2);
    }
    void KidLine()
    {
        kidLineText.text = "No!";
        kidLine.SetActive(true);
        landLordLine.SetActive(false);
        merchantLine.SetActive(false);
        Invoke("ArmyIn", 1.5f);
    }
    void ArmyIn()
    {
        army.transform.DOLocalMove(new Vector3(623, 354, 0), 2f);
        Invoke("KidLine1Done", 2.5f);
    }
    void KidLine1Done()
    {
        kidLine.SetActive(false);
        Invoke("KidLine2", 1f);
    }
    void KidLine2()
    {
        kidLineText.text = "Get'em";
        kidLine.SetActive(true);
        Invoke("KidLine2Done", 4f);
    }
    void KidLine2Done()
    {
        kidLine.SetActive(false);
        Invoke("KidLine3", 1f);
    }
    void KidLine3()
    {
        kidLineText.text = "It's OUR Harvest";
        kidLine.SetActive(true);
        Invoke("RicherDoomed", 4);
    }
    void RicherDoomed()
    {
        landLordLineText.text = "DOOMED";
        landLordLine.SetActive(true);
        merchantLineText.text = "DOOMED";
        merchantLine.SetActive(true);
        Invoke("TheEndPanel", 6f);
    }
    void TheEndPanel()
    {
        endPanel.SetActive(true);
        EndListController.Instance.isTrueEndGet = true;
    }
}
