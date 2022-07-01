using UnityEngine;

namespace MarwanZaky
{
    public class SwordWeapon : Weapon
    {
        [Header("Sword"), SerializeField] float damage = 10;
        [SerializeField] string targetTag;

        private void OnTriggerEnter(Collider col)
        {
        }
    }
}