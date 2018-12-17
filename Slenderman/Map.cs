﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Slenderman
{
    class Map
    {
        public List<int> map = new List<int> {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,2,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
                                              1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,
                                              1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,0,1,1,1,1,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,1,
                                              1,0,0,0,0,2,0,0,0,0,0,0,0,1,0,1,0,1,1,1,1,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,1,0,1,0,0,0,0,0,1,
                                              1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,1,
                                              1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
        };

        public int MapHeight;
        public int MapWidth;

        public Map()
        {
            MapWidth = 24;
            MapHeight = map.Count / MapWidth;
        }

        public Tuple<string[,],int> FindWave(int startX, int startY, int targetX, int targetY)
        {
            int[,] Map=new int[MapHeight,MapWidth];
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    Map[i, j] = map[i * 24 + j];
                }
            }
            bool add = true;
            int[,] cMap = new int[MapHeight, MapWidth];
            int x, y, step = 0;
            for (y = 0; y < MapHeight; y++)
                for (x = 0; x < MapWidth; x++)
                {
                    if (Map[y, x] == 1)
                        cMap[y, x] = -2;
                    else
                        cMap[y, x] = -1;
                }
            cMap[targetY, targetX] = 0;
            while (add == true)
            {
                add = false;
                for (y = 0; y < MapWidth; y++)
                    for (x = 0; x < MapHeight; x++)
                    {
                        if (cMap[x, y] == step)
                        {
                            //Ставим значение шага+1 в соседние ячейки (если они проходимы)
                            if (y - 1 >= 0 && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1)
                                cMap[x - 1, y] = step + 1;
                            if (x - 1 >= 0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1)
                                cMap[x, y - 1] = step + 1;
                            if (y + 1 < MapWidth && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1)
                                cMap[x + 1, y] = step + 1;
                            if (x + 1 < MapHeight && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1)
                                cMap[x, y + 1] = step + 1;
                        }
                    }
                step++;
                add = true;
                if (cMap[startY, startX] != -1)//решение найдено
                    add = false;
                if (step > MapWidth * MapHeight)//решение не найдено
                    add = false;
            }
            //Отрисовываем карты
            string[,] tMap = new string[MapHeight, MapWidth];
            for (y = 0; y < MapHeight; y++)
            {

                for (x = 0; x < MapWidth; x++)
                {
                    if (cMap[y, x] == -1)
                        tMap[y, x] = " _ ";
                    else
                     if (cMap[y, x] == -2)
                        tMap[y, x] = " # ";
                    else
                     if (y == startY && x == startX)
                        tMap[y, x] = " S ";
                    else
                     if (y == targetY && x == targetX)
                        tMap[y, x] = " F ";
                    else
                     if (cMap[y, x] > -1)
                        tMap[y,x] = " "+cMap[y,x].ToString()+" ";
                }
            }
            //return tMap;
            return Tuple.Create(tMap, step);
        }
    }
}
