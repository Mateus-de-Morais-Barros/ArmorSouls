using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class IronSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.IronHelmet;
        public override int BodyPieceID => ItemID.IronChainmail;
        public override int LegPieceID => ItemID.IronGreaves;

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
                .AddIngredient(ItemID.IronHelmet)
                .AddIngredient(ItemID.IronChainmail)
                .AddIngredient(ItemID.IronGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}