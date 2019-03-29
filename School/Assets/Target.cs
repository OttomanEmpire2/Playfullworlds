using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip[] Dingd;
    public float health = 10f;
    private Renderer ownMaterial;
    public List<Color> colorList = new List<Color>(2);
    public List<Renderer> buttonList = new List<Renderer>();
    public Color myColor;
    public doorScript[] doorScript;
    private Color startingColor;
    private bool allTheSameColor = true;
    public GameObject timer;
    
    // Start is called before the first frame update
    void Awake()
    {
        ownMaterial = GetComponent<Renderer>();
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].transform.gameObject.GetComponent<ButtonTarget>().doorScript = doorScript;
        }
        //myColor = colorList[Random.Range(0, colorList.Count)];
        //ownMaterial.material.color = myColor;

    }

    private void Start()
    {
        startingColor = GetComponent<Renderer>().material.color;
    }


    public void TakeDamage(float amount)
    {

        audioSource.PlayOneShot(Dingd[Random.Range(0, Dingd.Length)]);

        if (timer != null)
        {
            if (!timer.activeSelf)
            {
                timer.SetActive(true);
            }
        }
        if (ownMaterial.material.color == startingColor)
        {
            health -= amount;
            if (health <= 0)
            {
                Debug.Log("Hallo");
                Die();
                

            }
        }
    }

    void Die()
    {
        myColor = colorList[Random.Range(0, colorList.Count)];
        ownMaterial.material.color = myColor;

        while (allTheSameColor)
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].material.color = colorList[Random.Range(0, colorList.Count)];
                if(buttonList[i].material.color == myColor)
                {
                    allTheSameColor = false;
                }
            }
        }

        for (int i = 0; i < doorScript.Length; i++)
        {
            doorScript[i].colorDecider = ownMaterial;
            doorScript[i].wantedColor = myColor;
            doorScript[i].buttonList = buttonList;
            doorScript[i].CheckList();
        }

        //GetComponent<buttonScript>().enabled = false;
    }

}
