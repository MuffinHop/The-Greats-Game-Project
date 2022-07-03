using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warpball : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 scale;

    private float _hide;

    [SerializeField] private Player _player;
    void Start()
    {
        startPos = transform.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startPos.x,39f - _player.Steps * 10f, startPos.z);
        transform.localScale = scale * (1f + Mathf.Sin(Time.time)*0.1f * _player.Steps);
        if (Vector3.Distance(_player.transform.position, transform.position) < 15f && _player.Steps >= 2.9f)
        {
            _hide += Time.deltaTime;
            Shader.SetGlobalFloat("_Blend", _hide);    
        }
        else if (_player.Steps < 3f)
        {
            _hide = 0;
            Shader.SetGlobalFloat("_Blend", _hide);    
        }

        if (_hide > 4f)
        {
            SceneManager.LoadScene (sceneName:"Scenes/End");
        }
    }
}
