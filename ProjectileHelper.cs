using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RevenantAwoken
{
    public class ProjectileHelper
    {
        public static void Sync(int p)
        {
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, p);
        }
        public static int CountProjectiles(int type)
        {
            int count = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active && projectile.type == type)
                {
                    count++;
                }
            }
            return count;
        }
        public static void ClearProjectiles(int type = -1)
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active)
                {
                    if (type == -1)
                    {
                        projectile.Kill();
                    }
                    else if (projectile.type == type)
                    {
                        projectile.Kill();
                    }
                }
            }
        }
        public static void LimitOwnedProjectiles(int type, int owner, int amount)
        {
            int count = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.type == type && projectile.owner == owner)
                {
                    count++;
                }
                if (count > amount)
                {
                    projectile.Kill();
                }
            }
        }
        public static void DrawProjectile(Projectile projectile)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y3 = num156 * projectile.frame;
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Color alpha = Main.hslToRgb((projectile.localAI[0] / 2)%1f, 1f, 0.8f);
            Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), alpha, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
        }
    }
}