using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Managemail.Common;
using Managemail.Common.Constants;
using Managemail.Common.Extensions;
using Managemail.Common.Infrastructure;
using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using Managemail.Model.Infrastructure;
using Managemail.Service.Common.Infrastructure;
using Managemail.Service.Common.Interfaces;
using Managemail.Web.Infrastructure.DataAnnotationsExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Managemail.Web
{
    [ApiController]
    [Route(StringConstants.DefaultApiRoute + "email-history")]
    public class EmailHistoryController : ControllerBase
    {
        public EmailHistoryController(IEmailHistoryService emailHistoryService, IMapper mapper)
        {
            EmailHistoryService = emailHistoryService;
            Mapper = mapper;
        }

        public IEmailHistoryService EmailHistoryService { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<IActionResult> FindAsync([FromQuery]string orderBy)
        {
            IOptionsParameters options = new OptionsParameters();
            options.Includes = new List<string>()
            {
                PropertyName.GetPropertyName<IEmailHistoryModel>(c => c.ImportanceType)
            };
            options.Sorter = orderBy.GetSorter();

            IEnumerable<IEmailHistoryModel> list = await EmailHistoryService.FindAsync(options);
            return Ok(Mapper.Map<IEnumerable<EmailHistoryGet>>(list));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(EmailHistoryPost viewModel)
        {
            if(viewModel == null)
            {
                return BadRequest();
            }

            var model = Mapper.Map<IEmailHistoryModel>(viewModel);

            IResultModel result = await EmailHistoryService.InsertAsync(model);

            if (result.Succeeded)
            {
                return Created(Request.Path.Value, new { ((IEmailHistoryModel)result.Value).Id });
            }
            return BadRequest(result.Message);
        }

        public class EmailHistoryGet
        {
            public Guid Id { get; set; }
            public DateTime DateCreated { get; set; }
            public String FromEmailAddress { get; set; }
            public String ToEmailAddress { get; set; }
            public String CcEmailAddress { get; set; }
            public String Subject { get; set; }
            public String Content { get; set; }
            public ImportanceTypeGet ImportanceType { get; set; }
        }

        public class ImportanceTypeGet
        {
            public Guid Id { get; set; }
            public String Name { get; set; }
        }

        public class EmailHistoryPost
        {
            [Required]
            [EmailAddress]
            public String FromEmailAddress { get; set; }

            [Required]
            [EmailAddress]
            public String ToEmailAddress { get; set; }

            public String CcEmailAddress { get; set; }

            [Required]
            [MaxLength(250)]
            public String Subject { get; set; }

            [Required]
            [MaxLength(5000)]
            public String Content { get; set; }

            [Required]
            [NonEmptyGuid]
            public Guid ImportanceTypeId { get; set; }
        }
    }
}
