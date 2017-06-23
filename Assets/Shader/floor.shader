Shader "Custom/floor" {
	Properties
	{
		_Vector("Vector", Vector) = (0,0,0,0)
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Standard 
#pragma target 3.0

		struct Input {
		float3 worldPos;
	};

	float4 _Color;
	float4 _Vector;
	void surf(Input IN, inout SurfaceOutputStandard o) {
		float dist = distance(_Vector.xyz, IN.worldPos);
		float val = abs(sin(dist*0.01 - _Time * 20));
		if (val > 0.9999f) 
		{
			o.Albedo = fixed4(1, 1, 1, 1);
			o.Emission = fixed4(0.5, 0.5, 3, 1);
		}
		else 
		{
			//o.Albedo = fixed4(110 / 255.0, 87 / 255.0, 139 / 255.0, 1);
			o.Albedo = _Color;
			//discard;
		}
	}
	ENDCG
	}
		FallBack "Diffuse"
}