using System;

namespace Unity.Multiplayer.Samples.BossRoom
{
    /// <summary>
    /// List of all Actions supported in the game.
    /// </summary>
    public enum ActionType
    {
        None,
        TankBaseAttack,
        ArcherBaseAttack,
        MageBaseAttack,
        RogueBaseAttack,
        ImpBaseAttack,
        ImpBossBaseAttack,
        GeneralChase,
        GeneralRevive,
        DriveArrow,
        Emote1,
        Emote2,
        Emote3,
        Emote4,
        TankTestability,
        TankShieldBuff,
        ImpBossTrampleAttack,
        Stun,
        TankShieldRush,
        GeneralTarget,
        MageHeal,
        ArcherChargedShot,
        RogueStealthMode,
        ArcherVolley,
        RogueDashAttack,
    }
}
