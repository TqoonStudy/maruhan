using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.FileMapping.Model{
public class FileMappingDbItem : BasicObject {
public int Id{ get;set;}
public int Fileid{ get;set;}
public int Targetid{ get;set;}
public string Type{ get;set;}="";
}
}
