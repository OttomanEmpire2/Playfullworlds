using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    private Renderer ownMaterial;
    public List<Color> colorList = new List<Color>(2);
    public List<Renderer> buttonList = new List<Renderer>();
    public Color myColor;
    public doorScript doorScript;

    // Start is called before the first frame update
    void Awake()
    {
        ownMaterial = GetComponent<Renderer>();
        //myColor = colorList[Random.Range(0, colorList.Count)];
        //ownMaterial.material.color = myColor;

    }

    private void OnMouseOver()
    {
        //Put here an if death statement (for example if (health =< 0 ) (give this object 1 health and then let the if statement check)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            myColor = colorList[Random.Range(0, colorList.Count)];
            ownMaterial.material.color = myColor;
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].material.color = colorList[Random.Range(0, colorList.Count)];
            }
            doorScript.CheckList();
            GetComponent<buttonScript>().enabled = false;
        }
    }
}
