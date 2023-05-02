using Emp.DataAccess.Data;
using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Project project)
        {
            _db.projectsList.Update(project);
        }

    }
}
