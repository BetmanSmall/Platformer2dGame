using Game.Scripts.Canvases;
using Game.Scripts.PlayerControl;
using UnityEngine;
namespace Game.Scripts.BattleScripts {
    [RequireComponent(typeof(AnimatorController))]
    public class Health : MonoBehaviour {
        [SerializeField] private HealthBarCanvas healthBarCanvas;
        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;
        private bool isAlive;
        private AnimatorController animatorController;

        private void Start() {
            animatorController = GetComponent<AnimatorController>();
            currentHealth = maxHealth;
            isAlive = true;
        }

        public void TakeDamage(float damage) {
            Debug.Log("TakeDamage(); -- damage:" + damage + ",go:" + gameObject, gameObject);
            currentHealth -= damage;
            healthBarCanvas.SetHealthFillAmount(currentHealth/maxHealth);
            CheckIsAlive();
            if (!isAlive) {
                animatorController.Death();
                if (gameObject.CompareTag("Player")) { // todo конечно, не фонтан, но по простому
                    MainCanvas.instance.ShowLosePanel();
                }
                Invoke(nameof(DestroyMe), 2f);
            }
        }

        private void CheckIsAlive() {
            if (currentHealth > 0) {
                isAlive = true;
            } else {
                isAlive = false;
            }
        }

        private void DestroyMe() {
            Destroy(gameObject);
        }
    }
}