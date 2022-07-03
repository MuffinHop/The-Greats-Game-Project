Shader "Hidden/Custom/Grayscale"
{
  HLSLINCLUDE 
      #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
      TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
      float _Blend;
      uniform float _Red;
      uniform float _Green;
      uniform float _Blue;
      float4 Frag(VaryingsDefault i) : SV_Target
      {
          float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
// Compute the luminance for the current pixel
          float4 final = color;
          float luminance = dot(final.rgb, float3(0.2126729, 0.7151522, 0.0721750));
          final.r = lerp(luminance,max(final.r,luminance),_Red);
          final.g = lerp(luminance,max(final.g,luminance),_Green);
          final.b = lerp(luminance,max(final.b,luminance),_Blue);
          float avg = min(max(_Red+_Green+_Blue-2.0,0.0),1.0);
          final.r = lerp(final.r,color.r,avg);
          final.g = lerp(final.g,color.g,avg);
          final.b = lerp(final.b,color.b,avg);
          final.rgb += float3(_Blend,_Blend,_Blend); 
          final.a = 1.0;
// Return the result
          return final;
      }
  ENDHLSL
  SubShader
  {
      Cull Off ZWrite Off ZTest Always
      Pass
      {
          HLSLPROGRAM
              #pragma vertex VertDefault
              #pragma fragment Frag
          ENDHLSL
      }
  }
}