using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float Speed;
    public float DestroyTime;
    GameController p_gc;
    AudioSource au_S;
    public AudioClip au;

    // Start is called before the first frame update
    void Start()
    {
        //Lay ra 1 thanh phan cua doi tuong
        m_rb = GetComponent<Rigidbody2D>();
        p_gc = FindObjectOfType<GameController>();
        au_S = FindObjectOfType<AudioSource>();
        //Huy gameObject sau 1 khoan tg
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        //1.Thay doi position trong thanh phan transform
        //2.Dung Addforce cua rigibody2D

        //di chuyen vien dan
        m_rb.velocity = Vector2.up * Speed;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (au_S && au)
            {
                au_S.PlayOneShot(au);
            }
            
            p_gc.ScoreIncresing();
            Debug.Log("Hit and increasing the score");
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }


}
