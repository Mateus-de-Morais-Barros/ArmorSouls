using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class ObsidianSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.ObsidianHelm;
        public override int BodyPieceID => ItemID.ObsidianShirt;
        public override int LegPieceID => ItemID.ObsidianPants;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +30% de alcance e +15% de velocidade para chicotes, +15% de dano de summon
            player.whipRangeMultiplier += 0.30f;
            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.15f;
            player.GetDamage(DamageClass.Summon) += 0.15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ObsidianHelm)
                .AddIngredient(ItemID.ObsidianShirt)
                .AddIngredient(ItemID.ObsidianPants)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}