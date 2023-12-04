using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SelfBackEnd.Dtos.Request;
using SelfBackEnd.Dtos.Response;
using SelfBackEnd.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SelfBackEnd.Controllers;

[Route("contacts")]
[ApiController]
[Authorize]
public class ContactsController : BaseController
{
    private readonly IContactService _contactService;
    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ContactViewDto>> GetAllContacts()
    {
        return Ok();
    }

    [HttpGet]
    [Route("search")]
    public ActionResult<IEnumerable<ContactViewDto>> SearchContacts([FromQuery][Required] string keyword)
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ContactViewDto> GetContact([FromRoute] string id)
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult CreateContact([FromBody] CreateContactRequest request)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteContact([FromRoute] string id)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateContact([FromRoute] string id, [FromBody] UpdateContactRequest request)
    {
        return Ok();
    }

    [HttpPost]
    [Route("import-contacts")]
    public ActionResult ImportContact()
    {
        // how to : https://www.syncfusion.com/blogs/post/handling-csv-files-in-asp-net-core-web-apis.aspx
        // implement function in service
        return Ok();
    }

    [HttpGet]
    [Route("export-contacts")]
    public ActionResult ExportContact()
    {
        //get all contact

        using (var memoryStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        {
            // Write CSV records
      // ->>>>>      csvWriter.WriteRecords(employees);

            // Flush the writer and return the CSV file as a FileContentResult
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return File(memoryStream.ToArray(), "text/csv", "contacts.csv");
        }
    }
}
