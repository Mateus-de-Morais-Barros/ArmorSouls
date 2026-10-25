using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ArmorSouls.Common.Configs;
using ArmorSouls.Items.Souls;

namespace ArmorSouls.Common.Players
{
    public class SoulBankPlayer : ModPlayer
    {
        public override void PostUpdateEquips()
        {
            // Com os slots de alma ativos, as almas só funcionam equipadas neles
            if (ArmorSoulBase.SoulSlotsEnabled)
            {
                return;
            }

            ArmorSoulsServerConfig config = ModContent.GetInstance<ArmorSoulsServerConfig>();
            HashSet<int> appliedSouls = new HashSet<int>();

            // Percorre cada armazenamento habilitado na config
            if (config.SoulsWorkInPiggyBank)
                ProcessStorage(Player.bank.item, appliedSouls);

            if (config.SoulsWorkInSafe)
                ProcessStorage(Player.bank2.item, appliedSouls);

            if (config.SoulsWorkInDefendersForge)
                ProcessStorage(Player.bank3.item, appliedSouls);

            if (config.SoulsWorkInVoidVault)
                ProcessStorage(Player.bank4.item, appliedSouls);
        }

        private void ProcessStorage(Item[] inventory, HashSet<int> appliedSouls)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Item item = inventory[i];

                if (!item.IsAir && item.ModItem is ArmorSoulBase soul)
                {
                    // Só aplica se a alma ainda não rodou neste frame E se o player NÃO estiver com o set completo vestido
                    if (!soul.IsFullArmorSetEquipped(Player) && appliedSouls.Add(item.type))
                    {
                        soul.ApplyEffects(Player);
                    }
                }
            }
        }
    }
}
