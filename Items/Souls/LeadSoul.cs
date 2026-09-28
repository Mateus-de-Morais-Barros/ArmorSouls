using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class LeadSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.LeadHelmet;
        public override int BodyPieceID => ItemID.LeadChainmail;
        public override int LegPieceID => ItemID.LeadGreaves;

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
                .AddIngredient(ItemID.LeadHelmet)
                .AddIngredient(ItemID.LeadChainmail)
                .AddIngredient(ItemID.LeadGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}