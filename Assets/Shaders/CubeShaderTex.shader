Shader "Unlit/CubeShaderTex"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Pass
		{


			Tags{ "LightMode" = "ForwardBase" "RenderType" = "Opaque" }
			LOD 100

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			

			#pragma multi_compile_fwdbase

			#include "AutoLight.cginc"

			uniform sampler2D _MainTex;	

			struct vertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct vertOut
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;

				LIGHTING_COORDS(1, 2)
				UNITY_FOG_COORDS(3)
			};

			vertOut vert(vertIn v)
			{
				vertOut o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				UNITY_TRANSFER_FOG(o, o.pos);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag(vertOut v) : SV_Target
			{

				float attenuation = LIGHT_ATTENUATION(v);

				fixed4 col = tex2D(_MainTex, v.uv) * attenuation;
				
				UNITY_APPLY_FOG(v.fogCoord, col);
				UNITY_OPAQUE_ALPHA(col.a);

				return col;
			}
			ENDCG
		}
	}

	Fallback "VertexLit"
}
