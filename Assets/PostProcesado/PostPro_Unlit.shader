Shader "Unlit/PostPro_Unlit"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Desplazamiento("Desplazamiento", 2D) = "white"{}
        _Magnitud("Magnitud", Range(0,0.1)) = 0.1
    }
        SubShader
        {

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                sampler2D _Desplazamiento;
                float _Magnitud;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float2 uvTiempo = float2(i.uv.x + _Time.x * 2, i.uv.y + _Time.x * 2);
                    float2 desplazamiento = tex2D(_Desplazamiento, uvTiempo).xy;
                    desplazamiento = ((desplazamiento * 2) - 1) * _Magnitud;
                    float4 col = tex2D(_MainTex, i.uv + desplazamiento);
                    return col;
                }
                ENDCG
            }
        }
}