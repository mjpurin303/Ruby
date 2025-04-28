using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        //text.DOText("Text of DOTween",2f,true,ScrambleMode.All);
        text.DOCounter(500, 9999, 1.5f, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
