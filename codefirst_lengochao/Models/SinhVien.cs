namespace codefirst_lengochao.Models
{
    public class SinhVien
    {
        public int SinhVienId { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }

        // Khóa ngoại
        public int LopId { get; set; }
        public Lop Lop { get; set; }

    }
}
