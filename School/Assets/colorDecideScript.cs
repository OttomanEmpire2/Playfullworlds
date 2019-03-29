using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorDecideScript : MonoBehaviour
{
    public doorScript doorScript;

    private void OnMouseOver()
    {
        //Put here an if death statement (for example if (health =< 0 )
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            gameObject.SetActive(false);
            doorScript.CheckList();
        }
    }


}
