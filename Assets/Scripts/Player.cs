using System;
using MarwanZaky;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _redChannel;
    [SerializeField, Range(0,1)] private float _greenChannel;
    [SerializeField, Range(0,1)] private float _blueChannel;
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _theend;
    private bool _turnRed, _turnGreen, _turnBlue;
    public float Steps;

    public void Start()
    {
        _redChannel = 0f;
        _greenChannel = 0f;
        _blueChannel = 0f;
        _turnRed = false;
        _turnGreen = false;
        _turnBlue = false;
        for (int i = 1; i < 4; i++)
        {
            _audioSources[i].volume = 0f;
        }
    }

    public void TurnRed()
    {
        _turnRed = true;
    }

    public void TurnGreen()
    {
        _turnGreen = true;
    }

    public void TurnBlue()
    {
        _turnBlue = true;
    }
    void Update()
    {
        if (Time.timeSinceLevelLoad > 4f) {
        
            _camera.SetActive(true);
        }
        if (_turnRed)
        {
            _redChannel = Mathf.Min(_redChannel + Time.deltaTime/4f, 1f);
            _audioSources[1].volume = Mathf.Min(_audioSources[1].volume + Time.deltaTime/4f, 1f);;
        } 
        if (_turnGreen)
        {
            _greenChannel = Mathf.Min(_greenChannel + Time.deltaTime/4f, 1f);
            _audioSources[2].volume = Mathf.Min(_audioSources[2].volume + Time.deltaTime/4f, 1f);;
        }
        if (_turnBlue)
        {
            _blueChannel = Mathf.Min(_blueChannel + Time.deltaTime/4f, 1f);
            _audioSources[3].volume = Mathf.Min(_audioSources[3].volume + Time.deltaTime/4f, 1f);;
        }

        Steps = _redChannel + _greenChannel + _blueChannel;
        if (Steps == 3f && GetComponent<PlayerMovement>().CanMove)
        {
            _theend.SetActive(true);
        }
        Shader.SetGlobalFloat("_Red", _redChannel);    
        Shader.SetGlobalFloat( "_Green", _greenChannel);  
        Shader.SetGlobalFloat( "_Blue", _blueChannel); 
        
    }
}
