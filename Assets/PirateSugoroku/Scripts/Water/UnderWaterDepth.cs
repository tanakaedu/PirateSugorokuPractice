using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class UnderWaterDepth : MonoBehaviour
{
    Camera sourceCamera;
    Camera underWaterCamera;
    RenderTexture underWaterTex;
    float currentAspect;

    private void Awake()
    {
        sourceCamera = transform.parent.GetComponent<Camera>();
        underWaterCamera = GetComponent<Camera>();
        underWaterCamera.CopyFrom(sourceCamera);
        underWaterCamera.clearFlags = CameraClearFlags.Depth;
        underWaterCamera.cullingMask = underWaterCamera.cullingMask & (-1 ^ LayerMask.GetMask("Water"));
		underWaterCamera.depthTextureMode = DepthTextureMode.Depth;
		UpdateRenderTex();
    }

    private void LateUpdate()
    {
        UpdateRenderTex();
        Shader.SetGlobalTexture("_WaterDepthTex", underWaterTex);
    }

    private void OnDestroy()
    {
        DestroyTexture();
    }

    void DestroyTexture()
    {
        if (underWaterCamera.targetTexture != null)
        {
            underWaterCamera.targetTexture = null;
        }
        if (underWaterTex != null)
        {
            DestroyImmediate(underWaterTex);
            underWaterTex = null;
        }
    }

    /// <summary>
    /// RenderTextureÇê∂ê¨
    /// </summary>
    void UpdateRenderTex()
	{
        if ((sourceCamera == null) || (underWaterCamera == null)) return;

        if (underWaterTex != null)
        {
            if (currentAspect != sourceCamera.aspect)
            {
                currentAspect = sourceCamera.aspect;
                DestroyTexture();
            }
            else
            {
                return;
            }
        }

        underWaterTex = new RenderTexture(
            512,512,
            24,
            RenderTextureFormat.Depth,
            RenderTextureReadWrite.Linear);
		underWaterTex.dimension = TextureDimension.Tex2D;
		underWaterTex.autoGenerateMips = false;
		underWaterTex.anisoLevel = 1;
		underWaterTex.filterMode = FilterMode.Point;
		underWaterTex.wrapMode = TextureWrapMode.Clamp;
        underWaterCamera.targetTexture = underWaterTex;
        underWaterCamera.aspect = sourceCamera.aspect;
        currentAspect = sourceCamera.aspect;
    }
}
