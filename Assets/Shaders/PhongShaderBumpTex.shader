
Shader "Unlit/PhongShaderBumpTex"
{
	SubShader
	{
		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#define MAX_LIGHTS 10

			#include "UnityCG.cginc"

		
			#pragma multi_compile_fwdbase
			#pragma target 3.0
			
			
			#include "AutoLight.cginc"

			uniform float _AmbientCoeff;
			uniform float _DiffuseCoeff;
			uniform float _SpecularCoeff;
			uniform float _SpecularPower;

			uniform int _NumPointLights;
			uniform float3 _PointLightColors[MAX_LIGHTS];
			uniform float3 _PointLightPositions[MAX_LIGHTS];

			uniform sampler2D _MainTex;
			uniform sampler2D _NormalMapTex;

			struct vertIn
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				float4 tangent : TANGENT;
				float2 uv : TEXCOORD0;
			};

			struct vertOut
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 worldVertex : TEXCOORD1;
				float3 worldNormal : TEXCOORD2;
				float3 worldTangent : TEXCOORD3;
				float3 worldBinormal : TEXCOORD4;
				
				LIGHTING_COORDS(5, 6)
			};

			
			vertOut vert(vertIn v)
			{
				vertOut o;
				
				float4 worldVertex = mul(_Object2World, v.vertex);
				float3 worldNormal = normalize(mul(transpose((float3x3)_World2Object), v.normal.xyz));
				float3 worldTangent = normalize(mul(transpose((float3x3)_World2Object), v.tangent.xyz));
				float3 worldBinormal = normalize(cross(worldTangent, worldNormal));

				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;

				o.worldVertex = worldVertex;
				o.worldNormal = worldNormal;
				o.worldTangent = worldTangent;
				o.worldBinormal = worldBinormal;

				TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;
			}

			fixed4 frag(vertOut v) : SV_Target
			{
				float4 surfaceColor = tex2D(_MainTex, v.uv);

				float3 bump = (tex2D(_NormalMapTex, v.uv) - float3(0.5, 0.5, 0.5)) * 2.0;
				float3 bumpNormal = (bump.x * normalize(v.worldTangent)) + 
									(bump.y * normalize(v.worldBinormal)) + 
									(bump.z * normalize(v.worldNormal));
				bumpNormal = normalize(bumpNormal);

				float Ka = _AmbientCoeff; 
				float3 amb = surfaceColor * UNITY_LIGHTMODEL_AMBIENT.rgb * Ka;

				float3 dif_and_spe_sum = float3(0.0, 0.0, 0.0);
				for (int i = 0; i < _NumPointLights; i++)
				{
	
					float fAtt = 1;
					float Kd = _DiffuseCoeff;
					float3 L = normalize(_PointLightPositions[i] - v.worldVertex.xyz);
					float LdotN = dot(L, bumpNormal);
					float3 dif = fAtt * _PointLightColors[i].rgb * Kd * surfaceColor * saturate(LdotN);

					float Ks = _SpecularCoeff;
					float specN = _SpecularPower; //
					float3 V = normalize(_WorldSpaceCameraPos - v.worldVertex.xyz);
					float3 H = normalize(V + L);
					float3 spe = fAtt * _PointLightColors[i].rgb * Ks * pow(saturate(dot(bumpNormal, H)), specN);

					dif_and_spe_sum += dif + spe;
				}

				float4 returnColor = float4(0.0f, 0.0f, 0.0f, 0.0f);
				returnColor.rgb = amb.rgb + dif_and_spe_sum.rgb;
				returnColor.a = surfaceColor.a;


				float attenuation = LIGHT_ATTENUATION(v);

				return returnColor * attenuation;
			}
			ENDCG
		}
	}
	Fallback "CubeShaderTex"
	Fallback "VertexLit"
}
