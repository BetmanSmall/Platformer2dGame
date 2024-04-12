using Game.Scripts.BattleScripts;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.PlayerControl {
    public class CharacterDeath : MonoBehaviour {
        [SerializeField] protected Health health;
        private AnimatorController animatorController;
        public UnityAction characterDeath;

        protected void Start() {
            if (!health) {
                health = transform.GetComponent<Health>();
            }
            animatorController = GetComponent<AnimatorController>();
            health.HealthChanged += HealthChanged;
        }

        private void HealthChanged(float currentHealth) {
            if (!health.IsAlive) {
                animatorController.Death();
                Invoke(nameof(DestroyMe), 2f);
            }
        }

        private void DestroyMe() {
            characterDeath.Invoke();
            Destroy(gameObject);
        }
    }
}