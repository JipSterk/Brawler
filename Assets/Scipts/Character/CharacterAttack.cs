﻿using UnityEngine;
using UnityEngine.Experimental.Director;

namespace Brawler.Characters
{
    public class CharacterAttack : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex, controller);
        }
    }
}