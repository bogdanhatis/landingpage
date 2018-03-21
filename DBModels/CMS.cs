using System;
using System.Collections.Generic;
using System.Text;

namespace DBModels
{
    class CMS
    {
        private int Id { get; set; }
        public String Name { get; set; }
        public int MenuItemId { get; set; }
        public HtmlTypes HtmlType { get; set; }
        public String Content { get; set; }
    }
}
