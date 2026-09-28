using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class OrichalcumSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.OrichalcumBreastplate;
        public override int LegPieceID => ItemID.OrichalcumLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 2, silver: 25);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Invoca pétalas perfurantes ao atingir inimigos
            player.onHitPetal = true;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Máscara + Peitoral + Calças (melee)
            player.GetDamage(DamageClass.Melee) += 0.19f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.11f;
            player.GetCritChance(DamageClass.Melee) += 6f;
            player.moveSpeed += 0.18f;

            // Elmo + Peitoral + Calças (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.08f;
            player.GetCritChance(DamageClass.Ranged) += 21f;
            player.moveSpeed += 0.19f;

            // Capacete + Peitoral + Calças (magic)
            player.GetDamage(DamageClass.Magic) += 0.08f;
            player.GetCritChance(DamageClass.Magic) += 24f;
            player.statManaMax2 += 80;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.OrichalcumMask ||
                              player.armor[0].type == ItemID.OrichalcumHelmet ||
                              player.armor[0].type == ItemID.OrichalcumHeadgear;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] orichalcumHelmets = new[]
            {
                ItemID.OrichalcumMask,
                ItemID.OrichalcumHelmet,
                ItemID.OrichalcumHeadgear
            };

            // Permite craftar com qualquer um dos 3 elmos
            foreach (short helmet in orichalcumHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.OrichalcumBreastplate)
                    .AddIngredient(ItemID.OrichalcumLeggings)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}