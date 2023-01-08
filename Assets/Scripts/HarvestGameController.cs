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

    internal void Restart()
    {
        Start();
    }

    public static HarvestGameController Instance{get => instance;}

    public int yearCountDown = 5;
    public TextMeshProUGUI yearCountDownWordsText;
    public TextMeshProUGUI yearCountText;
    public bool isFinal = false;
    public bool isFinalSell = false;
    public bool isArmyKidRemoved = false;

    public GameObject endPanel;
    public TextMeshProUGUI endLineText;
    public GameObject endPic;
    public Image endPicSprite;
    public Sprite suicidePic;
    public Sprite starvePic;
    public Sprite strayPic;
    public Sprite dieInWarPic;

    public GameObject field;
    public GameObject fieldBase;
    public GameObject fieldDone;
    public GameObject fieldUnrent;
    public GameObject dams;
    public GameObject crops;
    public List<GameObject> cropList;
    public List<GameObject> cropRemain;

    public int money = 1000;
    public int gain = 0;
    public int cropNum = 24;
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
    public GameObject farmerLine;public TextMeshProUGUI farmerLineText;
    public GameObject wife;
    public GameObject kid1;
    public Sprite kidSad;
    public Sprite kidBoy;
    public GameObject kid2;
    public GameObject kid3;
    public GameObject surviveNeed;
    public int farmerNeed = -100;
    public int wifeNeed = -100;
    public int kid1Need = -100;
    public int kid2Need = -100;
    public int kid3Need = -100;
    public TextMeshProUGUI farmerNeedText;
    public TextMeshProUGUI wifeNeedText;
    public TextMeshProUGUI kid1NeedText;
    public TextMeshProUGUI kid2NeedText;
    public TextMeshProUGUI kid3NeedText;
    public GameObject words;
    public GameObject merchant;
    public GameObject merchantLine;
    public TextMeshProUGUI merchantLineText;
    public GameObject landLord;
    public GameObject landLordLine;
    public TextMeshProUGUI landLordLineText;
    public GameObject cropsTile;

    public Sprite transparent;
    public Sprite seedling;
    public Sprite grown;
    public Sprite fullgrown;
    public Sprite springWord;
    public Sprite summerWord;
    public Sprite autumnWord;
    public Sprite floodWord;
    public Sprite warWord;

    public Sprite winterWord;

    public GameObject grasshandler;
    public List<GameObject> grassList;

    public GameObject action;
    public string state;

    public GameObject skillboard;
    public GameObject skillRemoveFamily;
    public GameObject skillBuildDams;
    bool isFlood = false;
    public GameObject skillForWarlord;
    bool isProtectByWarlord = false;
    bool isWared = false;

    public AudioSource flickSound;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        yearCountDown = 5;
        yearCountDownWordsText.color = new Color(1, 1, 1);
        yearCountText.color = new Color(1, 1, 1);
        CheckYear();
        isFinal = false;
        isArmyKidRemoved = false;

        endPanel.SetActive(false);
        money = 300;
        gain = 0;
        cropPrice = 1f;
        gainPerCropBase = 50;
        moneyConsumePerPeepPerYear = 100;
        rentPrice = 600;
        peepNum = 5;
        cropNum = cropList.Count;

        kid3.SetActive(true); kid3NeedText.enabled = true;
        kid2.SetActive(true); kid2NeedText.enabled = true;
        kid1.SetActive(true); kid1NeedText.enabled = true;
        wife.SetActive(true); wifeNeedText.enabled = true;
        farmer.SetActive(true); farmerNeedText.enabled = true;
        farmerLine.SetActive(false);

        family = new List<GameObject>();
        family.Add(farmer);
        family.Add(wife);
        family.Add(kid1);
        family.Add(kid2);
        family.Add(kid3);

        farmerNeed = -100;
        wifeNeed = -100;
        kid1Need = -100;
        kid2Need = -80;
        kid3Need = -60;

        isFlood = false;
        isProtectByWarlord = false;
        dams.SetActive(false);
        skillBuildDams.SetActive(false);
        InitCropSpriteList();
        ShowSpringWord();
    }
    void InitCropSpriteList()
    {
        foreach (GameObject g in cropList) g.SetActive(true);
        cropRemain = new List<GameObject>(cropList);
        foreach (GameObject g in cropList)
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
        if(!isFinal)
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (state)
                {
                    case "SpringWord":
                        CheckYear(); SpringFiledShowUp(); break;
                    case "SpringDone":
                        ShowSummerWord(); break;
                    case "SummerWord":
                        CheckFlood(); break;
                    case "FloodWord":
                        SummerFiledShowUp(); break;
                    case "SummerDone":
                        ShowAutumnWord(); break;
                    case "AutumnWord":
                        CheckWar(); break;
                    case "WarWord":
                        EndOfWar(); break;
                    case "AutumnDone":
                        ShowWinterWord(); break;
                    case "WinterWord":
                        WinterFiledShowUp(); break;
                    case "WinterDone":
                        yearCountDown--; ShowSpringWord(); break;
                    default:
                        break;
                }
            }
        }
        if (isFinalSell && state == "FinalSellDone")
            if (Input.GetMouseButtonDown(0)) { state = "FinalPlot"; FarmerLastLine();}
        moneyText.text = money.ToString();
        gainText.text = gain.ToString();
        yearCountText.text = yearCountDown.ToString();

        farmerNeedText.text = farmerNeed.ToString();
        wifeNeedText.text = wifeNeed.ToString();
        kid1NeedText.text = kid1Need.ToString();
        kid2NeedText.text = kid2Need.ToString();
        kid3NeedText.text = kid3Need.ToString();
        if (isProtectByWarlord && kid1.activeSelf) kid1.GetComponent<Image>().sprite = kidSad;
        else kid1.GetComponent<Image>().sprite = kidBoy;
}
    void ShowSpringWord()
    {
        skillboard.SetActive(false);
        state = "SpringWord";
        statsBoard.SetActive(false);
        field.SetActive(false);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        foreach (GameObject g in cropList) g.SetActive(true);
        cropRemain = new List<GameObject>(cropList);
        cropNum = cropList.Count;
        familyHandle.SetActive(false);
        surviveNeed.SetActive(false);
        words.SetActive(true);
        words.GetComponent<Image>().sprite = springWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
        if (isFlood && !dams.activeSelf) skillBuildDams.SetActive(true);
        if (isWared && kid1.activeSelf && !isProtectByWarlord) skillForWarlord.SetActive(true);
    }
    void SpringFiledShowUp()
    {
        skillboard.SetActive(true);
        state = "Plough";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(true);
        flickSound.Play();
        state = "Sow";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(true);
        flickSound.Play();
        state = "SpringDone";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(false);
        state = "SummerWord";
        statsBoard.SetActive(false);
        field.SetActive(false);
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
        skillboard.SetActive(true);
        SeedlingCut();

        state = "Water";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(true);
        flickSound.Play();
        state = "Weed";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(true);
        flickSound.Play();
        state = "SummerDone";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(false);
        state = "AutumnWord";
        statsBoard.SetActive(false);
        field.SetActive(false);
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
        skillboard.SetActive(true);
        state = "Harvest";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(true);
        flickSound.Play();
        gain += gainPerCropBase * cropNum;
        if (yearCountDown == 0)
        {
            FinalYear();
        }
        state = "Sell";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        cropsTile.transform.DOScale(gain / 1000f, 0);
        action.SetActive(true);
        action.GetComponent<TextMeshProUGUI>().text = "Sell";
    }

    internal void SellDone()
    {
        skillboard.SetActive(true);
        flickSound.Play();
        money += (int)(gain * cropPrice);
        gain = 0;

        if (isFinalSell)
            state = "FinalSellDone";
        else
            state = "AutumnDone";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
        skillboard.SetActive(false);
        state = "WinterWord";
        statsBoard.SetActive(false);
        field.SetActive(false);
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
        skillboard.SetActive(true);
        state = "Survive";
        statsBoard.SetActive(true);
        field.SetActive(true);
        fieldBase.SetActive(true);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(true);
        surviveNeed.SetActive(true);
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
        skillboard.SetActive(true);
        flickSound.Play();

        if (money + farmerNeed >= 0) money += farmerNeed;
        else EndOfStarve();
        if(wife.activeSelf)
        {
            if (money + wifeNeed >= 0) money += wifeNeed;
            else { wife.SetActive(false); wifeNeedText.enabled = false; family.Remove(wife); peepNum--; };
        }
        if(kid1.activeSelf)
        {
            if (money + kid1Need >= 0 && kid1.activeSelf) money += kid1Need;
            else { kid1.SetActive(false); kid1NeedText.enabled = false; family.Remove(kid1); peepNum--; };
        }
        if(kid2.activeSelf)
        {
            if (money + kid2Need >= 0 && kid2.activeSelf) money += kid2Need;
            else { kid2.SetActive(false); kid2NeedText.enabled = false; family.Remove(kid2); peepNum--; };
        }
        if(kid3.activeSelf)
        {
            if (money + kid3Need >= 0 && kid3.activeSelf) money += kid3Need;
            else { kid3.SetActive(false); kid3NeedText.enabled = false; family.Remove(kid3); peepNum--; };
        }

        state = "Rent";
        statsBoard.SetActive(true);
        field.SetActive(true);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(true);
        crops.SetActive(false);
        familyHandle.SetActive(true);
        surviveNeed.SetActive(false);
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
        skillboard.SetActive(true);
        flickSound.Play();

        money -= rentPrice;
        if(money < 0)
        {
            EndOfStray();
        }

        state = "WinterDone";
        statsBoard.SetActive(true);
        field.SetActive(true);
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
    void EndOfStray()
    {
        skillRemoveFamily.SetActive(true);
        endLineText.text = "STRAY";
        endPicSprite.sprite = strayPic;
        endPanel.SetActive(true);
        EndListController.Instance.isBadEndStrayGet = true;
    }
    void EndOfStarve()
    {
        // got mercy to avoid flood;
        endLineText.text = "STARVATION";
        endPicSprite.sprite = starvePic;
        endPanel.SetActive(true);
        EndListController.Instance.isBadEndStarveGet = true;
    }
    void EndOfSuicide()
    {
        // got bravepoint to fight war;
        endLineText.text = "SUICIDE";
        endPicSprite.sprite = suicidePic;
        endPanel.SetActive(true);
        EndListController.Instance.isBadEndSuicideGet = true;
    }
    void EndOfWar()
    {
        skillForWarlord.SetActive(true);
        endLineText.text = "DIE BY WAR";
        endPicSprite.sprite = dieInWarPic;
        endPanel.SetActive(true);
        isWared = true;
        EndListController.Instance.isBadEndDieInWarGet = true;
    }
    void SeedlingCut()
    {
        CutCrops(0.3f,true);
        
    }
    void CutCrops(float p, bool isRandom)
    {
        int seedNum = cropRemain.Count;
        int seedKilled = 0;
        if (isRandom)
        {
            seedKilled = (int)Random.Range(1, (int)(seedNum * p));
        }
        else
        {
            seedKilled = (int)(seedNum * p);
        }
        cropNum -= seedKilled;
        List<GameObject> cropToBeKilledList = new List<GameObject>(cropRemain);
        int i = 0;
        while (i < seedKilled)
        {
            int j = (int)Random.Range(1, cropToBeKilledList.Count);
            cropToBeKilledList[j].SetActive(false);
            i++;
        }
        foreach(GameObject c in cropList)
        {
            if (!c.activeSelf) cropRemain.Remove(c);
        }
    }
    public void RemoveFamily()
    {
        if(!isFinal)
        {
            if (peepNum == 5)
            {
                kid3.SetActive(false); kid3NeedText.enabled = false; family.Remove(kid3); peepNum--; return;
            }
            if (peepNum == 4)
            {
                kid2.SetActive(false); kid2NeedText.enabled = false; family.Remove(kid2); peepNum--; return;
            }
            if (peepNum == 3)
            {
                CheckIfArmyKid(); kid1.SetActive(false); kid1NeedText.enabled = false; family.Remove(kid1); peepNum--; isProtectByWarlord = false; skillForWarlord.SetActive(false); return;
            }
            if (peepNum == 2)
            {
                wife.SetActive(false); wifeNeedText.enabled = false; family.Remove(wife); peepNum--; return;
            }
            if (peepNum == 1)
            {
                EndOfSuicide();
            }
        }
    }
    public void BuildDams()
    {
        if (!isFinal)
        {
            dams.SetActive(true);
            skillBuildDams.SetActive(false);
        }
    }
    public void WorkForWarlord()
    {
        if(!isFinal)
        {
            isProtectByWarlord = true;
            skillForWarlord.SetActive(false);
        }
    }
    void CheckFlood()
    {
        if(!dams.activeSelf)
        {
            int r = Random.Range(0, 2);
            Debug.Log(r);
            if (r > 0)
            {
                ShowFloodWord();
                isFlood = true;
            }
            else
            {
                SummerFiledShowUp();
            }
        }
        else
        {
            SummerFiledShowUp();
        }
    }
    void ShowFloodWord()
    {
        skillboard.SetActive(false);
        state = "FloodWord";
        statsBoard.SetActive(false);
        field.SetActive(false);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(false);
        surviveNeed.SetActive(false);
        words.SetActive(true);
        words.GetComponent<Image>().sprite = floodWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
        CutCrops(0.5f, false);
    }
    void CheckWar()
    {
        if(!isProtectByWarlord)
        {
            int r = Random.Range(0, 3);
            Debug.Log(r);
            if (r > 1)
            {
                ShowWarWord();
            }
            else
            {
                AutumnFiledShowUp();
            }
        }
        else
        {
            AutumnFiledShowUp();
        }
    }
    void ShowWarWord()
    {
        skillboard.SetActive(false);
        state = "WarWord";
        statsBoard.SetActive(false);
        field.SetActive(false);
        fieldBase.SetActive(false);
        fieldDone.SetActive(false);
        fieldUnrent.SetActive(false);
        crops.SetActive(false);
        familyHandle.SetActive(false);
        surviveNeed.SetActive(false);
        words.SetActive(true);
        words.GetComponent<Image>().sprite = warWord;
        merchant.SetActive(false);
        landLord.SetActive(false);
        grasshandler.SetActive(false);
        cropsTile.SetActive(false);
        action.SetActive(false);
    }
    void CheckYear()
    {
        if (yearCountDown == 1)
        {
            yearCountDownWordsText.text = "BIG FAT RICH HARVEST IN         YEAR";
            yearCountText.color = new Color(1, 1, 0);
        }
        if(yearCountDown == 0)
        {
            yearCountDownWordsText.text = "BIG FAT RICH HARVEST IN AUTUMN";
            yearCountDownWordsText.color = new Color(1, 1, 0);
            yearCountText.enabled = false;
        }
    }
    void FinalYear()
    {
        gain += 2000;
        cropPrice = 0.1f;
        state = "FinalPlot";
        isFinal = true;
        Invoke("FarmerShock", 2.5f);
        //Invoke("HideMerchantLine", 3f);
    }
    void FarmerShock()
    {
        farmerLineText.text = "What?!";
        farmerLine.SetActive(true);
        Invoke("MerchantThreat", 3.5f);
    }
    void HideMerchantLine()
    {
        merchantLine.SetActive(false);
    }
    void MerchantThreat()
    {
        merchantLineText.text = "It's BIG FAT RICH Harvest";
        merchantLine.GetComponent<RectTransform>().DOSizeDelta(new Vector2(400, 300), 0, false);
        merchantLine.SetActive(true);
        Invoke("HideMerchantLine", 5f);
        Invoke("MerchantThreat1", 6f);
    }
    void MerchantThreat1()
    {
        merchantLineText.text = "Too Much Gains";
        merchantLine.SetActive(true);
        Invoke("HideMerchantLine", 3f);
        Invoke("MerchantThreat2", 4f);
    }
    void MerchantThreat2()
    {
        merchantLineText.text = cropPrice.ToString()+"$, Take it or leave it!";
        merchantLine.SetActive(true);
        Invoke("FinalSell", 2.5f);
    }
    void FinalSell()
    {
        isFinalSell = true;
        Invoke("HideFarmerLine", 2f);
    }
    void HideFarmerLine()
    {
        farmerLine.SetActive(false);
    }
    void FarmerLastLine()
    {
        farmerLineText.text = "DOOMED";
        farmerLine.SetActive(true);
        Invoke("CutSceneTheEnd", 3.5f);
    }

    void CheckIfArmyKid()
    {
        if (isProtectByWarlord) isArmyKidRemoved = true;
    }
    void CutSceneTheEnd()
    {
        if(isArmyKidRemoved) SceneManager.LoadScene("TrueEnd");
        else SceneManager.LoadScene("TheEnd");
    }
}
