using UnityEngine;
[ExecuteAlways]
public class Player : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _redChannel;
    [SerializeField, Range(0,1)] private float _greenChannel;
    [SerializeField, Range(0,1)] private float _blueChannel;

    public void Start()
    {
        _redChannel = 0f;
        _greenChannel = 0f;
        _blueChannel = 0f;
    }
    public void SetRed(float red)
    {
        _redChannel = red;
    }
    public void SetGreen(float green)
    {
        _greenChannel = green;
    }
    public void SetBlue(float blue)
    {
        _blueChannel = blue;
    }
    void Update()
    {
        Shader.SetGlobalFloat("_Red", _redChannel);    
        Shader.SetGlobalFloat( "_Green", _greenChannel);  
        Shader.SetGlobalFloat( "_Blue", _blueChannel); 
        
    }
}
