using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoremanager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public int highscore;
    public static scoremanager instance;
    
   
   
    
  
 
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
       
        score = 0;
    }
    void increment()
    {
        score++;
    }
    public void startscore()
    {
        InvokeRepeating("increment", 0.1f, 0.5f);
    }
    public void stopscore()
    {
        
        CancelInvoke("startscore");
        CancelInvoke("increment");
        
        PlayerPrefs.SetInt("score", score);
        
        if(PlayerPrefs.HasKey("highscore"))
        {
            if(score>PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else 
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
