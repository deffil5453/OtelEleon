using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtelEleon.Data;
using OtelEleon.Models;

namespace OtelEleon.Pages.AdminPages.Clients
{
    public class CreateClientNationaleModel : PageModel
    {
		private readonly OtelEleonDbContext _context;
		
		public CreateClientNationaleModel(OtelEleonDbContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Client Client { get; set; }
		[BindProperty]
		public Passport Passport { get; set; }
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

            Passport.ClientId = Client.Id = Guid.NewGuid();

            Passport.ClientId = Client.Id;
				_context.Passports.Add(Passport);
			_context.Clients.Add(Client);
			await _context.SaveChangesAsync();
			return Page();
		}
	}
}
