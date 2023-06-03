﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_circle_1 : MonoBehaviour
{
    public GameObject bullet;
    public GameObject enemy;
    public GameObject player;
    public Transform[] b_position;
    public Transform[] e_position;
    public float color_time;
    public float color_check;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("makecolor");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

    }
    IEnumerator makecolor()
    {
        for (float i = 0f; i <= 1; i += color_time)
        {
            Color color = new Vector4(0, 0, 1, i);
            transform.GetComponent<SpriteRenderer>().color = color;
            color_check = i;
            if (color_check >= 0.9)
            {
                for(int a = 0; a <= 5; a++)
                {
                    GameObject bullet1 = Instantiate(bullet, b_position[a].position, b_position[a].rotation);
                    bullet1.GetComponent<e_bullet_type2>().player_location = player.transform.position;
                }
                GameObject enemy1 = Instantiate(enemy, e_position[0].position, e_position[0].rotation);
                enemy1.GetComponent<Enemy_basic>().e_hp = 30;
                enemy1.GetComponent<Enemy_basic>().speed = 0.5f;
                enemy1.GetComponent<Enemy_basic>().e_type = 2;
                enemy1.GetComponent<e_bulletManager>().e_bullet_mode = 1;
                Destroy(this.gameObject);
            }
            yield return 0;

        }
    }
}
