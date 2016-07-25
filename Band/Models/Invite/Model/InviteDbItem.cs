using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.Invite.Model{
public class InviteDbItem : BasicObject {
public int Id{ get;set;}
public int Groupid{ get;set;}
public int Toid{ get;set;}
public int Fromid{ get;set;}
public string Status{ get;set;}="";
public DateTime Invitedate{ get;set;}=SqlDateTime.MinValue.Value;
}
}
