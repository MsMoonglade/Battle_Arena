// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-8087-OUT,spec-358-OUT,gloss-8556-R,normal-8529-RGB,emission-4077-OUT,amspl-8410-RGB;n:type:ShaderForge.SFN_Slider,id:358,x:32282,y:32592,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:2758,x:31765,y:32214,ptovrint:False,ptlb:Pan_alpha,ptin:_Pan_alpha,varname:node_2758,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:489a4a9af9a7ac64ba60d911fbd0f8ef,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2624,x:32085,y:32200,ptovrint:False,ptlb:Albdedo,ptin:_Albdedo,varname:node_2624,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3649782ecbc05764fab240df8dd69f07,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7093,x:32030,y:32945,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_7093,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e01e891658f4e6b47a1fcdb0f64924a4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8556,x:32361,y:32679,ptovrint:False,ptlb:Glossines,ptin:_Glossines,varname:node_8556,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e147d53b2ffcf2148955883249a2888f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8529,x:32361,y:32849,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_8529,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e383ddac7e8b31b48904e9fdb1bb96bf,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9057,x:31765,y:32470,ptovrint:False,ptlb:Pan_texture,ptin:_Pan_texture,varname:node_9057,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:47a2f9361651d7744aeea78f5d330eb0,ntxv:0,isnm:False|UVIN-5268-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8410,x:32363,y:33156,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_8410,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:78ce1debad37da94eb5374eaa7def381,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4077,x:32363,y:33018,varname:node_4077,prsc:2|A-7093-RGB,B-2123-OUT;n:type:ShaderForge.SFN_Slider,id:2123,x:31899,y:33173,ptovrint:False,ptlb:Emissive_power,ptin:_Emissive_power,varname:node_2123,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:8590,x:31002,y:32260,varname:node_8590,prsc:2;n:type:ShaderForge.SFN_Slider,id:7644,x:31017,y:32578,ptovrint:False,ptlb:Pann_velocity,ptin:_Pann_velocity,varname:node_7644,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Panner,id:5268,x:31566,y:32368,varname:node_5268,prsc:2,spu:1,spv:0|DIST-7722-OUT;n:type:ShaderForge.SFN_Multiply,id:7722,x:31368,y:32368,varname:node_7722,prsc:2|A-8590-T,B-7644-OUT;n:type:ShaderForge.SFN_Add,id:8087,x:32356,y:32409,varname:node_8087,prsc:2|A-2624-RGB,B-4052-OUT;n:type:ShaderForge.SFN_Multiply,id:4052,x:31991,y:32365,varname:node_4052,prsc:2|A-2758-RGB,B-9057-RGB;proporder:2624-7644-9057-2758-358-8556-8529-2123-7093-8410;pass:END;sub:END;*/

