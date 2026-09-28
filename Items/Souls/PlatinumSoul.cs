using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class PlatinumSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.PlatinumHelmet;
        public override int BodyPieceID => ItemID.PlatinumChainmail;
        public override int LegPieceID => ItemID.PlatinumGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
        }

        public override void ApplySoulEffects(Player player)
        {
            player.statDefense += 4;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumHelmet)
                .AddIngredient(ItemID.PlatinumChainmail)
                .AddIngredient(ItemID.PlatinumGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}