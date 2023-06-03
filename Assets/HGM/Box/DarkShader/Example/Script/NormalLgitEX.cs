using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLgitEX : MonoBehaviour {

    //값들(Values)
    public float size = 0.2f;
    public float bright = 1.0f;

    //보통 조명 생성(Create Normal Light)
    void Start()
    {
        if (DarkShader.instance != null)
            DarkShader.instance.CreateNormalLight(transform.position, size, bright);
    }
}
