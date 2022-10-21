using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float movementSpeed;

    public float yEdge;

    public KeyCode up;
    public KeyCode down;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == "Pause")
        {
            if (Input.GetKey(up) && transform.position.y <= yEdge)
                transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0);

            else if (Input.GetKey(down) && transform.position.y >= -yEdge)
                transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
        }
    }
}
