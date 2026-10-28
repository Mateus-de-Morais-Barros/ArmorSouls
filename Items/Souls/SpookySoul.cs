using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class SpookySoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.SpookyHelmet;
        public override int BodyPieceID => ItemID.SpookyBreastplate;
        public override int LegPieceID => ItemID.SpookyLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +25% de dano de Summon
            player.GetDamage(DamageClass.Summon) += 0.25f;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Elmo: +1 lacaio; Peitoral: +2 lacaios; Calças: +1 lacaio e +20% de velocidade de movimento; +11% de dano de summon cada
            player.maxMinions += 4;
            player.GetDamage(DamageClass.Summon) += 0.33f;
            player.moveSpeed += 0.20f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SpookyHelmet)
                .AddIngredient(ItemID.SpookyBreastplate)
                .AddIngredient(ItemID.SpookyLeggings)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}