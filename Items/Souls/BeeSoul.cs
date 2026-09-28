using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class BeeSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.BeeHeadgear;
        public override int BodyPieceID => ItemID.BeeBreastplate;
        public override int LegPieceID => ItemID.BeeGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 80);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +10% de dano para lacaios (minions)
            player.GetDamage(DamageClass.Summon) += 0.10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BeeHeadgear)
                .AddIngredient(ItemID.BeeBreastplate)
                .AddIngredient(ItemID.BeeGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}