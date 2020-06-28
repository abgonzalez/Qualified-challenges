using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canon
{
    public class PaginationHelper<T>
    {
        private int pageCount;
       // public int PageCount { get => content.Count()/ elemenstByPage; set => pageCount = value; }
        private int itemCount;
       // public int ItemCount { get => content.Count(); set => itemCount = value; }
        private int pageIndex;
       // public int PageIndex { get => pageIndex; set => pageIndex = value; }
        private List<T> content;
        public List<T> Content { get => content; set => content = value; }
        private decimal elemenstByPage;
        public decimal ElemenstByPage { get => elemenstByPage; set => elemenstByPage = value; }


        public PaginationHelper( List<T> input, int elements)
        {
            elemenstByPage = elements;
            content = input;
            pageCount = (int)Math.Ceiling((decimal)(content.Count() / elemenstByPage));
            itemCount = content.Count();
        }
        public int PageCount()
        {
            return (int)pageCount;
        }
        public int ItemCount()
        {
            return (int)itemCount;
        }


        public int  PageItemCount(int number)
        {
            if (number+1 > pageCount)
                return -1;
            else if (number+1 < pageCount)
                return (int)elemenstByPage;
            else
            {
                return  ((int)elemenstByPage * (number+1))-content.Count();
            }

        }
        public int PageIndex(T number)
        {
            int position=content.FindIndex(c=> c.Equals(number));
            return (int)Math.Ceiling(position / elemenstByPage);
        }
        public int PageIndex(int position)
        {
            if (position > itemCount || position < 0)
                return -1;
            return (int)(position / elemenstByPage);
        }

    }
}