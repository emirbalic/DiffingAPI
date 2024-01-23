namespace API.Models
{
    public class DiffResponse
    {
        public string DiffResultType { get; set; }
        public ICollection<Diff> Diffs { get; set; }
    }
}
