using EventManager.Client.Enums;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Models.CSM;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.CSM
{
    /// <summary>
    /// Csomor Maker Settings page
    /// </summary>
    public partial class CsomorMakerSetting : IDisposable
    {
        /// <summary>
        /// Id
        /// </summary>
        [Parameter]
        public int? Id { get; set; }

        [Inject]
        private IGeneratorService GeneratorService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject] private IDialogService DialogService { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Inject]
        private ISnackbar Toaster { get; set; }

        private GeneratorSettings Settings { get; set; }
        private EditContext Context { get; set; }
        private GeneratorSettingsModel Model { get; set; }
        private EditContext PersonContext { get; set; }
        private PersonModel PersonModel { get; set; }
        private EditContext WorkContext { get; set; }
        private WorkModel WorkModel { get; set; }
        private bool IsModifiedState { get; set; }
        private CsomorRole Role { get; set; }
        private AddType PersonEvent { get; set; }
        private AddType WorkEvent { get; set; }

        private List<string> FilterList { get; set; } = new List<string>();
        private CsomorType Type { get; set; } = CsomorType.Work;

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.Model = new GeneratorSettingsModel();
            this.Context = new EditContext(this.Model);

            this.Context.OnFieldChanged += this.OnFieldChanged;

            this.PersonModel = new PersonModel();
            this.WorkModel = new WorkModel();

            this.PersonContext = new EditContext(this.PersonModel);
            this.WorkContext = new EditContext(this.WorkModel);
        }

        private void OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            this.IsModifiedState = true;
        }

        /// <inheritdoc />
        protected override async Task OnParametersSetAsync()
        {
            await this.GetRole();
            await this.GetSettings();
        }

        private async Task GetSettings()
        {
            if (this.Id != null)
            {
                this.Settings = await this.GeneratorService.Get((int)this.Id);
                if (this.Settings == null)
                {
                    this.NavigationManager.NavigateTo("/csomors");
                }
                this.Model = new GeneratorSettingsModel(this.Settings);
            }
            else
            {
                this.Model = new GeneratorSettingsModel();
                this.Settings = null;
            }
            this.IsModifiedState = false;
            this.StateHasChanged();
        }

        private async Task GetRole()
        {
            if (this.Id != null)
            {
                var role = await this.GeneratorService.GetRole((int)this.Id);

                if (role == CsomorRole.Denied)
                {
                    this.NavigationManager.NavigateTo("/csomors");
                }
                else
                {
                    this.Role = role;
                }
            }
            else
            {
                this.Role = CsomorRole.Owner;
            }
        }

        private async void SaveSettings()
        {
            if (this.Context.Validate())
            {
                if (this.Id == null)
                {
                    this.Id = await this.GeneratorService.Create(this.Model);
                    this.NavigationManager.NavigateTo($"/csomor/{this.Id}");
                }
                else
                {
                    await this.GeneratorService.Update((int)this.Id, this.Model);
                    await this.GetSettings();
                    this.IsModifiedState = false;
                }
            }
        }

        private void AddPerson()
        {
            if (this.PersonContext.Validate() && this.AddPerson(this.PersonModel))
            {
                this.PersonModel = new PersonModel();
                this.PersonContext = new EditContext(this.PersonModel);
            }
        }

        private bool AddPerson(PersonModel person)
        {
            if (string.IsNullOrEmpty(person.Name))
            {
                this.Toaster.Add($"Person name is incorrect ({person.Name})", Severity.Info);
                return false;
            }
            if (this.Model.Persons.Exists(x => x.Name == person.Name))
            {
                this.Toaster.Add($"Person already exists ({person.Name})", Severity.Info);
                return false;
            }

            person.SetTables(this.Model.Start, this.Model.Finish);
            this.Model.Persons.Add(person);
            this.IsModifiedState = true;
            this.StateHasChanged();
            this.Toaster.Add($"Person added ({person.Name})", Severity.Success);
            return true;
        }

        private void AddWork()
        {
            if (this.WorkContext.Validate() && this.AddWork(this.WorkModel))
            {
                this.WorkModel = new WorkModel();
                this.WorkContext = new EditContext(this.WorkModel);
            }
        }

        private bool AddWork(WorkModel work)
        {
            if (string.IsNullOrEmpty(work.Name))
            {
                this.Toaster.Add($"Work name is incorrect ({work.Name})", Severity.Info);
                return false;
            }
            if (this.Model.Works.Exists(x => x.Name == work.Name))
            {
                this.Toaster.Add($"Work already exists ({work.Name})", Severity.Info);
                return false;
            }

            work.SetTables(this.Model.Start, this.Model.Finish);
            this.Model.Works.Add(work);
            this.IsModifiedState = true;
            this.StateHasChanged();
            this.Toaster.Add($"Work added ({work.Name})", Severity.Success);
            return true;
        }

        private void StateChanged()
        {
            this.IsModifiedState = true;
            this.StateHasChanged();
        }

        private void DateChanged(DateTime? date, string type)
        {
            if (date == null)
            {
                return;
            }

            if (type == "start")
            {
                this.Model.Start = ((DateTime)date).AddMinutes(-((DateTime)date).Minute);
            }
            if (type == "finish")
            {
                this.Model.Finish = ((DateTime)date).AddMinutes(-((DateTime)date).Minute);
            }

            ReSetup();
        }

        private void TimeChanged(TimeSpan? time, string type)
        {
            if (time == null)
            {
                return;
            }

            if (type == "start")
            {
                this.Model.StartTime = (TimeSpan)time;
                this.Model.Start = this.Model.Start.AddHours(-this.Model.Start.Hour).AddHours(((TimeSpan)time).Hours);
            }
            if (type == "finish")
            {
                this.Model.FinishTime = (TimeSpan)time;
                this.Model.Start = this.Model.Start.AddHours(-this.Model.Finish.Hour).AddHours(((TimeSpan)time).Hours);
            }

            ReSetup();
        }

        private void ReSetup()
        {
            this.Model.Persons.ForEach(x => x.UpdateTable(this.Model.Start, this.Model.Finish));
            this.Model.Works.ForEach(x => x.UpdateTable(this.Model.Start, this.Model.Finish));
            this.IsModifiedState = true;
            this.Model.HasGeneratedCsomor = false;
            this.StateHasChanged();
        }

        private async void Generate()
        {
            if (!this.Context.IsModified())
            {
                var settings = await this.GeneratorService.GenerateSimple(new GeneratorSettings(this.Id, this.Model));
                this.Model.Persons = settings.Persons.Select(x => new PersonModel(x)).ToList();
                this.Model.Works = settings.Works.Select(x => new WorkModel(x)).ToList();
                this.Model.HasGeneratedCsomor = settings.HasGeneratedCsomor;
                this.Model.LastGeneration = settings.LastGeneration;
                this.Settings = settings;
                this.IsModifiedState = true;
                this.StateHasChanged();
            }
        }

        private bool CanSave()
        {
            return this.IsModifiedState && this.CheckRole(CsomorRole.Owner, CsomorRole.Write);
        }

        private bool CanGenerate()
        {
            return !this.CanSave() && this.CheckRole(CsomorRole.Owner, CsomorRole.Write);
        }

        private bool CanExport()
        {
            return !this.CanSave() && this.Id != null && this.CheckRole(CsomorRole.Owner, CsomorRole.Write, CsomorRole.Read);
        }

        private async void ExportXls()
        {
            if (this.Id != null)
            {
                await this.GeneratorService.ExportXls((int)this.Id, new ExportSettingsModel { Type = this.Type, FilterList = this.FilterList });
            }
        }

        private async void ExportPdf()
        {
            if (this.Id != null)
            {
                await this.GeneratorService.ExportPdf((int)this.Id, new ExportSettingsModel { Type = this.Type, FilterList = this.FilterList });
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Context.OnFieldChanged -= this.OnFieldChanged;
        }

        private async void OpenConfirmDialog(bool status)
        {
            var parameters = new DialogParameters {{"Input", new ConfirmDialogInput {
                Name = Model.Title,
                Action = status ? ConfirmType.Publish : ConfirmType.Hide,
                DeleteFunction = async () => await ConfirmAction()
            }}};

            var dialog = DialogService.Show<ConfirmDialog>(status ? "Confirm Publish" : "Confirm Hide", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                this.Settings.IsPublic = !(bool)this.Settings.IsPublic;
                this.StateHasChanged();
            }
        }

        private async Task<bool> ConfirmAction()
        {
            if (Settings != null && Settings.IsPublic != null)
            {
                return await this.GeneratorService.ChangePublicStatus((int)Id, new GeneratorPublishModel
                {
                    Status = !(bool)this.Settings.IsPublic
                });
            }

            return false;
        }

        private bool CheckRole(params CsomorRole[] roles)
        {
            foreach (var role in roles)
            {
                if (this.Role == role)
                {
                    return true;
                }
            }

            return false;
        }


        private async Task<string> GetContent(IReadOnlyList<IBrowserFile> files)
        {
            try
            {
                var file = files.FirstOrDefault();
                if (file == null)
                {
                    this.Toaster.Add("Cannot find any file", Severity.Info);
                    return "";
                }

                using (var stream = new MemoryStream())
                {
                    var sw = Stopwatch.StartNew();
                    await file.OpenReadStream().CopyToAsync(stream);
                    sw.Stop();
                    Console.WriteLine(file.ContentType);
                    if (stream.Length > 1024 * 1024 || !(file.ContentType == "text/plain" || file.ContentType == "text/csv"))
                    {
                        this.Toaster.Add("File is too big or type is not acceptable", Severity.Error);
                        return "";
                    }
                    else
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        using (var reader = new StreamReader(stream))
                        {
                            return await reader.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                await this.InvokeAsync(this.StateHasChanged);
            }

            this.Toaster.Add("Error during import", Severity.Error);
            return "";
        }

        private async void ImportPersons(InputFileChangeEventArgs e)
        {
            foreach (string c in (await this.GetContent(e.GetMultipleFiles())).Split("\n"))
            {
                this.AddPerson(new PersonModel(c));
            }
        }

        private async void ImportWorks(InputFileChangeEventArgs e)
        {
            foreach (string c in (await this.GetContent(e.GetMultipleFiles())).Split("\n"))
            {
                this.AddWork(new WorkModel(c));
            }
        }
    }
}