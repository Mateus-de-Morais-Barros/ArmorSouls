using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class ShadowSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.ShadowHelmet;
        public override int BodyPieceID => ItemID.ShadowScalemail;
        public override int LegPieceID => ItemID.ShadowGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +15% de velocidade de movimento e rastro de sombras com aceleração
            player.moveSpeed += 0.15f;
            player.shadowArmor = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowHelmet)
                .AddIngredient(ItemID.ShadowScalemail)
                .AddIngredient(ItemID.ShadowGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}