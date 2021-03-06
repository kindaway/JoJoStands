using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace JoJoStands.Projectiles
{
    public class HamonBloodBubble : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 18;
            projectile.aiStyle = 0;
            projectile.ranged = true;
            projectile.timeLeft = 800;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 7;
        }

        public override void AI()
        {
            if (projectile.timeLeft == 790)
            {
                projectile.velocity *= 0;
            }
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().HamonCounter >= 1)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 169, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            }
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
        }
    }
}