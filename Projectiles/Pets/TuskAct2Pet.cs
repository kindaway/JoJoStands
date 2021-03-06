using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Projectiles.Pets
{
    public class TuskAct2Pet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projPet[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 38;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.manualDirectionChange = true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            projectile.frameCounter++;
            if (player.dead)
            {
                modPlayer.TuskAct2Pet = false;
            }
            if (modPlayer.TuskAct2Pet)
            {
                projectile.timeLeft = 2;
            }
            float num = 4f;
            Vector2 value = new Vector2((float)(player.direction * 30), -20f);
            projectile.direction = (projectile.spriteDirection = player.direction);
            Vector2 vector = player.MountedCenter + value;
            float num6 = Vector2.Distance(projectile.Center, vector);
            if (num6 > 1000f)
            {
                projectile.Center = player.Center + value;
            }
            Vector2 vector2 = vector - projectile.Center;
            if (num6 < num)
            {
                projectile.velocity *= 0.25f;
            }
            if (vector2 != Vector2.Zero)
            {
                if (vector2.Length() < num * 0.5f)
                {
                    projectile.velocity = vector2;
                }
                else
                {
                    projectile.velocity = vector2 * 0.1f;
                }
            }
            if (projectile.velocity.Length() > 6f)
            {
                float num7 = projectile.velocity.X * 0.08f + projectile.velocity.Y * (float)projectile.spriteDirection * 0.02f;
                if (Math.Abs(projectile.rotation - num7) >= 3.14159274f)
                {
                    if (num7 < projectile.rotation)
                    {
                        projectile.rotation -= 6.28318548f;
                    }
                    else
                    {
                        projectile.rotation += 6.28318548f;
                    }
                }
                float num8 = 12f;
                projectile.rotation = (projectile.rotation * (num8 - 1f) + num7) / num8;
            }
            else
            {
                if (projectile.rotation > 3.14159274f)
                {
                    projectile.rotation -= 6.28318548f;
                }
                if (projectile.rotation > -0.005f && projectile.rotation < 0.005f)
                {
                    projectile.rotation = 0f;
                }
                else
                {
                    projectile.rotation *= 0.96f;
                }
            }
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 120f)
            {
                projectile.localAI[0] = 0f;
            }
            if (projectile.frameCounter >= 10)
            {
                projectile.frame += 1;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }
        }
    }
}