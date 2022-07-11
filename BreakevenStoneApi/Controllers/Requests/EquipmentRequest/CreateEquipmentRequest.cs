namespace BreakevenStoneApi.Controllers.Requests.EquipmentRequest
{
    public class CreateEquipmentRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
