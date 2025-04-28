using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOPunchScale(Vector3.one * 2,1f,5,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
