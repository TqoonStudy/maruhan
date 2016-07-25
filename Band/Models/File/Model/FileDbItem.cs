using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.File.Model{
public class FileDbItem : BasicObject {
public int Id{ get;set;}
public string Orifilename{ get;set;}="";
public string Storedfilename{ get;set;}="";
public string Extension{ get;set;}="";
}
}
