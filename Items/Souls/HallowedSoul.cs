using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class HallowedSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.HallowedPlateMail;
        public override int LegPieceID => ItemID.HallowedGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 4);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Concede esquiva/imunidade (Holy Protection) ao acertar inimigos
            player.onHitDodge = true;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Máscara + Peitoral + Grevas (melee)
            player.GetDamage(DamageClass.Melee) += 0.17f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
            player.GetCritChance(DamageClass.Melee) += 17f;

            // Elmo + Peitoral + Grevas (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.22f;
            player.GetCritChance(DamageClass.Ranged) += 15f;

            // Capacete + Peitoral + Grevas (magic)
            player.GetDamage(DamageClass.Magic) += 0.19f;
            player.GetCritChance(DamageClass.Magic) += 19f;
            player.statManaMax2 += 100;

            // Capuz + Peitoral + Grevas (summon)
            player.GetDamage(DamageClass.Summon) += 0.17f;
            player.maxMinions += 1;

            // Bônus de movimento das Grevas (comum a todas as variantes)
            player.moveSpeed += 0.08f;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            // Verifica peitoral (normal ou Ancient)
            bool hasBody = player.armor[1].type == ItemID.HallowedPlateMail ||
                           player.armor[1].type == ItemID.AncientHallowedPlateMail;

            // Verifica calça (normal ou Ancient)
            bool hasLegs = player.armor[2].type == ItemID.HallowedGreaves ||
                           player.armor[2].type == ItemID.AncientHallowedGreaves;

            // Verifica qualquer um dos 4 elmos (versão normal ou Ancient)
            bool hasAnyHead = player.armor[0].type == ItemID.HallowedMask ||
                              player.armor[0].type == ItemID.HallowedHelmet ||
                              player.armor[0].type == ItemID.HallowedHeadgear ||
                              player.armor[0].type == ItemID.HallowedHood ||
                              player.armor[0].type == ItemID.AncientHallowedMask ||
                              player.armor[0].type == ItemID.AncientHallowedHelmet ||
                              player.armor[0].type == ItemID.AncientHallowedHeadgear ||
                              player.armor[0].type == ItemID.AncientHallowedHood;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] hallowedHelmets = new[]
            {
                ItemID.HallowedMask,
                ItemID.HallowedHelmet,
                ItemID.HallowedHeadgear,
                ItemID.HallowedHood,
                ItemID.AncientHallowedMask,
                ItemID.AncientHallowedHelmet,
                ItemID.AncientHallowedHeadgear,
                ItemID.AncientHallowedHood
            };

            // Permite criar com qualquer variação de elmo usando as peças normais
            foreach (short helmet in hallowedHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.HallowedPlateMail)
                    .AddIngredient(ItemID.HallowedGreaves)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }

            // Permite criar usando o conjunto completo Ancient
            foreach (short helmet in hallowedHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.AncientHallowedPlateMail)
                    .AddIngredient(ItemID.AncientHallowedGreaves)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}