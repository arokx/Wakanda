namespace API.Utility
{
    public class Meta
    {
        public bool IsSucceeded { get; set; }
        public int HttpErrorCode { get; set; }
        public string Message { get; set; }
        public int PageNo { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
    }
}
