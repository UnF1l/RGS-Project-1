using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public string str, ans;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Generate()
    {
       
        int a = Random.Range(0, 100);
        int b, c;

        switch(Random.Range(0, 4))
        {
            case 0:
                b = Random.Range(0, 100-a);
                str = a.ToString() + " + " + b.ToString();
                c = a + b;
                ans = c.ToString();
                break;
            case 1:
                b = Random.Range(0, a+1);
                str = a.ToString() + " - " + b.ToString();
                c = a - b;
                ans = c.ToString();
                break;
            case 2:
                b = Random.Range(0, 10);
                if (a * b > 99) a = Random.Range(0, 25);
                while (true)
                {
                    if (a * b > 99) b = Random.Range(0, 10);
                    else break;
                }
                str = a.ToString() + " * " + b.ToString();
                c = a * b;
                ans = c.ToString();
                break;
            case 3:
                b = Random.Range(1, 10);
                while (true)
                {
                    if (a % b != 0) a = Random.Range(0, 100);
                    else break;
                }
                str = a.ToString() + " / " + b.ToString();
                c = a / b;
                ans = c.ToString();
                break;
        }
        
    }

}
