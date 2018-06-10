Shader "Custom/TV" {
	Properties{
		_OnOff("OnOff", Range(0, 1.5)) = 0
		_BackTint("Inside", Color) = (1, 1, 1, 1)
		_Color("Color", Color) = (1, 1, 1, 1)
		_ColorP("Color Point", Color) = (1, 1, 1, 1)
		_Vel("Velocity", Float) = 10
		_Type("Type", Range(0, 2)) = 0
		_PSize("Point Size", Float) = 1.0
		_ScreenSize("Screen Size", Float) = 100.0
		_Deformation("Deformation", Range(0, 2)) = 0
		_MaxDistance("MaxDistance", Range(0, 2)) = 0
		aX("amplitudeX", Float) = 1
		bX("periodX", Float) = 1
		aY("amplitudeY", Float) = 1
		bY("periodY", Float) = 1
		_Location("location", Vector) = (1, 1, 1, 1)
	}
		SubShader{
		// Draw ourselves after all opaque geometry
		Tags{ "Queue" = "Transparent" }

		// Grab the screen behind the object into _BackgroundTexture
		GrabPass{
			"_BackgroundTexture"
		}

		// Render the object with the texture generated above, and invert the colors
		Pass{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

			half4 _BackTint;
			half4 _Location;
			float _Deformation;
			float _MaxDistance;
			float aX,bX,aY,bY;
			float _OnOff;
				struct vertInput {
					float4 texcoord : TEXCOORD0;
					float4 vertex : POSITION;
				};

				struct v2f{
					float4 grabPos : TEXCOORD0;
					float4 pos : SV_POSITION;
					float4 worldPos: TEXCOORD1;
				};

				v2f vert(vertInput input) {
					v2f o;
					o.pos = UnityObjectToClipPos(input.vertex);
					float4 worldPos = mul(unity_ObjectToWorld, input.vertex); //Posiciçon en la escena
					float3 heading =  worldPos.xyz - _Location.xyz;
					float d = length(heading);
					float3 direction = heading / d;
					float distX =distance(_Location.x, worldPos.x);
					float distY = distance(_Location.y, worldPos.y);
					float zoom = 0;
					if ((distX < _MaxDistance && distY < _MaxDistance) ) {
						float PI = 3.14159265359;
						zoom += aX * cos((distX*PI*2)/bX);
						zoom -= aY * sin((distY*PI*2) / bY);
						zoom *= _Deformation;
					}
					o.worldPos = worldPos;
					float3 total=(direction*zoom);
					o.grabPos = ComputeGrabScreenPos(o.pos - half4(total.x, -total.y*1.7, 0,0));
					return o;
				}

				bool insideTheTV(float2 pos) {
					return (pow(_OnOff, 2) / pow(pos.y, 2) - pow(pos.x, 2) / pow(3 / _OnOff, 2) > 1);
				}

				sampler2D _BackgroundTexture;

				half4 frag(v2f i) : SV_Target{
					fixed4 color = tex2Dproj(_BackgroundTexture, UNITY_PROJ_COORD(i.grabPos));
					if (!insideTheTV(i.worldPos.xy - _Location.xy)) {
						color = (0, 0, 0, 0);
					}
					return color + _BackTint;
				}
			ENDCG
		}
		//Screen
		Pass{
			Tags{
				"LightMode" = "ForwardBase" // allows shadow rec/cast
				"Queue" = "Transparent"
			}
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha // standard alpha blending

			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				half4 _Location;
				half4 _Color;
				half4 _ColorP;
				float _PSize;
				float _ScreenSize;
				float _Vel;
				int _Type;
				float _OnOff;
				struct vertInput {
					float4 pos : POSITION;

				};

				struct vertOutput {
					float4 pos : SV_POSITION;
					float3 worldPos : TEXCOORD0;
				};

				vertOutput vert(vertInput input) {
					vertOutput o;
					o.pos = UnityObjectToClipPos(input.pos); //Posicion en la camara
					o.worldPos = mul(unity_ObjectToWorld, input.pos); //Posiciçon en la escena
					return o;
				};

				//2 -> point | 1 -> vertical | 0 -> horizontal
				float rand(float2 co) {
					if (_Type == 1) return frac((_Time*_Vel)*sin(dot(floor(floor(co.x*floor(_PSize*100.0))), float2(31.0003, 180.0002))*10000.0));
					else if (_Type == 2) return frac((_Time*_Vel)*sin(dot(floor(floor(co.xy*floor(_PSize*100.0))), float2(31.0003, 180.0002))*10000.0));
					else return frac((_Time*_Vel)*sin(dot(floor(floor(co.y*floor(_PSize*100.0))), float2(31.0003, 180.0002))*10000.0));
					
				}

				float3 background(float2 pos, float2 res) {
					float2 position = (pos / res);
					float3 col= _ColorP;
					col *= rand(position);
					return col;
				}

				bool insideTheTV(float2 pos) {
					return (pow(_OnOff, 2) / pow(pos.y, 2) - pow(pos.x, 2) / pow(3 / _OnOff, 2) > 1);
				}

				half4 frag(vertOutput output) : COLOR{
					float3 rgb = background(output.worldPos.xy, float2(_ScreenSize , _ScreenSize));
					half4 color = _Color;
					color += half4(rgb, 0);
					color.w = 0.1; //alpha
					if (!insideTheTV(output.worldPos.xy - _Location.xy)) {
						color = (0, 0, 0,0);
					}
					else if (_OnOff !=1.5) {
						color = lerp(color, (0,0,0, 1), clamp(1.5 - _OnOff,0,1));
					}
					return color;
				};
			ENDCG
		}
	}

}
