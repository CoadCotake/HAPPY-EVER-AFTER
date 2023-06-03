using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLightEX : MonoBehaviour {

    //값들(Values)
    public float size = 0.3f;
    public float speed = 0.01f;
    public float bright = 0.6f;

    //딜레이 마다 라이트 추가(Light Add Delay)
    private float time = 0;
    public float delay = 1.0f;

    //초기화(initialize)
    void Start () {
        if (DarkShader.instance != null)
            DarkShader.instance.CreateFadeLight(transform.position, size, speed, bright);
	}
	
	//Delay초 마다 FadeLight 추가(Add Light by Delay)
	void Update () {
        if (time < delay)
            time += Time.deltaTime;
        else
        {
            DarkShader.instance.CreateFadeLight(transform.position, size, speed, bright);
            time = 0;
        }
	}
}
