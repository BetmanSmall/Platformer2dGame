using UnityEngine;
namespace Game.Scripts.BattleScripts {
    public class DamageDealer : MonoBehaviour {
        [SerializeField] private bool bullet = true;
        [SerializeField] private float damage = 50f;

        private void OnTriggerEnter2D(Collider2D collider) {
            if (!collider.CompareTag(gameObject.tag)) { // todo 1/2 Необходим что бы Игрок не наносил сам себе урон Снарядом спавнущимся внутри его коллайдера
                if (collider.TryGetComponent(out Health otherHealth)) {
                    otherHealth.TakeDamage(damage);
                    if (bullet) {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}