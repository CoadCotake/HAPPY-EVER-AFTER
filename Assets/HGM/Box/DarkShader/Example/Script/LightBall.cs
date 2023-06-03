using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBall : MonoBehaviour {

    //값들(Values)
    public float size = 0.2f;
    public float speed = 0.05f;
    public float bright = 0.8f;

    //움직임 값(Move Value)
    public Vector2 MoveSpeed = new Vector2(200, 200);

    //컴포넌트(Component)
    private Rigidbody2D rb2d;

    //초기화(initialize)
    void Start () {
        //시작하면 움직이게(Start Move)
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(MoveSpeed);
    }

    //충돌판정(Check Collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //벽에 닿을 경우(Check Wall Name)
        if(collision.collider.name == "Left" ||
           collision.collider.name == "Right" ||
           collision.collider.name == "Up" ||
           collision.collider.name == "Down" ||
           collision.collider.name == "LightBall")
        {
            //FadeLight 추가(Add FadeLight)
            if (DarkShader.instance != null)
                DarkShader.instance.CreateFadeLight(transform.position, size, speed, bright);
        }
    }
}
