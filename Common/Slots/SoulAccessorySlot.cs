using Terraria;
using Terraria.ModLoader;
using ArmorSouls.Common.Configs;
using ArmorSouls.Items.Souls;

namespace ArmorSouls.Common.Slots
{
    // Registrado manualmente em ArmorSouls.Load, uma instância por slot
    [Autoload(false)]
    public class SoulAccessorySlot : ModAccessorySlot
    {
        private readonly int index;

        public SoulAccessorySlot(int index)
        {
            this.index = index;
        }

        public override string Name => "SoulAccessorySlot" + index;

        public override bool IsEnabled()
        {
            return ModContent.GetInstance<ArmorSoulsServerConfig>().EnableSoulSlots && index < GetAvailableSlotCount();
        }

        // Com a progressão ativa, começa com 1 slot e libera +1 a cada marco do mundo, até o máximo da config
        public static int GetAvailableSlotCount()
        {
            ArmorSoulsServerConfig config = ModContent.GetInstance<ArmorSoulsServerConfig>();

            if (!config.ProgressiveSoulSlots)
            {
                return config.SoulSlotCount;
            }

            int unlocked = 1;
            if (NPC.downedBoss3) unlocked++;          // Skeletron
            if (Main.hardMode) unlocked++;            // Wall of Flesh
            if (NPC.downedMechBossAny) unlocked++;    // Qualquer boss mecânico
            if (NPC.downedPlantBoss) unlocked++;      // Plantera
            if (NPC.downedMoonlord) unlocked++;       // Moon Lord

            return System.Math.Min(unlocked, config.SoulSlotCount);
        }

        // Almas não têm visual, então só o slot funcional é usado
        public override bool DrawVanitySlot => false;
        public override bool DrawDyeSlot => false;

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return context == AccessorySlotType.FunctionalSlot && checkItem.ModItem is ArmorSoulBase;
        }

        // Faz o clique direito/auto-equip mandar a alma para este slot
        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            return item.ModItem is ArmorSoulBase;
        }

        public override void OnMouseHover(AccessorySlotType context)
        {
            if (context == AccessorySlotType.FunctionalSlot)
            {
                Main.hoverItemName = "Soul Slot";
            }
        }
    }
}
