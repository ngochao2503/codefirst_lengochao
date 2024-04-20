namespace codefirst_lengochao.Models
{
    public class Lop
    {
        public int LopId { get; set; }
        public string TenLop { get; set; }

        // Khóa ngoại
        public int KhoaId { get; set; }
        public Khoa Khoa { get; set; }
    }

}
