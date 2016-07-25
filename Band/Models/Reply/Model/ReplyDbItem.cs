using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.Reply.Model{
public class ReplyDbItem : BasicObject {
public int Id{ get;set;}
public int Boardid{ get;set;}
public int Userid{ get;set;}
public string Content{ get;set;}="";
public DateTime Regdate{ get;set;}=SqlDateTime.MinValue.Value;
}
}
