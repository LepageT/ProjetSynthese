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
                var server = HttpContext.Current.Server;
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(server.MapPath("~/App_Data/UploadedFiles"), fileName);
                //var readFile = new ReadFile<Student>();
                file.SaveAs(path);

                using (var rd = new StreamReader(path))
                {
                    rd.ReadLine().Split(',');
                    while (!rd.EndOfStream)
                    {
                        var splits = rd.ReadLine().Split(',');
                        var createStudent = new ListStudent();
                        string matriculeString = Regex.Replace(splits[0], "[^0-9]", "");
                        createStudent.Matricule = Convert.ToInt32(matriculeString);
                        createStudent.LastName = splits[1];
                        createStudent.FirstName = splits[2];

                        createStudent.LastName = createStudent.LastName.Replace('"', ' ');
                        createStudent.FirstName = createStudent.FirstName.Replace('"', ' ');

                        listStudentToCreate.Add(createStudent);

                    }
                }
            }

            return listStudentToCreate;
        }
    }
}