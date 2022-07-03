using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    
    public float moveSpeed;
    Rigidbody2D p_rd;
    GameController p_gc;
    
    // Start is called before the first frame update
    void Start()
    {
        p_rd = GetComponent<Rigidbody2D>();
        p_gc = FindObjectOfType<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        p_rd.velocity = Vector2.down * moveSpeed;
    }

    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.CompareTag("Deathzone"))
        {
            p_gc.setGameOver(true);
            Debug.Log("Death_Zone touched");
            
            Destroy(gameObject);
            
        }
    }
}
