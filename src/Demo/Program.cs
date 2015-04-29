using Jusfr.Persistent;
using Jusfr.Persistent.NH;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Demo {
    class Program {
        static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args) {
            var conStr = ConfigurationManager.ConnectionStrings["Chuye"].ConnectionString;
            var context = new ChuyeContext();

            var workRepo = new NHibernateRepository<Work>(context);
            var pageRepo = new NHibernateRepository<Page>(context);
            var works = workRepo.All.EnumPaging(x => new { x.Id, x.Pages }, 100, false);
            var spliter = new[] { ' ', ',', '"', '[', ']' };

            foreach (var work in works.SelectMany(w => w.Items)) {
                W w = new W() {
                    Id = work.Id,
                    P = new List<P>()
                };

                if (work.Pages == null) {
                    _logger.Warn("Null page in work {0}", work.Id);
                }
                else {
                    var pages = work.Pages.Split(spliter, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => Int32.Parse(x)).ToArray();
                    if (pages.Length == 0) {
                        _logger.Warn("Empty page in work {0}", work.Id);
                    }
                    else {
                        foreach (var pageId in pages) {
                            var page = pageRepo.Retrive(pageId);
                            var p = new P() {
                                Id = pageId,
                                M = new List<M>()
                            };
                            w.P.Add(p);

                            if (page == null) {
                                _logger.Warn("Null page in work {0}, {1}", work.Id, pageId);
                            }
                            else {
                                var medias = page.Medias.Split(spliter, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => Int32.Parse(x)).ToArray();
                                if (medias.Length == 0) {
                                    _logger.Warn("Empty media in page {0}", pageId);
                                }
                                else {
                                    foreach (var mediaId in medias) {
                                        var m = new M() {
                                            Id = mediaId,
                                        };
                                        p.M.Add(m);
                                    }
                                }
                            }
                        }
                    }
                }

                var json = JsonConvert.SerializeObject(w);
                _logger.Trace(json);
            }
        }

        private static void PrepareData() {
            var conStr = ConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            var context = new PubsContext();

            Console.WriteLine("Remove all Jobs");
            context.EnsureSession<Job>().CreateSQLQuery("Delete from Job").ExecuteUpdate();
            Console.WriteLine();

            var jobRepo = new NHibernateRepository<Job>(context);
            var jobTitles = new[] { "Java", "C", "C++", "Objective-C", "C#", "JavaScript", "PHP", "Python" };
            var jobs = new List<Job>(jobTitles.Length);
            for (int i = 0; i < jobTitles.Length; i++) {
                var job = new Job {
                    Title = jobTitles[i],
                    Salary = Math.Abs(Guid.NewGuid().GetHashCode() % 8000 + 8000),
                };
                jobRepo.Create(job);
                jobs.Add(job);
            }

            var employeeRepo = new NHibernateRepository<Employee>(context);
            Console.WriteLine("Remove all employee");
            context.EnsureSession<Employee>().CreateSQLQuery("Delete from Employee").ExecuteUpdate();
            Console.WriteLine();

            var employeeNames = new[] { "Charles", "Mark", "Bill", "Vincent", "William", "Joseph", "James", "Henry", "Gary", "Martin" };
            for (int i = 0; i < employeeNames.Length; i++) {
                var entry = new Employee {
                    Name = employeeNames[i],
                    Address = Guid.NewGuid().ToString().Substring(0, 8),
                    Birth = DateTime.UtcNow,
                    Job = jobs[Math.Abs(Guid.NewGuid().GetHashCode()) % jobs.Count],
                };
                employeeRepo.Create(entry);
            }

            Console.WriteLine("Query all employee");
            foreach (var entry in employeeRepo.All.Where(r => r.Job.Salary > 3000)) {
                Console.WriteLine("{0,-10} {1}", entry.Name, entry.Job.Salary);
            }
            Console.WriteLine();
        }
    }

public class W {
    public Int32 Id { get; set; }
    public List<P> P { get; set; }
}

public class P {
    public Int32 Id { get; set; }
    public List<M> M { get; set; }
}

public class M {
    public Int32 Id { get; set; }
}
}
