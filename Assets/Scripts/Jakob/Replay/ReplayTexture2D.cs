using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ReplayTexture2D : MonoBehaviour
{
    private bool grab;
    public Renderer display;
    public RenderTexture renderTexture;
    public List<Material> textureFrames;

    private void Start()
    {
        textureFrames = new List<Material>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            grab = true;
        }
    }

    private void OnEnable()
    {
        RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
    }

    private void OnDisable()
    {
        RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
    }

    private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        OnPostRender();
    }
    private void OnPostRender()
    {
        if (grab)
        {
            Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0, false);
            texture.Apply();
            if (display != null)
            {
                display.material.mainTexture = texture;
            }

            grab = false;
        }
    }
}
