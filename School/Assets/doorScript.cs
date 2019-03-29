using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public Renderer colorDecider;
    public List<Renderer> buttonList = new List<Renderer>();
    public bool wrongColorGone;
    public Color wantedColor;
    private StopTimerScript sts;

    private void Awake()
    {
        GameObject tempSts = GameObject.FindGameObjectWithTag("stoptimer");
        sts = tempSts.GetComponent<StopTimerScript>();
    }

    public void CheckList()
    {
        //wantedColor = colorDecider.material.color;
        wrongColorGone = true;
        //Checks if object is destroyed or if color matches with color decider
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList[i].transform.gameObject.activeSelf == false)
            {
                buttonList.Remove(buttonList[i]);
                Debug.Log("Deleted");
                continue;
            } else if (buttonList[i].material.color == wantedColor)
            {
                wrongColorGone = false;
            }
        }

        if (wrongColorGone)
        {
            //Safety check
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (buttonList[i].material.color == wantedColor)
                {
                    wrongColorGone = false;
                }
            }
            if (wrongColorGone)
            {
                OpenDoor();
            }
        }
        

    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
        sts.CheckDoors();
        
    }

}

