using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class PalladiumSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.PalladiumBreastplate;
        public override int LegPieceID => ItemID.PalladiumLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 1, silver: 80);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Ativa cura rápida (Rapid Healing) ao atingir inimigos
            player.onHitRegen = true;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Máscara + Peitoral + Calças (melee)
            player.GetDamage(DamageClass.Melee) += 0.17f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.12f;
            player.GetCritChance(DamageClass.Melee) += 3f;

            // Elmo + Peitoral + Calças (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.14f;
            player.GetCritChance(DamageClass.Ranged) += 12f;

            // Capacete + Peitoral + Calças (magic)
            player.GetDamage(DamageClass.Magic) += 0.14f;
            player.GetCritChance(DamageClass.Magic) += 12f;
            player.statManaMax2 += 60;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.PalladiumMask ||
                              player.armor[0].type == ItemID.PalladiumHelmet ||
                              player.armor[0].type == ItemID.PalladiumHeadgear;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] palladiumHelmets = new[]
            {
                ItemID.PalladiumMask,
                ItemID.PalladiumHelmet,
                ItemID.PalladiumHeadgear
            };

            // Permite craftar com qualquer um dos 3 elmos
            foreach (short helmet in palladiumHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.PalladiumBreastplate)
                    .AddIngredient(ItemID.PalladiumLeggings)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
        }
    }
}