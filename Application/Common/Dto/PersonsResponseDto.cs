using Mapster;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.Dto
{
    public class PersonsResponseDto
    {
        public int TableId {  get; set; }        
        public string[] Columns { get; set; }

    }
}
