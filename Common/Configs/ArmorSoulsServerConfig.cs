using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorSouls.Common.Configs
{
    public class ArmorSoulsServerConfig : ModConfig
    {
        // Máximo de slots registrados no carregamento; a config só escolhe quantos ficam visíveis
        public const int MaxSoulSlots = 10;

        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("SoulSlots")]
        [DefaultValue(true)]
        public bool EnableSoulSlots;

        [DefaultValue(true)]
        public bool ProgressiveSoulSlots;

        [Range(1, MaxSoulSlots)]
        [DefaultValue(6)]
        [Slider]
        public int SoulSlotCount;

        [Header("SoulStorage")]
        [DefaultValue(true)]
        public bool SoulsWorkInPiggyBank;

        [DefaultValue(false)]
        public bool SoulsWorkInSafe;

        [DefaultValue(false)]
        public bool SoulsWorkInDefendersForge;

        [DefaultValue(false)]
        public bool SoulsWorkInVoidVault;

        [Header("SoulBonuses")]
        [DefaultValue(true)]
        public bool IncludePieceDamageBonuses;
    }
}
