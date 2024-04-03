using UnityEngine;
using UnityEngine.UI;
public class HealthBarCanvas : MonoBehaviour {
    [SerializeField] private Image healthImage;

    public void SetHealthFillAmount(float fillAmount) {
        healthImage.fillAmount = fillAmount;
    }
}