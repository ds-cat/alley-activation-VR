using DF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta_object_sender : MonoBehaviour
{

    public Meta_Infographic graphic;
    public objectInfo object_info;
    public void Start()
    {
        object_info = GetComponent<objectInfo>();
        graphic = FindObjectOfType<Meta_Infographic>();

           // SendToInfographic();
        
    }

    public void SendToInfographic()
    {
        if (object_info.image == null)
        { return; }
        //Debug.Log(object_info.image.name);
        //graphic.audioSource.Play();
        //Debug.Log(graphic.infoGraphic.sprite.name);
        graphic.infoGraphic.sprite = object_info.image;
        //Debug.Log(graphic.infoGraphic.sprite.name);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
