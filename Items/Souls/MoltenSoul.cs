using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class MoltenSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.MoltenHelmet;
        public override int BodyPieceID => ItemID.MoltenBreastplate;
        public override int LegPieceID => ItemID.MoltenGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 1, silver: 20);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +17% de dano corpo a corpo e imunidade a chamas
            player.GetDamage(DamageClass.Melee) += 0.17f;
            player.buffImmune[BuffID.OnFire] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MoltenHelmet)
                .AddIngredient(ItemID.MoltenBreastplate)
                .AddIngredient(ItemID.MoltenGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}