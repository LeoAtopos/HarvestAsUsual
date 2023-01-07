using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
//using System;

public class HarvestGameController : MonoBehaviour
{
    private static HarvestGameController instance;
    public static HarvestGameController Instance{get => instance;}

    public GameObject fieldBase;
    public GameObject fieldDone;
    public GameObject fieldUnrent;
    public GameObject crops;
    public List<GameObject> cropList;

    public int money = 1000;
    public int gain = 0;
    public float cropPrice = 1;
    public int gainPerCropBase = 50;
    public int moneyConsumePerPeepPerYear = 100;
    public int rentPrice = 500;
    public int peepNum = 5;

    public GameObject statsBoard;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI gainText;

    public List<Image> cropSpriteList;
    public List<GameObject> family;
    public GameObject familyHandle;
    public GameObject farmer;
    public GameObject wife;
    public GameObject kid1;
    public GameObject kid2;
    public GameObject kid3;
    public GameObject words;
    public GameObject merchant;
    public TextMeshProUGUI merchantLineText;
    public GameObject landLord;
    public TextMeshProUGUI landLordLineText;
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
        money = 100;
        gain = 0;
        cropPrice = 0.1f;
        gainPerCropBase = 50;
        moneyConsumePerPeepPerYear = 100;
        rentPrice = 500;
        peepNum = 5;

        family = new List<GameObject>();
        family.Add(farmer);
        family.Add(wife);
        family.Add(kid1);
        family.Add(kid2);
        family.Add(kid3);

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
        moneyText.text = money.ToString();
        gainText.text = gain.ToString();
    }
    void ShowSpringWord()
    {
        state = "SpringWord";
        statsBoard.SetActive(false);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(false);
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
        statsBoard.SetActive(true);
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(true);
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
        statsBoard.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(true);
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
        statsBoard.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = transparent;
        familyHandle.SetActive(true);
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
        statsBoard.SetActive(false);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(false);
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
        SeedlingCut();

        state = "Water";
        statsBoard.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = seedling;
        familyHandle.SetActive(true);
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
        statsBoard.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = grown;
        familyHandle.SetActive(true);
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
        statsBoard.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        familyHandle.SetActive(true);
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
        statsBoard.SetActive(false);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(false);
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
        statsBoard.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(true);
        fieldUnrent.SetActive(false);
        crops.SetActive(true);
        foreach (Image i in cropSpriteList) i.sprite = fullgrown;
        familyHandle.SetActive(true);
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
        int gainHarvest = 0;
        foreach(GameObject g in cropList)
        {
            gainHarvest += gainPerCropBase;
        }
        gain += gainHarvest;
        state = "Sell";
        statsBoard.SetActive(true);
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(true);
        merchantLineText.text = cropPrice.ToString() + "$";
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(true);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Sell";
    }

    internal void SellDone()
    {
        money += (int)(gain * cropPrice);
        gain = 0;
        
        state = "AutumnDone";
        statsBoard.SetActive(true);
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(true);
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
        statsBoard.SetActive(false);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(false);
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
        statsBoard.SetActive(true);
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(true);
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
        int i = 0;
        while(i < family.Count)
        {
            if(money >= moneyConsumePerPeepPerYear)
            {
                money -= moneyConsumePerPeepPerYear;
                i++;
            }
            else
            {
                if(i>0)
                {
                    family[i].SetActive(false);
                    family.Remove(family[i]);
                }
                else
                {
                    EndOfStarve();
                    break;
                }
            }
        }
        state = "Rent";
        statsBoard.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(true);
        crops.SetActive(false);
        familyHandle.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(false);
        landLord.SetActive(true);
        landLordLineText.text = rentPrice.ToString() + "$";
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Rent";
    }
    internal void RentDone()
    {
        money -= rentPrice;
        if(money < 0)
        {
            EndOfStay();
        }

        state = "WinterDone";
        statsBoard.SetActive(true);
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(true);
        words.SetActive(false);
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    void EndOfStay()
    {
        SceneManager.LoadScene("EndOfStay");
    }
    void EndOfStarve()
    {
        SceneManager.LoadScene("EndOfStarve");
    }
    void SeedlingCut()
    {
        int seedNum = cropList.Count;
        int seedKilled = (int)Random.Range(1, (int)(seedNum * 0.2f));
        List<GameObject> cropToBeKilledList = new List<GameObject>();
        int i = 0;
        while (i < seedKilled)
        {
            GameObject g =  cropList[i];
            cropList.Remove(g);
            g.SetActive(false);
            i++;
        }
    }
}
