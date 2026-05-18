using backend.Abstracts;
using backend.Models;
using System.Formats.Asn1;

namespace backend.DTO
{
    public class GetToDosResponseDTO
    {
        public IEnumerable<ToDoTask> Results { get; set; } = new List<ToDoTask>();

        public Pagination Pagination { get; set; }

        public GetToDosResponseDTO(IEnumerable<ToDoTask> results, int totalCount, int pagaIndex, int pageSize)
        {
            Results = results;
            Pagination = new Pagination(totalCount, pagaIndex, pageSize);
        }
    }
}
