using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_mov : MonoBehaviour
{
    //private float health;
    public GameObject player;
    public float speed;

    //private Vector2 direction;
    private float distance;
    void Start()
    {
        //health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //distance = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
