using Jusfr.Persistent;
using Jusfr.Persistent.NH;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Demo {
    class Program {
        static void Main(string[] args) {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            //CURD2(); return;
            //TransactionTest(); return;
            //PagingDemo(); return;
            //PagingSelectorDemo(); return;
            CURD(); return;
        }

        private static void CURD2() {
            using (var context = new PubsContext()) {
                var jobRepo = new NHibernateRepository<Job>(context);
                var jobs = EnumJobs().ToArray();
                foreach (var entry in jobs) {
                    jobRepo.Create(entry);
                }

                var empRepo = new NHibernateRepository<Employee>(context);
                var names = "Charles、Mark、Bill、Vincent、William、Joseph、James、Henry、Gary、Martin".Split('、', ' ');
                for (int i = 0; i < names.Length; i++) {
                    var entry = new Employee {
                        Name = names[i],
                        Address = Guid.NewGuid().ToString().Substring(0, 8),
                        Birth = DateTime.UtcNow,
                        Job = jobs[Math.Abs(Guid.NewGuid().GetHashCode() % jobs.Length)],
                    };
                    empRepo.Create(entry);
                }
            }
            using (var context = new PubsContext()) {
                var jobRepo = new NHibernateRepository<Job>(context);
                var jobs = jobRepo.All;
                Console.WriteLine("Query all jobs");
                foreach (var job in jobs) {
                    Console.WriteLine("{0,2} {1,10} {2:f2}", job.Id, job.Title, job.Salary);
                }

                var empRepo = new NHibernateRepository<Employee>(context);
                var emps = empRepo.All;
                Console.WriteLine("Query all employee");
                foreach (var entry in emps) {
                    Console.WriteLine("{0,2} {1,10} {2}",
                        entry.Id, entry.Name, entry.Address);
                }
            }
        }

        private static IEnumerable<Job> EnumJobs() {
            yield return new Job { Title = "C#", Salary = 4000 };
            yield return new Job { Title = "Java", Salary = 5000 };
            yield return new Job { Title = "JavaScript", Salary = 3000 };
            yield return new Job { Title = "Perl", Salary = 4800 };
            yield return new Job { Title = "Python", Salary = 4900 };
            yield return new Job { Title = "C++", Salary = 5900 };
            yield return new Job { Title = "Objective-C", Salary = 5900 };
        }
        
        private static void TransactionTest() {
            using (var context = new PubsContext()) {
                context.AutoTransaction = true;
                var repository = new NHibernateRepository<Employee>(context);
                repository.Delete(repository.All.AsEnumerable());
                var entry = new Employee {
                    Name = Guid.NewGuid().ToString("n"),
                    Address = Guid.NewGuid().ToString("n"),
                    Birth = DateTime.Now,
                };
                repository.Create(entry);
                context.Commit();

                entry.Name = "Josie";
                repository.Update(entry);
                context.Commit();

                entry.Address = "Wuhan";
                repository.Update(entry);
                context.Rollback();
            }
        }

        private static void PagingDemo() {
            using (var context = new PubsContext()) {
                var jobRepository = new NHibernateRepository<Job>(context);
                //context.EnsureSession().CreateSQLQuery("TRUNCATE TABLE [Job]").ExecuteUpdate();
                var pagings = jobRepository.All.EnumPaging(20, false);
                foreach (var paging in pagings) {
                    Console.WriteLine("Paging {0}/{1}, Items {2}",
                        paging.CurrentPage, paging.TotalPages, paging.Items.Count());
                    paging.CurrentPage = 100;
                }
            }
        }

        private static void PagingSelectorDemo() {
            using (var context = new PubsContext()) {
                var jobRepository = new NHibernateRepository<Employee>(context);
                var pagings = jobRepository.All.EnumPaging(r => r.Name, 100, false);
                foreach (var paging in pagings) {
                    Console.WriteLine("Paging {0}/{1}",
                        paging.CurrentPage, paging.TotalPages);
                    foreach (var p in paging.Items) {
                        Console.WriteLine(p);
                    }
                }
            }
        }

        private static void CURD() {
            using (var context = new PubsContext()) {
                //var query = context.EnsureSession().CreateSQLQuery("SELECT Id, Name AS Title, JobId AS Salary FROM dbo.Employee");
                //var jobs = query.UniqueResult<Job>();

                var jobRepository = new NHibernateRepository<Job>(context);
                var employeeRepository = new NHibernateRepository<Employee>(context);
                foreach (var entry in jobRepository.All) {
                    jobRepository.Delete(entry);
                }
                foreach (var entry in employeeRepository.All) {
                    employeeRepository.Delete(entry);
                }

                var CShape = new Job {
                    Title = "C#", Salary = 4
                };
                jobRepository.Create(CShape);
                var Java = new Job {
                    Title = "Java", Salary = 5
                };
                jobRepository.Create(Java);
                var Javascript = new Job {
                    Title = "Javascript", Salary = 3
                };
                jobRepository.Create(Javascript);

                var Aimee = new Employee {
                    Name = "Aimee", Address = "Los Angeles", Birth = DateTime.Now,
                    Job = CShape
                };
                employeeRepository.Create(Aimee);
                var Becky = new Employee {
                    Name = "Becky", Address = "Bejing", Birth = DateTime.Now,
                    Job = Java
                };
                employeeRepository.Create(Becky);
                var Carmen = new Employee {
                    Name = "Carmen", Address = "Salt Lake City", Birth = DateTime.Now,
                    Job = Javascript
                };
                employeeRepository.Create(Carmen);

                Console.WriteLine("Employee all");
                foreach (var entry in employeeRepository.All) {
                    Console.WriteLine("{0,-10} {1} {2}",
                        entry.Name, entry.Job.Salary, entry.Address);
                }
                Console.WriteLine();

                Carmen = employeeRepository.Retrive(Carmen.Id);
                Carmen.Job = Java;
                employeeRepository.Update(Carmen);

                Console.WriteLine("Employee live in USA");
                foreach (var entry in employeeRepository.Retrive("Address", new[] { "Los Angeles", "Salt Lake City" })) {
                    Console.WriteLine("{0,-10} {1} {2}",
                       entry.Name, entry.Job.Salary, entry.Address);
                }
                Console.WriteLine();

                employeeRepository.Delete(Carmen);
                Console.WriteLine("Employee left {0}", employeeRepository.All.Count());
            }
        }
    }
}
