using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DarkShader : MonoBehaviour {

    //쉐이더 처리할 Material(Shader Material)
    private Material material;

    //쉐이더 메터리얼(조명) 처리하는 객체(This Handling Lights)
    private DarkShaderLight shader_light;

    //조명 갯수(Light num) -> 최대 100개(Max Num = 100)
    public int NormalLightNum = 40;
    public int FadeLightNum = 20;

    //조명 갯수 최대/최소
    private const int light_max = 100;
    private const int light_min = 0;

    //초기화(Init)
    private void Awake()
    {
        //메터리얼 생성(Create Material)
        material = new Material(Shader.Find("Custom/DarkShader"));

        //조명 갯수 체크
        int normal_num = -1, fade_num = -1;
        if (light_min <= NormalLightNum && NormalLightNum <= light_max)
            normal_num = NormalLightNum;
        if (light_min <= FadeLightNum && FadeLightNum <= light_max)
            fade_num = FadeLightNum;

        //메터리얼 생성됬나 체크
        if(material != null)
        {
            //조명갯수를 잘못 입력한 경우 기본값으로 생성
            if (normal_num == -1 || fade_num == -1)
                shader_light = new DarkShaderLight(material);
            //조명값 다 올바르게 입력한 경우 원하는 갯수대로 생성
            else
                shader_light = new DarkShaderLight(material, normal_num, fade_num);
        }
    }

    #region 조명 처리(Light Update)
    //조명 갱신(Update Light)
    private void Update()
    {
        if (material != null)
            shader_light.UpdateLight();
    }

    //쉐이더 적용(Apply Shader)
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //이 함수가 소스(화면)을 가져와 후처리(matrial을 소스에 적용)한 후 Destination(후처리한 화면)로 게임화면에 적용
        //쉽게말해서 화면을 가져와 material로 후처리를 하고 후처리한 화면을 게임에 보여줌
        if (material != null)
            Graphics.Blit(source, destination, material);
    }
    #endregion

    #region 외부 참조(External Function)
    //보통 조명 생성(Create Normal Light)
    //size = 0 ~ 2, bright = 0 ~ 2
    public void CreateNormalLight(Vector2 _position, float _size, float _bright)
    {
        shader_light.CreateNormalLight(_position, _size, _bright);
    }

    public void CreateNormalLight(ref int _index, Vector2 _position, float _size, float _bright)
    {
        _index = shader_light.CreateNormalLight(_position, _size, _bright);
    }

    //보통 조명 갱신(Update Normal Light)
    //size = 0 ~ 2, bright = 0 ~ 2
    public void UpdateNormalLight(int _index, Vector2 _position, float _size, float _bright)
    {
        shader_light.UpdateNormalLight(_index, _position, _size, _bright);
    }

    //보통 조명 삭제(Delete Normal Light)
    public void DeleteNormalLight(ref int _index)
    {
        _index = shader_light.DeleteNormalLight(_index);
    }

    //커졌다 작아지는 조명 생성(Create Fade Light)
    //size max = 0 ~ 2, speed = 0.001f ~ 1f,  bright = 0 ~ 2
    public void CreateFadeLight(Vector2 _position, float _size_max, float _speed, float _bright)
    {
        shader_light.CreateFadeLight(_position, _size_max, _speed, _bright);
    }
    #endregion

    #region 싱글톤 처리(SingleTon)
    private static DarkShader _instance;
    public static DarkShader instance
    {
        get
        {
            if (_instance == null)
            {
                try
                {
                    _instance = FindObjectOfType<DarkShader>();
                }
                catch (System.Exception e)
                {
                    print(e.StackTrace);
                    return null;
                }
            }
            return _instance;
        }
    } 
    #endregion
}
