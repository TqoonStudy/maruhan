using Band.Dao;
using Models.File.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Band.Service
{
    public class FileService
    {
        IAbstractDao<FileItem> dao = new AbstractDao<FileItem>();

        public string GetImg(int fileid)
        {
            string result = "";

            try
            {
                result = dao.readStoredFileNameColumn(fileid);
            }
            catch(Exception e)
            {
                result = "/Content/img/exceptionBand.jpg";
            }
            return result;
        }

        internal List<string> GetAllBandImg()
        {
            List<string> result = new List<string>();

            try
            {
                result = dao.getColumnListByValue();
            }
            catch(Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}