Shader "Shader Forge/sh_publicitary" {
    Properties {
        _Albdedo ("Albdedo", 2D) = "white" {}
        _Pann_velocity ("Pann_velocity", Range(0, 1)) = 0.5
        _Pan_texture ("Pan_texture", 2D) = "white" {}
        _Pan_alpha ("Pan_alpha", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Glossines ("Glossines", 2D) = "white" {}
        _Normal ("Normal", 2D) = "white" {}
        _Emissive_power ("Emissive_power", Range(0, 1)) = 0
        _Emission ("Emission", 2D) = "white" {}
        _Specular ("Specular", 2D) = "white" {}
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform sampler2D _Pan_alpha; uniform float4 _Pan_alpha_ST;
            uniform sampler2D _Albdedo; uniform float4 _Albdedo_ST;
            uniform sampler2D _Emission; uniform float4 _Emission_ST;
            uniform sampler2D _Glossines; uniform float4 _Glossines_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _Pan_texture; uniform float4 _Pan_texture_ST;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform float _Emissive_power;
            uniform float _Pann_velocity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
            #endif
            #ifdef DYNAMICLIGHTMAP_ON
                o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
            #endif
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
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
            float3 normalLocal = _Normal_var.rgb;
            float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
            float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
            float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
            float Pi = 3.141592654;
            float InvPi = 0.31830988618;
///// Gloss:
            float4 _Glossines_var = tex2D(_Glossines,TRANSFORM_TEX(i.uv0, _Glossines));
            float gloss = _Glossines_var.r;
            float specPow = exp2( gloss * 10.0+1.0);
/// GI Data:
            UnityLight light;
            #ifdef LIGHTMAP_OFF
                light.color = lightColor;
                light.dir = lightDirection;
                light.ndotl = LambertTerm (normalDirection, light.dir);
            #else
                light.color = half3(0.f, 0.f, 0.f);
                light.ndotl = 0.0f;
                light.dir = half3(0.f, 0.f, 0.f);
            #endif
            UnityGIInput d;
            d.light = light;
            d.worldPos = i.posWorld.xyz;
            d.worldViewDir = viewDirection;
            d.atten = attenuation;
            #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                d.ambient = 0;
                d.lightmapUV = i.ambientOrLightmapUV;
            #else
                d.ambient = i.ambientOrLightmapUV;
            #endif
            d.boxMax[0] = unity_SpecCube0_BoxMax;
            d.boxMin[0] = unity_SpecCube0_BoxMin;
            d.probePosition[0] = unity_SpecCube0_ProbePosition;
            d.probeHDR[0] = unity_SpecCube0_HDR;
            d.boxMax[1] = unity_SpecCube1_BoxMax;
            d.boxMin[1] = unity_SpecCube1_BoxMin;
            d.probePosition[1] = unity_SpecCube1_ProbePosition;
            d.probeHDR[1] = unity_SpecCube1_HDR;
            UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
            lightDirection = gi.light.dir;
            lightColor = gi.light.color;
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
            float LdotH = max(0.0,dot(lightDirection, halfDirection));
            float4 _Albdedo_var = tex2D(_Albdedo,TRANSFORM_TEX(i.uv0, _Albdedo));
            float4 _Pan_alpha_var = tex2D(_Pan_alpha,TRANSFORM_TEX(i.uv0, _Pan_alpha));
            float4 node_8590 = _Time + _TimeEditor;
            float2 node_5268 = (i.uv0+(node_8590.g*_Pann_velocity)*float2(1,0));
            float4 _Pan_texture_var = tex2D(_Pan_texture,TRANSFORM_TEX(node_5268, _Pan_texture));
            float3 diffuseColor = (_Albdedo_var.rgb+(_Pan_alpha_var.rgb*_Pan_texture_var.rgb)); // Need this for specular when using metallic
            float specularMonochrome;
            float3 specularColor;
            diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
            specularMonochrome = 1-specularMonochrome;
            float NdotV = max(0.0,dot( normalDirection, viewDirection ));
            float NdotH = max(0.0,dot( normalDirection, halfDirection ));
            float VdotH = max(0.0,dot( viewDirection, halfDirection ));
            float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
            float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
            float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
            float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
            half grazingTerm = saturate( gloss + specularMonochrome );
            float3 indirectSpecular = (gi.indirect.specular + _Specular_var.rgb);
            indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
            float3 specular = (directSpecular + indirectSpecular);
/// Diffuse:
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
            float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
            float3 indirectDiffuse = float3(0,0,0);
            indirectDiffuse += gi.indirect.diffuse;
            float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
// Emissive:
            float4 _Emission_var = tex2D(_Emission,TRANSFORM_TEX(i.uv0, _Emission));
            float3 emissive = (_Emission_var.rgb*_Emissive_power);
// Final Color:
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
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #define _GLOSSYENV 1
        #include "UnityCG.cginc"
        #include "AutoLight.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #pragma multi_compile_fwdadd_fullshadows
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma multi_compile_fog
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform float4 _TimeEditor;
        uniform float _Metallic;
        uniform sampler2D _Pan_alpha; uniform float4 _Pan_alpha_ST;
        uniform sampler2D _Albdedo; uniform float4 _Albdedo_ST;
        uniform sampler2D _Emission; uniform float4 _Emission_ST;
        uniform sampler2D _Glossines; uniform float4 _Glossines_ST;
        uniform sampler2D _Normal; uniform float4 _Normal_ST;
        uniform sampler2D _Pan_texture; uniform float4 _Pan_texture_ST;
        uniform float _Emissive_power;
        uniform float _Pann_velocity;
        struct VertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 tangent : TANGENT;
            float2 texcoord0 : TEXCOORD0;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv0 : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float2 uv2 : TEXCOORD2;
            float4 posWorld : TEXCOORD3;
            float3 normalDir : TEXCOORD4;
            float3 tangentDir : TEXCOORD5;
            float3 bitangentDir : TEXCOORD6;
            LIGHTING_COORDS(7,8)
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv0 = v.texcoord0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
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
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
            float3 normalLocal = _Normal_var.rgb;
            float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
            float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
            float Pi = 3.141592654;
            float InvPi = 0.31830988618;
///// Gloss:
            float4 _Glossines_var = tex2D(_Glossines,TRANSFORM_TEX(i.uv0, _Glossines));
            float gloss = _Glossines_var.r;
            float specPow = exp2( gloss * 10.0+1.0);
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float LdotH = max(0.0,dot(lightDirection, halfDirection));
            float4 _Albdedo_var = tex2D(_Albdedo,TRANSFORM_TEX(i.uv0, _Albdedo));
            float4 _Pan_alpha_var = tex2D(_Pan_alpha,TRANSFORM_TEX(i.uv0, _Pan_alpha));
            float4 node_8590 = _Time + _TimeEditor;
            float2 node_5268 = (i.uv0+(node_8590.g*_Pann_velocity)*float2(1,0));
            float4 _Pan_texture_var = tex2D(_Pan_texture,TRANSFORM_TEX(node_5268, _Pan_texture));
            float3 diffuseColor = (_Albdedo_var.rgb+(_Pan_alpha_var.rgb*_Pan_texture_var.rgb)); // Need this for specular when using metallic
            float specularMonochrome;
            float3 specularColor;
            diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
            specularMonochrome = 1-specularMonochrome;
            float NdotV = max(0.0,dot( normalDirection, viewDirection ));
            float NdotH = max(0.0,dot( normalDirection, halfDirection ));
            float VdotH = max(0.0,dot( viewDirection, halfDirection ));
            float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
            float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
            float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
            float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
            float3 specular = directSpecular;
/// Diffuse:
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
            float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
            float3 diffuse = directDiffuse * diffuseColor;
// Final Color:
            float3 finalColor = diffuse + specular;
            return fixed4(finalColor * 1,0);
        }
        ENDCG
    }
    Pass {
        Name "Meta"
        Tags {
            "LightMode"="Meta"
        }
        Cull Off
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #define UNITY_PASS_META 1
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #define _GLOSSYENV 1
        #include "UnityCG.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #include "UnityMetaPass.cginc"
        #pragma fragmentoption ARB_precision_hint_fastest
        #pragma multi_compile_shadowcaster
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma multi_compile_fog
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform float4 _TimeEditor;
        uniform float _Metallic;
        uniform sampler2D _Pan_alpha; uniform float4 _Pan_alpha_ST;
        uniform sampler2D _Albdedo; uniform float4 _Albdedo_ST;
        uniform sampler2D _Emission; uniform float4 _Emission_ST;
        uniform sampler2D _Glossines; uniform float4 _Glossines_ST;
        uniform sampler2D _Pan_texture; uniform float4 _Pan_texture_ST;
        uniform float _Emissive_power;
        uniform float _Pann_velocity;
        struct VertexInput {
            float4 vertex : POSITION;
            float2 texcoord0 : TEXCOORD0;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv0 : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float2 uv2 : TEXCOORD2;
            float4 posWorld : TEXCOORD3;
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv0 = v.texcoord0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.posWorld = mul(_Object2World, v.vertex);
            o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
            return o;
        }
        float4 frag(VertexOutput i) : SV_Target {
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            UnityMetaInput o;
            UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
            
            float4 _Emission_var = tex2D(_Emission,TRANSFORM_TEX(i.uv0, _Emission));
            o.Emission = (_Emission_var.rgb*_Emissive_power);
            
            float4 _Albdedo_var = tex2D(_Albdedo,TRANSFORM_TEX(i.uv0, _Albdedo));
            float4 _Pan_alpha_var = tex2D(_Pan_alpha,TRANSFORM_TEX(i.uv0, _Pan_alpha));
            float4 node_8590 = _Time + _TimeEditor;
            float2 node_5268 = (i.uv0+(node_8590.g*_Pann_velocity)*float2(1,0));
            float4 _Pan_texture_var = tex2D(_Pan_texture,TRANSFORM_TEX(node_5268, _Pan_texture));
            float3 diffColor = (_Albdedo_var.rgb+(_Pan_alpha_var.rgb*_Pan_texture_var.rgb));
            float specularMonochrome;
            float3 specColor;
            diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
            float4 _Glossines_var = tex2D(_Glossines,TRANSFORM_TEX(i.uv0, _Glossines));
            float roughness = 1.0 - _Glossines_var.r;
            o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
            
            return UnityMetaFragment( o );
        }
        ENDCG
    }
}
FallBack "Diffuse"
CustomEditor "ShaderForgeMaterialInspector"
}
