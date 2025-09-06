using System.Net.Http.Json;
using FormulaUno.Models;

namespace FormulaUno.Services
{
    public class F1Service
    {
        private readonly HttpClient _http;

        public F1Service(HttpClient http) => _http = http;

        public async Task<DriversPageViewModel> GetDriversPageAsync(int page, int pageSize)
        {
            page = page < 1 ? 1 : page;
            var offset = (page - 1) * pageSize;

            var resp = await _http.GetFromJsonAsync<DriversListResponse>($"drivers?limit={pageSize}&offset={offset}")
                       ?? new DriversListResponse();

            var items = resp.Drivers.Select(d => new DriverListItemVM
            {
                DriverId = d.DriverId,
                FullName = $"{d.Name} {d.Surname}",
                Nationality = d.Nationality
            }).ToList();

            // La API no entrega un "total" confiable. Determinamos si hay página siguiente
            var hasNext = items.Count == pageSize;

            return new DriversPageViewModel
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                HasPrevious = page > 1,
                HasNext = hasNext
            };
        }

        public async Task<DriverDetailVM?> GetDriverAsync(string driverId)
        {
            var resp = await _http.GetFromJsonAsync<DriverDetailResponse>($"drivers/{driverId}");
            var d = resp?.Driver?.FirstOrDefault();
            if (d == null) return null;

            return new DriverDetailVM
            {
                DriverId = d.DriverId,
                FullName = $"{d.Name} {d.Surname}",
                Nationality = d.Nationality,
                Birthday = d.Birthday, // sin cálculo de edad (pedido)
                WikiUrl = d.Url
            };
        }
    }
}
