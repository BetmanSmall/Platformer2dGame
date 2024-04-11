using System.Collections;
using UnityEngine;

namespace Game.Scripts {
    public class PickableUpCoin : MonoBehaviour {
        [SerializeField] private int addCoinCount = 1;
        [SerializeField] private float timeToPickUp = 1f;
        [SerializeField] private float speedToPickUp = 5f;


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                StartCoroutine(PickUp());
            }
        }

        private IEnumerator PickUp() {
            float timeToEnd = Time.time + timeToPickUp;
            while (Time.time < timeToEnd) {
                transform.position = Vector3.Lerp(transform.position, transform.position+transform.up, Time.deltaTime*speedToPickUp);
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            PlayerStatsCanvas.Instance.AddCoinStat(addCoinCount);
            Destroy(gameObject);
        }
    }
}