﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellAlchemyTheFortressEscape.SoundModule;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TileEngine;

namespace SpellAlchemyTheFortressEscape.StaticObjectModule
{
    public class StaticObjectHandler
    {
        //Number setting of each item type
        private static int numOfKeyAndLock = 4;
        private static int numOfTotalItems = 20; //SpellItem + Stars
        private static int numOfSpellItem = 5;
        private static int numOfStars = 15;

        //Instance of each item type
        private Key[] key = new Key[numOfKeyAndLock];
        private Lock[] doorLock = new Lock[numOfKeyAndLock];
        private SpellItem[] spellItem = new SpellItem[numOfTotalItems];
        private SpellItem[] stars = new SpellItem[numOfStars];

        //MapData
        private MapData m_referenceMapData;
        private int _totalRow;
        private int _totalCol;
        private List<Vector2> staticObjectPositions = new List<Vector2>();
        private List<Vector2> walkablePositions = new List<Vector2>();

        public StaticObjectHandler()
        {
            InitializeKey();
            InitializeLock();
            InitializeSpellItem();
        }

        public StaticObjectHandler(MapData i_MapData)
        {
            m_referenceMapData = i_MapData;
            walkablePositions = m_referenceMapData.GetWalkablePaths();
            _totalRow = m_referenceMapData.GetMapTileHeight();
            _totalCol = m_referenceMapData.GetMapTileWidth();

            InitializeKey();
            InitializeLock();
            InitializeSpellItem();
        }

        public void SetMapReference(MapData i_MapData)
        {
            m_referenceMapData = i_MapData;
            walkablePositions = m_referenceMapData.GetWalkablePaths();
            _totalRow = m_referenceMapData.GetMapTileHeight();
            _totalCol = m_referenceMapData.GetMapTileWidth();
        }

        private void InitializeKey()
        {
            KeyLockColor[] keyLockColors = { KeyLockColor.RED, KeyLockColor.YELLOW, KeyLockColor.GREEN, KeyLockColor.BLUE };
            Vector2[] keyTilePositions = { new Vector2(5,3), new Vector2(23,1), new Vector2(23,23), new Vector2(1,23) };

            for (int i = 0; i < numOfKeyAndLock; i++)
            {
                key[i] = new Key();
                key[i].SetKeyTilePosition((int)keyTilePositions[i].X, (int)keyTilePositions[i].Y);
                key[i].SetKeyColour(keyLockColors[i]);
                
                //add keyTilePositions into the position list
                staticObjectPositions.Add(keyTilePositions[i]);
            }

            /*
            key[0].SetKeyTilePosition(5, 3);
            key[0].SetKeyColour(KeyLockColor.RED);
            key[1].SetKeyTilePosition(23, 1);
            key[1].SetKeyColour(KeyLockColor.YELLOW);
            key[2].SetKeyTilePosition(23, 23);
            key[2].SetKeyColour(KeyLockColor.GREEN);
            key[3].SetKeyTilePosition(1, 23);
            key[3].SetKeyColour(KeyLockColor.BLUE);
             */
        }

