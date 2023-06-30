using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Managemail.Common;
using Managemail.Model.Common.Interfaces;
using Managemail.Service.Common.Interfaces;
using Managemail.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Managemail.Web
{
    [ApiController]
    [Route(StringConstants.DefaultApiRoute + "importance-type")]
    public class ImportanceTypeController : ControllerBase
    {
        public ImportanceTypeController(IImportanceTypeLookup importanceTypeLookup, IMapper mapper)
        {
            ImportanceTypeLookup = importanceTypeLookup;
            Mapper = mapper;
        }

        public IImportanceTypeLookup ImportanceTypeLookup { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<IImportanceTypeModel> list = await ImportanceTypeLookup.GetAllAsync();
            return Ok(Mapper.Map<IEnumerable<ImportanceTypeGet>>(list));
        }

        public class ImportanceTypeGet
        {
            public Guid Id { get; set; }
            public String Name { get; set; }
            public String Abrv { get; set; }
        }
    }
}
