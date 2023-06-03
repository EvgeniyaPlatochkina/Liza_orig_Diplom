using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.ViewModels
{
    public class PrintStaffViewModel : ViewModelBase
    {
        public PrintStaffViewModel(ApplicationDbContext ctx, Staff staff)
        {
            _ctx = ctx;
            Staffs = staff;
        }

        private Staff _staff;
        private ApplicationDbContext _ctx;
        public Staff Staffs { get => _staff; set => Set(ref _staff, value, nameof(Staffs)); }
    }
}
