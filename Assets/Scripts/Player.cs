using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public int Health { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
