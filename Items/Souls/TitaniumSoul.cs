using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class TitaniumSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.TitaniumBreastplate;
        public override int LegPieceID => ItemID.TitaniumLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla do Titânio (1.4+): gera a barreira de fragmentos ao acertar ataques
            player.onHitTitaniumStorm = true;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Máscara + Peitoral + Calças (melee)
            player.GetDamage(DamageClass.Melee) += 0.16f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.09f;
            player.GetCritChance(DamageClass.Melee) += 15f;

            // Elmo + Peitoral + Calças (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.23f;
            player.GetCritChance(DamageClass.Ranged) += 13f;

            // Capacete + Peitoral + Calças (magic)
            player.GetDamage(DamageClass.Magic) += 0.23f;
            player.GetCritChance(DamageClass.Magic) += 13f;
            player.statManaMax2 += 100;

            // Bônus de movimento das Calças (comum às 3 variantes)
            player.moveSpeed += 0.06f;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.TitaniumHelmet ||
                              player.armor[0].type == ItemID.TitaniumMask ||
                              player.armor[0].type == ItemID.TitaniumHeadgear;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            var helmets = new[]
            {
                ItemID.TitaniumHelmet,
                ItemID.TitaniumMask,
                ItemID.TitaniumHeadgear
            };

            foreach (short helmet in helmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.TitaniumBreastplate)
                    .AddIngredient(ItemID.TitaniumLeggings)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}