using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipProgress : MonoBehaviour
{
    [SerializeField] Team team;
    [SerializeField] Constants constants;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider slider;
    
    public delegate void ShipCompleted(Team team);
    public event ShipCompleted shipCompleted;

    private int currentMaximusRepairus;

    void Start()
    {
        slider.maxValue = constants.shipRepairWinCondition;
    }

    public void AddRepairPoints(int points) {
        this.currentMaximusRepairus += points;
        if(this.currentMaximusRepairus <= 0) this.currentMaximusRepairus = 0;
        if(this.currentMaximusRepairus >= constants.shipRepairWinCondition && shipCompleted != null) shipCompleted(team); 
    }

    public int getCurrentShipProgression() {
        return this.currentMaximusRepairus;
    }

    void FixedUpdate()
    {
        slider.value = this.currentMaximusRepairus;
        text.text = string.Format("{0} / {1}", currentMaximusRepairus, constants.shipRepairWinCondition);
    }

}

[System.Serializable]
public enum Team {
    BLUE,
    RED
}