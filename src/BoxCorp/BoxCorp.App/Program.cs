using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Jaq
{
    public class Program
    {
        public void RunApp(string path)
        {
            CsvHandler csvHandler = new CsvHandler();
            List<Box> boxes = csvHandler.Load(path).ToList();
            SortBoxes(boxes);
        }

        public int SortBoxes(List<Box> boxes)
        {
            //eleminate based on rank threshold
            boxes = boxes.Where(box => box.Rank >= 0.5).ToList();

            //comparing each pair
            for (int i = 0; i < boxes.Count - 1; i++)
            {
                Rectangle curRect = new Rectangle
                    (boxes[i].Left, boxes[i].Top, boxes[i].Width, boxes[i].Height);

                //compare current with the rest of list
                for (int j = i + 1; j < boxes.Count; j++)
                {
                    Rectangle compRect = new Rectangle
                        (boxes[j].Left, boxes[j].Top, boxes[j].Width, boxes[j].Height);

                    if (curRect.IntersectsWith(compRect))
                    {
                        Rectangle intersectRect = Rectangle.Intersect(curRect, compRect);
                        int intersectArea = intersectRect.Height * intersectRect.Width;
                        int unionArea =
                            boxes[i].Height * boxes[i].Width
                            + boxes[j].Height * boxes[j].Width
                            - intersectArea;
                        double jaqard = (double)intersectArea / (double)unionArea;

                        if (Math.Round(jaqard, 2).CompareTo(0.4d) > 0)
                        {
                            //Jaqard > 0.4, remove Box with lower Rank
                            // if equal Rank, delete boxes[i]
                            boxes.RemoveAt(boxes[i].Rank > boxes[j].Rank ? j : i);
                        }
                    }
                }
            }
            return (boxes.Count);
        }
    }
}
