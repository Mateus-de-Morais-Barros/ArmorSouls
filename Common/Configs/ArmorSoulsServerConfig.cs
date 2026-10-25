using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorSouls.Common.Configs
{
    public class ArmorSoulsServerConfig : ModConfig
    {
        // Máximo de slots registrados no carregamento; a config só escolhe quantos ficam visíveis
        public const int MaxSoulSlots = 10;

        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(false)]
        public bool EnableSoulSlots;

        [Range(1, MaxSoulSlots)]
        [DefaultValue(3)]
        [Slider]
        public int SoulSlotCount;
    }
}
