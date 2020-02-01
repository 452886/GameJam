using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerData
{
    public static string Fire(ActivePlayer ap) {
        switch(ap) {
            case ActivePlayer.PLAYER1: return "Fire1_P1";
            case ActivePlayer.PLAYER2: return "Fire1_P2";
            case ActivePlayer.PLAYER3: return "Fire1_P3";
            case ActivePlayer.PLAYER4: return "Fire1_P4";
            default: return null;
        }
    }

    public static string Horizontal(ActivePlayer ap) {
        switch(ap) {
            case ActivePlayer.PLAYER1: return "Horizontal_P1";
            case ActivePlayer.PLAYER2: return "Horizontal_P2";
            case ActivePlayer.PLAYER3: return "Horizontal_P3";
            case ActivePlayer.PLAYER4: return "Horizontal_P4";
            default: return null;
        }
    }

        public static string Vertical(ActivePlayer ap) {
        switch(ap) {
            case ActivePlayer.PLAYER1: return "Vertical_P1";
            case ActivePlayer.PLAYER2: return "Vertical_P2";
            case ActivePlayer.PLAYER3: return "Vertical_P3";
            case ActivePlayer.PLAYER4: return "Vertical_P4";
            default: return null;
        }
    }
}

[System.Serializable]
public enum ActivePlayer {
    PLAYER1,
    PLAYER2,
    PLAYER3,
    PLAYER4
}
