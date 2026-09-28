using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class SilverSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.SilverHelmet;
        public override int BodyPieceID => ItemID.SilverChainmail;
        public override int LegPieceID => ItemID.SilverGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
        }

        public override void ApplySoulEffects(Player player)
        {
            player.statDefense += 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverHelmet)
                .AddIngredient(ItemID.SilverChainmail)
                .AddIngredient(ItemID.SilverGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}