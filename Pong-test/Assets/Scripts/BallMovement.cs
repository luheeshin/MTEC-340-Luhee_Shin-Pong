using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed;

    public float yEdge;
    public float xBounds;

    private Vector2 velocity = new Vector2(0, 0);
    private Rigidbody2D rb2d;



    //private int xDir;
    //private int yDir;


    public AudioClip collisionSound;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }


    private void FixedUpdate()
    {
        if (GameManager.Instance.State != "Play")
        {
            rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);

            if (Mathf.Abs(rb2d.position.y) >= yEdge)
                wallCollision();

            if (Mathf.Abs(rb2d.position.x) >= xbounds)
                wallCollision();

            //if (Mathf.Abs(transform.position.y) >= yEdge)
            //{
            //    //SwitchDirectionY();
            //    GameManager.Instance.PlaySound(collisionSound, 0.25f);
            //}

            //transform.position += new Vector3(
            //    xDir * ballSpeed * Time.deltaTime,
            //    yDir * ballSpeed * Time.deltaTime,
            //    0
            //);

            if (Mathf.Abs(transform.position.x) >= xBounds)
            {
                Debug.Log(0);
                GameManager.Instance.UpdateScore(transform.position.x > 0 ? 1 : 2);
                Debug.Log(1);

                Reset();
                Debug.Log(2);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State != "Play")
        {

            if (Mathf.Abs(transform.position.y) >= yEdge)
            {
                SwitchDirectionY();
                GameManager.Instance.PlaySound(collisionSound, 0.25f);
            }

            transform.position += new Vector3(
                xDir * ballSpeed * Time.deltaTime,
                yDir * ballSpeed * Time.deltaTime,
                0
            );

            if (Mathf.Abs(transform.position.x) >= xBounds)
            {
                Debug.Log(0);
                GameManager.Instance.UpdateScore(transform.position.x > 0 ? 1 : 2);
                Debug.Log(1);

                Reset();
                Debug.Log(2);
            }

        }
    }
   
    /*void Update()
    {
        if (transform.position.y >= 4.6f)
        {
            transform.position = new Vector3(transform.position.x, 4.6f, 0);
            yDir *= -1;
        }
        else if (transform.position.y >= -4.6f)
        {
            transform.position = new Vector3(transform.position.x, 4.6f, 0);
            yDir *= -1;
        }

        transform.position += new Vector3
        (
            xDir * ballSpeed * Time.deltaTime,
            yDir * ballSpeed * Time.deltaTime,
            0
        );
    }*/

    private void Death()
    {
        GameManager.Instance.UpdateScore(transform.position.x > 0 ? 1 : 2);
        Reset();
    }

    private void WallCollision()
    {
        velocity.y *= -1;

        rb2d.MovePosition(new Vector2(
            rb2d.position.x,
            rb2d.position.y > 0 ? yEdge - 0.01f : -yEdge + 0.01f
            ));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            velocity.x *= -1;
            velocity.x = IncrementSpeed(velocity.x);
        }
    }

    private float IncrementSpeed(float axis)
    {
        axis += axis > 0 ? GameManager.Instance.ballSpeedIncrement : -GameManager.Instance.ballSpeedIncrement;
        return axis;
    }

    //private int SetDirection()
    //{
    //    return Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1;
    //}

    //private void SwitchDirectionY()
    //{
    //    transform.position = new Vector3
    //    (
    //        transform.position.x, yEdge * yDir, 0
    //    );
    //    yDir *= -1;
    //}

    private int SetDirection()
    {
        return Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1;
    }

    private void Reset()
    {

        GameManager.Instance.State = "Serve";
        GameManager.Instance.messagesGUI.text = "Press Enter";
        GameManager.Instance.messagesGUI.enabled = true;

        transform.position = new Vector3(0, 0, 0);

        velocity = new Vector2(
            GameManager.Instance.initBallSpeed * (Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1;)

        //ballSpeed = GameManager.Instance.initBallSpeed;

        velocity.x = GameManager.Instance.initBallSpeed;
        velocity.y = GameManager.Instance.initBallSpeed;



        //xDir = SetDirection();
        //yDir = SetDirection();

    }

}
