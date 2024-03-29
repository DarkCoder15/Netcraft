﻿using System;
using global::System.Drawing;
using Microsoft.VisualBasic.CompilerServices;

namespace NCore
{
    public class WorldGenerator
    {
        private static readonly Random rnd = new Random();

        public static WorldServer Generate()
        {
            var world = new WorldServer();
            int a = 0;
            caveheight = rnd.Next(NCore.WORLDGEN_CAVE_MIN_HEIGHT, NCore.WORLDGEN_CAVE_MAX_HEIGHT);
            for (int i = 0; i <= 43; i++)
            {
                int YHeight = new Random().Next(1, 14);
                
                for (int o = 0; o <= 24; o++)
                {
                    if (o == 17)
                    {
                        world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.BEDROCK, true, false));
                    }

                    if (o < 17)
                    {
                        if (o > 7)
                        {
                            if (o < 13)
                            {
                                if (o > 9)
                                {
                                    var c = rnd.Next(1, 10);
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(c, 4, false)))
                                    {
                                        world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.IRON_ORE, false, false));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(Operators.ConditionalCompareObjectGreater(c, 4, false), Operators.ConditionalCompareObjectLess(c, 7, false)), "TrueTrue", false)))
                                    {
                                        world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.COAL_ORE, false, false));
                                    }
                                    else
                                    {
                                        world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.STONE, false, false));
                                    }

                                    continue;
                                }
                            }

                            if (o > 13)
                            {
                                if (o < 17)
                                {
                                    var c = rnd.Next(1, 10);
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(c, 3, false)))
                                    {
                                        world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.DIAMOND_ORE, false, false));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(Operators.ConditionalCompareObjectGreater(c, 3, false), Operators.ConditionalCompareObjectLess(c, 6, false)), "TrueTrue", false)))
                                    {
                                        world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.GOLD_ORE, false, false));
                                    }
                                    else
                                    {
                                        world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.STONE, false, false));
                                    }

                                    continue;
                                }
                            }

                            world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.STONE, false, false));
                        }
                    }

                    if (o < 8)
                    {
                        if (o > 6)
                        {
                            world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.DIRT, false, false));
                        }
                    }

                    if (o == 6)
                    {
                        var r = rnd.Next(1, 10);
                        if (r == 6)
                        {
                            world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.WATER, false, false));
                        }
                        else
                        {
                            world.Blocks.Add(new Block(new Point(i, o), EnumBlockType.GRASS_BLOCK, false, false));
                        }
                    }

                    if (o == 5)
                    {
                        if (a + 5 < i)
                        {
                            TreeGenerator.GenerateTree(new Point(i, o), world);
                            caveheight = rnd.Next(NCore.WORLDGEN_CAVE_MIN_HEIGHT, NCore.WORLDGEN_CAVE_MAX_HEIGHT);
                            a = i;
                        }
                    }
                }
                if(i == 0) pcaveheight = caveheight;
                if (caveheight > pcaveheight + 1) caveheight = pcaveheight + 1;
                if (caveheight < pcaveheight - 1) caveheight = pcaveheight - 1;
                world.GetBlockAt(i, caveheight).IsBackground = true;
                world.GetBlockAt(i, caveheight + 1).IsBackground = true;
                world.GetBlockAt(i, caveheight - 1).IsBackground = true;
                pcaveheight = caveheight;
            }

            return world;
        }

        static int caveheight;
        static int pcaveheight;

        public static WorldServer GenerateFlat()
        {
            var world = new WorldServer();
            for (int i = 0; i <= 60; i++)
                world.Blocks.Add(new Block(new Point(i, 17), EnumBlockType.BEDROCK, false, false));
            return world;
        }
    }
}