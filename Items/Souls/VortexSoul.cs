using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ArmorSouls.Common.Players;

namespace ArmorSouls.Items.Souls
{
    public class VortexSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.VortexHelmet;
        public override int BodyPieceID => ItemID.VortexBreastplate;
        public override int LegPieceID => ItemID.VortexLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 10);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Permite alternar o modo furtivo (Vortex Stealth)
            player.setVortex = true;

            // O UpdateArmorSets vanilla desliga o stealth quando o set não está vestido; o estado é restaurado em SoulSetBonusPlayer
            SoulSetBonusPlayer setBonusPlayer = player.GetModPlayer<SoulSetBonusPlayer>();
            setBonusPlayer.vortexSoul = true;
            setBonusPlayer.vortexStealthWasActive = player.vortexStealthActive;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.VortexHelmet)
                .AddIngredient(ItemID.VortexBreastplate)
                .AddIngredient(ItemID.VortexLeggings)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}