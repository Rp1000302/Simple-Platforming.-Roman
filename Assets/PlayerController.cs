using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb2d;
    public float jumpForce;
    public float speed;
    public GameObject bullet;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKeyDown(KeyCode.Space))
            rb2d.AddForce(new Vector2(0, jumpForce));

        if (Input.GetMouseButtonDown(0))
        {
            var b = GameObject.Instantiate(bullet,transform.position, transform.rotation);
            Vector2 bulletDirection = new Vector2(transform.forward.z, transform.forward.x);
            b.GetComponent<Rigidbody2D>().velocity = bulletDirection * 5f;
        }
    }
}
