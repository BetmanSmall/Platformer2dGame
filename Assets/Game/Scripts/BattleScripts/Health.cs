using Game.Scripts.PlayerControl;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.BattleScripts {
    [RequireComponent(typeof(AnimatorController))]
    public class Health : MonoBehaviour {
        private float currentHealth;
        [SerializeField] private float maxHealth = 100f;
        public float MaxHealth => maxHealth;
        public float CurrentHealth => currentHealth;
        public UnityAction<float> HealthChanged;
        public bool IsAlive => currentHealth > 0;

        private void Start() {
            currentHealth = maxHealth;
        }

        public bool TakeDamage(float damage) {
            if (damage > 0) {
                currentHealth -= damage;
                if (currentHealth < 0) currentHealth = 0;
                HealthChanged.Invoke(currentHealth);
                return true;
            }
            return false;
        }
    }
}