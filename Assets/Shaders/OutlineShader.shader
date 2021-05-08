Shader "Projekt/OutlineShader"
{
	Properties{
		_Color("Main Color", Color) = (.0,.0,.5,1)
		_OutlineColor("Outline Color", Color) = (1,0,0,1)
		_Outline("Outline width", Range(0, 1)) = 0.1
		_MainTex("Texture", 2D) = "white" { }
	}

		SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		fixed4 _Color;

		struct Input
		{
		float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG

		Pass
		{
			Name "OUTLINE"
			Tags { "LightMode" = "Always" }
			Cull Front
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag


			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : POSITION;
				float4 color : COLOR;
			};

			uniform float _Outline;
			uniform float4 _OutlineColor;

			v2f vert(appdata v) {
				v2f o;
				v.vertex *= (1 + _Outline);
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = _OutlineColor;
				return o;
			}
			half4 frag(v2f i) :COLOR
			{
				return i.color;
			}

			ENDCG
		}
	}
}