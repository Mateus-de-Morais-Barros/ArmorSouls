using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ArmorSouls.Items.Souls;

namespace ArmorSouls.Common.Players
{
    public class SoulBankPlayer : ModPlayer
    {
        public override void PostUpdateEquips()
        {
            HashSet<int> appliedSouls = new HashSet<int>();

            // Percorre o Piggy Bank
            ProcessStorage(Player.bank.item, appliedSouls);
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