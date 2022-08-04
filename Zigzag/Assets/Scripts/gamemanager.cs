using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static gamemanager instance;
   
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start()
    {
        UImanager.instance.gamestart();
        scoremanager.instance.startscore();
        GameObject.Find("platform spawing").GetComponent<platformspawn>().spawnstart();
    }
    public void end()
    {
        UImanager.instance.gameend();
        scoremanager.instance.stopscore();
    }
}
