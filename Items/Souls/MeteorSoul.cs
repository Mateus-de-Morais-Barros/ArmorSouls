using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class MeteorSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.MeteorHelmet;
        public override int BodyPieceID => ItemID.MeteorSuit;
        public override int LegPieceID => ItemID.MeteorLeggings;

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
            // Set Bonus vanilla: Space Gun custa 0 de mana
            player.spaceGun = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MeteorHelmet)
                .AddIngredient(ItemID.MeteorSuit)
                .AddIngredient(ItemID.MeteorLeggings)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}