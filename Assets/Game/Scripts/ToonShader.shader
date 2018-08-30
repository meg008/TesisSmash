Shader "Custom/Toon" 
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_UnlitColor("Shadow Color", Color) = (0.5,0.5,0.5,1)
		_ShadowThreshold("Shadow Threshold", Range(0,1)) = 0
		_OutlineThickness("Outline Thickness", Range(0,1)) = 0.1
		_MainTex("Main Texture", 2D) = "" {}
	}

		SubShader
	{
		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			uniform float4 _Color;
			uniform float4 _UnlitColor;
			uniform float _ShadowThreshold;
			uniform float _OutlineThickness;
			uniform sampler2D _MainTex;

			struct vertexInput 
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};

			struct vertexOutput 
			{
				float4 pos : SV_POSITION;
				float3 normalDir : TEXCOORD1;
				float4 lightDir : TEXCOORD2;
				float3 viewDir : TEXCOORD3;
				float2 uv : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				output.normalDir = normalize(mul(float4(input.normal, 0.0), unity_WorldToObject).xyz);

				float4 posWorld = mul(unity_ObjectToWorld, input.vertex);

				output.viewDir = normalize(_WorldSpaceCameraPos.xyz - posWorld.xyz);

				float3 fragmentToLightSource = (_WorldSpaceCameraPos.xyz - posWorld.xyz);
				output.lightDir = float4(
										normalize(lerp(_WorldSpaceLightPos0.xyz , fragmentToLightSource, _WorldSpaceLightPos0.w)),
										lerp(1.0 , 1.0 / length(fragmentToLightSource), _WorldSpaceLightPos0.w));

				output.pos = UnityObjectToClipPos(input.vertex);

				output.uv = input.texcoord;

				return output;

			}

			float4 frag(vertexOutput input) : COLOR
			{
				float4 finalColor;
				float nDotL = saturate(dot(input.normalDir, input.lightDir.xyz));
				float outlineStrength = saturate((dot(input.normalDir, input.viewDir) - _OutlineThickness) * 1000);

				if (nDotL > _ShadowThreshold)
					finalColor = _Color;
				else 
					finalColor = _UnlitColor;

				return tex2D(_MainTex, input.uv) * finalColor * outlineStrength;
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
}