using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class ForbiddenSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.AncientBattleArmorHat; // Forbidden Mask
        public override int BodyPieceID => ItemID.AncientBattleArmorShirt; // Forbidden Robes
        public override int LegPieceID => ItemID.AncientBattleArmorPants; // Forbidden Treads

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Invoca o Forbidden Sign e permite conjurar a tempestade de areia antiga
            player.setForbidden = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AncientBattleArmorHat)
                .AddIngredient(ItemID.AncientBattleArmorShirt)
                .AddIngredient(ItemID.AncientBattleArmorPants)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}