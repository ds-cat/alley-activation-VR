using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ligth_script : MonoBehaviour
{
    public Light[] lights;
    public GameObject[] bulbs;

    int current_color = 0;



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (current_color == 0)
                lights[i].color = Color.red;
            if (current_color == 1)
                lights[i].color = Color.green;
            if (current_color == 2)
            {
                lights[i].color = Color.blue;
                current_color = 0;
            }
            else
            {

            }

        }
        if (current_color == 2)
        {
            current_color = 0;
        }
        else
        {
            ++current_color;
        }
    }
}
