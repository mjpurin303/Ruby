using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogBulletController : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        
    }

    public void Launch(Vector2 direction,float force){
        rb.AddForce(direction *force,ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("CogBullet Collision with " + other.gameObject);
        EnemyController enemyCon = other.collider.GetComponent<EnemyController>();
        if(enemyCon != null){
            enemyCon.Fix();
        }
        Destroy(gameObject);
    }

}
