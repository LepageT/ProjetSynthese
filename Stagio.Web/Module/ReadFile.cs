using Stagio.Web.ViewModels.Student;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Stagio.Web.Module
{
    public class ReadFile
    {
        public List<ListStudent> ReadFileCsv(HttpPostedFileBase file)
        {
            var listStudentToCreate = new List<ListStudent>();
            if (file.ContentLength > 0)
            {
                var fileToRead = new StreamReader(file.InputStream);
 
                    fileToRead.ReadLine().Split(',');
                    while (!fileToRead.EndOfStream)
                    {
                        var splits = fileToRead.ReadLine().Split(',');
                        var createStudent = new ListStudent();

                        string matricule = Regex.Replace(splits[0], "[^0-9]", "");
                        createStudent.Matricule = Convert.ToInt32(matricule);
                        createStudent.LastName  = splits[1];
                        createStudent.FirstName = splits[2];

                        createStudent.LastName = createStudent.LastName.Replace('"', ' ');
                        createStudent.FirstName = createStudent.FirstName.Replace('"', ' ');

                        listStudentToCreate.Add(createStudent);
                }
            }

            return listStudentToCreate;
        }

        public bool ReadFileCVLetter(IEnumerable<HttpPostedFileBase> files, HttpServerUtilityBase server, int id)
        {
            bool firstfile = true;

            try
            {
                foreach (var file in files)
                {
                    if (file.ContentLength > 0)
                    {
                        var path = "";
                        var fileName = Path.GetFileName(file.FileName);
                        if (firstfile)
                        {
                            path = Path.Combine(server.MapPath("~/App_Data/UploadedFiles"), fileName );
                            firstfile = false;
                        }
                        else
                        {
                            path = Path.Combine(server.MapPath("~/App_Data/UploadedFiles"), fileName );
                        }
                       
                        file.SaveAs(path);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public byte[] Download(string file)
        {
            try
            {
                string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                path = path + "\\UploadedFiles\\" + file;
                byte[] fileBytes = System.IO.File.ReadAllBytes((path));
                string fileName = file;

                return (fileBytes);
            }
            catch (Exception)
            {
                return null;
            }
        }

    
    }
}