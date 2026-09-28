using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorSouls.Common.Configs
{
    public class ArmorSoulsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool IncludePieceDamageBonuses;
    }
}
