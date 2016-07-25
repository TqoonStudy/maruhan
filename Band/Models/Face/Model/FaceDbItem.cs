using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.Face.Model{
public class FaceDbItem : BasicObject {
public int Id{ get;set;}
public int Img{ get;set;}
public string Info{ get;set;}="";
}
}
