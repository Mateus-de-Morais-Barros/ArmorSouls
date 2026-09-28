using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class WoodSoul : ArmorSoulBase
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 5);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla de todas as madeiras: +1 de defesa
            player.statDefense += 2;
        }

        // Verifica se o jogador está vestindo o conjunto completo de qualquer tipo de madeira
        public override bool IsFullArmorSetEquipped(Player player)
        {
            (short head, short body, short legs)[] woodArmorSets = new[]
            {
                (ItemID.WoodHelmet, ItemID.WoodBreastplate, ItemID.WoodGreaves),
                (ItemID.BorealWoodHelmet, ItemID.BorealWoodBreastplate, ItemID.BorealWoodGreaves),
                (ItemID.PalmWoodHelmet, ItemID.PalmWoodBreastplate, ItemID.PalmWoodGreaves),
                (ItemID.RichMahoganyHelmet, ItemID.RichMahoganyBreastplate, ItemID.RichMahoganyGreaves),
                (ItemID.EbonwoodHelmet, ItemID.EbonwoodBreastplate, ItemID.EbonwoodGreaves),
                (ItemID.ShadewoodHelmet, ItemID.ShadewoodBreastplate, ItemID.ShadewoodGreaves),
                (ItemID.AshWoodHelmet, ItemID.AshWoodBreastplate, ItemID.AshWoodGreaves),
                (ItemID.PearlwoodHelmet, ItemID.PearlwoodBreastplate, ItemID.PearlwoodGreaves)
            };

            for (int i = 0; i < woodArmorSets.Length; i++)
            {
                var set = woodArmorSets[i];
                if (player.armor[0].type == set.head &&
                    player.armor[1].type == set.body &&
                    player.armor[2].type == set.legs)
                {
                    return true;
                }
            }

            return false;
        }

        public override void AddRecipes()
        {
            (short head, short body, short legs)[] woodSets = new[]
            {
                (ItemID.WoodHelmet, ItemID.WoodBreastplate, ItemID.WoodGreaves),
                (ItemID.BorealWoodHelmet, ItemID.BorealWoodBreastplate, ItemID.BorealWoodGreaves),
                (ItemID.PalmWoodHelmet, ItemID.PalmWoodBreastplate, ItemID.PalmWoodGreaves),
                (ItemID.RichMahoganyHelmet, ItemID.RichMahoganyBreastplate, ItemID.RichMahoganyGreaves),
                (ItemID.EbonwoodHelmet, ItemID.EbonwoodBreastplate, ItemID.EbonwoodGreaves),
                (ItemID.ShadewoodHelmet, ItemID.ShadewoodBreastplate, ItemID.ShadewoodGreaves),
                (ItemID.AshWoodHelmet, ItemID.AshWoodBreastplate, ItemID.AshWoodGreaves),
                (ItemID.PearlwoodHelmet, ItemID.PearlwoodBreastplate, ItemID.PearlwoodGreaves)
            };

            // Registra uma receita válida para cada tipo de madeira
            foreach (var set in woodSets)
            {
                CreateRecipe()
                    .AddIngredient(set.head)
                    .AddIngredient(set.body)
                    .AddIngredient(set.legs)
                    .AddTile(TileID.WorkBenches)
                    .Register();
            }
        }
    }
}