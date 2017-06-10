Shader "Custom/AlphaLife"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_MaskTex("MaskTexture", 2D) = "white" {}
		_Range("Range", Range(0, 1)) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float4 color    : COLOR;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			sampler2D _MaskTex;
			float _Range;
			float4 _Color;
			
			fixed4 frag (v2f i) : SV_Target
			{
				float col = tex2D(_MainTex, i.uv).a;
				float mask = tex2D(_MaskTex, i.uv).a - _Range;

				if (mask >= 0 || col <= 0.2)
				{
					discard;
				}

				return _Color;

			/*float mask = tex2D(_MainTex, i.uv) * tex2D(_MaskTex, i.uv).a;

			if (mask <= _Range)
			{
				discard;
			}

			return _Color;*/
			}
			ENDCG
		}
	}
}
