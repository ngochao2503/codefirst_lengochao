using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codefirst_lengochao.Models;
using codefirst_lengochao.data_access;

namespace codefirst_lengochao.Controllers
{
    public class SinhViensController : Controller
    {
        private readonly sinhvien_DbContext _context;

        public SinhViensController(sinhvien_DbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var sinhvien_DbContext = _context.SinhVien.Where(s => s.Tuoi >= 18 && s.Tuoi <= 20
        //                                        && s.Lop.Khoa.TenKhoa == "Cong nghe so")
        //                            .ToList();
        //    List<SinhVienViewModel> sinhvienlist = new List<SinhVienViewModel>();

        //    if (sinhvien_DbContext != null)
        //    {

        //        foreach (var sinhvien in sinhvien_DbContext)
        //        {
        //            string tenKhoa = string.Empty; // Mặc định là chuỗi rỗng

        //            // Kiểm tra xem đối tượng Lop và Khoa có tồn tại không trước khi truy cập
        //            if (sinhvien.Lop != null && sinhvien.Lop.Khoa != null)
        //            {
        //                tenKhoa = sinhvien.Lop.Khoa.TenKhoa; // Truy cập tên khoa
        //            }

        //            var SinhvienViewModel = new SinhVienViewModel()
        //            {
        //                SinhVienId = sinhvien.SinhVienId,
        //                Ten = sinhvien.Ten,
        //                Tuoi = sinhvien.Tuoi,
        //                LopId = sinhvien.LopId,
        //                TenKhoa = tenKhoa,
        //            };
        //            sinhvienlist.Add(SinhvienViewModel);
        //        }
        //        return View(sinhvienlist);
        //    }
        //    return View(sinhvienlist);
        //}
        // GET: SinhViens
        public async Task<IActionResult> Index()
        {
            var sinhvien_DbContext = _context.SinhVien.Include(s => s.Lop);
            return View(await sinhvien_DbContext.ToListAsync());
        }

        // GET: SinhViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.Lop)
                .FirstOrDefaultAsync(m => m.SinhVienId == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public IActionResult Create()
        {
            ViewData["LopId"] = new SelectList(_context.Lop, "LopId", "LopId");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SinhVienId,Ten,Tuoi,LopId")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LopId"] = new SelectList(_context.Lop, "LopId", "LopId", sinhVien.LopId);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["LopId"] = new SelectList(_context.Lop, "LopId", "LopId", sinhVien.LopId);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SinhVienId,Ten,Tuoi,LopId")] SinhVien sinhVien)
        {
            if (id != sinhVien.SinhVienId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.SinhVienId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LopId"] = new SelectList(_context.Lop, "LopId", "LopId", sinhVien.LopId);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.Lop)
                .FirstOrDefaultAsync(m => m.SinhVienId == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(int id)
        {
            return _context.SinhVien.Any(e => e.SinhVienId == id);
        }
    }
}
