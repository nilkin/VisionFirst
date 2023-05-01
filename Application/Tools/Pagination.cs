﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Application.Tools
{
    public class Pagination<T> where T : class
    {
        const int maxPaginationButtonCount = 100;

        public IEnumerable<T> Items { get; set; }
        public int CurrentIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int MaxPageIndex
        {
            get
            {
                return (int)Math.Ceiling(TotalCount * 1.0 / PageSize);
            }
        }

        public Pagination(ICollection<T> query, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            TotalCount = query.Count();

            if (pageIndex > MaxPageIndex && pageIndex > 1)
                pageIndex = MaxPageIndex;

            Items = query.Skip((pageIndex > 0 ? pageIndex - 1 : 0) * pageSize)
                .Take(pageSize)
                .ToList();

            CurrentIndex = pageIndex;
        }

        public HtmlString GetPagenation(IUrlHelper urlHelper,
            string action, string area = "",
            string paginateFunction = "")
        {
            if (PageSize >= TotalCount)
                return HtmlString.Empty;


            StringBuilder builder = new StringBuilder();
            bool hasPaginationFunction = !string.IsNullOrWhiteSpace(paginateFunction);

            builder.Append("<ul class='pagination justify-content-center'>");

            if (CurrentIndex > 1)
            {
                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({CurrentIndex - 1},{PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = CurrentIndex - 1,
                        pagesize = PageSize,
                        area
                    });

                builder.Append($@"<li class='next page-item'>
                                <a class='page-link' href='{link}' aria-label='Previous'>
                                  <span aria-hidden='true'>«</span><span class='sr-only'>Previous</span>
                                </a>
                                </li>");
            }
            else
            {
                builder.Append("<li class='page-item disabled'><a class='page-link'><span aria-hidden='true'>«</span><span class='sr-only'>Previous</span></a></li>");
            }

            int min = 1, max = MaxPageIndex;

            if (CurrentIndex > (int)Math.Floor(maxPaginationButtonCount / 2D))
            {
                min = CurrentIndex - (int)Math.Floor(maxPaginationButtonCount / 2D);
            }

            max = min + maxPaginationButtonCount - 1;

            if (max > MaxPageIndex)
            {
                max = MaxPageIndex;
                min = max - maxPaginationButtonCount + 1;
            }

            for (int i = (min < 1 ? 1 : min); i <= max; i++)
            {
                if (i == CurrentIndex)
                {
                    builder.Append($"<li class='active page-item'><a class='page-link'>{i}</a></li>");
                    continue;
                }

                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({i},{PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = i,
                        pagesize = PageSize,
                        area
                    });

                builder.Append($"<li class='page-item'><a class='page-link' href='{link}'>{i}</a></li>");

            }


            if (CurrentIndex < MaxPageIndex)
            {
                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({CurrentIndex + 1},{PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = CurrentIndex + 1,
                        pagesize = PageSize,
                        area
                    });

                builder.Append($@"<li class='next page-item'>
                                <a class='page-link' href='{link}' aria-label='Next'>
                                  <span aria-hidden='true'></span><span class='sr-only'>Next</span>»
                                </a>
                                </li>");
            }
            else
            {
                builder.Append("<li class='page-item disabled'><a class='page-link'><span aria-hidden='true'>»</span><span class='sr-only'>Next</span></a></li>");
            }


            builder.Append("</ul>");

            return new HtmlString(builder.ToString());
        }
    }
}