using UnityEngine;

public class ShipProgress : MonoBehaviour
{
    [SerializeField] Team team;
    [SerializeField] Constants constants;
    public delegate void ShipCompleted(Team team);

    public event ShipCompleted shipCompleted;


    public int currentMaximusRepairus;

    public void AddRepairPoints(int points) {
        this.currentMaximusRepairus += points;
        if(this.currentMaximusRepairus <= 0) this.currentMaximusRepairus = 0;
        if(this.currentMaximusRepairus >= constants.shipRepairWinCondition && shipCompleted != null) shipCompleted(team); 
    }

}

[System.Serializable]
public enum Team {
    BLUE,
    RED
}