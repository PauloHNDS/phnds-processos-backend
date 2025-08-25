using phnds_processos.domain.Base;

namespace phnds_processos.domain.Response
{
    public class ResponseDto<T> where T : BaseDTO
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    } 
}
