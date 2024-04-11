using UnityEngine;

namespace Game.Scripts.PlayerControl {
    public class EnemyCharacterDeath : CharacterDeath {
        [SerializeField] private int addEnemyStat = 1;
        private new void Start() {
            // Debug.Log("EnemyCharacterDeath::Start(); -- ");
            base.Start();
            characterDeath += () => {
                PlayerStatsCanvas.Instance.AddEnemyStat(addEnemyStat);
            };
        }
    }
}