using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class MythrilSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.MythrilChainmail;
        public override int LegPieceID => ItemID.MythrilGreaves;

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
            // Bônus do Elmo Melee: +10% de chance de crítico melee
            player.GetCritChance(DamageClass.Melee) += 10f;

            // Bônus do Chapéu Ranged: 20% de chance de economizar munição
            player.ammoCost80 = true;

            // Bônus do Capuz Magic: 17% de redução no custo de mana
            player.manaCost -= 0.17f;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Elmo + Corrente + Grevas (melee)
            player.GetDamage(DamageClass.Melee) += 0.17f;
            player.GetCritChance(DamageClass.Melee) += 18f;

            // Chapéu + Corrente + Grevas (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.19f;
            player.GetCritChance(DamageClass.Ranged) += 17f;

            // Capuz + Corrente + Grevas (magic)
            player.GetDamage(DamageClass.Magic) += 0.22f;
            player.GetCritChance(DamageClass.Magic) += 10f;
            player.statManaMax2 += 60;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.MythrilHelmet ||
                              player.armor[0].type == ItemID.MythrilHat ||
                              player.armor[0].type == ItemID.MythrilHood;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] mythrilHelmets = new[]
            {
                ItemID.MythrilHelmet,
                ItemID.MythrilHat,
                ItemID.MythrilHood
            };

            // Permite craftar com qualquer um dos 3 elmos na Bigorna de Mythril/Orichalcum
            foreach (short helmet in mythrilHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.MythrilChainmail)
                    .AddIngredient(ItemID.MythrilGreaves)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}