using CsomorGenerator.Services.Interfaces;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Models.CSM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Generator controller
    /// </summary>
    [Route("api/csomor")]
    [ApiController]
    [Authorize]
    public class GeneratorController : ControllerBase
    {
        private readonly IGeneratorService _generatorService;

        /// <summary>
        /// Init generator controller
        /// </summary>
        /// <param name="generatorService">Generator service</param>
        public GeneratorController(IGeneratorService generatorService)
        {
            this._generatorService = generatorService;
        }

        /// <summary>
        /// Generate endpoint
        /// </summary>
        /// <param name="settings">Body</param>
        [HttpPut("generate")]
        public IActionResult Generate([FromBody] GeneratorSettings settings)
        {
            return this.Ok(this._generatorService.Generate(settings));
        }

        /// <summary>
        /// Create endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost]
        public IActionResult Create([FromBody] GeneratorSettingsModel model)
        {
            return this.Ok(this._generatorService.Create(model));
        }

        /// <summary>
        /// Update endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] GeneratorSettingsModel model)
        {
            this._generatorService.Update(id, model);

            return this.Ok();
        }

        /// <summary>
        /// Delete endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            this._generatorService.Delete(id);

            return this.Ok();
        }

        /// <summary>
        /// Get endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            return this.Ok(this._generatorService.Get(id));
        }

        /// <summary>
        /// Get public list endpoint
        /// </summary>
        [HttpGet("public")]
        [AllowAnonymous]
        public IActionResult GetPublicList()
        {
            return this.Ok(this._generatorService.GetPublicList());
        }

        /// <summary>
        /// Get owned list endpoint
        /// </summary>
        [HttpGet("my")]
        public IActionResult GetOwnedList()
        {
            return this.Ok(this._generatorService.GetOwnedList());
        }

        /// <summary>
        /// Get shared list endpoint
        /// </summary>
        [HttpGet("shared")]
        public IActionResult GetSharedList()
        {
            return this.Ok(this._generatorService.GetSharedList());
        }

        /// <summary>
        /// Share endpoint
        /// </summary>
        /// <param name="id">Path param</param>
        /// <param name="models">Models</param>
        [HttpPut("{id}/share")]
        public IActionResult Share([FromRoute] int id, [FromBody] List<CsomorAccessModel> models)
        {
            this._generatorService.Share(id, models);

            return this.Ok();
        }

        /// <summary>
        /// Publish endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("{id}/publish")]
        public IActionResult ChangePublicStatus([FromRoute] int id, [FromBody] GeneratorPublishModel model)
        {
            this._generatorService.ChangePublicStatus(id, model);

            return this.Ok();
        }

        /// <summary>
        /// Get role endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpGet("{id}/role")]
        [AllowAnonymous]
        public IActionResult GetRoleForCsomor([FromRoute] int id)
        {
            return this.Ok(this._generatorService.GetRoleForCsomor(id));
        }

        /// <summary>
        /// Export PDF endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("{id}/export/pdf")]
        public IActionResult ExportPdf([FromRoute] int id, [FromBody] ExportSettingsModel model)
        {
            return this.Ok(this._generatorService.ExportPdf(id, model.Type, model.FilterList));
        }

        /// <summary>
        /// Export XLSX endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        /// <returns></returns>
        [HttpPut("{id}/export/xls")]
        public IActionResult ExportXls([FromRoute] int id, [FromBody] ExportSettingsModel model)
        {
            return this.Ok(this._generatorService.ExportXls(id, model.Type, model.FilterList));
        }

        /// <summary>
        /// Get shared people endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpGet("{id}/shared")]
        public IActionResult GetSharedPersonList([FromRoute] int id)
        {
            return this.Ok(this._generatorService.GetSharedPersonList(id));
        }

        /// <summary>
        /// Get correct people for sharing endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="name">Query param</param>
        [HttpGet("{id}/shared/correct")]
        public IActionResult GetCorrectPersonsForSharing([FromRoute] int id, [FromQuery] string name)
        {
            return this.Ok(this._generatorService.GetCorrectPersonsForSharing(id, name));
        }
    }
}
