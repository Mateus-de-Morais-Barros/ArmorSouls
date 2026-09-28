using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class GoldSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.GoldHelmet;
        public override int BodyPieceID => ItemID.GoldChainmail;
        public override int LegPieceID => ItemID.GoldGreaves;

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
                .AddIngredient(ItemID.GoldHelmet)
                .AddIngredient(ItemID.GoldChainmail)
                .AddIngredient(ItemID.GoldGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}