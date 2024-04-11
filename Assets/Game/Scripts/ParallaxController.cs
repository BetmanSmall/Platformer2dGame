using UnityEngine;

namespace Game.Scripts {
    public class ParallaxController : MonoBehaviour {
        [SerializeField] private Transform[] layers;
        [SerializeField] private float[] coefficients;

        private int layersCount;

        private void Start() {
            layersCount = layers.Length;
        }

        private void FixedUpdate() {
            for (int k = 0; k < layersCount; k++) {
                layers[k].position = transform.position * coefficients[k];
            }
        }
    }
}