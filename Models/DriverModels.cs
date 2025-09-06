namespace FormulaUno.Models
{
    // DTOs (mapean el JSON exactamente)
    public class DriversListResponse
    {
        public string? Api { get; set; }
        public string? Url { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; } // no lo usamos para paginar
        public List<DriverDto> Drivers { get; set; } = new();
    }

    public class DriverDetailResponse
    {
        public string? Api { get; set; }
        public string? Url { get; set; }
        public int Total { get; set; }
        public List<DriverDto> Driver { get; set; } = new();
    }

    public class DriverDto
    {
        public string DriverId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string? Birthday { get; set; }
        public int? Number { get; set; }
        public string? ShortName { get; set; }
        public string? Url { get; set; } // Wikipedia
    }

    // ViewModels
    public class DriverListItemVM
    {
        public string DriverId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
    }

    public class DriversPageViewModel
    {
        public List<DriverListItemVM> Items { get; set; } = new();
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }

    public class DriverDetailVM
    {
        public string DriverId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string? Birthday { get; set; }
        public string? WikiUrl { get; set; }
    }
}
