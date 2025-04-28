using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class SampleScript : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text=GetComponent<TextMeshProUGUI>();
        text.DOText("Hello World",2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
