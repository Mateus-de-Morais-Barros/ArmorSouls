using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class ChlorophyteSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.ChlorophytePlateMail;
        public override int LegPieceID => ItemID.ChlorophyteGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(gold: 4, silver: 50);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Invoca o Leaf Crystal sobre a cabeça do jogador
            player.AddBuff(BuffID.LeafCrystal, 18000);
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Máscara + Peitoral + Grevas (melee)
            player.GetDamage(DamageClass.Melee) += 0.21f;
            player.GetCritChance(DamageClass.Melee) += 14f;

            // Elmo + Peitoral + Grevas (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.21f;
            player.GetCritChance(DamageClass.Ranged) += 7f;
            player.ammoCost80 = true;

            // Capacete + Peitoral + Grevas (magic)
            player.GetDamage(DamageClass.Magic) += 0.21f;
            player.GetCritChance(DamageClass.Magic) += 7f;
            player.statManaMax2 += 80;
            player.manaCost -= 0.17f;

            // Bônus de movimento das Grevas (comum às 3 variantes)
            player.moveSpeed += 0.05f;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.ChlorophyteMask ||
                              player.armor[0].type == ItemID.ChlorophyteHelmet ||
                              player.armor[0].type == ItemID.ChlorophyteHeadgear;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] chlorophyteHelmets = new[]
            {
                ItemID.ChlorophyteMask,
                ItemID.ChlorophyteHelmet,
                ItemID.ChlorophyteHeadgear
            };

            // Permite craftar com qualquer uma das 3 variações de elmo
            foreach (short helmet in chlorophyteHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.ChlorophytePlateMail)
                    .AddIngredient(ItemID.ChlorophyteGreaves)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}