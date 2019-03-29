using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTarget : MonoBehaviour
{
    public doorScript[] doorScript;
    public float health = 10f;
    private Color startingColor;
    // Start is called before the first frame update
    private void Start()
    {
        startingColor = GetComponent<Renderer>().material.color;
    }

    public void TakeDamage(float amount)
    {
        if (GetComponent<Renderer>().material.color != startingColor)
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
        gameObject.SetActive(false);
        for (int i = 0; i < doorScript.Length; i++)
        {
            doorScript[i].CheckList();
        }
    }
}