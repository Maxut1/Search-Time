using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class CharterAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;


        public void PlayRejected()
        {
            _animator.SetTrigger("PlayRejected");
        }

        public void PlaySillyDance()
        {
            _animator.SetTrigger("PlaySillyDance");
        }
    }
}

