using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taptostart;
    public GameObject zigzag;
    public GameObject gameover;
    public static UImanager instance;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;

    public TextMeshProUGUI highscore2;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        highscore2.text = "highScore: " + PlayerPrefs.GetInt("highscore").ToString();
    }
   public void gamestart()
    {
        
        taptostart.SetActive(false);
        zigzag.GetComponent<Animator>().Play("panel");
    }
    public void newgame()
    {
        SceneManager.LoadScene(0);
    }
    public void gameend()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore.text = PlayerPrefs.GetInt("highscore").ToString();
        
        gameover.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
