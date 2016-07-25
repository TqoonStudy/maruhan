using Yusurun.Model;
using System;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Models.BoardFace.Model{
public class BoardFaceDbItem : BasicObject {
public int Id{ get;set;}
public int Userid{ get;set;}
public int Boardid{ get;set;}
public int Faceid{ get;set;}
}
}
