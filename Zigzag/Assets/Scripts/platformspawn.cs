using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformspawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public GameObject diamonds;
    Vector3 lastpos;
    float size;
    public bool gameover;
    void Start()
    {
        gameover = false;
        lastpos=platform.transform.position;
        size = platform.transform.localScale.x;
        
    }

    // Update is called once per frame
    public void spawnstart()
    {
        for (int i = 0; i < 20; i++)
        {
            spawnrandom();
        }
        InvokeRepeating("spawnrandom", 2.0f, 0.1f);
    }
    void Update()
    {
        if (gameover == true)
        {
            CancelInvoke("spawnrandom");
        }
    }
    void spawnrandom()
    {
        int ram = Random.Range(0, 6);
        if(ram<3)
        {
            spawnx();
        }
        else if(ram >=3)
        {
            spawnz();
        }
    }
    void spawnx()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos; 
        Instantiate(platform,pos,Quaternion.identity);
        int ram = Random.Range(0, 4);
        if(ram==0)
        {
            Instantiate(diamonds,new Vector3 (pos.x, pos.y + 1, pos.z),diamonds.transform.rotation);
        }
    }
    void spawnz()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int ram = Random.Range(0, 4);
        if (ram == 0)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }

}
