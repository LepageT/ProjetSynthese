using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Student;

namespace Stagio.Web.Module
{
    public class ReadFile<T>
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
    }
}