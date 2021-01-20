using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RevenantAwoken
{
    public class DrawHelper
    {
        public static void DrawChain(Texture2D texture, Vector2 from, Vector2 to, Color color2)
        {
            Rectangle? sourceRectangle = new Rectangle?();
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            float height = texture.Height;
            Vector2 vector1 = from - to;
            float rotation = (float)Math.Atan2(vector1.Y, vector1.X) - 1.57f;
            bool draw = true;
            if (float.IsNaN(to.X) && float.IsNaN(to.Y))
                draw = false;
            if (float.IsNaN(vector1.X) && float.IsNaN(vector1.Y))
                draw = false;
            while (draw)
            if (vector1.Length() < height + 1.0)
            {
                draw = false;
            }
            else
            {
                Vector2 vector2 = vector1;
                vector2.Normalize();
                to += vector2 * height;
                vector1 = from - to;
                Main.spriteBatch.Draw(texture, to - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
            }
        }
    }
}