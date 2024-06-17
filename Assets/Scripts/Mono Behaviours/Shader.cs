using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Mono_Behaviours
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public abstract class Shader : MonoBehaviour
    {
        protected MeshRenderer meshRenderer = null;
        protected Material shaderMaterial = null;

        protected virtual void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            shaderMaterial = meshRenderer.material;
        }
    }
}
