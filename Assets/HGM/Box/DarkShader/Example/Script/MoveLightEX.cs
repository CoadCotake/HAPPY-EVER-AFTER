using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLightEX : MonoBehaviour {

    public float size = 0.5f;
    public float bright = 0.8f;
    //추가한 라이트 인덱스 저장용(Save Light Index)
    private int index = 0;

    public GameObject targetObject;
    private float distanceToTarget;

    //초기화(initialize)
    void Start () {
        //보통 조명 생성(Add NormalLight)
        if (DarkShader.instance != null)
            DarkShader.instance.CreateNormalLight(ref index, transform.position, size, bright);
        distanceToTarget = transform.position.x - targetObject.transform.position.x;
    }
	
	//업데이트(Update)
	void Update () {
        //움직임(Move)
        float targetObjectX = targetObject.transform.position.x;
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + distanceToTarget;
        transform.position = newCameraPosition;

        //조명 껐다 켜기
        if (Input.GetKeyDown(KeyCode.L))
        {
            //-> index == -1이면 조명 없음(꺼짐)
            //-> index == -1 means Light is off
            if (index == -1)
                DarkShader.instance.CreateNormalLight(ref index, transform.position, size, bright);
            else
                DarkShader.instance.DeleteNormalLight(ref index);
        }

        //조명 값 갱신(Update Light Values) 
        //-> index == -1이면 조명 없음(꺼짐)
        //-> index == -1 means Light is off
        if (DarkShader.instance != null && index != -1)
            DarkShader.instance.UpdateNormalLight(index, transform.position, size, bright);
    }
}
