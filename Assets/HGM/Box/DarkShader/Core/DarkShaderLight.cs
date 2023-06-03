using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkShaderLight {

    //쉐이더 처리할 메터리얼(Shader Material)
    private Material material;

    //오프셋(Light Speed Down Offset)
    private float light_small_speed = 1.8f;  //조명 크기 작아지는 값

    //최대/최소값(Min / Max)
    private const float size_min = 0.0f;
    private const float size_max = 2.0f;
    private const float bright_min = 0.0f;
    private const float bright_max = 2.0f;
    private const float speed_min = 0.001f;
    private const float speed_max = 1.0f;

    //보통 조명(Normal Light)
    public struct NormalLight
    {
        public Vector2 position;    //위치
        public float size;          //크기
        public float bright;        //밝기
        public bool on_off;         //켜짐여부
    }
    //커졌다 작아지는 조명(This Light size up and down by timeflow)
    public struct FadeLight
    {
        public Vector2 position;
        public float size;      //현재 크기
        public float size_max;  //최대크기
        public bool size_up;    //커지는 여부
        public float speed;     //커지는 속도
        public float bright;    //밝기
        public bool on_off;     //켜짐 여부
    }

    //라이트 관련 변수들(Variables)
    private int normal_num = 40;
    private NormalLight[] normal_light = null;
    private int fade_num = 20;
    private FadeLight[] fade_light = null;

    #region 초기화
    //무조건 메터리얼 넘겨받아야되므로 이건 못쓰게만듬
    private DarkShaderLight() { }
    public DarkShaderLight(Material _mat)
    {
        material = _mat;
        InitMaterial();
    }
    public DarkShaderLight(Material _mat, int _normal_light_num, int _fade_light_num)
    {
        material = _mat;
        normal_num = _normal_light_num;
        fade_num = _fade_light_num;
        InitMaterial();
    }

    //메터리얼 초기화
    private void InitMaterial()
    {
        //화면 비율 설정
        material.SetFloat("_Ratio", (float)Screen.width / (float)Screen.height);
        //라이트 갯수 설정
        material.SetInt("_NormalLightNum", normal_num);
        material.SetInt("_FadeLightNum", fade_num);
        //기본값 설정
        normal_light = new NormalLight[normal_num];
        fade_light = new FadeLight[fade_num];
        ApplyNormalLight();
        ApplyFadeLight();
        //모두 꺼짐 표시
        for (int i = 0; i < normal_light.Length; i++)
            normal_light[i].on_off = false;
        //모두 꺼짐 표시
        for (int i = 0; i < fade_light.Length; i++)
            fade_light[i].on_off = false;
    }
    #endregion

    #region 라이트 처리
    //조명 갱신
    public void UpdateLight()
    {
        ApplyNormalLight();
        UpdateFadeLight();
    }
    
    //NormalLight 생성
    public int CreateNormalLight(Vector2 _pos, float _size, float _bright)
    {
        int empty_index = -1;
        //비어있는 인덱스 찾기(꽉찼으면 empty_index = -1)
        for (int i = 0; i < normal_num; i++)
        {
            if (!normal_light[i].on_off)
            {
                empty_index = i;
                break;
            }
        }

        //만약 데이터 배열이 남아있다면 값 대입
        if (empty_index != -1)
        {
            //켜졌다 표시
            normal_light[empty_index].on_off = true;

            //위치값
            normal_light[empty_index].position = _pos;

            //크기 보정
            if (_size < size_min)
                normal_light[empty_index].size = size_min;
            else if (_size > size_max)
                normal_light[empty_index].size = size_max;
            else
                normal_light[empty_index].size = _size;

            //밝기 보정
            if (_bright < bright_min)
                normal_light[empty_index].bright = bright_min;
            else if (_bright > bright_max)
                normal_light[empty_index].bright = bright_max;
            else
                normal_light[empty_index].bright = _bright;

            //화면 위치 보정
            if (Screen.orientation == ScreenOrientation.LandscapeLeft)
                normal_light[empty_index].position.y *= -1f;

            //메터리얼에 적용
            ApplyNormalLight();
        }

        //인덱스 보내기
        return empty_index;
    }

    //NormalLight 갱신
    public void UpdateNormalLight(int _index, Vector2 _pos, float _size, float _bright)
    {
        //인덱스 확인
        if(0 <= _index && _index < normal_light.Length)
        {
            //해당 조명이 켜졌나 확인
            if(normal_light[_index].on_off)
            {
                //위치값
                normal_light[_index].position = _pos;

                //크기 보정
                if (_size < size_min)
                    normal_light[_index].size = size_min;
                else if (_size > size_max)
                    normal_light[_index].size = size_max;
                else
                    normal_light[_index].size = _size;

                //밝기 보정
                if (_bright < bright_min)
                    normal_light[_index].bright = bright_min;
                else if (_bright > bright_max)
                    normal_light[_index].bright = bright_max;
                else
                    normal_light[_index].bright = _bright;

                //화면 위치 보정
                if (Screen.orientation == ScreenOrientation.LandscapeLeft)
                    normal_light[_index].position.y *= -1f;
            }
        }
    }

    //NormalLight 삭제
    public int DeleteNormalLight(int _index)
    {
        //인덱스 확인
        if (0 <= _index && _index < normal_light.Length)
        {
            //해당 조명이 켜졌나 확인
            if (normal_light[_index].on_off)
            {
                //모든 값 0으로
                normal_light[_index].position = Vector2.zero;
                normal_light[_index].size = 0;
                normal_light[_index].bright = 0;

                //조명 끄기
                normal_light[_index].on_off = false;
            }
        }

        //없다 표시
        return -1;
    }

    //FadeLight 생성
    public void CreateFadeLight(Vector2 _pos, float _size_max, float _speed, float _bright)
    {
        int empty_index = -1;
        //비어있는 인덱스 찾기(꽉찼으면 empty_index = -1)
        for (int i = 0; i < fade_num; i++)
        {
            if (!fade_light[i].on_off)
            {
                empty_index = i;
                break;
            }
        }

        //만약 데이터 배열이 남아있다면
        if (empty_index != -1)
        {
            //켜짐표시
            fade_light[empty_index].on_off = true;
            //위치값
            fade_light[empty_index].position = _pos;
            //크기값
            fade_light[empty_index].size = 0;
            //크기 커진다 표시
            fade_light[empty_index].size_up = true;
            //크기 보정
            if (_size_max < size_min)
                fade_light[empty_index].size_max = size_min;
            else if (_size_max > size_max)
                fade_light[empty_index].size_max = size_max;
            else
                fade_light[empty_index].size_max = _size_max;

            //밝기 보정
            if (_bright < bright_min)
                fade_light[empty_index].bright = bright_min;
            else if (_bright > bright_max)
                fade_light[empty_index].bright = bright_max;
            else
                fade_light[empty_index].bright = _bright;

            //속도 보정
            float speed = _speed;
            if (speed < speed_min)
                speed = speed_min;
            else if (speed > speed_max)
                speed = speed_max;
            fade_light[empty_index].speed = _size_max / (1.0f / speed);

            //화면 보정
            if (Screen.orientation == ScreenOrientation.LandscapeLeft)
                fade_light[empty_index].position.y *= -1f;

            //메터리얼에 적용
            ApplyFadeLight();
        }
    }

    //FadeLight 갱신
    private void UpdateFadeLight()
    {
        //조명 전체 갱신
        for (int i = 0; i < fade_light.Length; i++)
        {
            //조명 켜졌나 확인(밝기 != 0)
            if (fade_light[i].on_off)
            {
                //커지는 중인 조명이면
                if (fade_light[i].size_up)
                {
                    //다 커질때까지++
                    if (fade_light[i].size < fade_light[i].size_max)
                        fade_light[i].size += fade_light[i].speed;
                    else
                        fade_light[i].size_up = false;
                }
                //작아지는 중인 조명이면
                else
                {
                    //다 작아질때까지--
                    if (fade_light[i].size > fade_light[i].speed)
                        fade_light[i].size -= fade_light[i].speed / light_small_speed;
                    //다 작아지면 0으로 처리 + 꺼짐 표시
                    else
                    {
                        fade_light[i].size = 0;
                        fade_light[i].bright = 0;
                        fade_light[i].on_off = false;
                    }
                }
            }
        }

        //메터리얼에 적용
        ApplyFadeLight();
    }
    #endregion

    #region 메터리얼 처리
    private void ApplyNormalLight()
    {
        Vector4[] apply_data = new Vector4[normal_num];

        for (int i = 0; i < apply_data.Length; i++)
        {
            //켜져있으면 값 적용
            if (normal_light[i].on_off)
            {
                Vector2 pos = Camera.main.WorldToViewportPoint(normal_light[i].position);
                apply_data[i].x = pos.x;
                apply_data[i].y = pos.y;
                apply_data[i].z = normal_light[i].size;
                apply_data[i].w = normal_light[i].bright;
            }
            //꺼져있으면 전부 0으로
            else
                apply_data[i] = Vector4.zero;                
        }

        material.SetVectorArray("_NormalLights", apply_data);
    }

    private void ApplyFadeLight()
    {
        Vector4[] apply_data = new Vector4[fade_num];

        for (int i = 0; i < apply_data.Length; i++)
        {
            //켜져있으면 값 적용
            if (fade_light[i].on_off)
            {
                Vector2 pos = Camera.main.WorldToViewportPoint(fade_light[i].position);
                apply_data[i].x = pos.x;
                apply_data[i].y = pos.y;
                apply_data[i].z = fade_light[i].size;
                apply_data[i].w = fade_light[i].bright;
            }
            //꺼져있으면 전부 0으로
            else
                apply_data[i] = Vector4.zero;
        }

        material.SetVectorArray("_FadeLights", apply_data);
    }
    #endregion
}
