using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class ShroomiteSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.ShroomiteBreastplate;
        public override int LegPieceID => ItemID.ShroomiteLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 7, silver: 50);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Concede Shroomite Stealth ao ficar parado
            player.shroomiteStealth = true;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Elmo (arco/arma de fogo/especialista, ~12%) + Peitoral (13%) de dano ranged
            player.GetDamage(DamageClass.Ranged) += 0.25f;
            // Elmo (5%) + Peitoral (13%) + Grevas (7%) de crítico ranged
            player.GetCritChance(DamageClass.Ranged) += 25f;
            // Grevas: velocidade de movimento
            player.moveSpeed += 0.12f;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.ShroomiteHeadgear ||
                              player.armor[0].type == ItemID.ShroomiteMask ||
                              player.armor[0].type == ItemID.ShroomiteHelmet;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] shroomiteHelmets = new[]
            {
                ItemID.ShroomiteHeadgear,
                ItemID.ShroomiteMask,
                ItemID.ShroomiteHelmet
            };

            // Permite craftar com qualquer uma das 3 variações de capacete
            foreach (short helmet in shroomiteHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.ShroomiteBreastplate)
                    .AddIngredient(ItemID.ShroomiteLeggings)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}