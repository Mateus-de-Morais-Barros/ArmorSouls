using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class TungstenSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.TungstenHelmet;
        public override int BodyPieceID => ItemID.TungstenChainmail;
        public override int LegPieceID => ItemID.TungstenGreaves;

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
                .AddIngredient(ItemID.TungstenHelmet)
                .AddIngredient(ItemID.TungstenChainmail)
                .AddIngredient(ItemID.TungstenGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}