using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    Image img;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        //img.DOColor(Color.red,1.5f);
        Vector3 dir = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.DORotate(new Vector3(0,0,angle),1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
