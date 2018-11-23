using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OpenDataImport.Service
{
    public class EFImportService
    {
        private Repository.EFOpenDataRepository _efRepository;
        public EFImportService()
        {
            _efRepository = new Repository.EFOpenDataRepository();
        }

        
        public List<OpenData> FindOpenDataFromDb(string name)
        {

            return _efRepository.SelectAll(name);
        }




    }
}
