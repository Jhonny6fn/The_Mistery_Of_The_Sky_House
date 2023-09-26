Shader "Unlit/PostPro_Mirilla"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _CentroX("Centro X", Range(0.0, 0.5)) = 0.25
        _CentroY("Centro Y", Range(0.0, 0.5)) = 0.25
        _Radio("Radio", Range(0.01, 0.5)) = 0.1
        _Nitidez("Nitidez", Range(1, 20)) = 1
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _CentroX, _CentroY;
            float _Radio;
            float _Nitidez;

            fixed4 frag(v2f_img i) : SV_Target
            {
                float distancia = distance(float2(_CentroX, _CentroY), ComputeScreenPos(i.pos).xy / _ScreenParams.x);
                fixed4 col = tex2D(_MainTex, i.uv);
                return col * (1 - pow(distancia / _Radio, _Nitidez));
            }
            ENDCG
        }
    }
}