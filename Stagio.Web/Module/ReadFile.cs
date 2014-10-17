using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Stagio.Domain.Entities;

namespace Stagio.Web.Module
{
    public class ReadFile<T>
    {
        public List<Student> ReadFileCsv(HttpPostedFileBase file, string path)
        {
            var listStudentToCreate = new List<Student>();
            if (file.ContentLength > 0)
            {
              
                file.SaveAs(path);

                using (var rd = new StreamReader(path))
                {
                    rd.ReadLine().Split(',');
                    while (!rd.EndOfStream)
                    {
                        var splits = rd.ReadLine().Split(',');
                        var createStudent = new Student();

                        createStudent.Matricule = Convert.ToInt32(splits[0]);
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