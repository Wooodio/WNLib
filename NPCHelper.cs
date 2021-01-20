using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace RevenantAwoken
{
    public class NPCHelper
    {
        public static void SyncNPC(int n)
        {
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, n);
        }
        public static int FindClosest(Vector2 pos, float maxDistance, bool checkCollision = false)
        {
            int nearestTarget = -1;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC n = Main.npc[i];
                float distance = Vector2.Distance(n.Center, pos);
                if ((distance <= maxDistance || distance == -1) && (nearestTarget == -1 || Vector2.Distance(Main.npc[nearestTarget].Center, pos) > distance) && Main.npc[i].CanBeChasedBy())
                {
                    if (!checkCollision)
                    nearestTarget = i;
                    else if (Collision.CanHit(pos, 0, 0, n.Center, 0, 0))
                    nearestTarget = i;
                }
            }
            return nearestTarget;
        }
    }
}