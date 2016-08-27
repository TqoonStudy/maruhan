using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.Group.Model
{
    public class GroupDbItem : BasicObject
    {
        public int Id { get; set; }
        public string Groupname { get; set; } = "";
        public string Img { get; set; } = "";
        public DateTime Regdate { get; set; } = SqlDateTime.MinValue.Value;
        public string ColorCode { get; set; } = "";
    }
}
