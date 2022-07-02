using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _redChannel;
    [SerializeField, Range(0,1)] private float _greenChannel;
    [SerializeField, Range(0,1)] private float _blueChannel;

    void Update()
    {
        Shader.SetGlobalFloat("_Red", _redChannel);    
        Shader.SetGlobalFloat( "_Green", _greenChannel);  
        Shader.SetGlobalFloat( "_Blue", _blueChannel); 
        
    }
}
