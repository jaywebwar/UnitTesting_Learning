using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    CharacterController charController;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //charController.Move(new Vector3(speed * horizontal * Time.deltaTime, 0f, speed * vertical * Time.deltaTime));

        transform.position += new Vector3(speed * horizontal * Time.deltaTime, 0f, speed * vertical * Time.deltaTime);
    }
}
