using IcuService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

namespace MekashronTest.Client.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty]
		public string UserName { get; set; }
		[BindProperty]
		public string Password { get; set; }
		[BindProperty]
		public string? IPs { get; set; }

		private LoginResponse response;
		private JObject jResponse;
		private LoginRequest request;
		private readonly IICUTech _icuTech;
		private readonly IHttpContextAccessor _accessor;
		public IndexModel(IICUTech icuTech, IHttpContextAccessor accessor)
		{
			_icuTech = icuTech;
			_accessor = accessor;
		}
		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost()
		{
			IPs = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
			Console.WriteLine(IPs);
			request = new(UserName, Password, IPs);
			try
			{
				response = await _icuTech.LoginAsync(request);
			}
			catch (Exception ex)
			{
				TempData["error"] = $"Error: {ex.Message}";
			}
			jResponse = JObject.Parse(response.@return);
			if (response.@return.Contains("ResultCode", StringComparison.InvariantCultureIgnoreCase))
			{
				TempData["error"] = $"Error: {(string)jResponse["ResultMessage"]}";
				Console.WriteLine(response.@return);
				return Page();
			}
			string firstName = (string)jResponse["FirstName"];
			string lastName = (string)jResponse["LastName"];
			int entityId = (Int32)jResponse["EntityId"];
			TempData["success"] = $"Success. User {firstName} {lastName} has logged in. Entity Id = {entityId}";
			Console.WriteLine(JsonConvert.DeserializeObject(response.@return));
			return Page();
		}
	}
}