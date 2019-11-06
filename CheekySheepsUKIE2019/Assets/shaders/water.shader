Shader "Custom/Toon" {
	//show values to edit in inspector
	Properties{
		_Color1("Color1", Color) = (0, 0, 0, 1)
		_Color2("Color2", Color) = (0, 0, 0, 1)
		_MainTex("Texture", 2D) = "white" {}
		_SubTex("Texture", 2D) = "white" {}
		_MoveDir("MoveDir", Vector) = (0,0,0,0)
		//[HDR] _Emission("Emission", color) = (0,0,0)
	}
		SubShader{
		//the material is completely non-transparent and is rendered at the same time as the other opaque geometry
		Tags{ "RenderType" = "Opaque" "Queue" = "Geometry"}

		CGPROGRAM

		//the shader is a surface shader, meaning that it will be extended by unity in the background to have fancy lighting and other features
		//our surface shader function is called surf and we use our custom lighting model
		//fullforwardshadows makes sure unity adds the shadow passes the shader might need
		#pragma surface surf Standard fullforwardshadows vertex:vert
		#pragma target 4.0

		sampler2D _MainTex,_SubTex;
		fixed4 _Color,_Color1,_Color2;
		float2 _MoveDir;
		//input struct which is automatically filled by unity
		struct Input {
			float2 uv_MainTex;
			float2 uv_SubTex;
		};

		//vertex shader
		void vert(inout appdata_full v){
			v.vertex.y = 1.5*sin(v.vertex.xy - _SinTime*5);
		}

		//the surface shader function which sets parameters the lighting function then uses

		void surf(Input i, inout SurfaceOutputStandard o) {
			//sample and tint albedo texture
			fixed4 col1 = tex2D(_MainTex, i.uv_MainTex+ _SinTime/10);
			fixed4 col2 = tex2D(_SubTex, i.uv_SubTex + _CosTime/10);
			fixed4 col;
			float f = (col1.r + col2.r)/2;
			if (f >  0.8){
				col = _Color1;
			}
			else if (f <= 0.8 && f >=0.5 ) {
				col = lerp(_Color1, _Color2, 0.5);
			}
			else {
				col = _Color2;
			}

			o.Albedo = col.rgb;

			//o.Emission = _Emission;
		}
		ENDCG
	}
		FallBack "Standard"
}