using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3f;
    public int maxHealth=5;
    int currentHealth;
    Rigidbody2D rb;
    public int health{
        get{return currentHealth;}
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth=maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = rb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rb.MovePosition(position);
    }
    public void ChangeHealth(int amount){
        currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
        Debug.Log(currentHealth +"/"+maxHealth);
    }
}
