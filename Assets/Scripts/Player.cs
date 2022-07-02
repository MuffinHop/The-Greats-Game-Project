using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _redChannel;
    [SerializeField, Range(0,1)] private float _greenChannel;
    [SerializeField, Range(0,1)] private float _blueChannel;

    [SerializeField] private Grayscale _grayscale;
    void Update()
    {
        _grayscale.Red.value = _redChannel;    
        _grayscale.Green.value = _greenChannel;   
        _grayscale.Blue.value = _blueChannel;   
        
    }
}
