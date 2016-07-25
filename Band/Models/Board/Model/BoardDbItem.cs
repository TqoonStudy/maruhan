using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.Board.Model{
public class BoardDbItem : BasicObject {
public int Id{ get;set;}
public int Userid{ get;set;}
public int Groupid{ get;set;}
public string Content{ get;set;}="";
public DateTime Regdate{ get;set;}=SqlDateTime.MinValue.Value;
public string Notice{ get;set;}="";
}
}
