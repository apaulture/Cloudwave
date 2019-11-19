Shader "Unlit/Texture" {
    Properties
    {
        _Color ("Main Color", Color) = (1,.5,.5,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _ToonShade ("ToonShader Cubemap(RGB)", CUBE) = "" { }
    }

SubShader {
Tags { "RenderType"="Opaque" }
LOD 100
Fog { Mode Off }
Lighting Off

Pass {
SetTexture [_MainTex] { combine texture }
}
}
}
