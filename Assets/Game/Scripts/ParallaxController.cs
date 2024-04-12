using UnityEngine;

namespace Game.Scripts {
    public class ParallaxController : MonoBehaviour {
        [SerializeField] private Transform[] layers;
        [SerializeField] private float[] coefficients;

        private int layersCount;

        private void Start() {
            layersCount = layers.Length;
        }

        private void Update() {
            for (int i = 0; i < layersCount; i++) {
                layers[i].position = transform.position * coefficients[i];
            }
        }
    }
}