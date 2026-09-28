using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class GladiatorSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.GladiatorHelmet;
        public override int BodyPieceID => ItemID.GladiatorBreastplate;
        public override int LegPieceID => ItemID.GladiatorLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 80);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Imunidade a repulsão (knockback)
            player.noKnockback = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GladiatorHelmet)
                .AddIngredient(ItemID.GladiatorBreastplate)
                .AddIngredient(ItemID.GladiatorLeggings)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}