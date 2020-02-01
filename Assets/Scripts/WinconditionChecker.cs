using System.Linq;
using UnityEngine;

public class WinconditionChecker : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectsWithTag("Ship").ToList().ForEach(ship => {
            ship.GetComponent<ShipProgress>().shipCompleted  += OnShipCompletion;
        });
    }

    public void OnShipCompletion(Team team) {
        Debug.Log(string.Format("LOL TEAM {0} WON!", team == Team.BLUE ? "BLUE" : "RED"));
    }
}
