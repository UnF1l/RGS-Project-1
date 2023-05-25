using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToGameManager : MonoBehaviour
{
    int health = 1;
    public GameObject endScreen;

    private void Update()
    {
        if (health  <= 0)
        {
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }    
    }
}
