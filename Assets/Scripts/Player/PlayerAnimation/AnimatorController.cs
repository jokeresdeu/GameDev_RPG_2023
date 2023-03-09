using System;
using UnityEngine;

namespace Player.PlayerAnimation
{
    public abstract class AnimatorController : MonoBehaviour
    {
        private AnimationType _currentAnimationType;

        public event Action ActionRequested;
        public event Action AnimationEnded;

        public bool PlayAnimation(AnimationType animationType, bool active)
        {
            if (!active)
            {
                if (_currentAnimationType == AnimationType.Idle || _currentAnimationType != animationType)
                    return false;

                _currentAnimationType = AnimationType.Idle;
                PlayAnimation(_currentAnimationType);
                return false;
            }

            if (_currentAnimationType >= animationType)
                return false;

            _currentAnimationType = animationType;
            PlayAnimation(_currentAnimationType);
            return true;
        }

        protected abstract void PlayAnimation(AnimationType animationType);
        
        protected void OnActionRequested() => ActionRequested?.Invoke();
        protected void OnAnimationEnded() => AnimationEnded?.Invoke();
    }
}