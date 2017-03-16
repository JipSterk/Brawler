using System;
using UnityEngine;

namespace Brawler.Characters
{
    [Serializable]
    public class CharacterStats
    {
        public float WalkSpeed { get { return _walkSpeed; } }
        public float SprintSpeed { get { return _sprintSpeed; } }
        public float CrouchSpeed { get { return _crouchSpeed; } }
        public int Health { get { return _health; } }
        public float Weight { get { return _weight; } }

        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _sprintSpeed;
        [SerializeField] private float _crouchSpeed;
        [SerializeField] private int _health;
        [SerializeField] private float _weight;
    }
}