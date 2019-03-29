using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimerScript : MonoBehaviour
{
    public GameObject timer;
    public GameObject[] doors;

    private void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("door");
    }


    public void CheckDoors()
    {
        Debug.Log("CHECKING DOORS");
        bool allDoorsOpen = true;
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].activeSelf == true)
            {
                Debug.Log("ONE IS ACTIVE");
                allDoorsOpen = false;
                break;
            }
        }

        //doors = GameObject.FindGameObjectsWithTag("door");
        //if(doors == null)
        //{
        //    Debug.Log("YEEEEEEEEEEEEEEEEEEEEEEEEEEEEET");
        //    timer.GetComponent<TimerScript>().enabled = false;
        //}

        if (allDoorsOpen == true)
        {
            Debug.Log("ALLS DOORS OPEN");
            timer.GetComponent<TimerScript>().enabled = false;
        }

    }


}
