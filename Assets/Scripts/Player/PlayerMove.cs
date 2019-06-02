using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 5;
    public float minSpeed = -2;
    public float maxRunSpeed = 8;
    public float curbSpeed = 0.08f; // When no key is pressed, player gets speed reduce
    public float speed = 0; // We need to put both variable on the Range
    bool enabled;

    public GameObject camera1;
    private float playerRotationY;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enabled = true;

    }
    private void FixedUpdate()
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
        }
        // Update is called once per frame
    void Update()
    {
        // Rotation
        playerRotationY = camera1.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(0, playerRotationY, 0);
        // Translation
        {
            if (enabled)
            {
                // Up 
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
                {
                    speed++;
                    if (Input.GetKey(KeyCode.LeftShift))                                    // When player runs
                    {
                        if (speed > maxRunSpeed)
                        {
                            speed = maxRunSpeed;
                        }
                    }                                                                       // When player doesn't run
                    else
                    {
                        if (speed > maxSpeed)
                        {
                            speed = maxSpeed;
                        }
                    }

                }
                else
                {
                    if (speed > 0)
                        speed -= curbSpeed;
                    else
                    {
                        speed = 0;
                    }
                }
                // Down
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    speed--;
                    if (speed < minSpeed)
                    {
                        speed = minSpeed;
                    }
                }
                // Left
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
                {
                    transform.Rotate(0, -1, 0);
                }
                // Right
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(0, 1, 0);
                }
            }
        }


    }

 }
