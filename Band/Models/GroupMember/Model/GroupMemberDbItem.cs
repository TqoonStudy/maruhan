using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.GroupMember.Model{
public class GroupMemberDbItem : BasicObject {
public int Id{ get;set;}
public int Groupid{ get;set;}
public int Userid{ get;set;}
public string Grade{ get;set;}="";
public DateTime Regdate{ get;set;}=SqlDateTime.MinValue.Value;
}
}
