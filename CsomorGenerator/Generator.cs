using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsomorGenerator
{
    /// <summary>
    /// Generate Csomor
    /// </summary>
    public class Generator
    {
        private GeneratorSettings settings;

        private readonly int GenerateLimit = 500;

        /// <summary>
        /// Init Builder
        /// </summary>
        /// <param name="settings">Settings</param>
        public Generator(GeneratorSettings settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// Build table
        /// </summary>
        /// <returns>Fresh settings</returns>
        public GeneratorSettings Build()
        {
            // Settings pre checking
            // If it is invalid, return null
            if (!this.PreCheck())
            {
                return null;
            }

            // Pre settings
            SetWorkHours();

            settings.Works.ForEach(work =>
            {
                this.GenerateToWork(work.Id);
            });

            settings.HasGeneratedCsomor = true;
            settings.LastGeneration = DateTime.Now;

            return settings;
        }

        /// <summary>
        /// Calculate work hours to the persons
        /// </summary>
        private void SetWorkHours()
        {
            // All hour
            int hours = settings.Works.Sum(x => x.Tables.Count(y => y.IsActive));

            // Add hours to the persons
            while (hours > 0)
            {
                for (int i = 0; i < settings.Persons.Count && hours > 0; i++)
                {
                    // Max hours
                    int availableHours = settings.Persons[i].Tables.Count(x => x.IsAvailable);
                    if (settings.Persons[i].Hours < availableHours)
                    {
                        settings.Persons[i].Hours++;
                        hours--;
                    }
                }
            }
        }

        /// <summary>
        /// Generate csomor for works
        /// </summary>
        /// <param name="workId">Work Id</param>
        /// <returns>List of modified persons</returns>
        private void GenerateToWork(string workId)
        {
            var work = settings.Works.FirstOrDefault(x => x.Id == workId);

            if (work == null)
            {
                throw new MessageException("Invalid work Id");
            }

            for (int i = 0; i < work.Tables.Count; i++)
            {
                var table = work.Tables[i];

                this.GenerateToDate(ref table, workId, 0);

                work.Tables[i] = table;
            }
        }

        /// <summary>
        /// Generate csomor for table
        /// </summary>
        /// <param name="table">Work table</param>
        /// <param name="workId">Work Id</param>
        /// <param name="counter">Counter against infinite loop</param>
        private void GenerateToDate(ref WorkTable table, string workId, int counter = 0)
        {
            var person = this.GetValidRandomPerson();

            if (person == null)
            {
                return;
            }

            if (WorkerIsValid(person, table.Date, workId, settings.MaxWorkHour))
            {
                table.PersonId = person.Id;
                var date = table.Date;
                var pTable = person.Tables.FirstOrDefault(x => CompareDates(date, x.Date));

                if (pTable == null)
                {
                    throw new ArgumentException("Table is missing");
                }

                pTable.WorkId = workId;
                person.Hours--;
            }
            else if (counter < this.GenerateLimit)
            {
                if (counter > 100)
                {
                    // TODO: Worker switch
                    Console.WriteLine("Bigger than 100");
                    return;
                }
                else
                {
                    this.GenerateToDate(ref table, workId, counter++);
                }
            }
        }

        /// <summary>
        /// Get valid random person.
        /// Filtered to active and available persons
        /// </summary>
        /// <returns>Randomized person</returns>
        private Person GetValidRandomPerson()
        {
            var r = new Random();
            var validList = settings.Persons.Where(x => !x.IsIgnored && x.Hours != 0).ToList();

            return validList.Count == 0 ? null : validList[r.Next(validList.Count)];
        }

        /// <summary>
        /// Precheck simple generation
        /// </summary>
        /// <returns>Is startable or not</returns>
        private bool PreCheck()
        {
            return
                CheckPersons(settings.Persons, settings.Works) // Check persons
                && CheckWorks(settings.Works)  // Check works
                && CheckHours(settings)  // Check hours
                && CheckSum(settings); // Check sums
        }

        /// <summary>
        /// Check persons valid status
        /// </summary>
        /// <param name="persons">Persons</param>
        /// <param name="works">Works</param>
        /// <returns>Valid or not</returns>
        private static bool CheckPersons(List<Person> persons, List<Work> works)
        {
            persons.ForEach(x => CheckPerson(x, works));

            return true;
        }

        /// <summary>
        /// Check person
        /// </summary>
        /// <param name="person">Person</param>
        /// <param name="works">Work</param>
        private static void CheckPerson(Person person, List<Work> works)
        {
            // Check all hour is unavailable
            if (!person.Tables.Any(x => x.IsAvailable))
            {
                throw new MessageException($"Person ({person.Name}) cannot be unavailable all the time.");
            }

            // All works is ignored
            if (person.IgnoredWorks.Count == works.Count)
            {
                throw new MessageException($"Person ({person.Name}) must has at least one not ignored Work");

            }
        }

        /// <summary>
        /// Check work valid status.
        /// </summary>
        /// <param name="works">Work</param>
        /// <returns>Valid or not</returns>
        private static bool CheckWorks(List<Work> works)
        {
            works.ForEach(CheckWork);

            return true;
        }

        /// <summary>
        /// Check empty works.
        /// All work is empty or not.
        /// </summary>
        /// <param name="work">Work</param>
        private static void CheckWork(Work work)
        {
            if (!work.Tables.Any(x => x.IsActive))
            {
                throw new MessageException($"Work ({work.Name}) cannot be unavailable all the time.");
            }
        }

        /// <summary>
        /// Check hours.
        /// All hours is correct.
        /// </summary>
        /// <param name="settings">Generator settings</param>
        /// <returns>Valid or not</returns>
        private static bool CheckHours(GeneratorSettings settings)
        {
            // Start
            var start = settings.Start;

            while (start < settings.Finish)
            {
                // Count of works
                int works = settings.Works.Count(x =>
                    x.Tables.FirstOrDefault(y => CompareDates(start, y.Date))?.IsActive ?? false);

                // Count of persons
                int persons = settings.Persons.Count(x =>
                    x.Tables.FirstOrDefault(y => CompareDates(start, y.Date))?.IsAvailable ?? false);

                // Work number has to be less thank works
                if (works > persons)
                {
                    throw new MessageException($"There are not enough person in hour {start.Month.ToString().PadLeft(2, '0')}-{start.Day.ToString().PadLeft(2, '0')}-{start.Hour.ToString().PadLeft(2, '0')}.");
                }

                start = start.AddHours(1);
            }

            return true;
        }

        /// <summary>
        /// Check hour sums
        /// </summary>
        /// <param name="settings">Generator settings</param>
        /// <returns>Valid or not</returns>
        private static bool CheckSum(GeneratorSettings settings)
        {
            // Sums
            int personSum = settings.Persons.Sum(x => x.Tables.Count(y => y.IsAvailable));
            int workSum = settings.Works.Sum(x => x.Tables.Count(y => y.IsActive));

            // Work sum has to be less than person sum's 90% and minus the res hour sum
            if (workSum > (personSum * 0.75) - GetLength(settings.Start, settings.Finish) / (settings.MaxWorkHour + settings.MinRestHour) * settings.MinRestHour)
            {
                throw new MessageException("Does not have enough person.");
            }

            return true;
        }

        /// <summary>
        /// Compare two dates. Equals or not.
        /// </summary>
        /// <param name="date1">Date 1</param>
        /// <param name="date2">Date 2</param>
        /// <returns>Equals or not</returns>
        private static bool CompareDates(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day &&
                   date1.Hour == date2.Hour;
        }

        /// <summary>
        /// Get difference between two date in hour
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">Finish date</param>
        /// <returns>Length</returns>
        private static int GetLength(DateTime start, DateTime end)
        {
            int length = 0;
            var date = start;
            while (date < end)
            {
                length++;
                date = date.AddHours(1);
            }

            return length;
        }

        /// <summary>
        /// Check past.
        /// All last max work hour has work or not.
        /// </summary>
        /// <param name="person">Checked person</param>
        /// <param name="date">Current date</param>
        /// <param name="maxWorkHour">Maximum work hour setting</param>
        /// <returns>Valid or not</returns>
        private static bool CheckPast(Person person, DateTime date, int maxWorkHour)
        {
            // TODO: add min rest
            // TODO: check future too (because of change)
            for (int i = 1; i <= maxWorkHour; i++)
            {
                if (string.IsNullOrEmpty(person.Tables.FirstOrDefault(x => CompareDates(date.AddHours(-i), x.Date))
                    ?.WorkId))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Worker is valid in the current date for the given work or not.
        /// </summary>
        /// <param name="person">Person</param>
        /// <param name="date">Current date</param>
        /// <param name="workId">Work Id</param>
        /// <param name="maxWorkHour">Maximum work hour setting</param>
        /// <returns>Valid or not</returns>
        private static bool WorkerIsValid(Person person, DateTime date, string workId, int maxWorkHour)
        {
            // Person not has more available hour
            if (person.Hours == 0)
            {
                return false;
            }

            var table = person.Tables.FirstOrDefault(x => CompareDates(date, x.Date));

            // Worker does not have hour table.
            if (table == null)
            {
                throw new MessageException("Wrong person table");
            }

            // Person is not available or already has any work
            bool a = string.IsNullOrEmpty(table.WorkId);
            if (!table.IsAvailable || !string.IsNullOrEmpty(table.WorkId))
            {
                return false;
            }

            // The work is not ignored
            if (person.IgnoredWorks.Contains(workId))
            {
                return false;
            }

            // Past is acceptable for the settings
            if (!CheckPast(person, date, maxWorkHour))
            {
                return false;
            }

            return true;
        }
    }
}
