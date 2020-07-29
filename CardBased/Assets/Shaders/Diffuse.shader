//Shadow.W
//2020.07

Shader "Custom/Diffuse"
{
    Properties
    {
        _Color("Color",Color)=(1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct a2v
            {
                float4 vertex : POSITION;
                float3 normal:NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worNormal:TEXCOORD1;
                float3 worLightDir:TEXCOORD2;
            };

            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(a2v v)
            {
                v2f o = (v2f)0;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worNormal = UnityObjectToWorldNormal(v.normal);
                float3 worPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worLightDir = UnityWorldSpaceLightDir(worPos);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb;
                fixed3 worNormal = normalize(i.worNormal);
                fixed3 worLightDir = normalize(i.worLightDir);
                fixed Lambert = saturate(dot(worNormal, worLightDir));  //lambert模型
                fixed3 diffuse = _LightColor0.rgb * Lambert * tex2D(_MainTex, i.uv).rgb * _Color.rgb;
                fixed3 col = ambient + diffuse;
                return fixed4(col, 1);
            }
            ENDCG
        }
    }
}
