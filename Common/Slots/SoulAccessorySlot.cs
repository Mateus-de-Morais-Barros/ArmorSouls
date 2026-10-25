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
            ArmorSoulsServerConfig config = ModContent.GetInstance<ArmorSoulsServerConfig>();
            return config.EnableSoulSlots && index < config.SoulSlotCount;
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
