using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public static class HapticUtilities
{
    public static List<Hand> GetHands(Player player, WhichHand whichHand)
    {
        List<Hand> hands = new List<Hand>();

        if (whichHand == WhichHand.Left || whichHand == WhichHand.Both)
            hands.Add(player.leftHand);

        if (whichHand == WhichHand.Right || whichHand == WhichHand.Both)
            hands.Add(player.rightHand);

        return hands;
    }
}