        private void InitializeSpellItem()
        {
            SpellItemType[] spellItemTypes = { SpellItemType.HP_POTION, SpellItemType.HP_POTION, 
                                                 SpellItemType.QUEST_ITEM, SpellItemType.QUEST_ITEM, SpellItemType.QUEST_ITEM };
            Vector2[] itemTilePositions = { new Vector2(23, 11), new Vector2(21, 13), new Vector2(1, 19), new Vector2(9, 11), new Vector2(23,13) };

            for (int i = 0; i < numOfTotalItems; i++)
            {
                spellItem[i] = new SpellItem();
            }

            for (int i = 0; i < numOfSpellItem; i++)
            {
                spellItem[i].SetItemTilePosition((int)itemTilePositions[i].X, (int)itemTilePositions[i].Y);
                spellItem[i].SetItemType(spellItemTypes[i]);

                //add itemTilePositions into the position list
                staticObjectPositions.Add(itemTilePositions[i]);
            }
            /*
            spellItem[0].SetItemTilePosition(23, 11);
            spellItem[0].SetItemType(SpellItemType.HP_POTION);
            spellItem[1].SetItemTilePosition(21, 13);
            spellItem[1].SetItemType(SpellItemType.HP_POTION);
            spellItem[2].SetItemTilePosition(1, 19);
            spellItem[2].SetItemType(SpellItemType.QUEST_ITEM);
            spellItem[3].SetItemTilePosition(9, 11);
            spellItem[3].SetItemType(SpellItemType.QUEST_ITEM);
            spellItem[4].SetItemTilePosition(23, 13);
            spellItem[4].SetItemType(SpellItemType.QUEST_ITEM);
            */

            //Randomly generate locations for stars
            Random rnd = new Random();
            walkablePositions = walkablePositions.Except<Vector2>(staticObjectPositions).ToList<Vector2>();
            for (int i = 0; i < numOfStars; i++)
            {
                //Random pick a vector2 position from the walkable paths list
                Vector2 rndPos = walkablePositions[rnd.Next(walkablePositions.Count)];

                int x = (int)rndPos.X;
                int y = (int)rndPos.Y;
               
                spellItem[numOfSpellItem + i].SetItemTilePosition(x, y);
                spellItem[numOfSpellItem + i].SetItemType(SpellItemType.STAR);
            }
        }


        private void InitializeLock()
        {
            Vector2[] lockTilePositions = { new Vector2(8, 23), new Vector2(14, 6), new Vector2(15, 12), new Vector2(10, 14) };
            KeyLockColor[] keyLockColors = { KeyLockColor.RED, KeyLockColor.YELLOW, KeyLockColor.GREEN, KeyLockColor.BLUE };
            
            for (int i = 0; i < numOfKeyAndLock; i++)
            {
                doorLock[i] = new Lock();
                doorLock[i].SetLockTilePosition((int)lockTilePositions[i].X,(int)lockTilePositions[i].Y);
                doorLock[i].SetLockColour(keyLockColors[i]);

                //add lockTilePositions into the position list
                staticObjectPositions.Add(lockTilePositions[i]);
            }

            /*
            doorLock[0].SetLockTilePosition(8, 23);
            doorLock[0].SetLockColour(KeyLockColor.RED);
            doorLock[1].SetLockTilePosition(14, 6);
            doorLock[1].SetLockColour(KeyLockColor.YELLOW);
            doorLock[3].SetLockTilePosition(15, 12);
            doorLock[3].SetLockColour(KeyLockColor.GREEN);
            doorLock[2].SetLockTilePosition(10, 14);
            doorLock[2].SetLockColour(KeyLockColor.BLUE);
            */
        }

        public void CheckLooted(GameTime gameTime,Player player)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (key[i].CheckPlayerPos(player.GetTilePositionVector()))
                    player.SetPickUpFlag(true);


                for (int j = 0; j < doorLock.Length; j++)
                    if (key[i].GetKeyColourIndex() == doorLock[j].GetLockColourIndex())
                        doorLock[j].CheckIfDoorLockIsUnlocked(key[i].isLooted());

            }

            for (int i = 0; i < spellItem.Length; i++)
            {
                if (spellItem[i].CheckPlayerPos(player.GetTilePositionVector()))
                {
                    player.SetPickUpFlag(true);

                    if (spellItem[i].GetItemType() == SpellItemType.HP_POTION)
                    {
                        player.IncreaseHP(3);
                        player.SetIsHPIncreased(true);
                    }
                    else if (spellItem[i].GetItemType() == SpellItemType.QUEST_ITEM)
                    {
                        player.LootQuestItem();
                    }
                    else if (spellItem[i].GetItemType() == SpellItemType.STAR)
                    {
                        player.LootStar();
                    }
                }
            }


        }

        public Key[] GetKeys()
        {
            return key;
        }

        public Lock[] GetLocks()
        {
            return doorLock;
        }

        public SpellItem[] GetSpellItems()
        {
            return spellItem;
        }
        
       
    }
}
