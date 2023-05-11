using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answers : MonoBehaviour
{
    private string[] ans = new string[5];
    public int select = 0;
    public gameManager gameManager;
    int selectNew = 0;
    // Start is called before the first frame update
    void Start()
    {
        //fill(-1);
    }

    public void fill(string[] answers)
    {
        List<int> poss = new List<int>() { 1, 2, 3, 4, 0};
        foreach(string answer in answers) 
        {
            int pos = Random.Range(0, poss.Count);
            ans[poss[pos]] = answer;
            transform.GetChild(poss[pos]).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ans[poss[pos]];
            poss.RemoveAt(pos);
        }
        foreach(int ost in poss)
        {
            ans[ost] = Random.Range(0, 100).ToString();
            transform.GetChild(ost).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ans[ost];
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
        gameManager.GetComponent<gameManager>().value = ans[select];
    }
}
