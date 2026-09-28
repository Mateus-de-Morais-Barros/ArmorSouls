using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class CopperSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.CopperHelmet;
        public override int BodyPieceID => ItemID.CopperChainmail;
        public override int LegPieceID => ItemID.CopperGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
        }

        public override void ApplySoulEffects(Player player)
        {
            player.statDefense += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperHelmet)
                .AddIngredient(ItemID.CopperChainmail)
                .AddIngredient(ItemID.CopperGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}