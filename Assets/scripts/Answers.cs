using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answers : MonoBehaviour
{
    private int[] ans = new int[5];
    public int select = 0;
    public gameManager gameManager;
    int selectNew = 0;
    // Start is called before the first frame update
    void Start()
    {
        //fill(-1);
    }

    public void fill(int answer)
    {
        int pos = Random.Range(0, 5);
        for (int i = 0; i < ans.Length; i++)
        {
            if(i == pos)
            {
                ans[i] = answer;
                transform.GetChild(i).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ans[i].ToString();
            }
            else
            {
                ans[i] = Random.Range(0, 100);
                transform.GetChild(i).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ans[i].ToString();
            }  
        }
        transform.GetChild(0).gameObject.SetActive(true);
        gameManager.GetComponent<gameManager>().value = ans[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            selectNew = select;
            if (selectNew == 0) selectNew = 4;
            else selectNew--;
            ChangeSelect(selectNew);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            selectNew = select;
            if (selectNew == 4) selectNew = 0;
            else selectNew++;
            ChangeSelect(selectNew);
        }
    }
    void ChangeSelect(int sel)
    {
        transform.GetChild(select).gameObject.SetActive(false);
        select = sel;
        transform.GetChild(select).gameObject.SetActive(true);
        gameManager.GetComponent<gameManager>().value = ans[select].ToString();
    }
}
