using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace api.Services
{
    public class TodoAddModel
    {
        // [Required]
        // public int Type { get; set; }
        [Required]
        public string Value { get; set; }
    }
    public class TodoModel : TodoAddModel
    {
        public ObjectId Id { get; set; }
        public string Date { get; set; }
    }
}