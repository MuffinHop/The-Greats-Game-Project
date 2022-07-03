using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ThrowInEffect : MonoBehaviour
{
    public PostProcessVolume m_Volume;
    private Grayscale m_Vignette;

    void Start()
    {
        PostProcessVolume volume = FindObjectOfType<PostProcessVolume>();
        // Create an instance of a vignette
        m_Vignette = ScriptableObject.CreateInstance<Grayscale>();
        m_Vignette.enabled.Override(true);
        // Use the QuickVolume method to create a volume with a priority of 100, and assign the vignette to this volume
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
        Shader.SetGlobalFloat("_Red", 0f);    
        Shader.SetGlobalFloat( "_Green", 0f);  
        Shader.SetGlobalFloat( "_Blue", 0f); 
        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
