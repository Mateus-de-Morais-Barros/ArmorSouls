using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Common.Players
{
    public class StardustSoulPlayer : ModPlayer
    {
        // Ativado pela StardustSoul a cada frame
        public bool stardustSoul;

        public override void ResetEffects()
        {
            stardustSoul = false;
        }

        // Roda depois do UpdateArmorSets vanilla, que remove o buff do Guardian quando o set não está vestido
        public override void PostUpdate()
        {
            if (!stardustSoul || Player.whoAmI != Main.myPlayer)
                return;

            if (Player.FindBuffIndex(BuffID.StardustGuardianMinion) == -1)
            {
                Player.AddBuff(BuffID.StardustGuardianMinion, 3600);
            }

            // O buff só mantém o Guardian vivo; a invocação em si é feita aqui, como no set vanilla
            Player.stardustGuardian = true;

            if (Player.ownedProjectileCounts[ProjectileID.StardustGuardian] < 1)
            {
                int damage = 30;
                Projectile proj = Projectile.NewProjectileDirect(Player.GetSource_Misc("StardustSoul"), Player.Center, new Vector2(0f, -1f),
                    ProjectileID.StardustGuardian, damage, 0f, Player.whoAmI);
                proj.originalDamage = damage;
            }
        }
    }
}
