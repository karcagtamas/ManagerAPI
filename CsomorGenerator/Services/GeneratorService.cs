﻿using AutoMapper;
using CsomorGenerator.Services.Interfaces;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Entities.CSM;
using ManagerAPI.Services.Common.Excel;
using ManagerAPI.Services.Common.PDF;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Models;
using ManagerAPI.Shared.Models.CSM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsomorGenerator.Services
{
    /// <inheritdoc />
    public class GeneratorService : IGeneratorService
    {
        private const string CsomorDoesNotExistMessage = "Csomor does not exist";
        private const string CsomorThing = "csomor";
        private const string GeneratorServiceSource = "Generator Service";
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IUtilsService _utils;
        private readonly ILoggerService _logger;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        private readonly int GenerateLimit = 500;

        /// <summary>
        /// Init Generator Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="logger">Logger Service</param>
        /// <param name="excelService">Excel Service</param>
        /// <param name="pdfService">PDF Service</param>
        public GeneratorService(DatabaseContext context, IMapper mapper, IUtilsService utils, ILoggerService logger, IExcelService excelService, IPDFService pdfService)
        {
            this._context = context;
            this._mapper = mapper;
            this._utils = utils;
            this._logger = logger;
            this._excelService = excelService;
            this._pdfService = pdfService;
        }

        /// <inheritdoc />
        public GeneratorSettings Generate(GeneratorSettings settings)
        {
            // Settings pre checking
            // If it is invalid, return null
            if (!this.PreCheckSimple(settings))
            {
                return null;
            }

            this.SetWorkHours(ref settings);

            for (int i = 0; i < settings.Works.Count; i++)
            {
                var work = settings.Works[i];
                var persons = settings.Persons;

                this.GenerateToWork(ref work, ref persons, settings.MaxWorkHour);

                settings.Works[i] = work;
                settings.Persons = persons;
            }

            settings.HasGeneratedCsomor = true;
            settings.LastGeneration = DateTime.Now;

            return settings;
        }

        /// <inheritdoc />
        public GeneratorSettings GenerateSimple(GeneratorSettings settings)
        {
            // Pre check
            if (!this.PreCheckSimple(settings))
            {
                return null;
            }

            this.SetWorkHours(ref settings);

            for (int i = 0; i < settings.Works.Count; i++)
            {
                var work = settings.Works[i];
                var persons = settings.Persons;

                this.GenerateToWork(ref work, ref persons, settings.MaxWorkHour);

                settings.Works[i] = work;
                settings.Persons = persons;
            }

            return settings;
        }

        /// <summary>
        /// Generate csomor for works
        /// </summary>
        /// <param name="work">Work</param>
        /// <param name="persons">Persons</param>
        /// <param name="maxHour">Maximum work hour</param>
        /// <returns>List of modified persons</returns>
        private void GenerateToWork(ref Work work, ref List<Person> persons, int maxHour)
        {
            for (int i = 0; i < work.Tables.Count; i++)
            {
                var table = work.Tables[i];

                this.GenerateToDate(ref table, ref persons, work.Id, maxHour, 0);

                work.Tables[i] = table;
            }
        }

        /// <summary>
        /// Generate csomor for table
        /// </summary>
        /// <param name="table">Work table</param>
        /// <param name="persons">Person list</param>
        /// <param name="workId">Work Id</param>
        /// <param name="maxHour">Maximum work hour</param>
        /// <param name="counter">Counter against infinite loop</param>
        private void GenerateToDate(ref WorkTable table, ref List<Person> persons, string workId, int maxHour, int counter = 0)
        {
            var person = this.GetValidRandomPerson(persons);

            if (person == null)
            {
                return;
            }

            if (this.WorkerIsValid(person, table.Date, workId, maxHour))
            {
                table.PersonId = person.Id;
                var date = table.Date;
                var pTable = person.Tables.FirstOrDefault(x => this.CompareDates(date, x.Date));

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
                }
                else
                {
                    this.GenerateToDate(ref table, ref persons, workId, maxHour, counter++);
                }
            }
        }

        /// <summary>
        /// Get valid random person.
        /// Filtered to active and available persons
        /// </summary>
        /// <param name="persons">Person list</param>
        /// <returns>Randomized person</returns>
        private Person GetValidRandomPerson(List<Person> persons)
        {
            var r = new Random();
            var validList = persons.Where(x => !x.IsIgnored && x.Hours != 0).ToList();

            return validList.Count == 0 ? null : validList[r.Next(validList.Count)];
        }

        /// <summary>
        /// Precheck simple generation
        /// </summary>
        /// <param name="settings">Generator settings</param>
        /// <returns>Is startable or not</returns>
        private bool PreCheckSimple(GeneratorSettings settings)
        {
            return
                CheckPersons(settings.Persons, settings.Works) // Check persons
                && this.CheckWorks(settings.Works)  // Check works
                && this.CheckHours(settings)  // Check hours
                && this.CheckSum(settings); // Check sums
        }

        /// <summary>
        /// Check persons valid status
        /// </summary>
        /// <param name="persons">Persons</param>
        /// <param name="works">Works</param>
        /// <returns>Valid or not</returns>
        private bool CheckPersons(List<Person> persons, List<Work> works)
        {
            persons.ForEach(x => this.CheckPerson(x, works.Count));

            return true;
        }

        /// <summary>
        /// Check person
        /// </summary>
        /// <param name="person">Person</param>
        /// <param name="works">Work</param>
        private void CheckPerson(Person person, int works)
        {
            // Check all hour is unavailable
            if (!person.Tables.Any(x => x.IsAvailable))
            {
                throw new MessageException($"Person ({person.Name}) cannot be unavailable all the time.");
            }

            // All works is ignored
            if (person.IgnoredWorks.Count == works)
            {
                throw new MessageException($"Person ({person.Name}) must has at least one not ignored Work");
            }
        }

        /// <summary>
        /// Check work valid status.
        /// </summary>
        /// <param name="works">Work</param>
        /// <returns>Valid or not</returns>
        private bool CheckWorks(List<Work> works)
        {
            works.ForEach(this.CheckWork);

            return true;
        }

        /// <summary>
        /// Check empty works.
        /// All work is empty or not.
        /// </summary>
        /// <param name="work">Work</param>
        private void CheckWork(Work work)
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
        private bool CheckHours(GeneratorSettings settings)
        {
            // Start
            var start = settings.Start;

            while (start < settings.Finish)
            {
                // Count of works
                int works = settings.Works.Count(x =>
                    x.Tables.FirstOrDefault(y => this.CompareDates(start, y.Date))?.IsActive ?? false);

                // Count of persons
                int persons = settings.Persons.Count(x =>
                    x.Tables.FirstOrDefault(y => this.CompareDates(start, y.Date))?.IsAvailable ?? false);

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
        private bool CheckSum(GeneratorSettings settings)
        {
            // Sums
            int personSum = settings.Persons.Sum(x => x.Tables.Count(y => y.IsAvailable));
            int workSum = settings.Works.Sum(x => x.Tables.Count(y => y.IsActive));

            // Work sum has to be less than person sum's 90% and minus the res hour sum
            if (workSum > (personSum * 0.75) - this.GetLength(settings.Start, settings.Finish) / (settings.MaxWorkHour + settings.MinRestHour) * settings.MinRestHour)
            {
                throw new MessageException("Does not have enough person.");
            }

            return true;
        }

        /// <summary>
        /// Worker is valid in the current date for the given work or not.
        /// </summary>
        /// <param name="person">Person</param>
        /// <param name="date">Current date</param>
        /// <param name="workId">Work Id</param>
        /// <param name="maxWorkHour">Maximum work hour setting</param>
        /// <returns>Valid or not</returns>
        private bool WorkerIsValid(Person person, DateTime date, string workId, int maxWorkHour)
        {
            // Person not has more available hour
            if (person.Hours == 0)
            {
                return false;
            }

            var table = person.Tables.FirstOrDefault(x => this.CompareDates(date, x.Date));

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
            if (!this.CheckPast(person, date, maxWorkHour))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check past.
        /// All last max work hour has work or not.
        /// </summary>
        /// <param name="person">Checked person</param>
        /// <param name="date">Current date</param>
        /// <param name="maxWorkHour">Maximum work hour setting</param>
        /// <returns>Valid or not</returns>
        private bool CheckPast(Person person, DateTime date, int maxWorkHour)
        {
            // TODO: add min rest
            // TODO: check future too (because of change)
            for (int i = 1; i <= maxWorkHour; i++)
            {
                if (string.IsNullOrEmpty(person.Tables.FirstOrDefault(x => this.CompareDates(date.AddHours(-i), x.Date))
                    ?.WorkId))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Compare two dates. Equals or not.
        /// </summary>
        /// <param name="date1">Date 1</param>
        /// <param name="date2">Date 2</param>
        /// <returns>Equals or not</returns>
        private bool CompareDates(DateTime date1, DateTime date2)
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
        private int GetLength(DateTime start, DateTime end)
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
        /// Calculate work hours to the persons
        /// </summary>
        /// <param name="settings">Generator settings</param>
        private void SetWorkHours(ref GeneratorSettings settings)
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

        /// <inheritdoc />
        public int Create(GeneratorSettingsModel model)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._mapper.Map<Csomor>(model);
            csomor.OwnerId = user.Id;

            csomor.Persons = this._mapper.Map<List<CsomorPerson>>(model.Persons);
            csomor.Works = this._mapper.Map<List<CsomorWork>>(model.Works);

            this._context.Csomors.Add(csomor);
            this._context.SaveChanges();

            this._logger.LogInformation(user, GeneratorServiceSource, "create csomor", csomor.Id);

            return csomor.Id;
        }

        /// <inheritdoc />
        public void Update(int id, GeneratorSettingsModel model)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            csomor.Works.ToList().ForEach(x =>
            {
                x.Tables.ToList().ForEach(y =>
                {
                    y.PersonId = null;
                    this._context.CsomorWorkTables.Update(y);
                });

            });
            csomor.Persons.ToList().ForEach(x =>
            {
                x.Tables.ToList().ForEach(y =>
                {
                    y.WorkId = null;
                    this._context.CsomorPersonTables.Update(y);
                });
            });
            this._context.SaveChanges();

            csomor.Works.ToList().ForEach(x =>
            {
                this._context.CsomorWorkTables.RemoveRange(x.Tables);
                this._context.CsomorWorks.Remove(x);
                this._context.SaveChanges();
            });

            csomor.Persons.ToList().ForEach(x =>
            {
                this._context.CsomorPersonTables.RemoveRange(x.Tables);
                this._context.CsomorPersons.Remove(x);
                this._context.SaveChanges();
            });

            this._mapper.Map(model, csomor);

            csomor.Persons = this._mapper.Map<List<CsomorPerson>>(model.Persons);
            csomor.Works = this._mapper.Map<List<CsomorWork>>(model.Works);
            csomor.LastUpdate = DateTime.Now;
            csomor.LastUpdaterId = user.Id;


            this._context.Csomors.Update(csomor);
            this._context.SaveChanges();

            this._logger.LogInformation(user, GeneratorServiceSource, "update csomor", csomor.Id);
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            this._context.Csomors.Remove(csomor);
            this._context.SaveChanges();

            this._logger.LogInformation(user, GeneratorServiceSource, "delete csomor", id);
        }

        /// <inheritdoc />
        public GeneratorSettings Get(int id)
        {
            User user;

            try
            {
                user = this._utils.GetCurrentUser();
            }
            catch (Exception)
            {
                user = null;
            }

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                if (user == null)
                {
                    throw this._logger.LogAnonymousInvalidThings(GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
                }
                else
                {
                    throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
                }
            }

            if (user == null)
            {
                this._logger.LogAnonymousInformation(GeneratorServiceSource, "get csomor", id);
            }
            else
            {
                this._logger.LogInformation(user, GeneratorServiceSource, "get csomor", id);
            }


            return this._mapper.Map<GeneratorSettings>(csomor);
        }

        /// <inheritdoc />
        public List<CsomorListDTO> GetPublicList()
        {
            var list = this._mapper.Map<List<CsomorListDTO>>(this._context.Csomors.Where(x => x.IsPublic && x.HasGeneratedCsomor).OrderBy(x => x.Id));

            try
            {
                var user = this._utils.GetCurrentUser();

                this._logger.LogInformation(user, GeneratorServiceSource, "get csomor", list.Select(x => x.Id).ToList());
            }
            catch (Exception)
            {
                this._logger.LogAnonymousInformation(GeneratorServiceSource, "get csomor", list.Select(x => x.Id).ToList());
            }

            return list;
        }

        /// <inheritdoc />
        public List<CsomorListDTO> GetOwnedList()
        {
            var user = this._utils.GetCurrentUser();

            var list = this._mapper.Map<List<CsomorListDTO>>(user.OwnedCsomors.OrderBy(x => x.Id));

            this._logger.LogInformation(user, GeneratorServiceSource, "get csomor", list.Select(x => x.Id).ToList());

            return list;
        }

        /// <inheritdoc />
        public List<CsomorListDTO> GetSharedList()
        {
            var user = this._utils.GetCurrentUser();

            var list = this._mapper.Map<List<CsomorListDTO>>(user.SharedCsomors.Select(x => x.Csomor).OrderBy(x => x.Id));

            this._logger.LogInformation(user, GeneratorServiceSource, "get csomor", list.Select(x => x.Id).ToList());

            return list;
        }

        /// <inheritdoc />
        public void Share(int id, List<CsomorAccessModel> models)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._context.Csomors.Find(id);

            var shareList = csomor.SharedWith.ToList();

            models.ForEach(x =>
            {
                if (shareList.Select(y => y.UserId).ToList().Contains(x.Id))
                {
                    var element = shareList.FirstOrDefault(y => y.UserId == x.Id);
                    if (element.HasWriteAccess != x.HasWriteAccess)
                    {
                        element.HasWriteAccess = x.HasWriteAccess;

                        this._context.SharedCsomors.Update(element);
                    }
                }
                else
                {
                    var element = new UserCsomor
                    {
                        UserId = x.Id,
                        HasWriteAccess = x.HasWriteAccess,
                        CsomorId = id
                    };

                    this._context.SharedCsomors.Add(element);
                }
            });

            shareList.ForEach(x =>
            {
                if (!models.Select(y => y.Id).Contains(x.UserId))
                {
                    this._context.SharedCsomors.Remove(x);
                }
            });

            this._context.SaveChanges();

            this._logger.LogInformation(user, GeneratorServiceSource, "update shared", models.Select(x => x.Id).ToList());
        }

        /// <inheritdoc />
        public void ChangePublicStatus(int id, GeneratorPublishModel model)
        {
            var user = this._utils.GetCurrentUser();
            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            csomor.IsPublic = model.Status;
            this._context.Update(csomor);
            this._context.SaveChanges();

            this._logger.LogInformation(user, GeneratorServiceSource, model.Status ? "publish" : "unpublish" + " csomor", id);
        }

        /// <inheritdoc />
        public CsomorRole GetRoleForCsomor(int id)
        {
            User user;

            try
            {
                user = this._utils.GetCurrentUser();
            }
            catch
            {
                user = null;
            }

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            if (user != null)
            {
                if (csomor.OwnerId == user.Id)
                {
                    return CsomorRole.Owner;
                }

                var shared = csomor.SharedWith.Where(x => x.UserId == user.Id).FirstOrDefault();

                if (shared != null)
                {
                    if (shared.HasWriteAccess)
                    {
                        return CsomorRole.Write;
                    }
                    else
                    {
                        return CsomorRole.Read;
                    }
                }
            }

            if (csomor.IsPublic)
            {
                return CsomorRole.Public;
            }

            return CsomorRole.Denied;
        }

        /// <inheritdoc />
        public ExportResult ExportPdf(int id, CsomorType type, List<string> filterList)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            if (type == CsomorType.Work)
            {
                var works = csomor.Works.Where(x => !filterList.Contains(x.Id)).ToList();
                var result = this._pdfService.GenerateWorkCsomor(works);
                this._logger.LogInformation(user, GeneratorServiceSource, "export works", id);
                return result;
            }
            else
            {
                var persons = csomor.Persons.Where(x => !filterList.Contains(x.Id)).ToList();
                var result = this._pdfService.GeneratePersonCsomor(persons);
                this._logger.LogInformation(user, GeneratorServiceSource, "export persons", id);
                return result;
            }
        }

        /// <inheritdoc />
        public ExportResult ExportXls(int id, CsomorType type, List<string> filterList)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            if (type == CsomorType.Work)
            {
                var works = csomor.Works.Where(x => !filterList.Contains(x.Id)).ToList();
                var result = this._excelService.GenerateWorkCsomor(works);
                this._logger.LogInformation(user, GeneratorServiceSource, "export works", id);
                return result;
            }
            else
            {
                var persons = csomor.Persons.Where(x => !filterList.Contains(x.Id)).ToList();
                var result = this._excelService.GeneratePersonCsomor(persons);
                this._logger.LogInformation(user, GeneratorServiceSource, "export persons", id);
                return result;
            }
        }

        /// <inheritdoc />
        public List<CsomorAccessDTO> GetSharedPersonList(int id)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            this._logger.LogInformation(user, GeneratorServiceSource, "get shared persons", id);
            return this._mapper.Map<List<CsomorAccessDTO>>(csomor.SharedWith);
        }

        /// <inheritdoc />
        public List<UserShortDto> GetCorrectPersonsForSharing(int id, string name)
        {
            var user = this._utils.GetCurrentUser();

            var csomor = this._context.Csomors.Find(id);

            if (csomor == null)
            {
                throw this._logger.LogInvalidThings(user, GeneratorServiceSource, CsomorThing, CsomorDoesNotExistMessage);
            }

            var alreadyAdded = this.GetSharedPersonList(id).Select(x => x.Id).ToList();
            var users = this._context.AppUsers.Where(x => x.Id != csomor.Owner.Id && !alreadyAdded.Contains(x.Id) && (x.UserName.Contains(name) || x.FullName.Contains(name) || x.Email.Contains(name))).OrderBy(x => x.UserName).ThenBy(x => x.FullName).ThenBy(x => x.Email).Take(5).ToList();
            this._logger.LogInformation(user, GeneratorServiceSource, "get correct persons", id);
            return this._mapper.Map<List<UserShortDto>>(users);
        }
    }
}