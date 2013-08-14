using System;

using LinkGame1.Entities;

namespace LinkGame1.Common
{
    public class MapHelper
    {
        public static void InitializeMap<T>(T[][] map, int rowCount, int columnCount, int itemTypeCount)
            where T : IMapItem
        {
            var itemCount = rowCount * columnCount;
            var items = new int[itemTypeCount];
            var typeCount = itemCount / itemTypeCount;
            if (typeCount % 2 == 0)
            {
                for (int i = 0; i < itemTypeCount - 1; i++)
                {
                    items[i] = typeCount;
                }

                items[itemTypeCount - 1] = itemCount - ((itemTypeCount - 1) * typeCount);
            }
            else
            {
                typeCount -= 1;
                for (var i = 0; i < itemTypeCount - 1; i++)
                {
                    items[i] = typeCount;
                }

                items[itemTypeCount - 1] = itemCount - (typeCount * (itemTypeCount - 1));
            }


            var random = new Random(DateTime.Now.Second);
            for (var row = 0; row < rowCount; row++)
            {
                for (var column = 0; column < columnCount; column++)
                {
                    var item = Activator.CreateInstance<T>();
                    item.Row = row; 
                    item.Column = column;

                    while (true)
                    {
                        var num = random.Next(0, itemTypeCount);
                        if (items[num] > 0)
                        {
                            item.Value = num;
                            items[num]--;
                            break;
                        }
                    }

                    // item.Value = 0;
                    map[row][column] = item;
                }
            }
        }
    }
}
