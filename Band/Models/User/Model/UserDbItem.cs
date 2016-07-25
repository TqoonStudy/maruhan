using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.User.Model{
public class UserDbItem : BasicObject {
public int Id{ get;set;}
public string Userid{ get;set;}="";
public string Userpw{ get;set;}="";
public string Username{ get;set;}="";
public int Userphoto{ get;set;}
public DateTime Regdate{ get;set;}=SqlDateTime.MinValue.Value;
}
}
