// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1557-OUT,spec-6970-OUT,normal-4753-RGB,emission-4724-OUT;n:type:ShaderForge.SFN_Multiply,id:4724,x:32424,y:33232,varname:node_4724,prsc:2|A-8704-B,B-6467-OUT;n:type:ShaderForge.SFN_Tex2d,id:8704,x:31280,y:32787,ptovrint:False,ptlb:Mask_ID,ptin:_Mask_ID,varname:node_8704,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6467,x:32205,y:33330,varname:node_6467,prsc:2|A-3767-OUT,B-1831-RGB,T-7186-OUT;n:type:ShaderForge.SFN_Color,id:1831,x:31946,y:33388,ptovrint:False,ptlb:Emissive_OFFcolor,ptin:_Emissive_OFFcolor,varname:node_1831,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Cos,id:7186,x:31946,y:33576,varname:node_7186,prsc:2|IN-7832-OUT;n:type:ShaderForge.SFN_Multiply,id:7832,x:31771,y:33576,varname:node_7832,prsc:2|A-3656-T,B-7172-OUT;n:type:ShaderForge.SFN_Time,id:3656,x:31550,y:33522,varname:node_3656,prsc:2;n:type:ShaderForge.SFN_Slider,id:7172,x:31369,y:33686,ptovrint:False,ptlb:Emissive_frequency,ptin:_Emissive_frequency,varname:node_7172,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:100;n:type:ShaderForge.SFN_Multiply,id:3767,x:31946,y:33217,varname:node_3767,prsc:2|A-8055-RGB,B-7446-OUT;n:type:ShaderForge.SFN_Slider,id:7446,x:31532,y:33334,ptovrint:False,ptlb:Emissive_power,ptin:_Emissive_power,varname:node_7446,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:100;n:type:ShaderForge.SFN_Color,id:8055,x:31590,y:33160,ptovrint:False,ptlb:Emissive_ONcolor,ptin:_Emissive_ONcolor,varname:node_8055,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4753,x:32327,y:33042,ptovrint:False,ptlb:t_norm,ptin:_t_norm,varname:node_4753,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:7619,x:31851,y:32605,ptovrint:False,ptlb:t_spec,ptin:_t_spec,varname:node_7619,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5724,x:31643,y:32021,ptovrint:False,ptlb:t_alb,ptin:_t_alb,varname:node_5724,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:1557,x:32052,y:32224,varname:node_1557,prsc:2|A-298-OUT,B-6876-RGB,T-8704-R;n:type:ShaderForge.SFN_Color,id:6876,x:31643,y:32239,ptovrint:False,ptlb:Player_color,ptin:_Player_color,varname:node_6876,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:9817,x:31694,y:32513,ptovrint:False,ptlb:Metal_reflectivity,ptin:_Metal_reflectivity,varname:node_9817,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:1000;n:type:ShaderForge.SFN_Add,id:3662,x:32096,y:32562,varname:node_3662,prsc:2|A-9817-OUT,B-7619-RGB;n:type:ShaderForge.SFN_Multiply,id:6970,x:32345,y:32694,varname:node_6970,prsc:2|A-3662-OUT,B-8704-G;n:type:ShaderForge.SFN_Vector3,id:3595,x:31643,y:31883,varname:node_3595,prsc:2,v1:0.4926471,v2:0.4926471,v3:0.4926471;n:type:ShaderForge.SFN_Add,id:298,x:31842,y:31972,varname:node_298,prsc:2|A-3595-OUT,B-5724-RGB;proporder:6876-5724-4753-7619-7446-7172-8055-1831-8704-9817;pass:END;sub:END;*/

Shader "Shader Forge/sh_robots" {
    Properties {
        _Player_color ("Player_color", Color) = (0.5,0.5,0.5,1)
        _t_alb ("t_alb", 2D) = "white" {}
        _t_norm ("t_norm", 2D) = "bump" {}
        _t_spec ("t_spec", 2D) = "white" {}
        _Emissive_power ("Emissive_power", Range(0, 100)) = 0
        _Emissive_frequency ("Emissive_frequency", Range(0, 100)) = 0
        _Emissive_ONcolor ("Emissive_ONcolor", Color) = (0.5,0.5,0.5,1)
        _Emissive_OFFcolor ("Emissive_OFFcolor", Color) = (0.5,0.5,0.5,1)
        _Mask_ID ("Mask_ID", 2D) = "white" {}
        _Metal_reflectivity ("Metal_reflectivity", Range(1, 1000)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Mask_ID; uniform float4 _Mask_ID_ST;
            uniform float4 _Emissive_OFFcolor;
            uniform float _Emissive_frequency;
            uniform float _Emissive_power;
            uniform float4 _Emissive_ONcolor;
            uniform sampler2D _t_norm; uniform float4 _t_norm_ST;
            uniform sampler2D _t_spec; uniform float4 _t_spec_ST;
            uniform sampler2D _t_alb; uniform float4 _t_alb_ST;
            uniform float4 _Player_color;
            uniform float _Metal_reflectivity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _t_norm_var = UnpackNormal(tex2D(_t_norm,TRANSFORM_TEX(i.uv0, _t_norm)));
                float3 normalLocal = _t_norm_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _t_spec_var = tex2D(_t_spec,TRANSFORM_TEX(i.uv0, _t_spec));
                float4 _Mask_ID_var = tex2D(_Mask_ID,TRANSFORM_TEX(i.uv0, _Mask_ID));
                float3 specularColor = ((_Metal_reflectivity+_t_spec_var.rgb)*_Mask_ID_var.g);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _t_alb_var = tex2D(_t_alb,TRANSFORM_TEX(i.uv0, _t_alb));
                float3 diffuseColor = lerp((float3(0.4926471,0.4926471,0.4926471)+_t_alb_var.rgb),_Player_color.rgb,_Mask_ID_var.r);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_3656 = _Time + _TimeEditor;
                float3 emissive = (_Mask_ID_var.b*lerp((_Emissive_ONcolor.rgb*_Emissive_power),_Emissive_OFFcolor.rgb,cos((node_3656.g*_Emissive_frequency))));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Mask_ID; uniform float4 _Mask_ID_ST;
            uniform float4 _Emissive_OFFcolor;
            uniform float _Emissive_frequency;
            uniform float _Emissive_power;
            uniform float4 _Emissive_ONcolor;
            uniform sampler2D _t_norm; uniform float4 _t_norm_ST;
            uniform sampler2D _t_spec; uniform float4 _t_spec_ST;
            uniform sampler2D _t_alb; uniform float4 _t_alb_ST;
            uniform float4 _Player_color;
            uniform float _Metal_reflectivity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _t_norm_var = UnpackNormal(tex2D(_t_norm,TRANSFORM_TEX(i.uv0, _t_norm)));
                float3 normalLocal = _t_norm_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _t_spec_var = tex2D(_t_spec,TRANSFORM_TEX(i.uv0, _t_spec));
                float4 _Mask_ID_var = tex2D(_Mask_ID,TRANSFORM_TEX(i.uv0, _Mask_ID));
                float3 specularColor = ((_Metal_reflectivity+_t_spec_var.rgb)*_Mask_ID_var.g);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _t_alb_var = tex2D(_t_alb,TRANSFORM_TEX(i.uv0, _t_alb));
                float3 diffuseColor = lerp((float3(0.4926471,0.4926471,0.4926471)+_t_alb_var.rgb),_Player_color.rgb,_Mask_ID_var.r);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
