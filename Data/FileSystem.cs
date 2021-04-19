using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO; 
namespace UTSS.Data
{
    public class FileSystem
    {
        public string readFile(string filePath) {
            if(File.Exists(filePath))
            return File.ReadAllText(filePath);
            throw new Exception("The path for the file is incorrect"); 
        }


    }
}