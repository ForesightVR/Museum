using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HapticEffects : Effect
{
    public WhichHand handedness = WhichHand.Both;
    public float duration = 1;
    public float frequency = 1;
    public float amplitude = 1;

    Player player;
    List<Hand> hands = new List<Hand>();

    protected override void Awake()
    {
        base.Awake();
        player = Player.instance;
        hands = HapticUtilities.GetHands(player, handedness);
    }

    public void PerformHaptic()
    {
        foreach(Hand hand in hands)
            hand.TriggerHapticPulse(duration, frequency, amplitude);
    }

}
