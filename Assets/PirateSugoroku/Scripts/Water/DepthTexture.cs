using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://light11.hatenadiary.com/entry/2018/05/08/012149
public class DepthTexture : MonoBehaviour
{
    [SerializeField]
    Shader _shader;
    Material _material;

    private void Start()
    {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;

        _material = new Material(_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _material);
    }
}
