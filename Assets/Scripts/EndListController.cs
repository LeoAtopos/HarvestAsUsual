using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndListController : MonoBehaviour
{
    private static EndListController instance;
    public static EndListController Instance { get => instance; }

    public bool isBadEndStrayGet;
    public bool isBadEndStarveGet;
    public bool isBadEndSuicideGet;
    public bool isBadEndDieInWarGet;
    public bool isTheEndGet;
    public bool isTrueEndGet;
    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        isBadEndStrayGet = false;
        isBadEndStarveGet = false;
        isBadEndSuicideGet = false;
        isTheEndGet = false;
        isTrueEndGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
