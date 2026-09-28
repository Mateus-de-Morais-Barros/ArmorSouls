using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class PumpkinSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.PumpkinHelmet;
        public override int BodyPieceID => ItemID.PumpkinBreastplate;
        public override int LegPieceID => ItemID.PumpkinLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 20);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +10% de dano para todas as classes
            player.GetDamage(DamageClass.Generic) += 0.10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PumpkinHelmet)
                .AddIngredient(ItemID.PumpkinBreastplate)
                .AddIngredient(ItemID.PumpkinLeggings)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}