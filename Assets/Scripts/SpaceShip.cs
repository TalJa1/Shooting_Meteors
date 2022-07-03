using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float moveSpeed;

    public GameObject Projectile;
    public Transform shootingPoint;
    public AudioSource auS;
    public AudioClip au;
    GameController p_gc;
    UIManager p_UI;

    Transform PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = gameObject.GetComponent<Transform>();
        p_gc = FindObjectOfType<GameController>();
        p_UI = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p_gc.IsGameOver() == false)
        {
            if (Input.GetKey(KeyCode.A) && transform.position.x > -8.8)
            {
                PlayerMove.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.D) && transform.position.x < 8.8)
            {
                PlayerMove.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.S) && transform.position.y > -4.23)
            {
                PlayerMove.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.W) && transform.position.y < 4.23)
            {
                PlayerMove.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
                if (auS && au)
                {
                    auS.PlayOneShot(au);
                }
            }
        }
        /*float xDir = Input.GetAxisRaw("Horizontal");
        //float yDir = Input.GetAxisRaw("Vertical");
        //Vector3.right vi khi dung .left se lam chuyen dong bi nguoc
        transform.position += xDir * Vector3.right * moveSpeed * Time.deltaTime;*/

    }

    public void Shoot()
    {
        if (Projectile && shootingPoint)
        {
            Instantiate(Projectile, shootingPoint.position, Quaternion.identity);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            p_gc.setGameOver(true);
            Debug.Log("Die");
            //p_UI.setScoreText("Score: " + p_gc.getScore());
            Destroy(col.gameObject);

        }
    }

}
