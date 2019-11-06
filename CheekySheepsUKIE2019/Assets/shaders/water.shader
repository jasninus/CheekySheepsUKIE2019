Shader "Custom/Water" {
	//show values to edit in inspector
	Properties{
		_Color1("Color1", Color) = (0, 0, 0, 1)
		_Color2("Color2", Color) = (0, 0, 0, 1)
		_MainTex("Texture", 2D) = "white" {}
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

		sampler2D _MainTex;
		fixed4 _Color1,_Color2;
		float2 _MoveDir;
		//input struct which is automatically filled by unity
		struct Input {
			float2 uv_MainTex;
		};

		//vertex shader
		void vert(inout appdata_full v){
			v.vertex.y = 0.5*sin(v.vertex.xz + _SinTime*5);
		}

		//the surface shader function which sets parameters the lighting function then uses

		void surf(Input i, inout SurfaceOutputStandard o) {
			//sample and tint albedo texture
			fixed4 col1 = tex2D(_MainTex, i.uv_MainTex + _SinTime/10);
			fixed4 col2 = tex2D(_MainTex, i.uv_MainTex - _SinTime/10);
			fixed4 col;
			float f = (col1.r + col2.r)/2;
			if (f <= 0.5 || f >= 0.7 ) {
				col = _Color2;
			}
			else {
				col = _Color1;
			}

			o.Albedo = col.rgb;

			//o.Emission = _Emission;
		}
		ENDCG
	}
		FallBack "Standard"
}