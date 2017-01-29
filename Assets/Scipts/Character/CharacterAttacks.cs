using System;
using UnityEngine;

namespace Brawler.Characters
{
    [Serializable]
    public struct CharacterAttacks
    {
        public CharacterAttack NormalAttack { get { return _normalAttack; } }
        public CharacterAttack SpecialAttack { get { return _specialAttack; } }
        public CharacterAttack ChargedAttack { get { return _chargedAttack; } }

        [SerializeField] private CharacterAttack _normalAttack;
        [SerializeField] private CharacterAttack _specialAttack;
        [SerializeField] private CharacterAttack _chargedAttack;
    }
}