using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class FrostSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.FrostHelmet;
        public override int BodyPieceID => ItemID.FrostBreastplate;
        public override int LegPieceID => ItemID.FrostLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Ataques melee e ranged aplicam Frostbite / Frostburn
            player.frostBurn = true;

            // +10% de dano para corpo a corpo e à distância concedido pelo Set Bonus
            player.GetDamage(DamageClass.Melee) += 0.10f;
            player.GetDamage(DamageClass.Ranged) += 0.10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FrostHelmet)
                .AddIngredient(ItemID.FrostBreastplate)
                .AddIngredient(ItemID.FrostLeggings)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}