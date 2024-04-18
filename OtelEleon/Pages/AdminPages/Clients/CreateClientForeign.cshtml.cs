using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtelEleon.Data;
using OtelEleon.Models;

namespace OtelEleon.Pages.AdminPages.Clients
{
	public class CreateClientForeignModel : PageModel
	{
		private readonly OtelEleonDbContext _context;

		public CreateClientForeignModel(OtelEleonDbContext context)
		{
			_context = context;
		}
		public string LastName { get; set; }
		public string ClientName { get; set; }
		public string MiddleName { get; set; }
		public bool IsMigrant { get; set; }
		[BindProperty]
		public Client Client { get; set; }
		[BindProperty]
		public MigrateCart MigrateCart { get; set; }
		public async Task<IActionResult> OnPostAsync(bool isMigrant)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			Client.Id = Guid.NewGuid();
			Client.FullName = $"{LastName} {ClientName} {MiddleName}";
			MigrateCart.ClientId = Client.Id;
			_context.MigrateCarts.Add(MigrateCart);
			_context.Clients.Add(Client);
			await _context.SaveChangesAsync();
			return Page();
		}
	}
}
