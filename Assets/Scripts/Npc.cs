using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _redPerson;
    [SerializeField] private bool _greenPerson;
    [SerializeField] private bool _bluePerson;

    void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < 3f)
        {
            if (_redPerson)
            {
                _player.SetRed(1.0f);
            }
            if (_greenPerson)
            {
                _player.SetGreen(1.0f);
            }
            if (_bluePerson)
            {
                _player.SetBlue(1.0f);
            }
        }
    }
}
