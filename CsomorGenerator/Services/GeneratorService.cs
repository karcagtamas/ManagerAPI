using AutoMapper;
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
            return new Generator(settings).Build();
        }

        /// <inheritdoc />
        public GeneratorSettings GenerateSimple(GeneratorSettings settings)
        {
            return Generate(settings);
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

            // Eliminate persons from work table
            csomor.Works.ToList().ForEach(x =>
            {
                x.Tables.ToList().ForEach(y =>
                {
                    y.PersonId = null;
                    this._context.CsomorWorkTables.Update(y);
                });

            });
            
            // Eliminate works from persons
            csomor.Persons.ToList().ForEach(x =>
            {
                x.Tables.ToList().ForEach(y =>
                {
                    y.WorkId = null;
                    this._context.CsomorPersonTables.Update(y);
                });
            });
            this._context.SaveChanges();

            // Remove works
            csomor.Works.ToList().ForEach(x =>
            {
                this._context.CsomorWorkTables.RemoveRange(x.Tables);
                this._context.CsomorWorks.Remove(x);
            });

            // Remove persons
            csomor.Persons.ToList().ForEach(x =>
            {
                this._context.CsomorPersonTables.RemoveRange(x.Tables);
                this._context.CsomorPersons.Remove(x);
                
            });
            this._context.SaveChanges();

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
                    if (element != null)
                    {
                        if (element.HasWriteAccess != x.HasWriteAccess)
                        {
                            element.HasWriteAccess = x.HasWriteAccess;

                            this._context.SharedCsomors.Update(element);
                        }
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

                var shared = csomor.SharedWith.FirstOrDefault(x => x.UserId == user.Id);

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