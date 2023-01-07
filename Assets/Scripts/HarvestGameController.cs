using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class HarvestGameController : MonoBehaviour
{
    private static HarvestGameController instance;
    public static HarvestGameController Instance{get => instance;}

    public GameObject fieldBase;
    public GameObject fieldDone;
    public GameObject fieldUnrent;
    public GameObject crops;
    public List<GameObject> cropList;

    

    public List<Image> cropSpriteList;
    public GameObject farmer;
    public GameObject wife;
    public GameObject kid1;
    public GameObject kid2;
    public GameObject kid3;
    public GameObject words;
    public GameObject merchant;
    public GameObject landLord;
    public GameObject cropsTile;

    public Sprite transparent;
    public Sprite seedling;
    public Sprite grown;
    public Sprite fullgrown;
    public Sprite springWord;
    public Sprite summerWord;
    public Sprite autumnWord;

    public Sprite winterWord;
    float wordShowTime = 2.0f;

    public GameObject grasshandler;
    public List<GameObject> grassList;

    public GameObject action;
    public string state;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        InitCropSpriteList();
        ShowSpringWord();
    }
    void InitCropSpriteList()
    {
        foreach(GameObject g in cropList)
        {
            cropSpriteList.Add(g.transform.GetChild(0).GetComponent<Image>());
        }
        foreach(Image i in cropSpriteList)
        {
            i.sprite = transparent;
        }
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            switch(state)
            {
                case "SpringWord":
                    SpringFiledShowUp(); break;
                case "SpringDone":
                    ShowSummerWord(); break;
                case "SummerWord":
                    SummerFiledShowUp(); break;
                case "SummerDone":
                    ShowAutumnWord(); break;
                case "AutumnWord":
                    AutumnFiledShowUp(); break;
                case "AutumnDone":
                    ShowWinterWord(); break;
                case "WinterWord":
                    WinterFiledShowUp(); break;
                case "WinterDone":
                    ShowSpringWord(); break;
                default:
                    break;
            }
            
        }
    }
    void ShowSpringWord()
    {
        state = "SpringWord";
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(false);
        wife.SetActive(false);
        kid1.SetActive(false);
        kid2.SetActive(false);
        kid3.SetActive(false);
        words.SetActive(true);
        words.GetComponent<Image>().sprite = springWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    void SpringFiledShowUp()
    {
        state = "Plough";
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        words.GetComponent<Image>().sprite = springWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Plough";
    }
    public void PloughDone()
    {
        state = "Sow";
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        words.GetComponent<Image>().sprite = springWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Sow";
    }
    internal void SowDone()
    {
        state = "SpringDone";
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = transparent;
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        words.GetComponent<Image>().sprite = springWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    void ShowSummerWord()
    {
        state = "SummerWord";
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(false);
        wife.SetActive(false);
        kid1.SetActive(false);
        kid2.SetActive(false);
        kid3.SetActive(false);
        words.SetActive(true);
        words.GetComponent<Image>().sprite = summerWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    private void SummerFiledShowUp()
    {
        state = "Water";
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = seedling;
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        words.GetComponent<Image>().sprite = summerWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Water";
    }
    internal void WaterDone()
    {
        state = "Weed";
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = grown;
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        words.GetComponent<Image>().sprite = summerWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(true);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Weed";
    }
    internal void WeedDone()
    {
        state = "SummerDone";
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        words.GetComponent<Image>().sprite = summerWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    void ShowAutumnWord()
    {
        state = "AutumnWord";
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(false);
        wife.SetActive(false);
        kid1.SetActive(false);
        kid2.SetActive(false);
        kid3.SetActive(false);
        words.SetActive(true);
        words.GetComponent<Image>().sprite = autumnWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    private void AutumnFiledShowUp()
    {
        state = "Harvest";
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = fullgrown;
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        words.GetComponent<Image>().sprite = autumnWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Harvest";
    }
    internal void HarvestDone()
    {
        state = "Sell";
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(true);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(true);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Sell";
    }

    internal void SellDone()
    {
        state = "AutumnDone";
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    void ShowWinterWord()
    {
        state = "WinterWord";
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(false);
        wife.SetActive(false);
        kid1.SetActive(false);
        kid2.SetActive(false);
        kid3.SetActive(false);
        words.SetActive(true);
        words.GetComponent<Image>().sprite = winterWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    private void WinterFiledShowUp()
    {
        state = "Survive";
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Survive";
    }
    internal void SurviveDone()
    {
        state = "Rent";
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(true);
        crops.SetActive(false);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(false);
        landLord.SetActive(true);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Rent";
    }
    internal void RentDone()
    {
        state = "WinterDone";
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        farmer.SetActive(true);
        wife.SetActive(true);
        kid1.SetActive(true);
        kid2.SetActive(true);
        kid3.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
}
