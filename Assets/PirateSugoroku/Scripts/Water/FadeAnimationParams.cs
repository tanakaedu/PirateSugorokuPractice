using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1.PirateSugoroku
{
    /// <summary>
    /// Animationでフェードできるようにパラメーターを設定します。
    /// </summary>
    public class FadeAnimationParams : MonoBehaviour
    {
        [Tooltip("フェード用マテリアル"), SerializeField]
        Material[] fadeMaterials = default;

        MeshRenderer meshRenderer;
        Material[] fadeMaterialInstances;
        Material[] opaqueInstances;

        /// <summary>
        /// 描画モード。Opaque=0, Fade=2
        /// </summary>
        public int renderingMode;

        /// <summary>
        /// α値
        /// </summary>
        public float alpha;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            fadeMaterialInstances = new Material[fadeMaterials.Length];
            opaqueInstances = new Material[meshRenderer.materials.Length];
            for (int i=0;i<meshRenderer.materials.Length;i++)
            {
                opaqueInstances[i] = meshRenderer.materials[i];
            }
            for (int i=0;i<fadeMaterials.Length;i++)
            {
                fadeMaterialInstances[i] = new Material(fadeMaterials[i]);
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < opaqueInstances.Length; i++)
            {
                Destroy(opaqueInstances[i]);
            }
            for (int i = 0; i < fadeMaterialInstances.Length; i++)
            {
                Destroy(fadeMaterialInstances[i]);
            }
        }

        private void LateUpdate()
        {
            // Opaque
            if (renderingMode == 0)
            {
                meshRenderer.materials = opaqueInstances;
                return;
            }

            // Fade
            Color c;
            meshRenderer.materials = fadeMaterialInstances;
            for (int i=0;i<meshRenderer.materials.Length;i++)
            {
                c = meshRenderer.materials[i].color;
                c.a = alpha;
                meshRenderer.materials[i].color = c;
            }
        }
    }
}