Shader "Unlit/SemanticShader"
{
    Properties
    {
        _MainTex ("_MainTex", 2D) = "Textures/MyTexture" {}
        _SemanticTex ("_SemanticTex", 2D) = "Textures/MySemanticTexture" {}
        _Color ("_Color", Color) = (25,25,113,90)
        
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
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
                float3 texcoord : TEXCOORD1;
                float4 vertex : SV_POSITION;

            };

            float4x4 _DisplayMatrix;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                //we need to adjust our image to the correct rotation and aspect.
                o.texcoord = mul(_DisplayMatrix, float4(v.uv, 1.0f, 1.0f)).xyz;
                
                return o;
            }

            sampler2D _MainTex;
            sampler2D _SemanticTex;
            fixed4 _Color;

            fixed4 frag (v2f i) : SV_Target
            {
                //convert coordinate space
                float2 semanticUV = float2(i.texcoord.x / i.texcoord.z, i.texcoord.y / i.texcoord.z);
                
                float4 semanticCol = tex2D(_SemanticTex, semanticUV);
                //return float4(semanticCol.r/1.5f,semanticCol.r/0.9f,semanticCol.r*8,0.75f);
                float brightness = 1.4f; // 降低亮度
                semanticCol.rgb *= brightness;
                //fixed otherTexCol = tex2D(_MainTex, i.uv);
                //semanticCol *= otherTexCol; // 将semanticCol与otherTexCol相乘
                return float4(semanticCol.r,semanticCol.r*0.03f,semanticCol.r*0.04f,0.5f);
            }
            ENDCG
        }
    }
}