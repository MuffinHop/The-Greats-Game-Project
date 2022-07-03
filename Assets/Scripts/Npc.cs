using System.Collections;
using System.Collections.Generic;
using MarwanZaky;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _redPerson;
    [SerializeField] private bool _greenPerson;
    [SerializeField] private bool _bluePerson;
    public TextMeshProUGUI textmesh;
    public TextMeshProUGUI pressenter;
    public Image background;
    public string[] array;
    int  times=0;
    private bool saidEverything;
    void Update()
    {
        if (_player.GetComponent<PlayerMovement>().CanMove)
        {
            pressenter.color = new Color(1f,1f,1f,0f);
            pressenter.alpha = 0f;
            textmesh.color = new Color(1f, 1f, 1f, 0f);
        }
        if (Vector3.Distance(_player.transform.position, transform.position) < 6f)
        {
            transform.LookAt(_player.transform);
            if (!saidEverything)
            {
                if (_redPerson)
                {
                    _player.TurnRed();
                }

                if (_greenPerson)
                {
                    _player.TurnGreen();
                }

                if (_bluePerson)
                {
                    _player.TurnBlue();
                }


                textmesh.text = array[times];
                if (Input.GetButtonDown("Submit"))
                {
                    times = times + 1;
                }
            }
            
            if (times == array.Length)
            {
                textmesh.text = array[0];
                times = 0;
                saidEverything = true;
            }
            else
            {
                _player.GetComponent<Character>().CanMove = false;
                _player.GetComponent<PlayerMovement>().CanMove = false;
                pressenter.color = Color.white;
                background.color = new Color(0, 0, 0, 0.43f);
                pressenter.alpha = 1f;
                textmesh.color = Color.white;
            }

            if (saidEverything)
            {
                _player.GetComponent<Character>().CanMove = true;
                _player.GetComponent<PlayerMovement>().CanMove = true;
                pressenter.color = new Color(1f, 1f, 1f, 0f);
                background.color = new Color(0, 0, 0, 0.0f);
                pressenter.alpha = 0f;
                textmesh.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }
}
