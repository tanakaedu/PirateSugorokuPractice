Shader "LowPolyWater/WaterShadedZBuffer" {

	Subshader
	{
		// https://qiita.com/kajitaj63b3/items/3cf52494b01458da9127 �ɂ��Ē������āADepth�̏������݂����	
		Lod 500

		Tags { "RenderType" = "TransparentCutout" "Queue" = "AlphaTest+2" "IgnoreProjection" = "True"}

		//GrabPass { "_RefractionTex" }

		Pass
		{
			Tags { "LightMode" = "ShadowCaster"}
			ZWrite On
			ColorMask 0
		}
	}
	Fallback "Transparent/Diffuse"
}
