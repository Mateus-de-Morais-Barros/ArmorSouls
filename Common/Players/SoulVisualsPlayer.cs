using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Common.Players
{
    // Guarda quais visuais de set bonus estão escondidos neste frame (via HideSoulVisuals das almas)
    public class SoulVisualsPlayer : ModPlayer
    {
        public bool hideStardustGuardian;
        public bool hideLeafCrystal;
        public bool hideBeetleOrbs;
        public bool hideSolarShield;

        public override void ResetEffects()
        {
            hideStardustGuardian = false;
            hideLeafCrystal = false;
            hideBeetleOrbs = false;
            hideSolarShield = false;
        }

        public override void HideDrawLayers(PlayerDrawSet drawInfo)
        {
            if (hideBeetleOrbs)
            {
                PlayerDrawLayers.BeetleBuff.Hide();
            }

            if (hideSolarShield)
            {
                PlayerDrawLayers.SolarShield.Hide();
            }
        }
    }

    // Não desenha o Stardust Guardian / Leaf Crystal do dono quando o visual está escondido; eles continuam atacando
    public class SoulVisualsProjectile : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.StardustGuardian || entity.type == ProjectileID.CrystalLeaf;
        }

        public override bool PreDraw(Projectile projectile, ref Microsoft.Xna.Framework.Color lightColor)
        {
            SoulVisualsPlayer visuals = Main.player[projectile.owner].GetModPlayer<SoulVisualsPlayer>();

            if (projectile.type == ProjectileID.StardustGuardian)
            {
                return !visuals.hideStardustGuardian;
            }

            return !visuals.hideLeafCrystal;
        }
    }
}
