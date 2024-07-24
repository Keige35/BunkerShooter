using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IDamageable
    {
        void TakeDamage(int damage, DamageType damageType = DamageType.Player);
    }

    public enum DamageType
    {
        Enemy,
        Player,
    }

